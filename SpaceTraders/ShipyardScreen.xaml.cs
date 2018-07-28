using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceTraders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShipyardScreen : Page
    {
        private Shipyard shipyard;
        //private Ship currentShip;
        //private int costToBuy;
        private Player player;
        private ObservableCollection<string> options;
        private Ship playership;
        public ShipyardScreen()
        {
            this.InitializeComponent();
            GameInstance game = GameInstance.Instance;
            this.player = game.Player;
            playership = player.Ship;
            currShip.Text = playership.Name;

            Planet currentPlanet = game.CurrentPlanet;
            shipyard = currentPlanet.Shipyard;
            ShipyardTitle.Text = currentPlanet.Name + " Shipyard";

            if (currentPlanet.Techlevel.Equals(TechLevel.POST_INDUSTRIAL))
            {
                options = new ObservableCollection<string>{
                        Ship.Flea.Name
                };
            }
            else if (currentPlanet.Techlevel.Equals(TechLevel.HI_TECH))
            {
                options = new ObservableCollection<string>{
                    Ship.Flea.Name,
                    Ship.Gnat.Name,
                    Ship.Firefly.Name,
                    Ship.Mosquito.Name,
                    Ship.Bumblebee.Name
            };
            }
            ShipCombo.ItemsSource = options;
            PlayerMoney.Text = player.Money.ToString();

        }

        private void ShipCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ship selected = Ship.Values.Find(x => x.Name.Equals(ShipCombo.SelectedItem.ToString()));
            ShipInfo.Text = selected.Name;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }
    }
}
