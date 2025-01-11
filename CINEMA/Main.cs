namespace Proiect_Cinema;

public class Main
{
    class Program
    {
        static void Main(string[] args)
        { 
            DataManager dataManager = new DataManager();
            
            dataManager.GetMoviesFromTxt(); 
            List<Movie> movies = dataManager.GetMovies();
            dataManager.AfisareMovie(movies);
            dataManager.SaveMovieToTxt(movies);
            
            dataManager.GetSalaFromTxt(); 
            List<Sala> sali = dataManager.GetSali();
            dataManager.AfisareSala(sali);
            dataManager.SaveSalaToTxt(sali);
            
            dataManager.GetAdminFromTxt();
            List<Admin> admins = dataManager.GetAdmins();
            dataManager.AfisareAdmin(admins);
            dataManager.SaveAdminToTxt(admins);

        }
    
    }   
}