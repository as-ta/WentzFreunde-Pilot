namespace WentzFreunde_Pilot.Data
{
    public class EmailConfig
    {
        public string SmtpServer { get; set; } = "mail.your-server.de";

        public int SmtpPort { get; set; } = 587;

        public string Benutzername { get; set; } = "";

        public string AbsenderAdresse { get; set; } = "";

        public string AbsenderName { get; set; } = "";
    }
}