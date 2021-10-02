using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HW_Oct1_XamarinLab
{
    public partial class MainPage : ContentPage
    {
        bool isAdded = false;
        public Employee employee { get; set; }
        public MainPage()
        {
            employee = new Employee();
            InitializeComponent();
            BindingContext = this;
        }

        private bool IsValid()
        {
            if (!(dayTime.IsChecked ^ evening.IsChecked)) return false;

            return true;
        }

        async public void AddClicked(object sender, EventArgs e)
        {
            var errorMessage = employee.IsValid();

            if (errorMessage != null)
            {
                await DisplayAlert("Alert", errorMessage, "OK");
                return;
            }

            bool choice = await DisplayAlert("New Employee", "Are you sure you want add the employee named: " + employee.Name, "Yes", "No");
            if (choice == false)
            {
                employee.Name = null;
                employee.Salary = 0;
                nameEntry.Text = "";
                salaryEntry.Text = "";
                dayTime.IsChecked = false;
                evening.IsChecked = false;
                hockeyBox.IsChecked = false;
                basketballBox.IsChecked = false;
                noneBox.IsChecked = false;
            }
            else { isAdded = true; }
            //if (!string.IsNullOrWhiteSpace(nameEntry.Text) &&
            //    !string.IsNullOrWhiteSpace(salaryEntry.Text))
            //{
            //    await App.Database.SavePersonAsync(new Employee
            //    {
            //        Name = nameEntry.Text,
            //        Salary = int.Parse(salaryEntry.Text),
            //    });
            //}
        }
        async public void DisplayClicked(object sender, EventArgs e)
        {
            if(isAdded == true) { 
            string sport = "";
            string time = "";
            var errorMessage = employee.IsValid();

            if (errorMessage != null)
            {
                await DisplayAlert("Alert", errorMessage, "OK");
                return;
            }
            if(employee.Day == true) { time = "Day Time"; } else { time = "Evening Time"; }
            if (employee.Hockey == true && employee.Basketball == true && employee.None == true) { sport = "None"; }
            else if (employee.Hockey == true && employee.Basketball == true && employee.None == false) { sport = "Hockey and Basketball"; }
            else if (employee.Hockey == false && employee.Basketball == true && employee.None == false) { sport = "Basketball"; }
            else if (employee.Hockey == true && employee.Basketball == false && employee.None == false) { sport = "Hockey"; }
            else { sport = "None"; }
            await DisplayAlert("Recently Added Employee","Name: " + employee.Name + "\n" + "Salary: " + employee.Salary
                      + "\n" + "Time: " + time + "\n" + "Sport: " + sport, "Close");
            }
            else { await DisplayAlert("Error", "No employee recently added", "OK"); }
        }
    }
}