using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Shapes;

namespace SpaceTraders
{
    public sealed partial class MapScreen : Page
    {
        private ISet<SolarSystem> universe;
        private ColorList colorList = new ColorList();
        private Planet curPlanet;
        private int travelDistance;
        private Point playerLocation;
        private Point currentCirclePoint;
        private Line currentLine;
        private Ellipse currentCircle;
        private Random random = new Random();
        private Dictionary<String, SolarSystem> nameMap = new Dictionary<String, SolarSystem>(); 

        public MapScreen()
        {
            this.InitializeComponent();
            curPlanet = Game.Instance.CurrentPlanet;
            universe = Game.Instance.GetSolarSystems();
            playerLocation = Game.Instance.GetCurrentSolarSystem().Position;
            CurrentFuel.Text = "Current Fuel: " + Game.Instance.Player.Ship.CurrentFuel;
            currentLine = new Line
            {
                Stroke = new SolidColorBrush(Colors.Transparent),
                StrokeThickness = 5,
                X1 = playerLocation.Xpos,
                Y1 = playerLocation.Ypos
            };
            MapPane.Children.Add(currentLine);
            CreateMap();
        }

        // Creates the map for the map screen.
        private void CreateMap()
        {
            foreach (SolarSystem s in universe)
            {
                nameMap.Add(s.Planets.ElementAt(0).Name, s);
                ListPlanet.Items.Add(s.Planets.ElementAt(0).Name);

                Point point = s.Position;
                SolidColorBrush c = new SolidColorBrush(colorList.ElementAt(random.Next(colorList.Count)));
                Ellipse cor = new Ellipse
                {
                    Margin = new Thickness {Top = point.Ypos, Left = point.Xpos},
                    Fill = c,
                    Stroke = c,
                    Height = 15,
                    Width = 15,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Tag = s
                };
                cor.Tapped += CorOnTapped;
                /*
                circle.addEventHandler(MouseEvent.MOUSE_CLICKED, drawClickedCircle);
                mapPane.addEventHandler(MouseEvent.MOUSE_CLICKED, drawLine);
                mapPane.addEventHandler(MouseEvent.MOUSE_CLICKED, handleLabels);
                circle.setUserData(s);
                */
                MapPane.Children.Add(cor);
            }
        }

        private void CorOnTapped(object sender, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            Ellipse clickedCircle = (Ellipse) sender;
            currentLine.X2 = clickedCircle.Clip.Rect.X + (currentCircle.Clip.Rect.Width/2);
            currentLine.Y2 = clickedCircle.Clip.Rect.Y + (currentCircle.Clip.Rect.Height/2);
            currentLine.Stroke = new SolidColorBrush(Colors.Red);

            Point chosenPlanet = new Point
            {
                Xpos = (int)((int)clickedCircle.Clip.Rect.X + (currentCircle.Clip.Rect.Width / 2)),
                Ypos = (int)((int)clickedCircle.Clip.Rect.Y + (currentCircle.Clip.Rect.Height / 2))
            };

            /*
            currentLine.X1 = currentCircle.Clip.Rect.X + (currentCircle.Clip.Rect.Width/2);
            currentLine.Y1 = currentCircle.Clip.Rect.Y + (currentCircle.Clip.Rect.Height/2);
            */
            
            currentCircle.Stroke = new SolidColorBrush(colorList.ElementAt(random.Next()));
            currentCircle = clickedCircle;
            currentCirclePoint = chosenPlanet;
            currentCircle.Stroke = new SolidColorBrush(Colors.White);
        }

        private async void Travel_Click(object sender, RoutedEventArgs e)
        {
            Game.Instance.Player.Ship.CurrentFuel -= travelDistance;
            Game.Instance.CurrentPlanet = Game.Instance.Planets.Find(x => x.Name.Equals(ListPlanet.SelectedItem.ToString()));
            RandomEvent randomEvent = new RandomEvent(Game.Instance.Player);
            String even = randomEvent.Event();
            if (even.Length != 0) {
                MessageDialog c = new MessageDialog(even, "Something has happened...");
                await c.ShowAsync();
            }
            
            this.Frame.Navigate(typeof (PlanetScreen));
        }

        private void ToPlanet_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }

        private void ListPlanet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Travel.IsEnabled = true;
            Travel.Content = "Travel";
            travelDistance = Game.Instance.CurrentPlanet.Location.Distance(Game.Instance.Planets.Find(x => x.Name.Equals(ListPlanet.SelectedItem.ToString())).Location);
            NeededFuel.Text = "Needed Fuel: " + travelDistance;

            if (travelDistance > Game.Instance.Player.Ship.CurrentFuel)
            {
                Travel.IsEnabled = false;
                Travel.Content = "Too far ...";
            }
        }
    }
}
