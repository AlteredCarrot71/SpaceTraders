using SpaceTraders;
using System;
using System.Collections.Generic;
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
    public sealed partial class ConfigScreen : Page
    {
        public ConfigScreen()
        {
            this.InitializeComponent();
        }

        private void Sliders(object sender, RangeBaseValueChangedEventArgs e)
        {
            int total =
                (int)(EngSkill.Value + TradeSkill.Value + FightSkill.Value + InvestSkill.Value + PilotSkill.Value);
            int val = 15 - total;
            SkillPoints.Text = "Remaining Skill Points: " + val;
            if (total > 15 || PlayerName.Text == String.Empty)
            {
                Go.IsEnabled = false;
            }
            else
            {
                Go.IsEnabled = true;
            }
        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(EngSkill.Value + TradeSkill.Value + FightSkill.Value + InvestSkill.Value + PilotSkill.Value <= 15) ||
                PlayerName.Text == String.Empty) return;
            Player player = new Player(PlayerName.Text, (int)PilotSkill.Value, (int)FightSkill.Value,
                (int)EngSkill.Value, (int)TradeSkill.Value, (int)InvestSkill.Value);
            GameInstance game = GameInstance.Instance;
            player.ChangeMoney(10000);
            game.Player = player;
            game.createUniverse();
            this.Frame.Navigate(typeof(MapScreen));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
