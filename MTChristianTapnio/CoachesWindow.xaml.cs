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
    /// Interaction logic for CoachesWindow.xaml
    /// </summary>
    public partial class CoachesWindow : Window
    {
        public bool programClose = true;
        private List<Coach> _coaches;
        public CoachesWindow()
        {
            InitializeComponent();
            _coaches = new List<Coach>() {
                new Coach(4, 48, 48, 13481, 0, "Patrick Mutombo"),
                new Coach(3, 38, 42, 7282, 1, "Nate Bjorkgren"),
                new Coach(2, 32, 45, 5243, 2, "Sergio Scariolo"),
                new Coach(2, 36, 46, 9232, 3, "Adrian Griffin"),
                new Coach(1, 16, 56, 11248, 4, "Nick Nurse")
        };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            displayNames();
        }
        private void lstCoaches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstCoaches.SelectedIndex;
            var selectedCoach = (from coach in _coaches
                                 where coach.Id == index
                                 select coach).FirstOrDefault();
            if (selectedCoach != null)
            {
                txtId.Text = Convert.ToString(selectedCoach.Id);
                txtName.Text = Convert.ToString(selectedCoach.Name);
                txtNumberOfTeamsCoached.Text = Convert.ToString(selectedCoach.NumberOfTeamsCoached);
                txtPlayersTrained.Text = Convert.ToString(selectedCoach.PlayersTrained);
                txtWinPercentage.Text = Convert.ToString(selectedCoach.WinPercentage);
                txtYearsOfExperience.Text = Convert.ToString(selectedCoach.YearsOfExperience);

            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insertCoach();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCoach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteCoach();
        }

        private void displayNames()
        {
            var names = from coach in _coaches
                        select coach.Name;
            lstCoaches.ItemsSource = names;
        }
        private void insertCoach()
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
                    Coach coach = new Coach(
                        Convert.ToInt32(txtNumberOfTeamsCoached.Text),
                        Convert.ToInt32(txtPlayersTrained.Text),
                        Convert.ToInt32(txtWinPercentage.Text),
                        Convert.ToInt32(txtYearsOfExperience.Text),
                        _coaches.Count,
                        txtName.Text);

                    _coaches.Add(coach);
                    displayNames();
                }
                catch 
                {
                    MessageBox.Show("Invalid Input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void updateCoach()
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
                    int index = lstCoaches.SelectedIndex;

                    Coach coach = _coaches[index];

                    coach.Id = Convert.ToInt32(txtId.Text);
                    coach.Name = txtName.Text;
                    coach.NumberOfTeamsCoached = Convert.ToInt32(txtNumberOfTeamsCoached.Text);
                    coach.PlayersTrained = Convert.ToInt32(txtPlayersTrained.Text);
                    coach.WinPercentage = Convert.ToInt32(txtWinPercentage.Text);
                    coach.YearsOfExperience = Convert.ToInt32(txtYearsOfExperience.Text);
                    displayNames();
                }
                catch
                {
                    MessageBox.Show("Invalid Input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void deleteCoach()
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
                    int index = lstCoaches.SelectedIndex;
                    _coaches.RemoveAt(index);
                    for (int dex = 0; dex < _coaches.Count; dex++)
                    {
                        _coaches[dex].Id = dex;
                    }//updating the id offset
                    displayNames();

                }
                catch
                {
                    MessageBox.Show("Selection Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void sMenuInsert_Click(object sender, RoutedEventArgs e)
        {
            insertCoach();
        }

        private void sMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCoach();
        }

        private void sMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteCoach();
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
