using System;
using System.Collections.Generic;
using System.Text;

namespace micropos.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login
        {
            get;
            set;
        }

        public WelcomeViewModel Welcome
        {
            get;
            set;
        }

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            //this.LoadMenu();
        }
        #endregion

        #region Singleton
        public static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
