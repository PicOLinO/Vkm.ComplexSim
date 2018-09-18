﻿#region Usings

using System.Windows.Controls;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Dialogs.ViewModel;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseDeviceDialog.xaml
    /// </summary>
    public partial class ChooseDeviceDialog : DialogBase
    {
        public ChooseDeviceDialog(IDevicesFactory devicesFactory)
        {
            InitializeComponent();
            DataContext = new ChooseDeviceDialogViewModel(devicesFactory);
            Initialize();
        }


        public DeviceEntry SelectedDevice => (DataContext as ChooseDeviceDialogViewModel)?.SelectedDeviceEntry;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}