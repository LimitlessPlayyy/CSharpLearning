using System;
// to demonstrate the namespaces defined in VariousNamespaces.cs

// to make sure we can access this namespace, and the namespace nested within
using MyNamespace1;
using MyNamespace1.NestedNamespace;

// notice we haven't used 'using MyNamespace2 etc...'

namespace CSharpLearning   // we need this so our Program.cs can access this as its partial class implementation.
{
    partial class Program
    {
        static void TestNamespaces()
        {
            // since we used the 'using' directive, we don't need to specify the namespace
            AClassWithThisName classInNamespace1 = new AClassWithThisName();
            classInNamespace1.Test();

            // this is our from our nested namespace in MyNameSpace1.
            //   since we used the 'using' directive, we don't need to specify the namespaces
            LetsTestThisNestedNamespace classInNestedNamespace =
                 new LetsTestThisNestedNamespace();
            classInNestedNamespace.Test();

            // here we disambiguate the other class AClassWithThisName in MyNamespace2, with the dot '.' keyword
            // since we didn't use the 'using' directive for MyNamespace2, we need to specify it
            MyNamespace2.AClassWithThisName classInNamespace2 = new MyNamespace2.AClassWithThisName();
            classInNamespace2.Test();

            // this is from our second nested namepsace in MyNamespace2
            // we need to, again, specify the namespace using the '.' keyword, since we didn't use tse 'using' direction
            //   for this namespace
            MyNamespace2.NestedNamespace.LetsTestThisNestedNamespace classInNestedNamespace2 =
                new MyNamespace2.NestedNamespace.LetsTestThisNestedNamespace();
            classInNestedNamespace2.Test();

        }
    }
}

