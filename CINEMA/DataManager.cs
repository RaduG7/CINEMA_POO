namespace Proiect_Cinema;

public class DataManager
{
    private List<Movie> _movies = new List<Movie>();

    public void GetMoviesFromTxt()
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

    public void AfisareMovie()
    {
        foreach (Movie m in _movies)
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
            while (f.EndOfStream)
            {
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

                ok = true;
                while(ok)
                {
                    string line = f.ReadLine();
                    if (line != ".")
                    {
                        //string
                    }
                }
            }
        }
    }
    
}