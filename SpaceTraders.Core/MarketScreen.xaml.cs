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
    public sealed partial class MarketScreen : Page
    {
        private Planet currentPlanet;
        private Marketplace marketplace;
        private GameInstance gm;
        private Player player;
        private ObservableCollection<String> marketGoods = new ObservableCollection<String>();
        private ObservableCollection<String> shipGoods = new ObservableCollection<String>();
        public MarketScreen()
        {
            this.InitializeComponent();
            this.gm = GameInstance.getInstance();
            this.player = gm.getPlayer();
            currentPlanet = gm.getCurrentPlanet();
            MarketTitle.Text = currentPlanet.getName() + " Market";
            marketplace = currentPlanet.getMarketplace();

            foreach (Good good in marketplace.getMerchandise())
            {
                marketGoods.Add(good.toString());
            }
            if (player.getCargo().Count != 0)
            {
                SellButton.IsEnabled = false;
                foreach (Good good in player.getCargo())
                {
                    shipGoods.Add(good.toString());
                }
            }

            if (player.cargoRoomLeft() < 1)
            {
                BuyButton.IsEnabled = true;
            }
            MarketList.ItemsSource = marketGoods;
            ShipList.ItemsSource = shipGoods;

        }
    }
}
