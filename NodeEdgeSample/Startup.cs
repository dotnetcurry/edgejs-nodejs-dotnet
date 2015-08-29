using System.Threading.Tasks;

public class Startup
{
    public async Task<object> Invoke(object input)
    {
        return new Person(){
            Name="Alex",
            Occupation="Software Professional",
            Salary=10000,
            City="Tokyo"
        };
    }
}

public class Person{
    public string Name { get; set; }
    public string Occupation { get; set; }
    public double Salary { get; set; }
    public string City { get; set; }
}
