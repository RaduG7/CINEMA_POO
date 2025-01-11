namespace Proiect_Cinema;

public class Movie
{
    private string _name; 
    private int _duration; /*min*/
    private string _movieDescription;
    private List<DateTime> _dataDeAfisare=new List<DateTime>();

    public Movie( string name, int duration, string movieDescription )
    {
        _name = name;
        _duration = duration;
        _movieDescription = movieDescription;
    }

    public void MakeDate(int year, int month, int day,int hour, int minute)
    {
        DateTime date = new DateTime(year, month, day, hour, minute,0);
        _dataDeAfisare.Add(date);
    }
}