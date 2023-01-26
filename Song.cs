namespace Project{

    public class Song
{
    public string Name { get; set; }
    public string NameSonger { get; set; }
    public string Classf { get; set; }

    public string DateSong {get; set; }

   
   public Song(string name, string nameSonger,string classf, string dateSong)
{
    this.Name = name;
    this.NameSonger = nameSonger;
    this.Classf = classf;
    this.DateSong = dateSong;
}

}
}