class OrderItem
{
    public int OrderId { get; set; }
    public Order Order{get; set;}
    public int ItemsId {get; set; }
    public int ProductId {get; set; }
    public int Quantity {get; set; }
    public double ListPrice {get; set; }
    public double Discount {get; set; }
}