using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Seminar
{
    class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                using (var context = new ProduktContext())
                {
               
                    context.Database.GetDbConnection().Open(); 

                    
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

            ImportDataFromCsv("Produkte.csv");
            
            static void ImportDataFromCsv(string filePath)
            {
                using (var reader = new StreamReader(filePath, Encoding.GetEncoding("ISO-8859-1")))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Context.RegisterClassMap<ProduktMap>(); 

                    var records = csv.GetRecords<Produkt>().ToList(); 

                    using (var dbContext = new ProduktContext())
                    {
                        dbContext.Produkte.AddRange(records); 
                        dbContext.SaveChanges(); 
                    }
                }
            }
        }

        public class ProduktMap : ClassMap<Produkt>
            {
                public ProduktMap()
                {
                    Map(m => m.ProduktId).Ignore(); 
                    Map(m => m.Name).Name("Name"); 
                    Map(m => m.Beschreibung).Name("Beschreibung");
                    Map(m => m.Preis).Name("Preis");
                    Map(m => m.Kategorie).Name("Kategorie");
                    Map(m => m.Hersteller).Name("Hersteller");
                    Map(m => m.Lagerbestand).Name("Lagerbestand");
                    Map(m => m.Lieferzeit).Name("Lieferzeit");
                    Map(m => m.Gewicht).Name("Gewicht");
                    Map(m => m.EAN).Name("EAN");
                }
            }
        }
    }

