
// using System;
// using SmartHomeSecurity;
// delegate void PaymentDelegates(decimal amount); 

// static class PaymentExtension
// {
//     public static bool isValidPayment(this decimal amount)//extending amount to call method
//     {
//         return amount >0 && amount<=1_000_000;
//     }
// }


// delegate void ErrorDelegate(string message);


// class PaymentService
// {
//     public void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("The process amount is "+amount);
//     }
// }
// class Program
// {
    
//     public static void Main()
//     {
        
//         PaymentService service = new PaymentService();
//         //delegate store the address(refrece) of the method
//         PaymentDelegates payment = service.ProcessPayment;

//         decimal amount = 6000;
//         if (amount.isValidPayment())
//         {
//             payment(5000);                
//         }
//         else
//         {
//             Console.WriteLine("Invaild amount");
//         }

//         NotificationServiec services = new NotificationServiec();
//         OrderDelegate notify=null;
//         notify+=services.sendEmail;
//         notify+=services.sendSms;
//         notify("1234031");


//         Action<string,int> logActivity = (message,id) => Console.WriteLine("Log Entry:"+message+id);
//         logActivity("User log in at 10:10 Am",19);

//         Func<decimal,decimal,decimal> calDiscount = (price,discount) => price-(price*discount/100);
//         Console.WriteLine("Calculated Discount is "+calDiscount(1000,10));

//         //predicate delegate return bool type take one parameter
//         Predicate<int> isEligible = age => age>=18;

//         Console.WriteLine(isEligible(20));


//         //Anonymous Delegate
//         ErrorDelegate erroHandler  = delegate (string msg)
//         {
//           Console.WriteLine("Error: "+msg);  
//         };

//         erroHandler("File Not Found");


//         //event
//         Button btn = new Button();

//         //subscribe method to the event
//         btn.Clicked+=()=>Console.WriteLine("Button is clicked");
//         btn.Clicked+=()=>Console.WriteLine("triggred to notify to ");
//         btn.Clicked+=()=>Console.WriteLine("open the notifyed messg");

//         btn.Click();


//             // Objects Initialization
//             MotionSensor livingRoomSensor = new MotionSensor();
//             AlarmSystem siren = new AlarmSystem();
//             PoliceNotifier police = new PoliceNotifier();

//             // 2. INSTANTIATION & MULTICASTING
//             // We "Subscribe" different methods to the sensor's delegate
//             SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
//             panicSequence += police.CallDispatch;

//             // Linking the sequence to the sensor
//             livingRoomSensor.OnEmergency = panicSequence;
// 	        // class_object.delegate_instance = delegate_instance_multicast

//             // Simulation
//             livingRoomSensor.DetectIntruder("Main Lobby");
//     }
// }


using System;
using System.Threading;

namespace CallbackDemo
{
    // STEP 1: Define the Delegate
    public delegate void DownloadFinishedHandler(string fileName);

    class FileDownloader
    {
        // STEP 2: Method that accepts the callback
        public void DownloadFile(string name, DownloadFinishedHandler callback)
        {
            Console.WriteLine($"Starting download: {name}...");
            
            // Simulating work
            Thread.Sleep(2000); 
            
            Console.WriteLine($"{name} download complete.");

            // STEP 3: Execute the Callback
            if (callback != null)
            {
                callback(name); 
            }
        }
    }

    class Program
    {
        // STEP 4: The actual Callback Method
        static void DisplayNotification(string file)
        {
            Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        }

        static void Main()
        {
            FileDownloader downloader = new FileDownloader();

            // Pass the method 'DisplayNotification' as a callback
            downloader.DownloadFile("Presentation.pdf", DisplayNotification);

            //Comparison<T> delegates 
            Comparison<int> sortDecending = (a,b) =>b.CompareTo(a);
            Console.WriteLine(sortDecending(5,10));
            Console.WriteLine(sortDecending(10,5));
            Console.WriteLine(sortDecending(5,5));

            
            // Comparison<string> sortDecending = (a,b) =>b.CompareTo(a);
            // Console.WriteLine(sortDecending("Ritik","ritik"));
        }
    }
}

