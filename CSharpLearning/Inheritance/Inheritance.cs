using System;
namespace CSharpLearning
{
	partial class Program
	{
		// ----- demonstrate inheritance hierarcy and abstract classes
		static void AbstractClassesAndInheritance()
		{ 
			// create instances of the shapes
			Rectangle rect = new Rectangle(5, 10);
			Circle circ = new Circle(3.5);
			Square sq = new Square(1.1);

			// test the override method
			Console.WriteLine(rect.Area());

			// Use Polymorphism to create an array of Shapes
			// and call those methods for each of those shapes
			Shape[] myShapes = new Shape[3];
			myShapes[0] = rect;
			myShapes[1] = circ;
			myShapes[2] = sq;

			// using a foreach loop to iterate through that array
			foreach (Shape myShape in myShapes)
			{
				Console.WriteLine("Area: {0}, Perimeter: {1}", myShape.Area(), myShape.Perimeter());
			}
		}

		// ----- demonstrate base and keywords in method overriding
		static void BaseAndNewKeywordPractice()
		{
			// creating instances of the class to test overriding and
			// the new keyword
			Cat fluffy = new Cat();
			Dog bob = new Dog();
			fluffy.MakeSound();
			bob.MakeSound();

			// using polymorphism, we demonstrate that the new keyword
			// hides the base method, and thus bobby will not "Woof"
			Animal fatty = new Cat();
            // polymorphism doesn't apply, since cat uses the new keyword on the method
            fatty.MakeSound(); 

			// polymorphism does apply, because the Dog class overrides the method MakeSound()
			// rather than hiding it with the new keyword
			Animal bobby = (Animal)bob;
			bobby.MakeSound();
		}

		// ---- demonstrate the classes, and inheritance
		/* disabled because of multiple Shape classes
		static void InheritancePractice1()
		{
			Shape[] myShapes = new Shape[3]; // an array to hold our shapes. demonstrates polymorhpism
            myShapes[0] = new Circle("little circle", 1.2);
            myShapes[1]  = new Circle("big circle", 5.5);
            myShapes[2] = new Rectangle("2x4 rectangle", 2, 4);

			// iterate through the shapes and print their info
			foreach (Shape myShape in myShapes) 
			{
				myShape.PrintInfo();
			}

        }
		*/
	}

    #region Inheritance hierarchy and Abstract classes
	// ** this also includes sealed classes and methods.
	// the abstract class with abstract methods
	public abstract class Shape
	{
		protected const double minValue = 0.1;

		public abstract double Area();
		public abstract double Perimeter();
	}
	// the derived classes - first level
	public class Rectangle : Shape
	{
		// i chose not to go with Properties, because I was tired and wanted to short-cut
		// so i went with protected Fields, and the constructor as the initial "setter" with
		// contingencies in place to make sure we have appropriate values
		protected double width;
		protected double height;

		public Rectangle(double aWidth, double aHeight)
		{
			width = aWidth >= minValue ? width = aWidth : width = minValue;
			height = aWidth >= minValue ? height = aWidth : height = minValue;
		}
		// sealed: so no class that inherits can override Area()
		public sealed override double Area()
		{
			return width * height;
		}
		public override double Perimeter()
		{
			return 2 * (width + height);
		}
	}
	// make this a sealed class, so no other class can inherit from it
	public sealed class Circle : Shape
	{
		double radius;

		public Circle(double aRadius)
		{
			radius = aRadius >= minValue ? radius = aRadius : radius = minValue;
		}
		public override double Area()
		{
			return Math.PI * Math.Pow(radius, 2);
		}
		public override double Perimeter()
		{
			return 2 * Math.PI * radius;
		}
	}
	// a second level of inheritance
	// this is also made a sealed class, so no class can inherit from it
	public sealed class Square : Rectangle
	{
		protected double side;

		public Square(double aSide) : base(aSide, aSide)
		{
            side = aSide >= minValue ? side = aSide : side = minValue;
			// since a square has equal sides...
			width = side;
			height = side;
        }
	}

    /* ChatGPT assignment additional CHALLENGE:
	Implement additional shapes, such as Triangle, Ellipse, or Pentagon,
	as new classes derived from the Shape class.
	Provide appropriate properties and override the abstract methods to
	calculate the area and perimeter for each shape.
	*/
	// implementation if i do it ....

    #endregion

    #region Base and New Keywords in Method Overriding
    // base class
    public class Animal
	{
		public virtual void MakeSound()
		{
			Console.WriteLine("Animal sound:");
		}
	}
	// derived classes
	public class Dog : Animal
	{
        public override void MakeSound()
        {
            base.MakeSound();
			Console.WriteLine("Woof");
        }
    }
	public class Cat : Animal
	{
		public new void MakeSound()
		{
			Console.WriteLine("Meow");
        }
	}
    #endregion

    #region Inheritance lesson basics
	/*
    // "This assignment will help you solidify your understanding of
    // basic inheritance concepts, constructors, method overriding,
    // and polymorphism" - ChatGPT

    // Shape, Base Class
    public class Shape
	{
		string name;

		public Shape(string aName)
		{
			Name = aName;
		}

		public string Name
		{
			get { return name; }
			set { name = value;  }
		}

		public virtual void PrintInfo()
		{
			Console.WriteLine("Name of the shape: {0}", Name);
		}

		protected virtual void CalculateShape()
		{ }
	

	}

	// Derived Class
	public class Circle : Shape
	{
		double radius;
		double circumference;
		double area;
		double minRadius = 0.1;

		
		public Circle (string aName, double aRadius) : base (aName)
		{
			Radius = aRadius;
			CalculateShape();
		}

		public double Radius
		{
			get { return radius;  }
			set { radius = value >= minRadius ? value : minRadius; }
		}

		public double Circumference
		{
			get { return circumference; }
		}
		public double Area
		{
			get { return area;  }
		}

		protected override void CalculateShape()
		{
			area = Math.Pow((Math.PI * radius), 2);
			circumference = 2 * Math.PI * radius;
		}

        public override void PrintInfo()
		{
			base.PrintInfo();
            Console.WriteLine("radius: {0}, circumference: {1}, area: {2}", radius, area, circumference);
        }

    }

	// Derived Class
	public class Rectangle : Shape
	{
		double length, width;
		double area;
		double minValue = 0.1;

		public Rectangle (string aName, double aLength, double aWidth) : base (aName)
		{
			Name = aName;
			length = aLength;
			width = aWidth;
			CalculateShape();
		}

		public double Length
		{
			get { return length;  }
			set { length = value >= minValue ? value : minValue; }
		}
        public double Width
        {
            get { return width; }
            set { width = value >= minValue ? value : minValue; }
        }
		public double Area
		{
			get { return area; }
		}

        protected override void CalculateShape()
        {
			area = length * width;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
			Console.WriteLine("length: {0}, width: {1}, area: {2}", length, width, area);
        }
    }
	*/
    #endregion


}


