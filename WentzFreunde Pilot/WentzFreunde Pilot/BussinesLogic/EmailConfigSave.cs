using System;
using System.IO;
using System.Xml.Serialization;
using WentzFreunde_Pilot.Data;

namespace WentzFreunde_Pilot.BussinesLogic
{
    public static class EmailConfigSave
    {
        private static readonly string DateiPfad =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "WentzFreunde_Pilot",
                "email_config.xml");

        public static void Speichern(EmailConfig config)
        {
            string? ordner = Path.GetDirectoryName(DateiPfad);

            if (!string.IsNullOrWhiteSpace(ordner))
                Directory.CreateDirectory(ordner);

            XmlSerializer serializer =
                new XmlSerializer(typeof(EmailConfig));

            using FileStream stream =
                new FileStream(DateiPfad, FileMode.Create);

            serializer.Serialize(stream, config);
        }

        public static EmailConfig Laden()
        {
            if (!File.Exists(DateiPfad))
                return new EmailConfig();

            try
            {
                XmlSerializer serializer =
                    new XmlSerializer(typeof(EmailConfig));

                using FileStream stream =
                    new FileStream(DateiPfad, FileMode.Open);

                return (EmailConfig)serializer.Deserialize(stream)!;
            }
            catch
            {
                return new EmailConfig();
            }
        }

        public static string GetDateiPfad()
        {
            return DateiPfad;
        }
    }
}