using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceTraders
{
    public sealed partial class ShipyardScreen : Page
    {
        //private Shipyard shipyard;
        private ObservableCollection<string> options;

        public ShipyardScreen()
        {
            this.InitializeComponent();

            currShip.Text = GameInstance.Instance.Player.Ship.Name;
            ShipInfo.Text = GameInstance.Instance.Player.Ship.Text;
            ShipyardTitle.Text = GameInstance.Instance.CurrentPlanet.Name + " Shipyard";

            options = new ObservableCollection<string>();

            foreach ( Ship ship in Ship.Values.FindAll(x => x.MinTechLevel <= GameInstance.Instance.CurrentPlanet.Techlevel ) )
            {
                options.Add(ship.Name);
            }

            ShipCombo.ItemsSource = options;
            PlayerMoney.Text = GameInstance.Instance.Player.Money.ToString();
        }

        private void ShipCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ship selected = Ship.Values.Find(x => x.Name.Equals(ShipCombo.SelectedItem.ToString()));
            ShipInfo.Text = selected.Text;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }
    }
}
