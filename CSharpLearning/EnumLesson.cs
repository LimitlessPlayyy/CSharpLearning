using System;
namespace CSharpLearning;

partial class Program
{
    // declaration of an enum can be at the leve of a namespace
    // or at the level of a class, such as here
    enum PlayerState
    {
        // An enum is a value type, of a set of named integral constants
        Idle,   // value would be 0
        Walking,  // 1 .. and it would implicitly increment for each subsequent constant
        Running,  // 2 ....
        Attacking,
        Meditating,
        Dead  // 5 
    }

    // you can specify the integral type 
    enum SwitchState: sbyte
    {
        On = 5, // you can also specify the values
        Broken, // = 6
        Off = 10,
        NotInstalled // = 11

    }

    // classic example.
    enum DaysOfTheWeek
    {
        Mon = 1,
        Tue,
        Wed,
        Thur,
        Fri,
        Sat,
        Sun
    }

    static void EnumsLesson()
    {
        // declaring an enum variable 
        PlayerState fpsPlayerState = PlayerState.Idle;

        // conversions / casting
        //   enum to int
        Console.WriteLine((int)fpsPlayerState);
        //   int to enum
        Console.WriteLine((PlayerState)(1+4));

        SwitchState myLightSwitchState = SwitchState.NotInstalled;

        // comparisons
        if (myLightSwitchState == SwitchState.NotInstalled)
        {
            Console.WriteLine("my light switch is not installed");
        }
        //   making the same comparison using a conversion of integer 11
        //      to its' corresponding SwitchState
        if (myLightSwitchState == (SwitchState)11)
        {
            Console.WriteLine("my light switch is not installed");
        }

        // Iteration through Enums

        // create an array of type System.Enum (base type)
        //    typeof() operator returns the base type of the specific Enum
        Array daysArray = Enum.GetValues(typeof(DaysOfTheWeek));

        // use a foreach loop to iterate through each day of the week
        foreach (DaysOfTheWeek day in daysArray)
        {
            Console.WriteLine("Day {0}: {1}", (int)day, day);
        }

        // ****** to practice:  parsing? ******
    }
}

