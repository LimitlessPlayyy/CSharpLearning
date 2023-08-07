using System;
namespace CSharpLearning
{
    partial class Program
    {
        // Apply our operator overloading in an example
        static void OperatorOverloading()
        {
            // create two vectors
            MyVector2D point1 = new MyVector2D(2f, 2f);
            MyVector2D point2 = new MyVector2D(2f, 2f);

            // check their equality (should be true) using our overloaded == comparison operator
            Console.WriteLine("compare point1 and point2: " + (point1 == point2));
            point2.X = 3f; // then change the value of one of them, should then print false
            Console.WriteLine("compare point1 and point2 after value change: " + (point1 == point2));

            // add the values using our overloaded '+' operator
            MyVector2D point3 = point1 + point2;
            Console.WriteLine("point1 + point2 =  point3({0}, {1})", point3.X, point3.Y) ;

        }
    }

    // let's practice Operator Overloading
    //  operator overloading let's you specify how operators behave when you apply them
    //  to objects of your custom classes
    public class MyVector2D
    {
        const float minValue = 0.01f;

        public float X { get; set; }
        public float Y { get; set; }

        public MyVector2D(float x, float y)
        {
            X = x >= minValue ? x : minValue;
            Y = y >= minValue ? y : minValue;
        }
        // this is overloading the '+' and '-' operator
        //   synatax:  public static <MyClass> operator <operator> (parameters)
        public static MyVector2D operator +(MyVector2D a, MyVector2D b)
        {
            MyVector2D resultVector2D =
                new MyVector2D(a.X + b.X, a.Y + b.Y);
            return resultVector2D;
        }
        public static MyVector2D operator -(MyVector2D a, MyVector2D b)
        {
            MyVector2D resultVector2D =
                new MyVector2D(a.X - b.X, a.Y - b.Y);
            return resultVector2D;
        }

        // this is overloading the '==' and '!=' operator
        public static bool operator ==(MyVector2D a, MyVector2D b)
        {
            bool equality = (a.X == b.X) && (a.Y == b.Y);
            return equality;
 
        }
        public static bool operator !=(MyVector2D a, MyVector2D b)
        {
            bool inequality = (a.X != b.X) || (a.Y != b.Y);
            return inequality;

        }

        // overriding the Equals method for consistency 
        public override bool Equals(object? obj)
        {
            // if the object compared is null or not of this type then return false
            if (obj == null || !(obj is MyVector2D) )
                    return false;

            // cast the object in question to a MyVector2D to compare values for equality
            MyVector2D other = (MyVector2D)obj;

            // finally, compare the other object's values with this MyVector2D object instance
            //   this utilizes our overloaded == operator!
            return this == other;
        }

        // skipped overriding GetHashCode()...
        //    it's usually recommend that we do that along with the comparison opperators

    } 

}