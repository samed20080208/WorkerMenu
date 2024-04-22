namespace WpfApp4;

public class Person
{
    public string? Name{ get; set; }
    public string? Surname{ get; set; }
    public string? Gender { get; set; }
    public bool Step { get; set; }
    public string? City{ get; set; }

    public Person(string? name, string? surname, string? gender, bool step, string? city)
    {
        Name = name;
        Surname = surname;
        Gender = gender;
        Step = step;
        City = city;
    }

    public override string ToString()
    {
        return $"{Name}-{Surname}-{Gender}-{Step}-{City.ToString()}";
    }
}
