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

    /*public void AddOrDeleteDate(DataManager dataManager)
    {
        dataManager.ModificareInterval();
    }*/
}