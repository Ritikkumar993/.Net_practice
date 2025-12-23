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
        

        Practice practice = new Practice();
        practice.display();

        Questions questions = new Questions();
        questions.solve();

        Conditions conditions = new Conditions();
        conditions.solve();

        // Game game = new Game();
        // game.play();
        // game.fci();

        Fci fci = new Fci();
        fci.play();
        fci.fci();      
                

    }
}