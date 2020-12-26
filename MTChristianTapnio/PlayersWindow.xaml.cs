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
    /// Interaction logic for PlayersWindow.xaml
    /// </summary>
    public partial class PlayersWindow : Window
    {
        public bool programClose = true;
        private List<Player> _players ;
        
        public PlayersWindow()
        {
            InitializeComponent();
            _players = new List<Player>() {
                new Player(914, 94, 38, 13481, 0, "Kyle Lowry"),
                new Player(313, 123, 42, 7282, 1, "Fred Vanvleet"),
                new Player(182, 84, 30, 5243, 2, "OG Anunoby"),
                new Player(422, 165, 32, 9232, 3, "Pascal Siakam"),
                new Player(879, 124, 80, 11248, 4, "Serge Ibaka")
        };

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            displayNames();
        }
        private void lstPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstPlayers.SelectedIndex;
            var selectedPlayer = (from player in _players
                                  where player.Id == index
                                  select player).FirstOrDefault();
            if (selectedPlayer != null)
            {
                txtId.Text = Convert.ToString(selectedPlayer.Id);
                txtName.Text = selectedPlayer.Name;
                txtMatchesPlayed.Text = Convert.ToString(selectedPlayer.MatchesPlayed);
                txtWon.Text = Convert.ToString(selectedPlayer.Won);
                txtLost.Text = Convert.ToString(selectedPlayer.Lost);
                txtGoalsScored.Text = Convert.ToString(selectedPlayer.GoalsScored);
            }

        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insertPlayer();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updatePlayer();
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePlayer();
        }

        private void sMenuInsert_Click(object sender, RoutedEventArgs e)
        {
            insertPlayer();
        }
        private void sMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updatePlayer();
        }

        private void sMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePlayer();
        }
        private void displayNames()
        {
            var names = from player in _players
                        select player.Name;
            lstPlayers.ItemsSource = names;
        }

        private void insertPlayer()
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
                    Player player = new Player(
                    Convert.ToInt32(txtMatchesPlayed.Text),
                    Convert.ToInt32(txtWon.Text),
                    Convert.ToInt32(txtLost.Text),
                    Convert.ToInt32(txtGoalsScored.Text),
                    _players.Count,
                    txtName.Text);

                    _players.Add(player);
                    displayNames();
                }
                catch 
                {
                    MessageBox.Show("Invalid Input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            
        }
        private void updatePlayer()
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
                    int index = lstPlayers.SelectedIndex;

                    Player player = _players[index];

                    player.Id = Convert.ToInt32(txtId.Text);
                    player.Name = txtName.Text;
                    player.MatchesPlayed = Convert.ToInt32(txtMatchesPlayed.Text);
                    player.Won = Convert.ToInt32(txtWon.Text);
                    player.Lost = Convert.ToInt32(txtLost.Text);
                    player.GoalsScored = Convert.ToInt32(txtGoalsScored.Text);

                    displayNames();
                }
                catch 
                {
                    MessageBox.Show("Selection Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
                

        }
        private void deletePlayer()
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
                    int index = lstPlayers.SelectedIndex;
                    _players.RemoveAt(index);
                    for (int dex = 0; dex < _players.Count; dex++)
                    {
                        _players[dex].Id = dex;
                    }//updating the id offset
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
