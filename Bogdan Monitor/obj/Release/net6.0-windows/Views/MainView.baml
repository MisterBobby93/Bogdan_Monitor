   M S B A M L   `   `   `  ���� I  EBogdan Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Bogdan_Monitor.ViewsBogdan_Monitor.Views  I)clr-namespace:Bogdan_Monitor.UserControlsBogdan_Monitor.UserControls  #    Bogdan_Monitor.Views.MainView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah
 dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai  eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj! fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag" cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af# bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj$ fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak% gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah& dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137axIcon-http://metro.mahapps.com/winfx/xaml/iconpacks!    	 
                        ! " # $ % & nlocal"clr-namespace:Bogdan_Monitor.Views!    	 
                        ! " # $ % & y	linechart)clr-namespace:Bogdan_Monitor.UserControls!    	 
                        ! " # $ % & -     >�Name$  mainView��$	��700��$	��700�� � 	Resources    RoundedProgressBar �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName��%O  &	        �� " �.���  � ��$ 10����  � �� �� " �.R�� $
 Root��#��z��.+��� $ 
PART_Track��#��z��$ 5���� $ PART_Indicator��#��z��$ 5��$
��Left=�$��0��	 P� 
 �@�IsIndeterminate$
 True��. ��� $ PART_Indicator�� � y�$ 	Collapsed=�P� 
 �@�Orientation$ Vertical=�.��� ���#181a23 � RowDefinitions �� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+���   
mainBorder#��[ $��0��$��0��$��14q����#23243a$ 16�� �� Padding$ 18q�._��  �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0�� �� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Center=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Chip=�$��28��$��28�����#2889fc$��0,0,8,0q��� $	��CPU��$��22(�$
��Bold"����#fcfafa$��Center=��� -    ��Name$ cpuLabel��$��1��$��36(�$
��Bold"����#2889fc$��Center=�$��Right=�$��0%��+   %Bogdan_Monitor.UserControls.LineChart  -     Name$ cpuChart��$��1��$��2��$��0,18,0,8q�$��90���� $��3��$ 
Horizontal=�$
��Left=�$��0,8,0,0q�.+��� $��Processor Time:��$��13(����#a0a0a0$��0,0,6,0q��� -    ��Name$ cpuTimeLabel�����#fcfafa$��13(�$��SemiBold"�$��0q� �� ContentStringFormat$ {0:F0}��$��Center=��� $��%�����#fcfafa$��13(�$��SemiBold"�$��3,0,0,0q��� #��[ $��0��$��1��$��14q����#23243a$ 16��$ 18q�._��  �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0�� �� $��* ��� $
��Auto �.+��� $ 
Horizontal=�$��Center=�.+�  $ MonitorDashboard=�$��28��$��28�����#00c853$��0,0,8,0q��� $	��GPU��$��22(�$
��Bold"����#fcfafa$��Center=��� -   $ gpuLoadLabel��$��1��$��36(�$
��Bold"����#00c853$��Center=�$��Right=�$��0%��.   (Bogdan_Monitor.UserControls.GpuLineChart  -     Name$ gpuChart��$��1��$��2��$��0,18,0,8q�$��90���� $��3��$ 
Horizontal=�$
��Left=�$��0,8,0,0q�.+��� $ 
Horizontal=�$��0,0,24,0q�.+��� $��Temp:��$��13(����#a0a0a0$��0,0,4,0q��� -   $ gpuTempLabel�����#fcfafa$��13(�$��SemiBold"�$��0q�$ {0:F0}��$��Center=��� $	��°C�����#fcfafa$��13(�$��SemiBold"�$��3,0,0,0q��� $ 
Horizontal=�$��0,0,24,0q�.+��� $��Used:��$��13(����#a0a0a0$��0,0,4,0q��� -   $ gpuRamUsedLabel�����#fcfafa$��13(�$��SemiBold"�$��0q�$ {0:F1}��$��Center=��� $��GB�����#fcfafa$��13(�$��SemiBold"�$��3,0,0,0q��� $ 
Horizontal=�.+��� $��Total:��$��13(����#a0a0a0$��0,0,4,0q��� -	   $ gpuRamTotalLabel�����#fcfafa$��13(�$��SemiBold"�$��0q�$ {0:F1}��$��Center=��� $��GB�����#fcfafa$��13(�$��SemiBold"�$��3,0,0,0q��� #��[ $��1��$��0��$��14q����#23243a$ 16��$ 18q�._��� $
��Auto=�$��Disabled=�  � Value � Minimum � Maximum ]� Thumb J� Opacity��%�   '��       �� " ��.���  � ��
 ���� ��  � �� �	#80FFFFFF��  � ��$ 2����  � �� �� " ��.R�� #��z��.+�]� $��
PART_Track��#��z #��z #��z  n� #��z��$��24��$��16��$	 0.5Q�.���� -
    ��Name$ 	diskPanel��$��0q����� .R��� ���� .R��� $ 10��$��0q�$��10q�$ 15q����#26283a._��  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $��* ��� $��* �.+��� $��0��$��2��$ 
Horizontal=�$��Center=�$��0,0,0,10q�.+�  $ Harddisk=�$��20��$��20�����#a0a0a0$��0,0,8,0q��� $
��Disk��$��18(�$��SemiBold"����#fcfafa$��Center=��� $��1��$��0��$
��Used��$��12(����#a0a0a0$��0,0,0,2q��� $��1��$��1��$��Total GB��$��12(����#a0a0a0$��Right=�$��0,0,0,2q��� $��2��$��0��$��20(�$
��Bold"����#fcfafa$��Bottom=����� *UsedGB+ �� StringFormat$ 	{0:F1} GB���� $��2��$��1��$ Vertical=�$��Right=�$��Bottom=�.+��� $��20(�$
��Bold"����#fcfafa$��Right=�$��0,0,0,5q����� *UsedPercent+$ {0:F0}%��� $��6��$ 0Q�$	 100Q����#007FFF���#393b52$��0q�$	��100��#��[   �� *UsedPercent+� $��1��$��1��$��14q� �� $��* ��� $��* �.+��� #��[ $��0��$��0 0 0 8q����#23243a$ 16��$ 18q�._��  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $��* ��� $��* �.+�� $��0��$��2�� �� $��* ��� $
��Auto �.+��� $ 
Horizontal=�$��Center=�.+�  $ Memory=�$��22��$��22�����#05F4FC$��0,0,8,0q��� $	��RAM��$��20(�$
��Bold"����#fcfafa$��Center=��� $��1��$��20(�$
��Bold"����#05F4FC$��Center=�$��Right=����� *	Content+ �� ElementName$ ramLabel��$ {0:F0}%��� -    �Name$ ramProgressBar��$��1��$��2��$��0,8,0,8q�$��7��$ 0Q�$	 100Q����#05F4FC���#393b52$��0q�#��[   �� *	Content+$ ramLabel��  �� Mode$  OneWay=�� $��2��$��2�� �� $��* ��� $��* �.+��� $��0��$ Vertical=�$
��Left=�.+��� $
��Used��$��12(����#a0a0a0$��0,0,0,2q��� $ 
Horizontal=�.+��� -   $ ramUsedLabel�����#fcfafa$��18(�$
��Bold"�$��Center=�$��0q�$ {0:F1}���� $��GB�����#fcfafa$��14(�$��SemiBold"�$��5,0,0,0q�$��Bottom=��� $��1��$ Vertical=�$��Right=�.+��� $
��Free��$��12(����#a0a0a0$��0,0,0,2q�$��Right=��� $ 
Horizontal=�.+��� -   $ ramFreeLabel�����#fcfafa$��18(�$
��Bold"�$��Center=�$��0q�$ {0:F1}���� $��GB�����#fcfafa$��14(�$��SemiBold"�$��5,0,0,0q�$��Bottom=��� -   $ ramLabel��$y�	Collapsed=��� #��[ $��1��$��0 8 0 0q����#23243a$ 16��$ 18q�._��  �� $
��Auto ��� $��* � �� $��* ��� $��* �.+�� $��0��$��2�� �� $��* ��� $
��Auto �.+��� $ 
Horizontal=�$��Center=�.+�  $ 
LanConnect=�$��22��$��22�����#05F4FC$��0,0,8,0q��� $��Network��$��20(�$
��Bold"����#fcfafa$��Center=�� $��1��$��2�� �� $��* ��� $��* �.+��� $��0��$ Vertical=�$
��Left=�.+��� $
��Sent��$��12(����#a0a0a0$��0,0,0,2q��� $ 
Horizontal=�.+��� -   $ networkSentBytesLabel�����#fcfafa$��18(�$
��Bold"�$��Center=�$��0q�$ {0:F1}���� $
��Mb/s�����#fcfafa$��14(�$��SemiBold"�$��5,0,0,0q�$��Bottom=��� $��1��$ Vertical=�$��Right=�.+��� $��Received��$��12(����#a0a0a0$��0,0,0,2q�$��Right=��� $ 
Horizontal=�.+��� -   $ networkReceivedBytesLabel�����#fcfafa$��18(�$
��Bold"�$��Center=�$��0q�$ {0:F1}���� $
��Mb/s�����#fcfafa$��14(�$��SemiBold"�$��5,0,0,0q�$��Bottom=�