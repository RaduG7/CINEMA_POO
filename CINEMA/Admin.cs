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

    public void RemoveMovie(DataManager dataManager,List<Movie> movie)
    {
        dataManager.StergereMovie(movie);
    }

    public void AddOrDeleteDate(DataManager dataManager, List<Movie> movies)
    {
        dataManager.ModificareInterval(movies);
    }

    public void ModifySeats(DataManager dataManager)
    {
        dataManager.ModificareLocuriSala();
    }
}