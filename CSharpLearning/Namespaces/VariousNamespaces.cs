using System;


// the first namespace
namespace MyNamespace1
{
    // a class in this namespace
    public class AClassWithThisName
    {
        public void Test()
        {
            Console.WriteLine("I am in the first namespace");
        }
    }

    // a namespace nested within this MyNamespace1
    namespace NestedNamespace
    {
        public class LetsTestThisNestedNamespace
        {
            public void Test()
            {
                Console.WriteLine("I am in the nested namespace, within the first namespace");
            }
        }
    }
}

// the second namespace
namespace MyNamespace2
{
    // and a class with the same name as the one in the other
    public class AClassWithThisName
    {
        public void Test()
        {
            Console.WriteLine("I am in the second namespace");
            Console.WriteLine("I am a unique class even though i also have the name \"AClassWithThisName\"");
        }
    }

    // aother namespace nested within this MyNamespace2
    namespace NestedNamespace
    {
        public class LetsTestThisNestedNamespace
        {
            public void Test()
            {
                Console.WriteLine("I am in the nested namespace, within the second namespace");
            }
        }
    }
}