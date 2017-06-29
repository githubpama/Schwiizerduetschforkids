using System;
using Sample.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using UWPLoginPage;
using Windows.UI.Popups;
using UWPLoginPage.Common;

namespace Sample.Views
{
    public sealed partial class MainPage : Page
    {

        Database db;
        public MainPage()
        {
            this.InitializeComponent();
            db = new Database();
        }
          
        
        

            private void btnRegister_Click(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(RegisterPage));
            }

            private async void BtnLogin_Click_1(object sender, RoutedEventArgs e)
            {
                if (db.Login(txtUser.Text, txtPassword.Password))
                {
                    var message = new MessageDialog("Login success");
                    await message.ShowAsync();
                }
                else
                {
                    var message = new MessageDialog("Login failed");
                    await message.ShowAsync();
                }
            }

    }
    }

