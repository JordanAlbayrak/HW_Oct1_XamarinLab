using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW_Oct1_XamarinLab
{
    public partial class App : Application
    {
        static DBEmployee database;
        public static DBEmployee Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBEmployee
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "student.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }



    }
}
