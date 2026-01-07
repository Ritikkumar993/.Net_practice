namespace EcommerceAssessment
{
    class OrderProcessor
    {
        public event Action<string> OrderProcessed;

        public void ProcessOrder(Order order,Func<double,double> taxCalculator, Func<double,double> discountCalculator, Predicate<Order> validator, OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Failed to Validate order");
                return;
            }

            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount+ tax - discount;

            callback("Order processed successfully.");

            OrderProcessed?.Invoke("Order processed event triggred.");

        }
    }
}