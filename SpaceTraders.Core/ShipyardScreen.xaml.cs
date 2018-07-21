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
        private Ship currentShip;
        private Player player;
        private ObservableCollection<string> options;
        private int costToBuy;
        private Ship playership;
        public ShipyardScreen()
        {
            this.InitializeComponent();
            GameInstance gm = GameInstance.getInstance();
            this.player = gm.getPlayer();
            playership = player.Ship;
            currShip.Text = playership.toString();

            Planet currentPlanet = gm.getCurrentPlanet();
            shipyard = currentPlanet.getShipyard();
            ShipyardTitle.Text = currentPlanet.getName() + " Shipyard";

            if (currentPlanet.getTechLevel().Equals(TechLevel.POST_INDUSTRIAL))
            {
                options = new ObservableCollection<string>{
                        Ship.flea().toString()
                };
            }
            else if (currentPlanet.getTechLevel().Equals(TechLevel.HI_TECH))
            {
                options = new ObservableCollection<string>{
                    Ship.flea().toString(),
                    Ship.gnat().toString(),
                    Ship.firefly().toString(),
                    Ship.mosquito().toString(),
                    Ship.bumblebee().toString()
            };
            }
            ShipCombo.ItemsSource = options;
            PlayerMoney.Text = player.Money.ToString();

        }

        private void ShipCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ship selected = (Ship) ShipCombo.SelectedItem;
            ShipInfo.Text = selected.toString();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }
    }
}
