namespace Project{

    public class Songer
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Points { get; set; }

    public int Awards {get; set;}

   
   public Songer(string name, string country)
{
    this.Name = name;
    this.Country = country;
    this.Points =0;
    this.Awards =0;
}

}
}