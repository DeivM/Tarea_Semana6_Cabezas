using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea_Semana6_Cabezas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new  MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
