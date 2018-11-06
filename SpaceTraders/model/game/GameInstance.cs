using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

// Singleton game monitor. The game model will control the passing of turns and
// random events

namespace SpaceTraders
{
    public class Game
    {
        // Player
        public Player Player { get; set; }

        // Universe
        public Universe Universe { get; set; }

        // Folder, that stores the saved states
        private readonly Windows.Storage.StorageFolder LocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        // Reference to the Singleton GameInstance.
        private static readonly Lazy<Game> lazy = new Lazy<Game>(() => new Game());

        public static Game Instance
        {
            get { return lazy.Value; }
        }
        
        private Game()
        {
            //
        }

        // Saving game state
        public static void SaveState()
        {
            //string path = LocalFolder.Path.ToString() + "/savegame.xml";
            //FileStream fileStream = new FileStream(path, FileMode.Create);

            //XmlWriterSettings settings = new XmlWriterSettings
            //{
            //    Indent = true
            //};

            //XmlWriter writer = XmlWriter.Create(fileStream, settings);
            //DataContractSerializer serializer = new DataContractSerializer(Game.Instance.GetType());
            //serializer.WriteObject(writer, Game.Instance);
        }

        // Loading game state
        public static void LoadState()
        {
            //string path = LocalFolder.Path.ToString() + "/" + Game.Instance.Player.Name.ToString() + ".xml";
            //using (Stream stream = new MemoryStream())
            //{
            //    byte[] data = System.Text.Encoding.UTF8.GetBytes(path);
            //    stream.Write(data, 0, data.Length);
            //    stream.Position = 0;
            //    DataContractSerializer deserializer = new DataContractSerializer(Game.Instance.GetType());
            //    deserializer.ReadObject(stream);
            //}
        }
    }
}
