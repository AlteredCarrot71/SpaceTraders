using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

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
                (int)(EngSkill.Value + TradeSkill.Value + FightSkill.Value + PilotSkill.Value);
            int val = 16 - total;
            SkillPoints.Text = "Remaining Skill Points: " + val;
            if (total > 16 || PlayerName.Text.Length == 0)
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
            if (!(EngSkill.Value + TradeSkill.Value + FightSkill.Value + PilotSkill.Value <= 16) ||
                PlayerName.Text.Length == 0) return;

            Game.Instance.Player = new Player
                                        {
                                            Name = PlayerName.Text,
                                            TradeSkill = (int)TradeSkill.Value,
                                            FightingSkill = (int)FightSkill.Value,
                                            EngineeringSkill = (int)EngSkill.Value,
                                            PilotSkill = (int)PilotSkill.Value,
                                            Money = 10000,
                                            Ship = Ships.Gnat
                                        };
            Game.Instance.CreateUniverse();

            Game.Instance.Player.Ship.IsVisible = false;
            Game.Instance.Player.Ship.CurrentFuel = Ships.Gnat.MaxFuel;
            Game.Instance.Player.Ship.CurrentHullStrength = Ships.Gnat.HullStrength;

            // Planet screen will be the starting point of game
            this.Frame.Navigate(typeof(PlanetScreen));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
