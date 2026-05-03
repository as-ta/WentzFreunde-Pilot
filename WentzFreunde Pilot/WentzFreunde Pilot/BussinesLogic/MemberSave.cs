using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WentzFreunde_Pilot.BussinesLogic
{
    public static class MemberSave
    {
        private static readonly string OrdnerPfad =
               Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                   "Mitgliederverwaltung");

        private static readonly string DateiPfad =
            Path.Combine(OrdnerPfad, "mitglieder.xml");

        public static List<Data.Member> Laden()
        {
            if (!Directory.Exists(OrdnerPfad))
                Directory.CreateDirectory(OrdnerPfad);

            if (!File.Exists(DateiPfad))
            {
                var leereListe = new List<Data.Member>();
                Speichern(leereListe);
                return leereListe;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Data.Member>));

            using FileStream stream = new FileStream(DateiPfad, FileMode.Open);

            return (List<Data.Member>)serializer.Deserialize(stream);
        }

        public static void Speichern(List<Data.Member> mitglieder)
        {
            if (!Directory.Exists(OrdnerPfad))
                Directory.CreateDirectory(OrdnerPfad);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Data.Member>));

            using FileStream stream = new FileStream(DateiPfad, FileMode.Create);

            serializer.Serialize(stream, mitglieder);
        }

        public static string GetDateiPfad()
        {
            return DateiPfad;
        }


    }
}
