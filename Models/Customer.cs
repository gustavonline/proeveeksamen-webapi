namespace proeveeksamen_webapi.Models;

public class Customer
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string email { get; set; }
    
    //type can be either "private" or "business"
    public string type { get; set; }
    
    
    
}