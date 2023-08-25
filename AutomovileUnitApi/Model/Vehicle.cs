namespace AutomovileUnitApi.Model;

public class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Band { get; set; }
    public string Color { get; set; }
    public double Prize { get; set; }
    
    public string Rental_Start_Date { get; set; }
    
    public string Date_End_Rental { get; set; }
}