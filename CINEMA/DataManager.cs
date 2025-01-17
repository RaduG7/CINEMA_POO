﻿using System.Globalization;

namespace Proiect_Cinema;

//Se ocupa cu gestionarea conexiunii dintre fisier txt si datele din program
public class DataManager
{
    private List<Movie> _movies = new List<Movie>();
    private List<Sala> _sali = new List<Sala>();
    private List<Admin> _admins = new List<Admin>();

    public void GetMoviesFromTxt()  //prioritate: 1
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Movie.txt";
        string filePath = Path.Combine(currentDirectory, fileName);

        //citirea datelor din fisier (ordinea lor este NUME, DURATA, DESCRIERE, urmate de AN/LUNA/ZI ORA MINUT)
        using (StreamReader f = new StreamReader(filePath))
        {

            bool ok = true;
            string line = "";
            string name;
            int duration;
            string description;
            while (!f.EndOfStream)
            {
                name = f.ReadLine();
                duration = int.Parse(f.ReadLine());
                description = f.ReadLine();
                Movie m = new Movie(name, duration, description);
                ok = true;
                while (ok)
                {

                    line = f.ReadLine();

                    //convertirea datelor la tipul de data DataTime
                    if (line != ".")
                    {
                        int year = int.Parse(line);
                        line = f.ReadLine();
                        int month = int.Parse(line);
                        line = f.ReadLine();
                        int day = int.Parse(line);
                        line = f.ReadLine();
                        int hour = int.Parse(line);
                        line = f.ReadLine();
                        int minute = int.Parse(line);
                        m.MakeDate(year, month, day, hour, minute);
                        line = f.ReadLine();
                        int takenseats = int.Parse(line);
                        m.AddTakenSeat(takenseats);
                        line = f.ReadLine();
                        int sala =int.Parse(line);
                        m.AddSala(sala);
                    }
                    else
                    {
                        ok = false;
                    }

                }

                _movies.Add(m);
            }
        }
    }

    public void AfisareMovie(List<Movie> movie)
    {
        foreach (Movie m in movie)
        {
            m.AfisareMovie();
        }
    }

    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public void SaveMovieToTxt(List<Movie> movies)
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Movie.txt";
        string filePath = Path.Combine(currentDirectory, fileName);

        using (StreamWriter f = new StreamWriter(filePath))
        {
            foreach (Movie m in _movies)
            {
                f.WriteLine(m.GetName());
                f.WriteLine(m.GetDuration());
                f.WriteLine(m.GetMovieDescription());
                var dateList = m.GetDataDeAfisare();
                var takenseats = m.GetTakenSeats();
                var sala = m.GetSala();
                int i = 0;
                for (i = 0; i < dateList.Count; i++)
                {
                    f.WriteLine(dateList[i].Year);
                    f.WriteLine(dateList[i].Month);
                    f.WriteLine(dateList[i].Day);
                    f.WriteLine(dateList[i].Hour);
                    f.WriteLine(dateList[i].Minute);
                    f.WriteLine(takenseats[i]);
                    f.WriteLine(sala[i]);
                }
                f.WriteLine(".");
            }
        }

    }

    public void GetSalaFromTxt()
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Sala.txt";
        string filePath = Path.Combine(currentDirectory, fileName);

        using (StreamReader f = new StreamReader(filePath))
        {
            bool available, ok = true;
            while (!f.EndOfStream)
            {
                int idSala = int.Parse(f.ReadLine());
                int numberOfSeats = int.Parse(f.ReadLine());
                Sala sala = new Sala(numberOfSeats, idSala);
                ok = true;
                while (ok)
                {
                    string line = f.ReadLine();
                    if (line != ".")
                    {
                        foreach (Movie m in _movies)
                        {
                            if (line == m.GetName())
                            {
                                sala.AddMovie(m);
                            }
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                _sali.Add(sala);
            }
        }
    }

    public void AfisareSala(List<Sala> sali)
    {
        foreach (Sala sala in sali)
        {
            sala.AfisareSala();
        }
    }

    public void SaveSalaToTxt(List<Sala> sali)
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Sala.txt";
        string filePath = Path.Combine(currentDirectory, fileName);
        using (StreamWriter f = new StreamWriter(filePath, false))
        {
            foreach (Sala sala in _sali)
            {
                f.WriteLine(sala.GetIdSala());
                f.WriteLine(sala.GetNumberOfSeats());
                List<Movie> movies = sala.GetMovies();
                foreach (Movie m in movies)
                {
                    f.WriteLine(m.GetName());
                }
                f.WriteLine(".");
            }
        }
    }

    public List<Sala> GetSali()
    {
        return _sali;
    }

    public void GetAdminFromTxt()
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Admin.txt";
        string filePath = Path.Combine(currentDirectory, fileName);
        using (StreamReader f = new StreamReader(filePath))
        {
            while (!f.EndOfStream)
            {
                string name = f.ReadLine();
                string password = f.ReadLine();
                Admin admin = new Admin(name, password);
                _admins.Add(admin);
            }
        }
    }

    public void SaveAdminToTxt()
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Admin.txt";
        string filePath = Path.Combine(currentDirectory, fileName);
        using (StreamWriter f = new StreamWriter(filePath))
        {
            foreach (Admin admin in _admins)
            {
                f.WriteLine(admin.GetName());
                f.WriteLine(admin.GetPassword());
            }
        }
    }

    public void AfisareAdmin(List<Admin> admins)
    {
        foreach (Admin admin in admins)
        {
            Console.WriteLine(admin);
        }
    }

    public List<Admin> GetAdmins()
    {
        return _admins;
    }
    // PENTRU ADMIN DE AICI IN JOS
    public void AdaugareMovie(int id, string name, int duration, string description, int year, int month, int day, int hour, int minute, List<Sala>sali)
    {
        int locuri = 0;
        Movie film = new Movie(name, duration, description);
        film.MakeDate(year, month, day, hour, minute);
        film.AddTakenSeat(locuri);
        film.AddSala(id);
        _movies.Add(film);
        foreach(Sala sala in sali)
        {
            if (sala.GetIdSala() == id)
                sala.AddMovie(film);
        }
    }

    public void StergereMovie(string selectedmovie, List<Sala>sali)
    {
        foreach(Movie movie in _movies)
        {
            if (movie.GetName() == selectedmovie)
            {
                _movies.Remove(movie);
                break;
            }
        }
        foreach (Sala sala in sali)
        {
            foreach (Movie movie in sala.GetMovies())
            {
                if (movie.GetName() == selectedmovie)
                {
                    sala.GetMovies().Remove(movie);
                    break;
                }
            }
        }
    }

    /*public void ModificareInterval()
    {
        for (int i = 0; i < _movies.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{_movies[i].GetName()}");
        }

        Console.WriteLine("Introduceti numarul filmului pe care doriti sa il modificati:");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= _movies.Count)
        {
            Console.WriteLine("Nu ati selectat corect filmul, incercati din nou.");
            return;
        }

        Movie filmAles = _movies[index];

        Console.WriteLine($"Filmul ales este {filmAles.GetName()}\nDoriti sa adaugati sau sa stergeti interval?(adauga/sterge)");
        string optiune = Console.ReadLine()?.ToLower();

        if (optiune == "adauga")
        {
            Console.WriteLine("Introduceti data de adaugare:");
            Console.WriteLine("Anul:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Luna:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Ziua:");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Ora:");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Minutul:");
            int minute = int.Parse(Console.ReadLine());

            filmAles.MakeDate(year, month, day, hour, minute);
            Console.WriteLine("Interval adaugat cu succes!");
            int locuri = 0;
            filmAles.AddTakenSeat(locuri);
        }
        else if (optiune == "sterge")
        {
            Console.WriteLine("Date existente: ");
            for(int i=0;i<filmAles.GetDataDeAfisare().Count;i++)
            {
                Console.WriteLine($"{i + 1}.{filmAles.GetDataDeAfisare()[i].ToShortDateString()} {filmAles.GetDataDeAfisare()[i].ToShortTimeString()}");
            }   
            Console.WriteLine("Introduceti data de adaugare:");
            Console.WriteLine("Anul:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Luna:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Ziua:");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Ora:");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Minutul:");
            int minute = int.Parse(Console.ReadLine());

            DateTime data = new DateTime(year, month, day, hour, minute, 0);
            List<DateTime> date = filmAles.GetDataDeAfisare();
            List<int> locuri = filmAles.GetTakenSeats();
            for (int i = 0; i < date.Count; i++)
            {
                if (date[i] == data)
                {
                    date.RemoveAt(i);
                    locuri.RemoveAt(i);
                    Console.WriteLine("Interval sters cu succes!");
                    return;
                }
            }
            Console.WriteLine("Intervalul nu a fost gasit.");
        }
        else
        {
            Console.WriteLine("Optiunea aleasa nu este valida.");
        }

    }*/
    

    //PENTRU UTILIZATOR DE AICI IN JOS


    public void AfisareFilmeUtilizator()
    {
        Console.WriteLine("Filme ce se ruleaza: ");
        int i = 0;
        foreach(var movie in _movies)
        {
            Console.WriteLine($"{i+1}.{movie.GetName()}");
            i++;
        }
        Console.WriteLine("Doriti sa vedeti detaliile unui film? (da/nu):");
        string raspuns = Console.ReadLine().ToLower();
        if (raspuns == "da")
        {
            Console.WriteLine("Introduceti numarul filmului:");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < _movies.Count)
            {
                _movies[index].AfisareMovie();
            }
            else
            {
                Console.WriteLine("Nu ati selectat corect filmul, incercati din nou.");
                return;
            }
        }
    }


    public void CautareFilmeDupaData()
    {
        Console.WriteLine("Introduceti data la care doriti sa vedeti filmele:");
        Console.WriteLine("Anul:");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Luna:");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Ziua:");
        int day = int.Parse(Console.ReadLine());
        

        DateTime data = new DateTime(year, month, day);
        bool ok = false;
        foreach (var movie in _movies)
        {
            foreach (var date in movie.GetDataDeAfisare())
            {
                if (date.Date == data)
                {
                    Console.WriteLine($"Filmul {movie.GetName()} ruleaza la data de {data.ToShortDateString()} la ora {data.ToShortTimeString()}");
                    ok = true;
                }
            }
        }
        if (!ok)
        {
            Console.WriteLine("Nu exista filme la data introdusa.");
        }
    }

    public void CautareFilmDupaTitlu()
    {
        Console.WriteLine("Introduceti titlul filmului:");
        string titlu = Console.ReadLine();
        bool ok = false;
        foreach (var movie in _movies)
        {
            if (movie.GetName() == titlu)
            {
                movie.AfisareMovie();
                ok = true;
            }
        }
        if (!ok)
        {
            Console.WriteLine("Filmul nu a fost gasit.");
        }
    }

    public void RezervareFilm()
    {
        AfisareFilmeUtilizator();
        Console.WriteLine("Introduceti numarul filmului pe care doriti sa il vizionati:");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _movies.Count)
        {
            Movie movie = _movies[index];
            //afisare date ale filmului
            movie.AfisareDate();
            Console.WriteLine("Introduceti numarul datei la care doriti sa vizualizati filmu:");
            index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < movie.GetTakenSeats().Count)

            {
                Console.WriteLine("Introduceti numarul locuri pentru rezervare:");
                int loc = int.Parse(Console.ReadLine());
                if (loc > 0 && loc <= 5)
                {
                    movie.IncrementTakenSeat(index,loc);

                    Console.WriteLine("Locuri rezervate cu succes!");
                    
                }
                else
                {
                    Console.WriteLine("Ati depasit numarul maxim de locuri ce se pot face per rezervare.");
                }
            }
            else
            {
                Console.WriteLine("Data nu a fost gasita.");
            }
        }
        else
        {
            Console.WriteLine("Filmul nu a fost gasit.");
        }
    }
        
    
}