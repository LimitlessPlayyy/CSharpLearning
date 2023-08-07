using System;
namespace CSharpLearning

// Sealed classes and methods
//   when they are sealed, these classes cannot be inherited
//   when the methods are sealed, they cannot be overriden (further)

{
    partial class Program
    {
        // demonstrate sealed classes and methods
        static void SealedClassesAndMethods()
        {
            string personToGreet = "Arjuna";
            Greeter greeter = new Greeter();
            greeter.Greeting(personToGreet);

            RudeGreeter rudeGreeter = new RudeGreeter();
            rudeGreeter.Greeting(personToGreet);

            FriendlyGreeter friendlyGreeter = new FriendlyGreeter();
            friendlyGreeter.Greeting(personToGreet);

            VeryFriendlyGreeter veryFriendlyGreeter = new VeryFriendlyGreeter();
            veryFriendlyGreeter.OfferFoodAndBeverage(personToGreet);
        }
    }

    #region Sealed Classes and Methods
    // a base class
    class Greeter
    {
        public virtual void Greeting(string name)
        {
            Console.WriteLine("Hello {0}!", name);
        }
    }
    // a class that inherits from the base, but is sealed so it cannot be inherited
    sealed class RudeGreeter : Greeter
    {
        public override void Greeting(string name)
        {
            base.Greeting(name);
            Console.WriteLine("You smell and look funny!");
        }
    }
    /* This derived class cannot be created because RudeGreeter is sealed and cannot be inherited from
     class VeryRudeGreeter : RudeGreeter
    {
        public override void Greeting(string name)
        {
            // some code
        }
    }
    */

    // a class that inherits from the base but is not sealed so can be inherited
    class FriendlyGreeter : Greeter
    {
        // a method that cannot be overriden in any inherting class
        public sealed override void Greeting(string name)
        {
            base.Greeting(name);
            Console.WriteLine("It's so lovely to have you here!");
        }
    }
    // a class that inherits from the FriendlyGreeter class. it is not sealed
    class VeryFriendlyGreeter: FriendlyGreeter
    {
        /* the method Greeting() cannot be overriden because it is sealed in the base class FriendlyGreeter
        public override void Greeting(string name)
        {
            // some code
        }
        */

        // since it cannot override the Greeting() method, it can use it but must
        // extend in its own way.
        public string OfferFoodAndBeverage(string name)
        {
            Greeting(name);
            Console.Write("Is there anything you'd like to drink?: ");
            string foodAndBeverageUserWants = Console.ReadLine();
            return foodAndBeverageUserWants;
        }
    }
    #endregion
}

