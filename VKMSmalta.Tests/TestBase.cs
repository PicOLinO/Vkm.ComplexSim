﻿using NUnit.Framework;
using VKMSmalta.Services;
using VKMSmalta.Tests.Fakes.ServicesAndFactories;

namespace VKMSmalta.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected AppGlobal App;
        protected DialogFactoryStub DialogFactory;
        protected HintServiceStub HintService;
        protected VIewInjectionManagerStub ViewInjectionManagerStub;

        [SetUp]
        protected virtual void Setup()
        {
            var config = new Config("adminUriBase");
            DependencyContainer.Initialize(config);
            App = DependencyContainer.GetApp();
            DialogFactory = new DialogFactoryStub();
            HintService = new HintServiceStub();
            ViewInjectionManagerStub = new VIewInjectionManagerStub();
        }
    }
}
