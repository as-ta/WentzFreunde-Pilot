using System.IO;
using System.Xml.Serialization;

namespace WentzFreunde_Pilot.BussinesLogic
{
    public static class SepaConfigSave
    {
        private static readonly string Pfad =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Mitgliederverwaltung",
                "sepa_config.xml");

        public static SepaConfig Laden()
        {
            if (!File.Exists(Pfad))
            {
                var config = new SepaConfig();
                Speichern(config);
                return config;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(SepaConfig));

            using FileStream stream = new FileStream(Pfad, FileMode.Open);
            return (SepaConfig)serializer.Deserialize(stream);
        }

        public static void Speichern(SepaConfig config)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Pfad));

            XmlSerializer serializer = new XmlSerializer(typeof(SepaConfig));

            using FileStream stream = new FileStream(Pfad, FileMode.Create);
            serializer.Serialize(stream, config);
        }

        public static string GetDateiPfad()
        {
            return Pfad;
        }
    }
}