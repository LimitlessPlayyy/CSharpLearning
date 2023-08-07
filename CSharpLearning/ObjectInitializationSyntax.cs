using System;
using System.Collections.Generic;

// demonstrating Object Initialization Syntax on class objects

namespace CSharpLearning
{
    partial class Program
    {
        static void ObjectInitializationSyntax()
        {
            // make a new list of our type, and use this method to initialize the properties
            List<CoolBox> myCoolBoxes = new List<CoolBox>()
            {
                // notice this is different than a constructor, and is used to set values without
                //    explicitly calling constructors
                // notice the curly brackets.
                new CoolBox { Size = 3f, Color = "blue" },
                new CoolBox { Size = 1.1f, Color = "green"},
                new CoolBox { Size = 7.2f, Color = "yellow"}
            };

            // another object and the initialization of the properties
            CoolBox theBestCoolBox = new CoolBox { Size = 6f, Color = "white" };
        }   
    }

    // simple custom type with 2 getsetters, 2 properties
    public class CoolBox
    {
        public float Size { get; set; }
        public string Color { get; set; }
    }

}

