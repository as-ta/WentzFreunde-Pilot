using System;
using System.IO;
using System.Text;

namespace WentzFreunde_Pilot.BussinesLogic
{
    public static class EmailVersandProtokoll
    {
        private static readonly string OrdnerPfad =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "WentzFreunde_Pilot",
                "EmailProtokolle");

        public static string NeuesProtokoll()
        {
            Directory.CreateDirectory(OrdnerPfad);

            string dateiname =
                $"EmailVersand_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";

            string pfad =
                Path.Combine(OrdnerPfad, dateiname);

            File.WriteAllText(
                pfad,
                "",
                Encoding.UTF8);

            return pfad;
        }

        public static void Schreiben(
            string protokollPfad,
            string text)
        {
            File.AppendAllText(
                protokollPfad,
                $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {text}" +
                Environment.NewLine,
                Encoding.UTF8);
        }

        public static string GetOrdnerPfad()
        {
            Directory.CreateDirectory(OrdnerPfad);

            return OrdnerPfad;
        }
    }
}