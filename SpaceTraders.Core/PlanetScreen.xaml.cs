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
            game = GameInstance.getInstance();
            curPlanet = game.getCurrentPlanet();
            player = game.getPlayer();
            Random r = new Random();
            ColorList cl = new ColorList();
            PlanetImg.Fill = new SolidColorBrush(cl.ElementAt(r.Next(cl.Count)));
            Refuel.Content = "Refuel: " + player.GetRefuelCost() + " cr";
            TitleScreen.Text = curPlanet.getName();
            Description.Text = curPlanet.toString() + "\n Resources:  "
                               + curPlanet.getResource().Name + "\n\nFuel: " + player.Ship.getCurrentFuel()
                               + "\nMoney: "
                               + player.Money;

            if (curPlanet.getTechLevel().Equals(TechLevel.POST_INDUSTRIAL))
            {
                enterShipyard.IsEnabled = true;
            }
            else if (curPlanet.getTechLevel().Equals(TechLevel.HI_TECH))
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

        private void enterMarket_Click(object sender, RoutedEventArgs e)
        {
            game.getCurrentPlanet().enterMarket(game.getPlayer());
            this.Frame.Navigate(typeof (MarketScreen));
        }

        private void enterShipyard_Click(object sender, RoutedEventArgs e)
        {
            game.getCurrentPlanet().enterShipyard(game.getPlayer());
            this.Frame.Navigate(typeof (ShipyardScreen));
        }

        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            player.BuyFuel();
            Description.Text = curPlanet.toString() + "\n Resources:  "
                               + curPlanet.getResource().Name + "\n\nFuel: " + player.Ship.getCurrentFuel()
                               + "\nMoney: "
                               + player.Money;
            Refuel.Content = "Refuel: " + 0 + " cr";
        }
    }
}
