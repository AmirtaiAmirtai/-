using ChooseAday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ChooseAday
{
    public class Chooseday
    {
        public string e = "Encanto";
        public string f = "Frozen";
        public string d = "Dune";
        public string ff = "Fast and Furious";
        string userInput;
        List<string> sessionTimes = new List<string>();
        List<string> movies = new List<string>();
        private Dictionary<string, string> schedule = new Dictionary<string, string>();

        public Chooseday()
        {
            GenerateSchedule();
        }

         void GenerateSchedule()
        {
            sessionTimes = new List<string> { "10:00-12:30", "12:40-14:20", "14:30-16:50", "17:15-19:45" };
            List<string> movies = new List<string> { e, f, ff, d };
            movies = movies.OrderBy(x => Guid.NewGuid()).ToList(); 

            for (int i = 0; i < sessionTimes.Count; i++)
            {
                schedule.Add(sessionTimes[i], movies[i]);
            }

        }

        public void ChooseaMovie()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("********* \n Welcome to Broadway Theater's booking site! \nHere are available movies:\n*********");
            Thread.Sleep(3000);
            Console.Clear();
            Console.ResetColor();
            ShowSchedule();
            CheckErrors(GetInput());
        }
        public void ShowSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n1 -- " + e + "\n2 -- " + f + "\n3 -- " + d + "\n4 -- " + ff);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWhat day of the week are you planning your booking on?\n(Write it fully)");
            Console.ResetColor();
        }

        public string GetInput()
        {
            userInput = Console.ReadLine().ToLower();
            return userInput;
        }
        

        public void CheckErrors(string userInput)
        {
            while (!(userInput == "monday" ||
                     userInput == "tuesday" ||
                     userInput == "wednesday" ||
                     userInput == "thursday" ||
                     userInput == "friday" ||
                     userInput == "saturday" ||
                     userInput == "sunday"))
            {
                Console.WriteLine("Invalid option. \nPlease read our instructions and try again:");
                userInput = GetInput();
            }
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n1 -- " + e + "\n2 -- " + f + "\n3 -- " + d + "\n4 -- " + ff);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Here's our schedule on {userInput}:");
            Console.ResetColor();
            PrintBooking();
            ProcessBooking();
        }

        public void PrintBooking()
        {
            foreach (var item in schedule)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{item.Value} --- {item.Key}");
                Console.ResetColor();
            }
        }

        public void ProcessBooking()
        {
            Console.WriteLine("\nChoose the movie by its number from schedule: (1-4):");
            string movieChoice = GetInput();

            string selectedMovie = "";
            string sessionTime = "";
            switch (movieChoice)
            {
                case "1":
                    selectedMovie = e;
                    break;
                case "2":
                    selectedMovie = f;
                    break;
                case "3":
                    selectedMovie = d;
                    break;
                case "4":
                    selectedMovie = ff;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a valid movie number.");
                    ProcessBooking(); 
                    return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You've chosen: {selectedMovie}");
            Console.ResetColor();

            
            sessionTime = schedule.FirstOrDefault(x => x.Value == selectedMovie).Key;
            Console.WriteLine($"\nSession time for {selectedMovie}: {sessionTime}");

            int bookingPrice = GetBookingPrice();
            Console.WriteLine($"\nBooking price after discount: ${bookingPrice}");

            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nYour booking information:");
            Console.ResetColor();
            Console.WriteLine($"Movie: {selectedMovie}");
            int converted = Convert.ToInt32(userInput);
            Console.WriteLine($"Session time: {sessionTimes[converted - 1]}");
            Console.WriteLine($"Price: ${bookingPrice}");
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Is this correct? (yes/no)");
            Console.ResetColor();
            gettheanswer();
            void gettheanswer()
            {
string answer = Console.ReadLine();
            if ( answer == "yes")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great! Good luck."); 
                Console.ResetColor();
            }
            else if (answer == "no")
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("then you might want to register your booking again. :(");
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
                ChooseaMovie();
            }
            else
            {
                Console.WriteLine("excuse me");
                gettheanswer();
            }
            }
            
                
        }


       
        public int GetBookingPrice()
        {
            Console.WriteLine("\nWhat option suits you more?\n1 - Adult\n2 - College Student\n3 - Child");
            string ageOption = GetInput();

            int discount = 0;
            switch (ageOption)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("\nYou get no discounts.");
                    Console.ResetColor();
                    Console.WriteLine($"");
                    Console.WriteLine("The booking price is 5.");
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.WriteLine("\nYou get $1 discount!");
                    Console.ResetColor();
                    Console.WriteLine("The booking price for you is $4");
                    discount = 1;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("\nYou get $2 discount!");
                    Console.ResetColor();
                    Console.WriteLine("The booking price for you is $3");
                    discount = 2;
                    break;
                default:
                    Console.WriteLine("\nInvalid option. The booking price is $5.");
                    return GetBookingPrice();
            }
            Console.ResetColor();

            
            int bookingPrice = 5 - discount;
            return bookingPrice;
        }
    }
}


