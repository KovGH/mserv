namespace Seminar;

public class Benutzer
{
    public int Id { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Email { get; set; }
    public string Telefonnummer { get; set; }
    public string Adresse { get; set; }
    public string Stadt { get; set; }
    public string PLZ { get; set; }
    public string Land { get; set; }
    public DateOnly Geburtsdatum { get; set; }
}