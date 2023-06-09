﻿using Microsoft.Win32;
using System.Data;

namespace Login_and_Registr
{
    public class Profile
    {
        public string _firstName;
        public string _lastName;
        public string _email;
        public string _password;
        public Profile(string firstName, string lastName, string email, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
        }
    }
    internal class Program
    {
        public static List<Profile> profiles = new List<Profile>();       
        static void Main(string[] args)
        {
            while (true)
            {                  
                  Console.WriteLine("");
                  Console.WriteLine("1. /register");
                  Console.WriteLine("2. /login");
                  Console.WriteLine("3. /exit");

                  Console.WriteLine("");
                  Console.Write("Add your choise : ");
                  string command = Console.ReadLine()!;
         
                  switch (command)
                  {
                      case "/register":
                          bool register = Register(command);
                          break;

                      case "/login":
                        bool login = Login(command);
                          break;

                      case "/exit":
                          Console.WriteLine("");
                          Console.WriteLine("Bye bye");
                        return;
                  }
            }
        }
         
        #region Menu
        public static bool Register(string command)
        {
            string firstName,lastName,email, password;           
                            
                bool isFirstNameLengthTrue = IsFirstNameLength(out firstName);
                bool isLastNameLengthTrue = IsLastNameLength(out lastName);
                bool isEmail = IsEmail(out email);
                bool isPasswordTrue = IsPasswordTrue(out password);

                Console.WriteLine("");
                Console.WriteLine("You successfully registered, now you can login with your new account!");
                                                
                Profile profile = new Profile(firstName, lastName, email, password);
                profiles.Add(profile);
                return true;                
        }
        public static bool Login(string command)
        {            
             string firstName = "Super";
             string lastName = "Admin";
             string email = "admin@gmail.com";
             string password = "123321";

            Profile admin = new Profile(firstName, lastName, email, password);
            profiles.Add(admin);

            while(true)
            {
              Console.Write("Entry email : ");
              string entryEmail = Console.ReadLine()!;
              Console.Write("Entry password : ");
              string entryPassword = Console.ReadLine()!;

                foreach (Profile profile in profiles)
                {
                    if (profile._email == entryEmail && profile._password == entryPassword && profile._email != "admin@gmail.com")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Welcome to your account " + profile._firstName + " " + profile._lastName + " !");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("###########################################");
                        return true;
                    }
                    if (profile._email == entryEmail && profile._password == entryPassword && profile._email == "admin@gmail.com")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Welcome to your account, our dear admin " + profile._firstName + " " + profile._lastName + " !");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("###########################################");
                        return true;
                    }
                }
              Console.WriteLine("Pls add correct email or password!");
            }          
        }
        #endregion

        #region Utility
        public static bool IsFirstNameLength(out string firstName)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Enter first name : ");
                firstName = Console.ReadLine()!;

                 if(firstName.Length >= 3 && firstName.Length <= 30)
                     return true;  
                 
                 Console.WriteLine("Incorrect input!");
                 Console.WriteLine("Must be between 3 and 30 characters"); 
            }            
        }
        public static bool IsLastNameLength(out string lastName)
        {           
            while (true)
            {
                Console.Write("Enter last name : ");
                lastName = Console.ReadLine()!;

                if (lastName.Length >= 5 && lastName.Length <= 20)
                    return true;

                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Must be between 5 and 20 characters");                
            }            
        }
        public static bool IsEmail(out string email)
        {
            while (true)
            {
                Console.Write("Enter email :");
                email = Console.ReadLine()!;

                bool isEmailTrue = IsEmailTrue(ref email);
                bool isEmailExists = IsEmailExists(ref email);

                if (isEmailTrue && isEmailExists)
                    return true;
            }
        }
        static bool IsEmailTrue(ref string email)
        {
            char[] lowerLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int k = 0;
            for (int j = 0; j < lowerLetters.Length; j++)
            {
                if (email[0] == lowerLetters[j])
                {
                    k++;
                    break;
                }
            }
            for (int c = 0; c < numbers.Length; c++)
            {
                if (email[0] == numbers[c])
                {
                    k++;
                    break;
                }
            }
            if (k <= 0)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("The first character must be a lower case letter or a number.");
                return false;
            }
            while (true)
            {
                 for (int i = 0; i < email.Length; i++)
                 {
                     if (email[i] == '@')
                         return true;
                 }
                  Console.WriteLine("Incorrect input!");
                  Console.WriteLine("Email must contain 1 '@' symbol");
                  return false;
            }                
        }
        static bool IsEmailExists(ref string email)
        {
            foreach (Profile item in profiles)
            {
                if (item._email == email)
                {
                    Console.WriteLine("This email address already exists! check another one");
                    return false;
                }
            }
            return true;
        }
        public static bool IsPasswordTrue(out string password)
        {
            while (true)
            {
                Console.Write("Enter password :");
                password = Console.ReadLine()!;

                Console.Write("Re-enter password : ");
                string testPassword = Console.ReadLine()!;
                
                if(password == testPassword)
                    return true;                
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Passwords do not match");
            }           
        }
        #endregion
    }
}