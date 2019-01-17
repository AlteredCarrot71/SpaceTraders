using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceTraders
{
    public sealed partial class ShipyardScreen : Page
    {
        //private Shipyard shipyard;
        private ObservableCollection<string> shipsforsale;
        private ObservableCollection<string> weaponsforsale;
        //TODO: implement gadgets

        public ShipyardScreen()
        {
            this.InitializeComponent();

            currShip.Text = "Current Ship: " + Game.Instance.Player.Ship.Name;
            ShipInfo.Text = Game.Instance.Player.Ship.Text;
            ShipyardTitle.Text = Game.Instance.Universe.CurrentPlanet.Name + " Shipyard";

            shipsforsale = new ObservableCollection<string>();
            foreach ( Ship ship in Ships.Values.FindAll(x => x.MinTechLevel <= Game.Instance.Universe.CurrentPlanet.Techlevel ) )
            {
                shipsforsale.Add(ship.Name);
            }
            ShipCombo.ItemsSource = shipsforsale;

            weaponsforsale = new ObservableCollection<string>();
            foreach (Weapon weapon in Weapons.Values.FindAll(x => x.MinTechLevel <= Game.Instance.Universe.CurrentPlanet.Techlevel))
            {
                weaponsforsale.Add(weapon.Name);
            }

            PlayerMoney.Text = Game.Instance.Player.Money.ToString();
        }

        private void ShipCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ship selected = Ships.Values.Find(x => x.Name.Equals(ShipCombo.SelectedItem.ToString()));
            ShipInfo.Text = selected.Text;
            ShipCost.Text = "Cost of Ship: " + selected.Price.ToString();

            if (Game.Instance.Player.Money >= selected.Price)
            {
                TradeButton.IsEnabled = true;
            }
            else
            {
                TradeButton.IsEnabled = false;
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }

        private void TradeButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: implement shipyard actions
        }
    }
}
