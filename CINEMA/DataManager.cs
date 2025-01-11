﻿namespace Proiect_Cinema;

public class DataManager
{
    private List<Movie> _movies = new List<Movie>();
    private List<Sala> _sali = new List<Sala>();
    private List<Admin> _admins = new List<Admin>();

    public void GetMoviesFromTxt()/*prioritate: 1*/
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fileName = "Movie.txt";
        string filePath = Path.Combine(currentDirectory, fileName);

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
            foreach(Movie m in movies)
            {
              f.WriteLine(m.GetName());
              f.WriteLine(m.GetDuration());
              f.WriteLine(m.GetMovieDescription());
              var dateList = m.GetDataDeAfisare();
              foreach (DateTime date in dateList)
              {
                  f.WriteLine(date.Year);
                  f.WriteLine(date.Month);
                  f.WriteLine(date.Day);
                  f.WriteLine(date.Hour);
                  f.WriteLine(date.Minute);
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
            bool available,ok = true;
            while (!f.EndOfStream)
            {
                int idSala = int.Parse(f.ReadLine());
                int numberOfSeats = int.Parse(f.ReadLine());
                int takenSeats = int.Parse(f.ReadLine());
                if (takenSeats >= numberOfSeats)
                {
                    available = false;
                }
                else
                {
                    available = true;
                }
                Sala sala=new Sala(numberOfSeats,takenSeats,available,idSala);
                ok = true;
                while(ok)
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
        using (StreamWriter f = new StreamWriter(filePath))
        {
            foreach (Sala sala in sali)
            {
                f.WriteLine(sala.GetIdSala());
                f.WriteLine(sala.GetNumberOfSeats());
                f.WriteLine(sala.GetTakenSeats());
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
                Admin admin = new Admin(name,password);
                _admins.Add(admin);
            }
        }
    }

    public void SaveAdminToTxt(List<Admin> admins)
    {
        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        string fileName = "Admin.txt";
        string filePath = Path.Combine(currentDirectory, fileName);
        using (StreamWriter f = new StreamWriter(filePath))
        {
            foreach (Admin admin in admins)
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
            admin.AfisareAdmin();
        }
    }

    public List<Admin> GetAdmins()
    {
        return _admins;
    }
    
}