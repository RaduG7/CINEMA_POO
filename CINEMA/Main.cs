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



            //test mai jos
            Console.WriteLine("Nume admin: ");
            string numeADMIN = Console.ReadLine();

            Admin admin = admins.FirstOrDefault(a => a.GetName() == numeADMIN);

            if (admin != null)
            {
                // Adminul adaugă un film
                Console.WriteLine($"Adminul {numeADMIN} adaugă un film:");
                admin.AddNewMovie(dataManager, movies);

                // Salvăm filmele adăugate în fișier
                dataManager.SaveMovieToTxt(movies);

                // Afișăm toate filmele
                Console.WriteLine("\nFilmele curente sunt:");
                dataManager.AfisareMovie(movies);
            }
            else
            {
                Console.WriteLine("Adminul nu a fost găsit.");
            }


        }
    
    }   
}