using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceTraders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlanetScreen : Page
    {
        private GameInstance game;
        private Planet curPlanet;
        private Player player;

        public PlanetScreen()
        {
            this.InitializeComponent();
            game = GameInstance.Instance;
            curPlanet = game.CurrentPlanet;
            player = game.Player;
            Random r = new Random();
            ColorList cl = new ColorList();
            PlanetImg.Fill = new SolidColorBrush(cl.ElementAt(r.Next(cl.Count)));
            Refuel.Content = "Refuel: " + player.GetRefuelCost() + " cr";
            TitleScreen.Text = curPlanet.Name;
            Description.Text = curPlanet.GetInfo() + "\n Resources:  "
                               + curPlanet.Resource.Name + "\n\nFuel: " + player.Ship.CurrentFuel
                               + "\nMoney: "
                               + player.Money;

            if (curPlanet.Techlevel.Equals(TechLevel.POST_INDUSTRIAL))
            {
                enterShipyard.IsEnabled = true;
            }
            else if ( curPlanet.HasShipYard() )
            {
                enterShipyard.IsEnabled = true;
            }
            else
            {
                enterShipyard.IsEnabled = false;
            }
        }

        private void ToMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MapScreen));
        }

        private void EnterMarket_Click(object sender, RoutedEventArgs e)
        {
            game.CurrentPlanet.EnterMarket(game.Player);
            this.Frame.Navigate(typeof (MarketScreen));
        }

        private void EnterShipyard_Click(object sender, RoutedEventArgs e)
        {
            game.CurrentPlanet.EnterShipyard(game.Player);
            this.Frame.Navigate(typeof (ShipyardScreen));
        }

        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            player.BuyFuel();
            Description.Text = curPlanet.GetInfo() + "\n Resources:  "
                               + curPlanet.Resource.Name + "\n\nFuel: " + player.Ship.CurrentFuel
                               + "\nMoney: "
                               + player.Money;
            Refuel.Content = "Refuel: " + 0 + " cr";
        }
    }
}
