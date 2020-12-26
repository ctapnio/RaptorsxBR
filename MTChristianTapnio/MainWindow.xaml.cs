/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTChristianTapnio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public bool programClose = true;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            PlayersWindow playersWindow = new PlayersWindow();
            programClose = false;
            Close();
            playersWindow.ShowDialog();
            
        }

        private void btnCoaches_Click(object sender, RoutedEventArgs e)
        {
            CoachesWindow coachesWindow = new CoachesWindow();
            programClose = false;
            Close();
            coachesWindow.ShowDialog();
        }

        private void btnManagers_Click(object sender, RoutedEventArgs e)
        {
            ManagersWindow managersWindow = new ManagersWindow();
            programClose = false;
            Close();
            managersWindow.ShowDialog();
        }

        private void sMenuQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void sMenuPlayers_Click(object sender, RoutedEventArgs e)
        {
            PlayersWindow playersWindow = new PlayersWindow();
            programClose = false;
            Close();
            playersWindow.ShowDialog();
        }

        private void sMenuCoaches_Click(object sender, RoutedEventArgs e)
        {
            CoachesWindow coachesWindow = new CoachesWindow();
            programClose = false;
            Close();
            coachesWindow.ShowDialog();
        }

        private void sMenuManagers_Click(object sender, RoutedEventArgs e)
        {
            ManagersWindow managersWindow = new ManagersWindow();
            programClose = false;
            Close();
            managersWindow.ShowDialog();
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
