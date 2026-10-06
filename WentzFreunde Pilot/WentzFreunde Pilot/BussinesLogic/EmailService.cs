using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using WentzFreunde_Pilot.Data;

namespace WentzFreunde_Pilot.BussinesLogic
{
    public static class EmailService
    {
        public static async Task SendeTestmailAsync(
            EmailConfig config,
            string passwort,
            string testEmpfaenger,
            string betreff,
            string nachricht,
            string anhangDatei = "")
        {
            var message = new MimeMessage();

            // Absender
            message.From.Add(
                new MailboxAddress(
                    config.AbsenderName,
                    config.AbsenderAdresse));

            // Testempfänger - genau EINE Adresse!
            message.To.Add(
                MailboxAddress.Parse(testEmpfaenger));

            message.Subject = betreff;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = nachricht
            };

            // Optionaler Anhang
            if (!string.IsNullOrWhiteSpace(anhangDatei))
            {
                if (!File.Exists(anhangDatei))
                    throw new FileNotFoundException(
                        "Der ausgewählte Anhang wurde nicht gefunden.",
                        anhangDatei);

                bodyBuilder.Attachments.Add(anhangDatei);
            }

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            // Hetzner: Port 587 + STARTTLS
            await client.ConnectAsync(
                config.SmtpServer,
                config.SmtpPort,
                SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(
                config.Benutzername,
                passwort);

            await client.SendAsync(message);

            await client.DisconnectAsync(true);
        }

        public static async Task SendeBatchesAsync(
            EmailConfig config,
            string passwort,
            List<List<string>> batches,
            string betreff,
            string nachricht,
            string anhangDatei,
            Action<int, int, int> fortschritt)
        {
            if (batches == null || batches.Count == 0)
                throw new ArgumentException(
                    "Es wurden keine Versand-Batches übergeben.",
                    nameof(batches));

            using var client = new SmtpClient();

            try
            {
                // Nur EINMAL mit dem SMTP-Server verbinden
                await client.ConnectAsync(
                    config.SmtpServer,
                    config.SmtpPort,
                    SecureSocketOptions.StartTls);

                // Nur EINMAL anmelden
                await client.AuthenticateAsync(
                    config.Benutzername,
                    passwort);

                int versendeteEmpfaenger = 0;

                for (int i = 0; i < batches.Count; i++)
                {
                    List<string> batch = batches[i];

                    var message = new MimeMessage();

                    message.From.Add(
                        new MailboxAddress(
                            config.AbsenderName,
                            config.AbsenderAdresse));

                    // Sichtbarer Empfänger = eigene Vereinsadresse
                    message.To.Add(
                        new MailboxAddress(
                            config.AbsenderName,
                            config.AbsenderAdresse));

                    // Mitglieder ausschließlich als BCC
                    foreach (string email in batch)
                    {
                        message.Bcc.Add(
                            MailboxAddress.Parse(email));
                    }

                    message.Subject = betreff;

                    var bodyBuilder = new BodyBuilder
                    {
                        TextBody = nachricht
                    };

                    // Optionaler Anhang
                    if (!string.IsNullOrWhiteSpace(anhangDatei))
                    {
                        if (!File.Exists(anhangDatei))
                        {
                            throw new FileNotFoundException(
                                "Der ausgewählte Anhang wurde nicht gefunden.",
                                anhangDatei);
                        }

                        bodyBuilder.Attachments.Add(anhangDatei);
                    }

                    message.Body = bodyBuilder.ToMessageBody();

                    // Mail dieses Batches versenden
                    await client.SendAsync(message);

                    versendeteEmpfaenger += batch.Count;

                    // Form über Fortschritt informieren
                    fortschritt?.Invoke(
                        i + 1,
                        batches.Count,
                        versendeteEmpfaenger);
                }
            }
            finally
            {
                if (client.IsConnected)
                    await client.DisconnectAsync(true);
            }
        }
    }
}