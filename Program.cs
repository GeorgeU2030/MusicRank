using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Project;
internal class Program
{

    public static ArrayList arrSingers = new ArrayList();

    public static ArrayList arrSongs = new ArrayList();

    public class MyComparerRanking:IComparer{
        int IComparer.Compare(object? x, object? y){

            Songer w = (Songer) x!;
            Songer z = (Songer) y!;
            return z.Points.CompareTo(w.Points);
        }
    }
    public class MyComparerAwards:IComparer{
        int IComparer.Compare(object? x, object? y){

            Songer w = (Songer) x!;
            Songer z = (Songer) y!;
            return z.Awards.CompareTo(w.Awards);
        }
    }

    private static void Main(string[] args)
    {

       chargeTO();
       chargeTOA();
        
        int option = -1;
        do
        {
            option = menu();
            selection(option);
        } while (option != 0);

        saveTO();
        saveTOA();

        Console.WriteLine("EXIT SUCESSFUL");
    }


    static void saveTO(){
       var arrayJson = arrSingers;
       string jsonString = JsonSerializer.Serialize(arrayJson);  
       File.WriteAllText("listSingers.txt",jsonString);     
    }
    static void saveTOA(){
       var arrayJson = arrSongs;
       string jsonString = JsonSerializer.Serialize(arrayJson);  
       File.WriteAllText("listSongs.txt",jsonString);     
    }
    static void chargeTO(){
        string miJson = File.ReadAllText("listSingers.txt");
        var listsongers = JsonSerializer.Deserialize<List<Songer>>(miJson)!;
        if(listsongers!=null){
            foreach(Songer s in listsongers){
                arrSingers.Add(s);
            }
        }
    }
     static void chargeTOA(){
        string miJson = File.ReadAllText("listSongs.txt");
        var listsongs = JsonSerializer.Deserialize<List<Song>>(miJson)!;
        if(listsongs!=null){
            foreach(Song s in listsongs){
                arrSongs.Add(s);
            }
        }
    }
    //menu
    static int menu()
    {
        Console.WriteLine(" {0, 35:f5}", "Menu\n");
        Console.WriteLine("1.Add Week Song");
        Console.WriteLine("2.Add Points Singer");
        Console.WriteLine("3.Look Ranking");
        Console.WriteLine("4.Look Awards");
        Console.WriteLine("5.Look Songs");
        Console.WriteLine("6.Edit a Singer");
        Console.WriteLine("0.Exit");
        int option = 0;
        option = int.Parse(Console.ReadLine()!);
        return option;
    }


    // add a New Song
    public static void addNewSong()
    {
        string nameSong = "";
        string nameSonger = "";
        string nameSongerR="";
        string country = "";
        ArrayList songercurrent = new ArrayList();
        bool exists = false;
        Console.WriteLine("Enter the name of the song");
        nameSong = Console.ReadLine()!;
        Console.WriteLine("Enter the number of the singers");
        int numSing = int.Parse(Console.ReadLine()!);
        while(numSing>0){
        Console.WriteLine("Enter the name of the singer");
        nameSongerR = Console.ReadLine()!;
        foreach(Songer s in arrSingers){
            if(s.Name==nameSongerR){
                exists=true;
                break;
            }else{
                exists=false;
            }
        }
        if (exists==false)
        {
            Console.WriteLine("Enter the Country of the singer");
            country = Console.ReadLine()!;
            Songer songer = new Songer(nameSongerR, country);
            arrSingers.Add(songer);
            songercurrent.Add(songer);
        }else {
            foreach(Songer s in arrSingers){
                if(nameSongerR==s.Name){
                    songercurrent.Add(s);
                }
            }
        }
        nameSonger = nameSonger+nameSongerR + " ";
        addAwards(nameSongerR);
        numSing = numSing-1;
        nameSongerR="";
        exists=false;
        }
        Console.WriteLine("Enter the Week of the Song");
        string dateSong = Console.ReadLine()!;
        Console.WriteLine("Enter the class of the Song");
        Console.WriteLine("1.A+");
        Console.WriteLine("2.A");
        Console.WriteLine("3.B+");
        Console.WriteLine("4.B");
        Console.WriteLine("5.C");
        int classS = int.Parse(Console.ReadLine()!);
        switch (classS)
        {
            case 1:
                Song song1 = new Song(nameSong, nameSonger, "A+", dateSong);
                arrSongs.Add(song1);
                foreach(Songer n in songercurrent){
                addPointsSonger(n.Name, 80);
                }
                break;
            case 2:
                Song song2 = new Song(nameSong, nameSonger, "A", dateSong);
                arrSongs.Add(song2);
                foreach(Songer n in songercurrent){
                addPointsSonger(n.Name, 70);
                }
                break;
            case 3:
                Song song3 = new Song(nameSong, nameSonger, "B+", dateSong);
                arrSongs.Add(song3);
                foreach(Songer n in songercurrent){
                addPointsSonger(n.Name, 65);
                }
                break;
            case 4:
                Song song4 = new Song(nameSong, nameSonger, "B", dateSong);
                arrSongs.Add(song4);
                foreach(Songer n in songercurrent){
                addPointsSonger(n.Name, 60);
                }
                break;
            case 5:
                Song song5 = new Song(nameSong, nameSonger, "C", dateSong);
                arrSongs.Add(song5);
                foreach(Songer n in songercurrent){
                addPointsSonger(n.Name, 55);
                }
                break;
            default:
                Console.WriteLine("option no valid");
                break;
        }
    }


    //add extra points -2 option

    public static void addExtraPoints()
    {
        Console.WriteLine(" {0, 35:f5}", "Menu\n");
        Console.WriteLine("1.Add Singer Month");
        Console.WriteLine("2.Add 2nd Week Points");
        Console.WriteLine("3.Add 3rd Week Points");
        Console.WriteLine("4.Add 4th Week Points");
        Console.WriteLine("5.Add 5th or More Week Points");
        Console.WriteLine("0.Exit");
        int option = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the name of the Singer");
        string nameSinger = Console.ReadLine()!;
        switch (option)
        {
            case 1:
                addPointsSonger(nameSinger, 100);
                break;
            case 2:
                addPointsSonger(nameSinger, 20);
                break;
            case 3:
                addPointsSonger(nameSinger, 30);
                break;
            case 4:
                addPointsSonger(nameSinger, 40);
                break;
            case 5:
                addPointsSonger(nameSinger, 50);
                break;
        }
    }

    //look Ranking Singers

    public static void lookRanking(){
        arrSingers.Sort(new MyComparerRanking());
        
        Console.WriteLine("\n"+ "{0, 35:f5}", "RANKING\n");
        int i=1;
        foreach(Songer s in arrSingers){
              if(s.Name!=""){
        Console.WriteLine("{0, -2} {1, -30} {2, -7} {3, -10}",i,s.Name,s.Country,s.Points);
        i++;
              }
        }
        Console.WriteLine("\n");
    }

    //look Awards Singers
    public static void lookAwards(){
        
        
        arrSingers.Sort(new MyComparerAwards());
         Console.WriteLine("\n"+ "{0, 35:f5}", "AWARDS\n");
        foreach(Songer s in arrSingers){
              if(s.Name!=""){
        Console.WriteLine("{0, -30} {1, -10}",s.Name,"x"+s.Awards);
              }
        }
        Console.WriteLine("\n");
    }

    //look songs

    public static void lookSongs(){
         Console.WriteLine("\n"+ "{0, 35:f5}", "SONGS\n");
        foreach(Song s in arrSongs){
            if(s.Name!=""){
         Console.WriteLine("{0, -20} {1, -40} {2, -10} {3, -30}",s.Name,s.NameSonger,s.Classf,s.DateSong);
        }
        }
       // Console.WriteLine("\n");
    }

    //add awards to a singer
    public static void addAwards(string nameSonger)
    {

        foreach (Songer s in arrSingers)
        {
            if (s.Name == nameSonger)
            {
                s.Awards = s.Awards + 1;
            }
        }
    }

    //add points to a singer

    public static void addPointsSonger(string nameSonger, int points)
    {

        foreach (Songer s in arrSingers)
        {
            if (s.Name == nameSonger)
            {
                s.Points += points;
                break;
            }
        }
        
    }
  
    public static void editSinger(){
        Console.WriteLine("Enter the name of the singer");
        string nameSinger = Console.ReadLine()!;
        foreach(Songer s in arrSingers){
               if(s.Name==nameSinger){
                Console.WriteLine("Enter the new Name");
                string name=Console.ReadLine()!;
                Console.WriteLine("Enter the Country");
                string country = Console.ReadLine()!;
                s.Name=name;
                s.Country=country;
                break;
               }
        }
    }

    //selection of the menu 
    static void selection(int option)
    {
        switch (option)
        {
            case 0:
                Console.WriteLine("Byee");
                break;
            case 1:
                addNewSong();
                break;
            case 2:
                addExtraPoints();
                break;
            case 3:
                lookRanking();
                break;
            case 4:
                lookAwards();
                break;
            case 5:
                lookSongs();
                break;
            case 6:
                 editSinger();
                 break;
            default:
                Console.WriteLine("Choose an option valid");
                break;
        }
    }

}