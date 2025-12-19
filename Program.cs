using System;
using System.Collections.Frozen;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
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

        Fci fci = new Fci();
        fci.play();
        fci.fci();

    }
}