using System;
using System.Data.SqlTypes;
using System.Reflection;

namespace CSharpLearning
{
    // Apply what i have learned about Interfaces, Inheritance and Polymorphism
    partial class Program
    {
        static void InterfaceBasics()
        {
            List<IInfoAsString> listOfObjects = new List<IInfoAsString>() ;
            listOfObjects.Add(new Phone("iPhone", 128f));
            listOfObjects.Add(new BagOfFries("Curly"));
            listOfObjects.Add(new City("Toronto", "Canada", 123987));
            listOfObjects.Add(new SatelitePhone("SpaceCat", 1000, 9999));

            foreach (IInfoAsString objectsToGetInfoFrom in listOfObjects)
            {
                Console.WriteLine(objectsToGetInfoFrom.InfoAsString());
            }
        }
    }

    // an interface example
    // it is supposed to be a utility to give custom information about the class
    public interface IInfoAsString
    {
        public string InfoAsString();
    }

    // 3 classes that may not have anything to do with each other, but all implement our interface.
    public class Phone : IInfoAsString
    {
        protected string model;
        protected float storageSpace;

        public Phone (string model, float storageSpace)
        {
            this.model = model;
            this.storageSpace = storageSpace;
        }

        // implementation of the interface 
        public virtual string InfoAsString()
        {
            return string.Format("A Phone! Model: {0}, with {1} storage space", model, storageSpace);
        }
    }
    // a class that inherits from Phone, also inherits the interface
    public class SatelitePhone : Phone
    {
        float range;

        public SatelitePhone(string model, float storageSpace, float range) : base (model, storageSpace)
        {
            this.range = range;
        }

        // implements the interface, and overrides the base classes implementation
        public override string InfoAsString()
        {
            return string.Format("A Satelite Phone! Model: {0}, with {1} storage space and {2} range!", model, storageSpace, range);
        }
    }

    public class BagOfFries : IInfoAsString
    {
        string name = "fries";

        public BagOfFries(string typeOfFries)
        {
            name = typeOfFries + " " + name;
        }

        // implementation of the interface
        public string InfoAsString()
        {
            return string.Format("I am a bag of " + name);
        }
    }

    public class City : IInfoAsString
    {
        string country;
        string name;
        int population;

        public City (string country, string name, int population)
        {
            this.country = country;
            this.name = name;
            this.population = population;
        }

        // implementation of the interface 
        public string InfoAsString()
        {
            return string.Format("I am a city named: {0} in the country of {1}, with a population of {2}", name, country, population);
        }
    }
}

