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
            //dataManager.AfisareMovie(movies);
            //dataManager.SaveMovieToTxt(movies);
            
            dataManager.GetSalaFromTxt(); 
            List<Sala> sali = dataManager.GetSali();
            //dataManager.AfisareSala(sali);
            //dataManager.SaveSalaToTxt(sali);
            
            dataManager.GetAdminFromTxt();
            List<Admin> admins = dataManager.GetAdmins();
            //dataManager.AfisareAdmin(admins);
            //dataManager.SaveAdminToTxt(admins);



            //test mai jos de adaugare film

            /*Console.WriteLine("Nume admin: ");
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

            //test mai jos de stergere film

            Console.WriteLine("Doriti sa stergeti filmul?");
            string alegere = Console.ReadLine().ToLower();
            if(alegere == "da")
            {
                admin.RemoveMovie(dataManager, movies);
                dataManager.SaveMovieToTxt(movies);
                Console.WriteLine("Filmul a fost sters cu succes!\nFilmele curente sunt: ");
                dataManager.AfisareMovie(movies);
            }
            else
            {
                Console.WriteLine("Nu s-a sters niciun film de la rulare.");
            }



            //test mai jos de modificare data
            Console.WriteLine("Doriti modificarea unui interval de rulare?");
            string optiune = Console.ReadLine().ToLower();
            if(optiune == "da")
            {
                admin.AddOrDeleteDate(dataManager, movies);
                dataManager.SaveMovieToTxt(movies);
                Console.WriteLine("Modificarile au fost salvate cu succes!");
            }
            else
            {
                Console.WriteLine("Nu s-a produs nicio modificare.");
            }


            //test mai jos de modificare locuri
            Console.WriteLine("Doriti sa modificati locurile unei sali?");
            string optiune2 = Console.ReadLine().ToLower();
            if(optiune2 == "da")
            {
                admin.ModifySeats(dataManager);
                dataManager.SaveSalaToTxt(sali);
                Console.WriteLine("Modificarile au fost salvate cu succes!");
            }
            else
            {
                Console.WriteLine("Nu s-a produs nicio modificare.");
            }*/


            //test pentru vizualizare filme UTILIZATOR + daca doreste sa vada detaliile unui film

            Utilizator utilizator = new Utilizator();
            Console.WriteLine("Numele va rog: ");
            string numeUtilizator = Console.ReadLine();
            Console.WriteLine("Doriti sa vedeti filmele?");
            string optiune3 = Console.ReadLine().ToLower();
            if(optiune3 == "da")
            {
                utilizator.ViewMovieList(dataManager);
            }
            else
            {
                Console.WriteLine("Nu s-a afisat niciun film.");
            }

            //test pentru cautare film dupa data UTILIZATOR

            Console.WriteLine("Doriti sa cautati un film dupa data?");
            string optiune4 = Console.ReadLine().ToLower();
            if(optiune4 == "da")
            {
                utilizator.SearchMovieByDate(dataManager);
            }
            else
            {
                Console.WriteLine("Nu s-a gasit niciun film.");
            }

            //test pentru cautare film dupa titlu UTILIZATOR
            Console.WriteLine("Doriti sa cautati un film dupa titlu?");
            string optiune5 = Console.ReadLine().ToLower();
            if(optiune5 == "da")
            {
                utilizator.SearchMovieByTitle(dataManager);
            }
            else
            {
                Console.WriteLine("Nu s-a gasit niciun film dupa acest nume.");
            }

            //test pentru rezervare la un film UTILIZATOR --- trebuie finalizata, numarul de locuri luate pe film si update la cate locuri sunt luate, selectia datei de rezervare daca sunt mai multe filme cu acelasi nume

            Console.WriteLine("Doriti sa rezervati loc/locuri la un film? (Maxim intre 1-5 locuri)");
            string optiune6 = Console.ReadLine().ToLower();
            if(optiune6 == "da")
            {
                utilizator.SeatReservation(dataManager);
            }
            else
            {
                Console.WriteLine("Nu s-a facut nicio rezervare.");
            }
        }
    
    }   
}