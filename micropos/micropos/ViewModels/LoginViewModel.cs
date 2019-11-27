﻿using System;
using System.Collections.Generic;
using System.Text;

namespace micropos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using micropos.Views;
    using Xamarin.Forms;


    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string password;
        private string user;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemember
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar Usuario", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar Contraseña", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.User != "micropos" || this.Password != "micropos")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña Incorrecto", "Aceptar");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;
            string Usuario = string.Copy(this.User);

            this.User = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Welcome = new WelcomeViewModel(Usuario);
            await Application.Current.MainPage.Navigation.PushAsync(new WelcomePage());

        }

        public ICommand RecuperarCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;
            this.User = "micropos";
            this.Password = "micropos";

        }
        #endregion
    }

}
