using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proiect_Cinema;

namespace CinemaUI
{
    /// <summary>
    /// Interaction logic for AdminLoggerPage.xaml
    /// </summary>
    public partial class AdminLoggerPage : Window
    {
        public AdminLoggerPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            DataManager dataManager = new DataManager();
            dataManager.GetAdminFromTxt();
            List<Admin> admins = dataManager.GetAdmins();
            bool loginsuccess = false;
            foreach (Admin admin in admins)
            {

                if (admin.GetName() == username.Text && admin.GetPassword() == password.Password)
                {
                    loginsuccess = true;
                    AdminPage adminPage = new AdminPage();
                    adminPage.Show();
                    this.Close();
                    break;
                }
            }
            if (!loginsuccess)
                MessageBox.Show("Username sau parola incorecta!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
