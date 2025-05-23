using System;
using System.Windows.Controls;
using System.Windows.Threading;
using Bogdan_Monitor;
using System.Windows; 
using System.IO;
using System.Collections.Generic;

namespace Bogdan_Monitor.Views
{
    public partial class MainView : UserControl
    {
        private Counter counter = new Counter();
        private DispatcherTimer timer;
        private double _cpuValue;
        private double _gpuValue;

        public double CpuValue
        {
            get => _cpuValue;
            set
            {
                _cpuValue = value;
                if (cpuLabel != null)
                    cpuLabel.Text = $"{value:F1}%";
            }
        }

        public double GpuValue
        {
            get => _gpuValue;
            set
            {
                _gpuValue = value;
                if (gpuLoadLabel != null)
                    gpuLoadLabel.Text = $"{value:F1}%";
            }
        }

        public MainView()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs? e) // Убедитесь, что добавлены '?'
        {
            //CPU Usage
            CpuValue = counter.PerformanceCPU.NextValue();
            cpuTimeLabel.Content = counter.TimeCPU.NextValue();


            //RAM Usage
            ramLabel.Content = counter.GetFreeRAMInPercent();
            ramProgressBar.Value = counter.GetFreeRAMInPercent();
            ramUsedLabel.Content = counter.GetUsedRAMInGBytes();
            ramFreeLabel.Content = counter.GetFreeRAMInGBytes();

            //Network Usage
            networkSentBytesLabel.Content = counter.SentBytesPerSecond?.NextValue() * 8 / 1000000 ?? 0;
            networkReceivedBytesLabel.Content = counter.ReceivedBytesPerSecond?.NextValue() * 8 / 1000000 ?? 0;

            // GPU
            var gpuLoad = counter.GetGpuVideoEncode() ?? 0;
            var gpuTemp = counter.GetGpuTemperature() ?? 0;
            var gpuRamUsed = counter.GetGpuMemoryUsed() ?? 0;
            var gpuRamTotal = counter.GetGpuMemoryTotal() ?? 0;

            GpuValue = gpuLoad;
            gpuTempLabel.Content = gpuTemp;
            gpuRamUsedLabel.Content = gpuRamUsed;
            gpuRamTotalLabel.Content = gpuRamTotal;

            UpdateDiskInfo();
        }

        // Класс для привязки данных к дискам
        public class DiskInfo
        {
            public string DiskName { get; set; } = string.Empty; // Инициализация
            public string DiskType { get; set; } = string.Empty; // Инициализация
            public double UsedGB { get; set; }
            public double FreeGB { get; set; }
            public double TotalGB { get; set; }
            public double UsedPercent { get; set; }
        }

        private void UpdateDiskInfo()
        {
            var diskInfoList = new List<DiskInfo>();
            foreach (var disk in counter.LogicalDisks)
            {
                try
                {
                    var drive = new DriveInfo(disk + "\\");
                    double total = drive.TotalSize / 1024.0 / 1024.0 / 1024.0;
                    double free = drive.AvailableFreeSpace / 1024.0 / 1024.0 / 1024.0;
                    double used = total - free;
                    double percent = total > 0 ? (used / total) * 100 : 0;

                    // Определение типа диска (SSD/HDD)
                    string type = "HDD";
                    try
                    {
                        // Windows 8+ API, если доступно
                        var query = $"SELECT MediaType FROM Win32_DiskDrive WHERE DeviceID LIKE '%{drive.Name[0]}%'";
                        using (var searcher = new System.Management.ManagementObjectSearcher(query))
                        {
                            foreach (var obj in searcher.Get())
                            {
                                var mediaType = obj["MediaType"]?.ToString() ?? "";
                                if (mediaType.Contains("SSD")) type = "SSD";
                            }
                        }
                    }
                    catch { /* Если не удалось определить, оставить HDD */ }

                    diskInfoList.Add(new DiskInfo
                    {
                        DiskName = disk,
                        DiskType = type,
                        UsedGB = used,
                        FreeGB = free,
                        TotalGB = total,
                        UsedPercent = percent
                    });
                }
                catch
                {
                    // Если диск не готов или ошибка доступа
                    diskInfoList.Add(new DiskInfo
                    {
                        DiskName = disk,
                        DiskType = "Unknown",
                        UsedGB = 0,
                        FreeGB = 0,
                        TotalGB = 0,
                        UsedPercent = 0
                    });
                }
            }
            diskPanel.ItemsSource = diskInfoList;
        }
    }
}
