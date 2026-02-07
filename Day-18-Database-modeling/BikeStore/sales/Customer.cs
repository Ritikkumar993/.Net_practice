
class Customer
{
    public int CustomerId{ get; set; }
    public string FirstName{ get; set; } 
    public string LastName{ get; set; } 
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string City {get; set; }
    public string State {get; set; }
    public string zip_code{ get; set; }


     public List<Order> Orders {get; set;} =new List<Order>();
}

