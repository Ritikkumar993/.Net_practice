class Order
{
    public int OrderId{ get; set; }
    public int CustomerId{ get; set; }
    public Customer Customer{get; set;} =null;
    
    public string OrderStatus{ get; set; }
    public DateTime OrderDate{get; set; }
    public DateTime RequiredDate{get; set; }
    public DateTime ShippedDate{ get; set; }

    public int StoreId {get; set; }
    public Store Store{get; set; }=null;

    public int StaffId {get; set; }

    public Staff Staff  {get; set;}=null;

    public List<OrderItem> OrderItems {get; set; } =new List<OrderItem>();
    
   
}