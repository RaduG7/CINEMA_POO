namespace Proiect_Cinema;

public class Main
{
    class Program
    {
        static void Main(string[] args)
        { 
            DataManager dataManager = new DataManager();
            dataManager.GetMoviesFromTxt();
            Console.Write("haha");
        }
    
    }   
}