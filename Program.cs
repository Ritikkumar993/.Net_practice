using System;
using System.Collections.Frozen;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Security.Cryptography;
using HelloWorldApp;
using Microsoft.VisualBasic;
//internal 
//internal protected
class HelloWorld
{
    public static void Main()
    {
        // Console.WriteLine("Hello World");
        // Console.ReadLine();

        //variables 

        // Employee employee=new Employee();
        // employee.AcceptDetails();
        // employee.DisplayDetails();

        // Calculator cal = new Calculator();
        // cal.Add();
        // cal.Sub();
        // cal.Multiply();
        // cal.Divide();

        // Practice practice = new Practice();
        // practice.display();

        // Questions questions = new Questions();
        // questions.solve();

        // Conditions conditions = new Conditions();
        // conditions.solve();

        // Game game = new Game();
        // game.play();
        // game.fci();

        // Fci fci = new Fci();
        // fci.play();
        // fci.fci();

        // BankAccount acc1= new BankAccount();
        // acc1.AccNum=101;
        // acc1.Deposit(4000);
       
        // Console.WriteLine(acc1.AccNum);
    
        

        // Employees ep1= new Employees();
        // ep1.Name="Ritik";
        // ep1.salary=1000000;
        // ep1.DisplayDetails();
        // ep1.person(age:21,Name:"Ritik", city:"Chd");
        // ep1.namearr("Ritik");
        


        //wallet
        // Wallet wt1= new Wallet();
        // wt1.AddMoney(500);
        // Console.WriteLine(wt1.getbalance());

        //MathOps
        // MathOps mt=new MathOps();
        // Console.WriteLine(MathOps.add(1,2));
        // Console.WriteLine(MathOps.add(1.1,2));
        // Console.WriteLine(MathOps.add(1.1,2.2));

        // Console.WriteLine(mt.add(1,3));
        // int[] arr={1,2,3,4,5,6};
        // mt.sum(arr);
        // mt.sum(1,2,3,4);
        // int x=10;
        // mt.Increasebyten(ref  x);
        // mt.display(x);
        // mt.Process();

        //ref, prams, out, in
        // int q, r; 
        // Cal.Divide(10, 3, out q, out r);

        // Console.WriteLine("Quotient = " + q);
        // Console.WriteLine("Remainder = " + r);

        // int num = 50;
        // Cal.Calculator();
        // Cal.Lambda();

        // BankAccounts b1=new BankAccounts();




        Console.WriteLine("Assignment");
        Console.WriteLine("Welcome to Banking Services");
        Console.Write("Enter Account Number: ");
        int accountNumber;
        while(!int.TryParse(Console.ReadLine(), out accountNumber))
        {
            Console.Write("Invalid Account Number, Please Enter Correct Account Number: ");
        }

        Console.WriteLine("Enter Initial Balance: ");
        double initialBalance;
        while(!double.TryParse(Console.ReadLine(), out initialBalance))
        {
            Console.Write("Invalid input!, Enter Valid Balance: ");
        }

        BankAccounts account1 = new BankAccounts(accountNumber, initialBalance);

        int choice = 0;
        while(choice != 4)
        {
            Console.WriteLine("Choose: \n1. Deposit. \n2. Withdraw. \n3.Display Details. \n4. Exit");
            Console.Write("Choice: ");
            while(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid Input!, Enter Valid choice: ");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Enter Deposit Amount: ");
                        double depositAmount;
                        if(double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            account1.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Deposit Amount!");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter Withdraw Amount: ");
                        double withdrawAmount;
                        if(double.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            if(account1.Withdraw(withdrawAmount, out string msg))
                            {
                                Console.WriteLine(msg);
                            }
                            else
                            {
                                Console.WriteLine(msg);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Withdraw Amount!");
                        }
                        break;
                    }
                case 3:
                    {
                        account1.Display();
                        break;
                    }
                case 4:
                    {
                        break;
                    }
            }
        }


                

            }
        }