namespace WebApplication3.Models;

public class Birth
{
    public String? Name { get; set; }
    public TimeSpan? Data { get; set; }
    public double? Y { get; set; }

    
    
    public int Calculate()
    {
        
        Data = DateTime.Now - Data;
        return 0;
        
    }

}