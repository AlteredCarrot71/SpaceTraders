using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceTraders
{
    public sealed partial class MarketScreen : Page
    {
        private Planet currentPlanet;
        private Marketplace marketplace;
        private GameInstance game;
        private Player player;
        private ObservableCollection<String> marketGoods = new ObservableCollection<String>();
        private ObservableCollection<String> shipGoods = new ObservableCollection<String>();

        private void EnablingButtons()
        {
            if (player.Ship.cargoRoomLeft() > 0)
            {
                BuyButton.IsEnabled = true;
            }
            else
            {
                BuyButton.IsEnabled = false;
            }

            if ( player.Ship.cargoSize() - player.Ship.cargoRoomLeft() > 0 )
            {
                SellButton.IsEnabled = true;
            }
            else
            {
                SellButton.IsEnabled = false;
            }
        }

        public MarketScreen()
        {
            this.InitializeComponent();
            this.game = GameInstance.Instance;
            this.player = game.Player;
            currentPlanet = game.CurrentPlanet;
            MarketTitle.Text = currentPlanet.Name + " Market";
            marketplace = currentPlanet.Marketplace;

            foreach (Good good in marketplace.Supply)
            {
                marketGoods.Add(good.Name);
            }

            foreach (Good good in player.Ship.getCargo())
            {
                shipGoods.Add(good.Name);
            }

            EnablingButtons();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            game.Player = player;
            this.Frame.Navigate(typeof(PlanetScreen));
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if ( MarketList.SelectedItems.Count > 0 )
            {
                marketplace.PlayerBuys(Goods.Values.Find(x => x.Name.Contains(MarketList.SelectedValue.ToString())));

                shipGoods.Add(MarketList.SelectedItem.ToString());
                marketGoods.RemoveAt(MarketList.SelectedIndex);
            }

            EnablingButtons();
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShipList.SelectedItems.Count > 0)
            {
                marketplace.PlayerSells(Goods.Values.Find(x => x.Name.Contains(ShipList.SelectedValue.ToString())));

                marketGoods.Add(ShipList.SelectedItem.ToString());
                shipGoods.RemoveAt(ShipList.SelectedIndex);
            }

            EnablingButtons();
        }
    }
}
