namespace Proiect_Cinema;

public class Admin
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

    public override string ToString() 
    {
        return $"Nume: {_name}\nParola: {_password}\n";
    }
   
    public void AddNewMovie(DataManager dataManager, List<Movie> movies)
    {
        dataManager.AdaugareMovie(movies);
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