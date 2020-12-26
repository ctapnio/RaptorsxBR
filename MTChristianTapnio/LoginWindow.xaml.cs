/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace MTChristianTapnio
{
    
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 
    public partial class LoginWindow : Window
    {
        public bool programClose = true;//default behavior of program is to close entire application in Close()
        Login login1 = new Login(0, "guccim", "atlanta");
        Login login2 = new Login(1, "lilwayne", "neworleans");
        Login login3 = new Login(2, "klamar", "compton");
        Login login4 = new Login(3, "drake", "toronto");
        Login login5 = new Login(4, "joeyb", "newyork");
        

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Login> logins = new Dictionary<string, Login>() {
                {login1.Username, login1},
                {login2.Username, login2},
                {login3.Username, login3},
                {login4.Username, login4},
                {login5.Username, login5}
            };

            bool logged = false;
            while (!logged)
            {
                //parse through Login credentials
                foreach (var login in logins)
                {
                    //if match
                    if (login.Value.Password == txtPassword.Password && login.Value.Username == txtUsername.Text)
                    {
                        //show Main Window && Close Login Window
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        logged = true;
                        //close without prompt
                        programClose = false;
                        Close();
                        break;
                    }
                
                }
                if (!logged)
                {
                    logged = true;
                    MessageBox.Show("Invalid Login", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (programClose)
            {
                var result = MessageBox.Show("Confirm to close program", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
