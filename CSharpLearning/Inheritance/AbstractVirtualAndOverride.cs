using System;
namespace CSharpLearning
{
    partial class Program
    {
        public static void AbstractVirtualAndOverride()
        {
            Pizza foodItem1 = new Pizza("Triple Cheese Pizza", 11.99);
            Spaghetti foodItem2 = new Spaghetti("Classic Spaghetti", 13.99);

            Food[] myFoods = new Food[2];
            myFoods[0] = foodItem1;
            myFoods[1] = foodItem2;
            Console.WriteLine("The food i am having is: ");
            foreach (Food myFood in myFoods)
            {
                Console.WriteLine(myFood.GetName());
            }

            foodItem1.OrderFood(3);
            foodItem2.OrderFood(2);
            foodItem2.WhatIsInTheSpaghetti();
        }
    }

    #region Abstract, Virtual and Override keywords
    // an abstract class, so it cannot be instantiated
    public abstract class Food
    {
        protected string name;
        protected double cost;

        public Food(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        // normal methods
        //   these cannot be overriden but are inherited by the inheriting classes
        public string GetName()
        {
            return name;
        }

        // abstract methods
        //     have no implementation, but a signature (return type and paramters)
        //     they must be implemented by the deriving class
        public abstract double GetCost();

        // methods marked virtual can be overriden by inheriting classes
        //    and they do have implementation
        public virtual void OrderFood(int numberOfItems)
        {
            Console.WriteLine("You placed an order for  {0} {1}s", numberOfItems, name);
            Console.WriteLine("Your total will be {0}", cost * numberOfItems);
        }
    }

    // a second abstract class in the chain - also cannot be inherited
    public abstract class FastFood : Food
    {
        public FastFood(string name, double cost) : base (name, cost)
        {
            this.name = "Fast Food: " + name;
        }
        // it does override the abstract method declared in the base abstract class though
        public override double GetCost()
        {
            // fast food is on a discount, 50% off!!
            return cost / 2;
        }
    }
    public class Pizza : FastFood
    {
        public Pizza(string name, double cost) : base (name, cost)
        {
        }

        // this is a second in the chain override from the Food base class
        public override double GetCost()
        {
            // pizza is a further 10% off, off of the %50 off already on fast food
            //   here we use the base.GetCost() from FastFood and we extend its' functionality
            double fastFoodBaseCost = base.GetCost() * 0.9;
            return fastFoodBaseCost;
        }

        public override void OrderFood(int numberOfItems)
        {
            base.OrderFood(numberOfItems);
            Console.WriteLine("Please enjoy your pizza! And the 50% off for fastfood, and further 10% off for pizza!");
        }
    }
    public class Spaghetti : Food
    {
        public Spaghetti(string name, double cost) : base(name, cost)
        {
            this.name = "Mr. Italiono Chef Presents: " + name;
        }

        // overriding the abstract method with implementation
        public override double GetCost()
        {
            return cost;
        }
        // overriding the virtual method in the base class, and chaining the methods to include default implementation
        // and current classes' implementation as well
        public override void OrderFood(int numberOfItems)
        {
            base.OrderFood(numberOfItems);
            Console.WriteLine("Get ready for the best spaghetti in town!!");
        }

        // adding anothr virtual method so that any class that inherits from Spaghetti
        // can override this message, say to give a custom message about the ingredients and prep of the spaghetti.
        //   e.g. public class SpaghettiAndMeatballs {}
        public virtual void WhatIsInTheSpaghetti()
        {
            Console.WriteLine("Our classic Spaghetti is made with the finest tomato sauce, ground beef and special blend of spices!");
        }
    }
    #endregion
}

