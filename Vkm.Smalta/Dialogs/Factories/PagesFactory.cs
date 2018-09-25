﻿using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class PagesFactory : IPagesFactory
    {
        public List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm)
        {
            switch (device)
            {
                case Device.LO01_Smalta:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Smalta/Backgrounds/LO01I_LO01K.png", algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Smalta/Backgrounds/LO01P.png", algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Smalta/Backgrounds/LO01R.png", algorithm)
                           };
                case Device.RLS_ONC:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.Station, "/Vkm.Smalta;component/View/Images/RlsOnc/Backgrounds/rls_onc_station.jpg", algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.ControlPanelSimulator, "/Vkm.Smalta;component/View/Images/RlsOnc/Backgrounds/rls_onc_controlpanelsim.jpg", algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.G5_15, "/Vkm.Smalta;component/View/Images/RlsOnc/Backgrounds/********.jpg", algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.C1_65, "/Vkm.Smalta;component/View/Images/RlsOnc/Backgrounds/********.jpg", algorithm)
                           };
                default:
                    throw new ArgumentOutOfRangeException(nameof(device), device, null);
            }
        }
    }
}