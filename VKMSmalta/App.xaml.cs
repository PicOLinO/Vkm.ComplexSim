﻿#region Usings

using System;
using System.Configuration;
using System.Windows;
using Appccelerate.CommandLineParser;
using DevExpress.Xpf.Core;
using VKMSmalta.Services;

#endregion

namespace VKMSmalta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ApplicationThemeHelper.ApplicationThemeName = "Office2016White";
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var config = CreateConfig();

            DependencyContainer.InitializeService(config);
            NetworkService.InitializeService(config.AdminUri);

            ParseArgs(e.Args);
        }

        private Config CreateConfig()
        {
            var adminAddress = ConfigurationManager.AppSettings["AdminBaseAddress"];

            return new Config(adminAddress);
        }

        private void ParseArgs(string[] args)
        {
            var app = DependencyContainer.GetApp();

            var configuration = CommandLineParserConfigurator
                                .Create()
                                    .WithSwitch("debug", () => app.IsDebug = true)
                                        .DescribedBy("Enable debug mode")
                                .BuildConfiguration();
            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (!parseResult.Succeeded)
            {
                throw new ArgumentException("Unknown arguments");
            }
        }
    }
}