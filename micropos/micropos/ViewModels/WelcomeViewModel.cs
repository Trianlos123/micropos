using System;
using System.Collections.Generic;
using System.Text;

namespace micropos.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        #region Atributes
        private string name;
        private string usuario;
        private string carrera;
        private string us;
        private bool isRunning; 
        #endregion

        #region Properties

        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string Us
        {
            get { return this.us; }
            set { SetValue(ref this.us, value); }
        }

        public string Carrera
        {
            get { return this.carrera; }
            set { SetValue(ref this.carrera, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Constructors
        public WelcomeViewModel(string usuario)
        {
            this.IsRunning = true;
            this.usuario = usuario;
        }
        #endregion
    }
}
