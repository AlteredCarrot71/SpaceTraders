using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Shapes;

namespace SpaceTraders
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapScreen : Page
    {

        private ISet<SolarSystem> universe;
        private ColorList colorList = new ColorList();
        private GameInstance game;
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
            game = GameInstance.getInstance();
            universe = game.getSolarSystems();
            playerLocation = game.getCurrentSolarSystem().getPosition();
            CurrentFuel.Text = "Current Fuel: " + game.getPlayer().getCurrentFuel();
            currentLine = new Line
            {
                Stroke = new SolidColorBrush(Colors.Transparent),
                StrokeThickness = 5,
                X1 = playerLocation.getX(),
                Y1 = playerLocation.getY()
            };
            MapPane.Children.Add(currentLine);
            CreateMap();

        }

        /**
     * Creates the map for the map screen.
     *
     */

        private void CreateMap()
        {

            foreach (SolarSystem s in universe)
            {

                nameMap.Add(s.getPlanets().ElementAt(0).getName(), s);
                ListPlanet.Items.Add(s.getPlanets().ElementAt(0).getName());

                Point point = s.getPosition();
                SolidColorBrush c = new SolidColorBrush(colorList.ElementAt(random.Next(colorList.Count)));
                Ellipse cor = new Ellipse
                {
                    Margin = new Thickness {Top = point.getY(), Left = point.getX()},      
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

            Point chosenPlanet = new Point((int) ((int) clickedCircle.Clip.Rect.X + (currentCircle.Clip.Rect.Width/2)),
                            (int) ((int)clickedCircle.Clip.Rect.Y + (currentCircle.Clip.Rect.Height / 2)));
            /*
            currentLine.X1 = currentCircle.Clip.Rect.X + (currentCircle.Clip.Rect.Width/2);
            currentLine.Y1 = currentCircle.Clip.Rect.Y + (currentCircle.Clip.Rect.Height/2);
             */
            
            
            currentCircle.Stroke = new SolidColorBrush(colorList.ElementAt(random.Next()));
            currentCircle = clickedCircle;
            currentCirclePoint = chosenPlanet;
            currentCircle.Stroke = new SolidColorBrush(Colors.White);
            
        }

        private void Travel_Click(object sender, RoutedEventArgs e)
        {
            SolarSystem p;
            nameMap.TryGetValue((String) ListPlanet.SelectedItem, out p);
            game.setCurrentPlanet(p.getPlanets().ElementAt(0));
            game.getPlayer().travel(travelDistance);
            RandomEvent randomEvent = EventFactory.createRandomEvent(game.getPlayer());
            String even = randomEvent.Event();
            if (!even.Equals("")) {
                MessageDialog c = new MessageDialog(even, "Something has happened...");
                c.ShowAsync();
            }
            game.getCurrentPlanet().enterMarket(game.getPlayer());
            game.getCurrentPlanet().enterShipyard(game.getPlayer());
            this.Frame.Navigate(typeof (PlanetScreen));
        }

        private void ToPlanet_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PlanetScreen));
        }

        private void ListPlanet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Travel.IsEnabled = true;
            SolarSystem s;
            nameMap.TryGetValue((String)ListPlanet.SelectedItem, out s);
            travelDistance = s.getPosition().distance(playerLocation);
            NeededFuel.Text = "Needed Fuel: " + travelDistance;
        }
    }

    public class ColorList : List<Windows.UI.Color>
    {
        public ColorList()
            {
            this.Add(Windows.UI.Colors.Blue);
            this.Add(Windows.UI.Colors.BlueViolet);
            this.Add(Windows.UI.Colors.Brown);
            this.Add(Windows.UI.Colors.CadetBlue);
            this.Add(Windows.UI.Colors.Chartreuse);
            this.Add(Windows.UI.Colors.Chocolate);
            this.Add(Windows.UI.Colors.Coral);
            this.Add(Windows.UI.Colors.CornflowerBlue);
            this.Add(Windows.UI.Colors.Crimson);
            this.Add(Windows.UI.Colors.Cyan);
            this.Add(Windows.UI.Colors.LimeGreen);
            this.Add(Windows.UI.Colors.Magenta);
            this.Add(Windows.UI.Colors.Navy);
            this.Add(Windows.UI.Colors.Olive);
            this.Add(Windows.UI.Colors.OliveDrab);
            this.Add(Windows.UI.Colors.Orange);
            this.Add(Windows.UI.Colors.OrangeRed);
            this.Add(Windows.UI.Colors.Orchid);
            this.Add(Windows.UI.Colors.Red);
            this.Add(Windows.UI.Colors.RosyBrown);
            this.Add(Windows.UI.Colors.RoyalBlue);
            this.Add(Windows.UI.Colors.Sienna);
            this.Add(Windows.UI.Colors.Silver);
            this.Add(Windows.UI.Colors.SkyBlue);
            this.Add(Windows.UI.Colors.Yellow);
            this.Add(Windows.UI.Colors.YellowGreen);
        }
    }
}
