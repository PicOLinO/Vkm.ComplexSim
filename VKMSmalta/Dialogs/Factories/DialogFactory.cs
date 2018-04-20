﻿using System;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.XtraEditors;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.Factories
{
    public class DialogFactory
    {
        public bool ShowLoginDialog()
        {
            var loginDialog = new LoginDialog();
            var result = loginDialog.ShowDialog();
            return result.HasValue && result.Value;
        }

        public void ShowRegisterDialog()
        {
            var registerDialog = new RegisterDialog();
            registerDialog.ShowDialog();
        }

        public void ShowInfoDialog(string infoText)
        {
            var infoDialog = new InfoDialog(infoText);
            infoDialog.ShowDialog();
        }

        public static void ShowWarningMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowErrorMessage(Exception error, string caption = null)
        {
            DXMessageBox.Show(error.Message, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowErrorMessage(string error, string caption = null)
        {
            DXMessageBox.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInfoMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}