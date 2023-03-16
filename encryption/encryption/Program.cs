using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string IO = "";
            while (true)
            {
                Console.Write("Please select:\n1.)Encrypt\n2.)Decrypt\n3.)View previous entries / outputs\n");
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {


                    case 1:

                        bool enteredKey = false;
                        int KEY = 0;
                        string input = null;
                        string output = "";

                        while (!enteredKey)
                        {
                            Console.Write("Enter a KEY (11-99): ");
                            int check = int.Parse(Console.ReadLine());
                            if (check > 10 && check < 100)
                            {
                                KEY = check;
                                enteredKey = true;
                            }                                                                    //Check if KEY value is between 11-99
                            else
                            {
                                Console.WriteLine("Invalid input, try again...");
                                Console.ReadLine(); Console.Clear();
                            }
                        }
                        bool validString = false;
                        while(!validString)
                        {
                            Console.Write("Please enter a string: ");
                            input = Console.ReadLine();
                            if (input.Contains(","))
                            {
                                Console.WriteLine("INVALID INPUT, NO COMMAS");
                            }                                                                   //Check if string has comma
                            else
                            {
                                validString = true;
                            }
                        }
                        foreach (char c in input)
                        {
                            int ASCIIval = c;
                            ASCIIval *= 5;
                            output += ASCIIval;                                                 //Magic
                            int plusfour = ASCIIval + 4;
                            output += plusfour + "-";
                        }

                        string firstDigitOfKEY = KEY.ToString().Substring(0, 1);
                        string secondDigitOfKEY = KEY.ToString().Substring(1);                  //Place key value in front and back

                        firstDigitOfKEY += "-" + output;
                        firstDigitOfKEY += secondDigitOfKEY;                                    //Place slashes between key values
                        output = firstDigitOfKEY;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The encrypted string is: \n \n" + output);           //output
                        Console.ForegroundColor = ConsoleColor.White;
                        IO += "ENC: " + output + ",";                                           //store output in array thing
                        Console.ReadLine();
                        break;





                    case 2:
                        Console.Write("Enter the encrypted string: ");
                        string encStr = Console.ReadLine();
                        encStr = encStr.Substring(2);                                           // Remove first and last char
                        encStr = encStr.Substring(0, encStr.Length - 2);                        // Key value
                        string[] words = encStr.Split('-');
                        string unencStr = "";
                        for(int i = 0; i < words.Length; i++)
                        {
                            string firstThree = words[i].Substring(0, 3);
                            int whole = int.Parse(firstThree);
                            whole -= 4;
                            whole /= 5;                                                         //magic
                            whole += 1;
                            char c = (char)whole;
                            unencStr += c;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Unencrypted String: " + unencStr);                   //output
                        Console.ForegroundColor = ConsoleColor.White;
                        IO += "UN: " + unencStr + ",";
                        Console.ReadLine();
                        break;





                    case 3:
                        string[] allIO = IO.Split(',');                                         //split string to array
                        Console.WriteLine("Which entry would you like to view, type 'dump' to dump all data:\n");
                        string isData = Console.ReadLine();
                        if(isData == "dump")
                        {
                            Console.Write("\n");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            foreach(string str in allIO)
                            {
                                Console.WriteLine(str);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            break;
                        }
                        int index = int.Parse(isData);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(allIO[index].ToString());                            //output requested index
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        break;





                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}