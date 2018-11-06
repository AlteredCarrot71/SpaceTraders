using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SpaceTraders
{
    public sealed partial class PlanetScreen : Page
    {
        public PlanetScreen()
        {
            this.InitializeComponent();
            Random r = new Random();
            ColorList cl = new ColorList();
            PlanetImg.Fill = new SolidColorBrush(cl.ElementAt(r.Next(cl.Count)));
            Refuel.Content = "Refuel: " + RefuelCost() + " cr";
            TitleScreen.Text = Game.Instance.Universe.CurrentPlanet.Name;
            Description.Text = Game.Instance.Universe.CurrentPlanet.GetInfo();

            Fuel.Text = "Fuel: " + Game.Instance.Player.Ship.CurrentFuel;
            Money.Text = "Money: " + Game.Instance.Player.Money;

            if (Game.Instance.Universe.CurrentPlanet.Techlevel >= TechLevel.POST_INDUSTRIAL)
            {
                enterShipyard.IsEnabled = true;
            }
            else if (Game.Instance.Universe.CurrentPlanet.HasShipYard())
            {
                enterShipyard.IsEnabled = true;
            }
            else
            {
                enterShipyard.IsEnabled = false;
            }

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                enterShipyard.IsEnabled = true;
            }
#endif

            if (Game.Instance.Player.Ship.MaxFuel > Game.Instance.Player.Ship.CurrentFuel )
            {
                Refuel.IsEnabled = true;
            }
            else
            {
                Refuel.IsEnabled = false;
            }

            if (Game.Instance.Player.Ship.HullStrength > Game.Instance.Player.Ship.CurrentHullStrength)
            {
                Repair.IsEnabled = true;
            }
            else
            {
                Repair.IsEnabled = false;
            }
        }

        private void ToMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MapScreen));
        }

        private void EnterMarket_Click(object sender, RoutedEventArgs e)
        {
            Game.Instance.Universe.CurrentPlanet.EnterMarket(Game.Instance.Player);
            this.Frame.Navigate(typeof (MarketScreen));
        }

        private void EnterShipyard_Click(object sender, RoutedEventArgs e)
        {
            Game.Instance.Universe.CurrentPlanet.EnterShipyard(Game.Instance.Player);
            this.Frame.Navigate(typeof (ShipyardScreen));
        }

        // Adds fuel to the player's ship and removes the appropriate amount of money from the player.
        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            Game.Instance.Player.Money -= RefuelCost();
            Game.Instance.Player.Ship.CurrentFuel += RefuelQuantity();
            Fuel.Text = "Fuel: " + Game.Instance.Player.Ship.CurrentFuel;
            Money.Text = "Money: " + Game.Instance.Player.Money;
            Refuel.Content = "Refuel: " + 0 + " cr";
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement repair functionality
            Repair.IsEnabled = false;
        }

        // Returns the total cost of refueling a ship.
        public static int RefuelCost()
        {
            return RefuelQuantity() * Game.Instance.Player.Ship.FuelCost;
        }

        // Calculates the amount of fuel a player can buy based on money and fuel cost.
        private static int RefuelQuantity()
        {
            int fuelAmount;

            if ( ((Game.Instance.Player.Ship.MaxFuel - Game.Instance.Player.Ship.CurrentFuel) * Game.Instance.Player.Ship.FuelCost) > Game.Instance.Player.Money )
            {
                fuelAmount = Game.Instance.Player.Money / Game.Instance.Player.Ship.FuelCost;
            }
            else
            {
                fuelAmount = Game.Instance.Player.Ship.MaxFuel - Game.Instance.Player.Ship.CurrentFuel;
            }

            return fuelAmount;
        }
    }
}
