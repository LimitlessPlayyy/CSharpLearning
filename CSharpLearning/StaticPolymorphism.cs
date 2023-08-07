using System;
namespace CSharpLearning
{
    /* Static polymorphism, also known as compile-time polymorphism or method overloading, 
     * is a type of polymorphism that occurs during the compilation phase of a program. 
     * In static polymorphism, the decision of which method to call is made by the compiler 
     * based on the number or types of arguments passed to the method.
     *
     * Method overloading allows a class to have multiple methods with the same name but different
     * parameter lists. The compiler determines which method to call based on the number and types 
     * of arguments provided during the method call.
     * 
     * Even if you have a different return type, and the arguments are the same, you cannot create
     * an overloaded method
    */
    partial class Program
    {
        static void StaticPolymorphism()
        {
            MyCalc calc = new MyCalc();
            Console.WriteLine(calc.Add("polymo", "rphism"));
            Console.WriteLine(calc.Add(1, 2));
            Console.WriteLine(calc.Add(1.1, 2.22222));

        }
    }

    public class MyCalc
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
        public string Add(string a, string b)
        {
            return String.Format(a + b);
        }
        /* this cannot work, even though the return type is different.
         * that's because the arguments are the same
        public float Add(int a, int b)
        {
            return (float)a + b;
        }
        */
    }
}

