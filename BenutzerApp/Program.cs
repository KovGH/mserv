    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using CsvHelper;
    using CsvHelper.Configuration;

    namespace Seminar
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                ImportDataFromCsv("Benutzer.csv");
                
                try
                {
                    using (var context = new BenutzerContext())
                    {
                        context.Database.OpenConnection();
                        
                        if (context.Database.CanConnect())
                        {
                            Console.WriteLine("Erfolgreich eine Verbindung zur Datenbank hergestellt!");
                        }
                        else
                        {
                            Console.WriteLine("Verbindung zur Datenbank konnte nicht hergestellt werden!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Herstellen einer Verbindung zur Datenbank: " + ex.Message);
                }

                static void ImportDataFromCsv(string filePath)
                {
                    using (var reader = new StreamReader(filePath, System.Text.Encoding.Default))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        csv.Context.RegisterClassMap<BenutzerMap>(); 

                        var records = csv.GetRecords<Benutzer>().ToList(); 

                        using (var dbContext = new BenutzerContext())
                        {
                            dbContext.Benutzerx.AddRange(records); 
                            dbContext.SaveChanges(); 
                        }
                    }
                }
            }

            public class BenutzerMap : ClassMap<Benutzer>
            {
                public BenutzerMap()
                {
                    Map(m => m.Id).Ignore(); 
                    Map(m => m.Vorname).Name("Vorname"); 
                    Map(m => m.Nachname).Name("Nachname");
                    Map(m => m.Email).Name("Email");
                    Map(m => m.Telefonnummer).Name("Telefonnummer");
                    Map(m => m.Adresse).Name("Adresse");
                    Map(m => m.Stadt).Name("Stadt");
                    Map(m => m.PLZ).Name("PLZ");
                    Map(m => m.Land).Name("Land");
                    Map(m => m.Geburtsdatum).Name("Geburtsdatum").TypeConverterOption.Format("yyyy-MM-dd");
                }
            }
            }
        }
