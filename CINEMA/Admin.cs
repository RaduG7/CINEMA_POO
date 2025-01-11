namespace Proiect_Cinema;

public class Admin :IAdmin
{
    private string _name;
    private string _password;
    
    public Admin(string name, string password)
    {
        _name = name;
        _password = password;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetPassword()
    {
        return _password;
    }

    public void AfisareAdmin()
    {
        Console.WriteLine($"Nume: {_name}");
        Console.WriteLine($"Parola: {_password}");
        Console.WriteLine();
    }
    public void AddNewMovie(int movie_id, string name, string description, int duration)
    {
        //_movies.Add();
    }

    public void DeleteMovie(string name)
    {
        throw new NotImplementedException();
    }

    public void ChangeMovieTheater(string rooms)
    {
        throw new NotImplementedException();
    }

    public void OcupiedSeats()
    {
        throw new NotImplementedException();
    }  
}