﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.ViewModel;

namespace VKMSmalta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            DataContext = vm;

            InitializeDependencyContainer(vm);
            ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => new MainPageViewModel(), typeof(MainPage));
        }

        private void InitializeDependencyContainer(MainWindowViewModel vm)
        {
            DependencyContainer.InitializeService(vm);
        }
    }
}
