using System;

namespace PigLatinConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string  userName,
                    pigLatinConfirm;

            bool pigLatinConfirm_Loop = true;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***Pig Latin converter 9000***");
            Console.ForegroundColor = ConsoleColor.Gray;

            if(args.Length <= 0) {
                Console.Write("Please enter your name: ");
                string readName = Console.ReadLine();
                userName = readName;
            }
            else {
                Console.WriteLine("h");
                userName = args[0];
            }

            Console.WriteLine($"Hello {userName}, it's a pleasure to meet you!");

            //Console.WriteLine(DoMaths());
            while(pigLatinConfirm_Loop) 
            {
                Console.Write("Would you like to read this in pig latin? (Y/N): ");
                
                pigLatinConfirm = Console.ReadLine();
                
                // Clean up the incoming message
                pigLatinConfirm = pigLatinConfirm.TrimStart(); // trim any leading/trailing space
                pigLatinConfirm = pigLatinConfirm.TrimEnd();
                pigLatinConfirm = pigLatinConfirm.ToLower(); // put into lower case
                
                if(pigLatinConfirm == "y" || pigLatinConfirm == "n") {
                    pigLatinConfirm_Loop = false;
                    if(pigLatinConfirm == "y") 
                    {
                        Console.Write("Converting");
                        // Loading message
                        for(int i = 0; i < 3; i++) {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(1000);
                        }
                        Console.WriteLine("\n"+ ConvertToPigLatin(userName) + "\n");
                    }
                    break;
                }
                // else loop round with a feedback message
                Console.WriteLine("\nInvalid response: Please enter 'Y' or 'N'");
            }           
        }

        static string ConvertToPigLatin(string msg) {
            /*
            *** Rules of Pig Latin ***
            * - Pig Latin takes the first consonant (or consonant cluster) of an English word, moves it to the end of the word 
            * - If the word begins with a vowel, you add "way" to the end.
            * - If the word begins with a consonant, you add "ay" to the end.
            *
            * For example, pig becomes igpay, banana becomes ananabay, and aadvark becomes aadvarkway.
            */
            string      firstLetter = msg.Substring(0, 1),
                        lastLetter = msg.Substring(msg.Length - 1, 1),
                        pigName = "",
                        updatedMsg;

            string[] vowels = {"a", "e", "i", "o", "u"};

            bool isVowel = false;

            //Console.WriteLine($"First letter: {firstLetter}, last letter: {lastLetter}");
            
            foreach(var vowel in vowels) {
                if(vowel == firstLetter) {
                    isVowel = true; // it's a vowell
                    pigName = msg.Substring(0); // Get the substring of everything after the first character
                    pigName = pigName + firstLetter + "way"; // build the new string
                    break;
                }
            }

            if(!isVowel) {
                pigName = msg + "ay";
            }

            updatedMsg = $"ElcomeWay {pigName}, oodGay ayDay otay youway!";

            return updatedMsg;
        }
    }
}
