using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO; 
using System.Linq;
using System.Management;
using LibreHardwareMonitor.Hardware;

namespace Bogdan_Monitor
{
    public class Counter
    {
        public PerformanceCounter PerformanceCPU { get; set; }
        public PerformanceCounter TimeCPU { get; set; }
        public PerformanceCounter OS_CPU { get; set; }
        public PerformanceCounter UserCPU { get; set; }

        public PerformanceCounter PerformanceRAM { get; set; }
        public PerformanceCounter FreeRAM { get; set; }

        public PerformanceCounter? SentBytesPerSecond { get; set; }
        public PerformanceCounter? ReceivedBytesPerSecond { get; set; }

        public double? GpuVideoEncode { get; private set; }
        public double? GpuMemoryUsed { get; private set; }
        public double? GpuMemoryTotal { get; private set; }
        public double? GpuTemperature { get; private set; }

        public Dictionary<string, PerformanceCounter> DiskFreeSpaceCounters { get; private set; } = new();
        public Dictionary<string, PerformanceCounter> DiskLoadCounters { get; private set; } = new(); 

        public List<string> LogicalDisks { get; private set; } = new();

        private string? GetNetworkAdapterName()
        {
            var category = new PerformanceCounterCategory("Network Interface");
            var instances = category.GetInstanceNames();

            return instances.FirstOrDefault();
        }

        private Computer _computer;

        public Counter()
        {
            PerformanceCPU = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
            TimeCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            OS_CPU = new PerformanceCounter("Processor", "% Privileged time", "_Total");
            UserCPU = new PerformanceCounter("Processor", "% User Time", "_Total");
            PerformanceRAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            FreeRAM = new PerformanceCounter("Memory", "Available MBytes");
            try
            {
                var adapterName = GetNetworkAdapterName();
                if (adapterName == null)
                {
                    throw new InvalidOperationException("No network adapters found.");
                }

                SentBytesPerSecond = new PerformanceCounter("Network Interface", "Bytes Sent/sec", adapterName);
                ReceivedBytesPerSecond = new PerformanceCounter("Network Interface", "Bytes Received/sec", adapterName);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Error initializing network counters: {ex.Message}");
                SentBytesPerSecond = null;
                ReceivedBytesPerSecond = null;
            }

            _computer = new Computer
            {
                IsGpuEnabled = true
            };
            _computer.Open();

            LogicalDisks.Clear();
            DiskFreeSpaceCounters.Clear();
            DiskLoadCounters.Clear(); 
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    var name = drive.Name.TrimEnd('\\');
                    LogicalDisks.Add(name);
                    try
                    {
                        DiskFreeSpaceCounters[name] = new PerformanceCounter("LogicalDisk", "% Free Space", name);
                    }
                    catch { }
                    try
                    {
                        DiskLoadCounters[name] = new PerformanceCounter("LogicalDisk", "% Disk Time", name);
                    }
                    catch { }
                }
            }
        }

        public void UpdateGpuInfo()
        {
            GpuVideoEncode = null;
            GpuMemoryUsed = null;
            GpuMemoryTotal = null;
            GpuTemperature = null;

            foreach (var hardware in _computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.GpuNvidia ||
                    hardware.HardwareType == HardwareType.GpuAmd ||
                    hardware.HardwareType == HardwareType.GpuIntel)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && GpuTemperature == null)
                        {
                            GpuTemperature = sensor.Value;
                        }
                        if (sensor.SensorType == SensorType.Load &&
                            sensor.Name.Contains("Video Encode") &&
                            GpuVideoEncode == null)
                        {
                            GpuVideoEncode = sensor.Value;
                        }
                        if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("Memory Used"))
                        {
                            GpuMemoryUsed = sensor.Value.HasValue ? Math.Round(sensor.Value.Value / 1024, 2) : (double?)null; 
                        }
                        if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("Memory Total"))
                        {
                            GpuMemoryTotal = sensor.Value.HasValue ? Math.Round(sensor.Value.Value / 1024, 2) : (double?)null; 
                        }
                    }
                }
            }
        }

        public double GetFreeRAMInPercent()
        {
            return 100 - (FreeRAM.NextValue() * 100 / 32518);
        }
        public double GetFreeRAMInGBytes()
        {
            return FreeRAM.NextValue() / 1000;
        }
        public double GetUsedRAMInGBytes()
        {
            return 32.518 - (FreeRAM.NextValue() / 1000);
        }

        public double GetFreeSpaceDisk(string disk)
        {
            if (DiskFreeSpaceCounters.TryGetValue(disk, out var counter))
            {
                return 1 - (counter.NextValue() / 100);
            }
            return 0;
        }

        public Dictionary<string, double> GetAllDisksFreeSpace()
        {
            var result = new Dictionary<string, double>();
            foreach (var disk in LogicalDisks)
            {
                result[disk] = GetFreeSpaceDisk(disk);
            }
            return result;
        }

        public double GetFreeSpaceDiskGauge(string disk)
        {
            if (DiskFreeSpaceCounters.TryGetValue(disk, out var counter))
            {
                return 100 - counter.NextValue();
            }
            return 0;
        }

        public double? GetGpuVideoEncode() 
        {
            UpdateGpuInfo();
            return GpuVideoEncode;
        }

        public double? GetGpuMemoryUsed() 
        {
            UpdateGpuInfo();
            return GpuMemoryUsed;
        }

        public double? GetGpuMemoryTotal() 
        {
            UpdateGpuInfo();
            return GpuMemoryTotal;
        }

        public double? GetGpuTemperature() 
        {
            UpdateGpuInfo();
            return GpuTemperature;
        }

        public double GetDiskLoad(string disk)
        {
            if (DiskLoadCounters.TryGetValue(disk, out var counter))
            {
                return counter.NextValue();
            }
            return 0;
        }

        public Dictionary<string, double> GetAllDisksLoad()
        {
            var result = new Dictionary<string, double>();
            foreach (var disk in LogicalDisks)
            {
                result[disk] = GetDiskLoad(disk);
            }
            return result;
        }
    }
}
