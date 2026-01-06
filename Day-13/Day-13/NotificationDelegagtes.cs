delegate void OrderDelegate(string id);

class NotificationServiec
{
    public void sendEmail(string id)
    {
        Console.WriteLine("Email sent for order id is "+id);
    }
    public void sendSms(string id)
    {
        Console.WriteLine("Sms sent for order id is "+id);
    }
}