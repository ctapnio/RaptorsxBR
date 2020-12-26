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
using System.Linq;
using MTChristianTapnio.window;

namespace MTChristianTapnio
{
    /// <summary>
    /// Interaction logic for ManagersWindow.xaml
    /// </summary>
    public partial class ManagersWindow : Window
    {
        public bool programClose = true;
        private List<Manager> _managers;
        public ManagersWindow()
        {
            InitializeComponent();
            _managers = new List<Manager>() {
                new Manager(8, 80000.00, "Influencial, Assertive", 0, "Wayne Embry"),
                new Manager(3, 30000.00, "Innovative, Leader", 1, "Bobby Webster"),
                new Manager(8, 20000.00, "Vocal, Motivator", 2, "Dan Tolzman"),
                new Manager(7, 70000.00, "High IQ, Decisiveness", 3, "Teresa Resch"),
                new Manager(4, 10000.00, "High IQ, Visionary", 4, "Masai Ujiri")
        };
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            displayNames();
        }
        private void lstManagers_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int index = lstManagers.SelectedIndex;
            var selectedManager = (from manager in _managers
                                  where manager.Id == index
                                  select manager).FirstOrDefault();
            if (selectedManager != null)
            {
                txtId.Text = Convert.ToString(selectedManager.Id);
                txtName.Text = selectedManager.Name;
                txtPlayersRecruited.Text = Convert.ToString(selectedManager.PlayersRecruited);
                txtAvailableBudget.Text = Convert.ToString(selectedManager.AvailableBudget);
                txtStrength.Text = selectedManager.Strength;
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insertManager();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateManager();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteManager();
        }

        private void sMenuInsert_Click(object sender, RoutedEventArgs e)
        {
            insertManager();
        }

        private void sMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateManager();
        }

        private void sMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteManager();
        }

      
        private void displayNames()
        {
            var names = from manager in _managers
                        select manager.Name;
            lstManagers.ItemsSource = names;
        }
        private void insertManager()
        {
            var prompt = MessageBox.Show("Confirm to Insert Record", "Confirmation", MessageBoxButton.OKCancel);
            if (prompt == MessageBoxResult.Cancel)
            {
                displayNames();
            }
            else
            {
                try
                {
                    Manager manager = new Manager(
                    Convert.ToInt32(txtPlayersRecruited.Text),
                    Convert.ToInt32(txtAvailableBudget.Text),
                    txtStrength.Text,
                    _managers.Count,
                    txtName.Text);

                    _managers.Add(manager);
                    displayNames();
                }
                catch
                {
                    MessageBox.Show("Invalid Input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void updateManager()
        {
            var prompt = MessageBox.Show("Confirm to Update Record", "Confirmation", MessageBoxButton.OKCancel);
            if (prompt == MessageBoxResult.Cancel)
            {
                displayNames();
            }
            else
            {
                try
                {
                    int index = lstManagers.SelectedIndex;

                    Manager manager = _managers[index];

                    manager.Id = Convert.ToInt32(txtId.Text);
                    manager.Name = txtName.Text;
                    manager.PlayersRecruited = Convert.ToInt32(txtPlayersRecruited.Text);
                    manager.AvailableBudget = Convert.ToInt32(txtAvailableBudget.Text);
                    manager.Strength = txtStrength.Text;

                    displayNames();
                }
                catch
                {
                    MessageBox.Show("Selection Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void deleteManager()
        {
            var prompt = MessageBox.Show("Confirm to Delete Record", "Confirmation", MessageBoxButton.OKCancel);
            if (prompt == MessageBoxResult.Cancel)
            {
                displayNames();
            }
            else
            {
                try
                {
                    int index = lstManagers.SelectedIndex;
                    _managers.RemoveAt(index);
                    for (int dex = 0; dex < _managers.Count; dex++)
                    {
                        _managers[dex].Id = dex;
                    }
                    displayNames();

                }
                catch 
                {
                    MessageBox.Show("Selection Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void sMenuQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void sMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            programClose = false;
            Close();
            aboutWindow.ShowDialog();
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
