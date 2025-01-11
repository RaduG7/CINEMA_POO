namespace Proiect_Cinema;

public class DataManager
{
    List<Movie> _movies = new List<Movie>();
    public void GetMoviesFromTxt()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory; 
        string fileName = "Movie.txt";
        string filePath = Path.Combine(currentDirectory, fileName);

        using (StreamReader f = new StreamReader(filePath))
        {
            
            bool ok = true;
            string line="";
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
                    if(line!="")
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
}