
using System.Data;
using System.Runtime.CompilerServices;

namespace HelloWorldApp
{
    class Fci
    {
        public void play()
        {
            Console.WriteLine("GAME BEGINS");
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"player killed e{i}");
                if(i==4)
                {
                    Console.WriteLine($"e{i} is invisible skipping e{i}");

                }
            }
            Console.WriteLine("GAME END");
            
        }

        public void fci()
        {
            bool check=true;
            while (check)
            {
                //CREDIT
                Console.WriteLine("1.Credit");

                //DEBIT
                Console.WriteLine("2.Debit");

                // Income Tax Calculation
                Console.WriteLine("3.Income Tax Calculation");

                // Exit Program
                Console.WriteLine("4.Exit Program");
                int val=Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        
                        Credit.menu();
                        break;
                    case 2:
                        Debit.menu();
                        break;
                    case 3:
                        Console.WriteLine("Enter your anual income to calculate tax");
                        int anualincome=Convert.ToInt32(Console.ReadLine());
                       
                        if (anualincome <= 250000)
                        {
                            int tax1=0;
                            Console.WriteLine($"Your calculated tax is:{tax1}");
                        }
                        else if(anualincome > 250000 && anualincome<=500000)
                        {
                            int tax2=anualincome*5/100;
                            Console.WriteLine($"Your calculated tax is:{tax2}");
                        }
                        else if(anualincome>500000 && anualincome<=100000)
                        {
                            int tax3=anualincome*20/100;
                            Console.WriteLine($"Your calculated tax is:{tax3}");
                        }
                        else
                        {
                            int tax4=anualincome*30/100;
                            Console.WriteLine($"Your calculated tax is:{tax4}");
                        }
                        break;
                    case 4:
                        check=false;
                        break;
                    default:
                        Console.WriteLine("you intered invalid options");
                        break;
                }
            }
        }
    }
}