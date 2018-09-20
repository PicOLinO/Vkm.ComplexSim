﻿using DevExpress.Mvvm;
using NUnit.Framework;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Services;
using Vkm.Smalta.Tests.DSL;
using Vkm.Smalta.Tests.Fakes.ServicesAndFactories;

namespace Vkm.Smalta.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected AppGlobal App;
        protected DialogFactoryStub DialogFactory;
        protected HintServiceStub HintService;
        protected LoadingServiceStub LoadingService;
        protected HistoryService HistoryService;
        protected ViewInjectionManagerStub ViewInjectionManager;

        protected DevicesFactory DevicesFactory;
        protected ActionsFactory ActionsFactory;
        protected PagesFactory PagesFactory;

        protected GiveMe GiveMe;

        [SetUp]
        protected virtual void Setup()
        {
            ViewInjectionManager = new ViewInjectionManagerStub();

            App = DependencyContainer.GetApp();
            HintService = new HintServiceStub();
            LoadingService = new LoadingServiceStub();
            HistoryService = new HistoryService();

            DialogFactory = new DialogFactoryStub();
            ActionsFactory = new ActionsFactory();
            DevicesFactory = new DevicesFactory();
            PagesFactory = new PagesFactory();

            var config = new Config("adminUriBase");
            DependencyContainer.Initialize(config, ViewInjectionManager);

            ServiceContainer.Default.RegisterService(ViewInjectionManager);
            ServiceContainer.Default.RegisterService(HintService);
            ServiceContainer.Default.RegisterService(LoadingService);
            ServiceContainer.Default.RegisterService(HistoryService);

            ServiceContainer.Default.RegisterService(DialogFactory);
            ServiceContainer.Default.RegisterService(PagesFactory);
            ServiceContainer.Default.RegisterService(DevicesFactory);
            ServiceContainer.Default.RegisterService(ActionsFactory);

            GiveMe = new GiveMe(App, DialogFactory, HintService, LoadingService, HistoryService, ViewInjectionManager, DevicesFactory, ActionsFactory, PagesFactory);
        }
    }
}
