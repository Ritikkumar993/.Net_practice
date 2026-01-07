namespace EcommerceAssessment
{
    class Order
    {
        public int OrderId{get;set;}
        public string CustomerName{get;set;}
        public double Amount{get;set;}

        public string ToString()
        {
            return $"OrderId ={OrderId} \nCustomer Name ={CustomerName} \nAmount = {Amount} ";

        }

        
    }
}