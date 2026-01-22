namespace PettyCash
{
    interface I1
    {
        public void m1();
        public void m2();

    }
    interface I2
    {
        public void m3();

    }
    interface I3
    {
        public void m4();
    }
    
    public class ClassA:I1, I2, I3
    {
        public void m1()
        {
            Console.WriteLine("Method m1 is called");
        }
        public void m2()
        {
            Console.WriteLine("Method m2 is called");
        }
        public void m3()
        {
            Console.WriteLine("Method m2 is called");
        }
       
        public void m4()
        {
            Console.WriteLine("Method m2 is called");
        }
        
    }

    public class ClassB: ClassA
    {
        public void Bm5new()
        {
            Console.WriteLine("Method m2 is called");
        }
    }
}


