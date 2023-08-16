using System.Diagnostics;

namespace CSharpLearning;

partial class Program
{
    static void Main(string[] args)
    {

        // The tutorial or lesson we're working on/demonstrating
        WriteToTextFile();
        ReadTextFromFile();

        Console.ReadLine();
    }

    #region CURRENT LEARNING SECTION
    #endregion


    #region LEARNING SECTIONS

    #region STRUCTS
    // ****** Structures - STRUCTS *******
    // A Struct for keeping track of Player Stats
    struct PlayerStats
    {
        // The fields representing the statistics
        string name;
        int? highestScore;
        bool hasBeatTheGame;

        // the default constructor (?)
        public PlayerStats(string aName, int? aHighestScore, bool aHasBeatTheGame)
        {
            name = aName;
            highestScore = aHighestScore;
            hasBeatTheGame = aHasBeatTheGame;
        }

        // the members of the srtuct
        public string GetPlayerStats()
        {
            // setting up compositional formatting
            string returnString = "Name: {0} Highest Score: {1}   Has Beat The Game? {2}";
            // using the string.Format() to finalize the compositional formatting
            return string.Format(returnString, Name, HighestScore, HasBeatTheGame);
        }

        // getters and setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int? HighestScore
        {
            // we used a nullable type and the null coalescing operator here
            // we use a nullable type because there can be a time where the player hasn't played
            //    then highestScore would be null
            get { return highestScore ?? 0; }  // however if this getter is called, it returns 0
            // in the set, we use a Ternary operator to shorthand and if-else condition
            set { highestScore = value >= 0 ? value : 0; }
        }

        public bool HasPlayedBefore()
        {
            // if the player hasn't played before, and the score is null, then return false
            // if the player has, and the score is anything but null, then return true
            return highestScore == null ? false : true;
        }
        public bool HasBeatTheGame
        {
            // a simple bool get and set
            get { return hasBeatTheGame; }
            // using the ternary operator here again
            set { hasBeatTheGame = value == true ? true : false; }
        }
    }

    // A method to test our Structure!
    static void Structures()
    {

        PlayerStats player1 = new PlayerStats("Ajha", 100, false);
        Console.WriteLine(player1.GetPlayerStats());

        PlayerStats player2 = new PlayerStats("Benji", null, false);
        Console.WriteLine(player2.GetPlayerStats());
        Console.WriteLine("Has " + player2.Name + " played the game before?  " +
            player2.HasPlayedBefore());
    }
    #endregion

    static void NullCoalescingOperator()
    {
        // Using the Null Coalescing Operator, so that on assignment of a value/variable to another, a default value is given to a variable
        // if the value of the variable it is assigned is null.

        // normal and nullable type of the same data type.
        // int
        int num1 = 10;
        int? num2 = null;

        // bool
        bool boolVal1 = false;
        bool? boolVal2 = new bool();    // pay attention this vs
        bool? boolVal3 = new bool?();   // this... 

        // using the Null Coalescing Operator to assign a default value IF the nullable type value is null
        // otherwise it is assigned to the value

        // if num2 == null, then num1 = 0, else num1 = num2;
        num1 = num2 ?? 0;
        Console.WriteLine(num1);

        // if boolVal2 == null, then boolVal1 = true; else boolVal1 = boolVal2
        //   in this case boolVal2 would be false by default becase = bool() was used in declaration
        boolVal1 = boolVal2 ?? true;
        Console.WriteLine(boolVal1);

        // if boolVal3 == null, then boolVal1 = true; else boolVal1 = boolVal2
        //   in this case boolVal2 would be null by default becase = bool?() was used in declaration
        //   the nullable struct new bool? or new Nullable<bool> assigns null by default
        boolVal1 = boolVal3 ?? true;
        // since boolVal3 is null, boolVal1 gets assigned true due to the coalescing operator
        Console.WriteLine(boolVal1);

        // change the value of num2
        num2 = 777;
        num1 = num2 ?? 0;
        Console.WriteLine(num1);
    }


    static void Nullables()
    {
        // Nullable types
        // For those, you can assign normal values as well as a null value type.
        //   null meaning the absence of a value

        // regular value types
        int num1 = 7;
        float fl1 = 5;

        // nullable value type
        //   ('?') needs to be used when declaring the variable.
        int? num2 = null;
        float? fl2 = new float?();

        bool? boolVal = new bool?();

        // As seen from the output, null values are expressed as a blank space when outputed
        Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, fl1, fl2);
        Console.WriteLine("A Nullable bool value: " + boolVal + ".");

        // changing the values of the nullable types
        //   notice that the ('?') symbol doesn't need to be used anymore after declaring the variable
        num2 = 10;
        fl2 = 6.66f;
        boolVal = true;

        Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, fl1, fl2);
        Console.WriteLine("A Nullable bool value: " + boolVal + ".");

        // we can assign both null and normal values to a nullable type
        num2 = null;

        Console.WriteLine("num2 is assigned null again: {0}", num2);
    }
    #endregion
}

