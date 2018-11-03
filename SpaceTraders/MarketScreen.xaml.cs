using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceTraders
{
    public sealed partial class MarketScreen : Page
    {
        private Marketplace marketplace;
        private ObservableCollection<String> marketGoods = new ObservableCollection<String>();
        private ObservableCollection<String> shipGoods = new ObservableCollection<String>();

        private void EnablingButtons()
        {
            if ( Game.Instance.Player.Ship.MaxCargo > Game.Instance.Player.Ship.Cargo.Count )
            {
                BuyButton.IsEnabled = true;
            }
            else
            {
                BuyButton.IsEnabled = false;
            }

            if ( Game.Instance.Player.Ship.Cargo.Count > 0 )
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

            MarketTitle.Text = Game.Instance.CurrentPlanet.Name + " Market";
            marketplace = Game.Instance.CurrentPlanet.Marketplace;

            foreach (Good good in marketplace.Supply)
            {
                marketGoods.Add(good.Name);
            }

            foreach (Good good in Game.Instance.Player.Ship.Cargo)
            {
                shipGoods.Add(good.Name);
            }

            EnablingButtons();
            PlayerMoney.Text = Game.Instance.Player.Money.ToString();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            //Game.Instance.SaveState();
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
            PlayerMoney.Text = Game.Instance.Player.Money.ToString();
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
            PlayerMoney.Text = Game.Instance.Player.Money.ToString();
        }
    }
}
