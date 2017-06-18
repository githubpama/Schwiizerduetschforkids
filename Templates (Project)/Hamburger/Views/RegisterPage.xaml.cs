using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPLoginPage.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPLoginPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        Database db;
        public RegisterPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Handle Back Button
            SystemNavigationManager.GetForCurrentView().BackRequested += RegisterPage_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //Remove Handle Back Button
            SystemNavigationManager.GetForCurrentView().BackRequested -= RegisterPage_BackRequested;

        }

        private void RegisterPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
           int code =  db.Register(new Common.User() {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Password,
                Email = txtEmail.Text.Trim()
            });
            if(code == -1)
            {
                var message = new MessageDialog("Register failed");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Register success");
                await message.ShowAsync();
            }
        }
    }
}
