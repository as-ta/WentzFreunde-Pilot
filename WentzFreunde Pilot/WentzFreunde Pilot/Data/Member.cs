using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentzFreunde_Pilot.Data
{
    public class Member
    {
        public string Mitgliedernummer { get; set; } = "";
        public string Anrede { get; set; } = "";
        public string Anrede2 { get; set; } = "";

        public string Name { get; set; } = "";
        public string Vorname { get; set; } = "";
        public string Titel { get; set; } = "";

        public string Strasse { get; set; } = "";
        public string Plz { get; set; } = "";
        public string Wohnort { get; set; } = "";

        public string Telefonnummer { get; set; } = "";
        public decimal Mitgliedsbeitrag { get; set; }

        public string KontoinhaberNachname { get; set; } = "";
        public string KontoinhaberVorname { get; set; } = "";
        public string NameDerBank { get; set; } = "";
        public string IBAN { get; set; } = "";
        public string BIC { get; set; } = "";

        public string Email { get; set; } = "";

        public string Eintritt { get; set; } = "";
    }


}
