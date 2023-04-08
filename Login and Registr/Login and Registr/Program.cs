using Microsoft.Win32;
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
        static void Main(string[] args)
        { 
            List<Profile> profiles = new List<Profile>();

            Console.WriteLine("1. /register");
            Console.WriteLine("2. /login");
            Console.WriteLine("3. /exit");

            Console.WriteLine("");
            Console.Write("Add your choise : ");
            string command = Console.ReadLine();
            Console.WriteLine("");

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
                    break;
            }
        }

        #region Menu
        public static bool Register(string command)
        {
            if(command == "/register")
            {                
                bool isFirstNameLengthTrue = IsFirstNameLength();
                bool isLastNameLengthTrue = IsLastNameLength();
                bool isEmailTrue = IsEmailTrue();
                bool isPasswordTrue = IsPasswordTrue();
                return true;
            }
            return false;
        }
        public static bool Login(string command) ////Didnt completed
        {
            if (command == "/login")
            {
                
                return true;
            }
            return false;
        }
        #endregion

        #region Utility
        public static bool IsFirstNameLength()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine(" Enter first name : ");
                 string firstName = Console.ReadLine();

                 if(firstName.Length >= 3 && firstName.Length <= 30)
                     return true;  
                 
                 Console.WriteLine("Incorrect input!");
                 Console.WriteLine("Must be between 3 and 30 characters"); 
            }
        }
        public static bool IsLastNameLength()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine(" Enter last name : ");
                string lastName = Console.ReadLine();

                if (lastName.Length >= 5 && lastName.Length <= 20)
                    return true;

                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Must be between 5 and 20 characters");
            }
        }
        public static bool IsEmailTrue()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter email :");
                string addEmail = Console.ReadLine();

            for(int i = 0; i < addEmail.Length; i++)
                {
                    if (addEmail[i] == '@')
                        return true;
                }
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Email must contain 1 '@' symbol");
            }
        }
        public static bool IsPasswordTrue()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter password :");
                string addPassword = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Re-enter the password");
                string testPassword = Console.ReadLine();
                
                if(addPassword == testPassword)
                {
                    return true;
                }                
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Passwords do not match");
            }
        }
        #endregion

        #region Get Data




        #endregion

    }
}