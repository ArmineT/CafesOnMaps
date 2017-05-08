using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cafes
{
    class Program
    {
        static void Main(string[] args)
        {

            //  Text File   //
            StreamWriter output = new StreamWriter
                (@"output.txt");
            //  text File End   //

            List<Cafe> cafes = new List<Cafe>();
            TimeSpan openTime, closeTime;
            Random rnd = new Random();
            List<Account> accs = new List<Account>();
            ConsoleKeyInfo key;

            string input = "";
            string cafeName, cafeAddress, cafePhoneNumber, cafePassword = "";
            string cafeLink = "Cafe doesn't have a link, sorry.";
            string cafeEmail = "Cafe doesn't have a eMail, sorry.";
            string[] hourAndMinute = new string[2];
            string login;
            string password;
            
            bool imAdmin = false;
            bool imUser = false;
            bool addACafe = false;
            bool makeChanges = false;
            bool cafeExist = false;
            bool imSearchingCafe = true;
            bool searchingCafeExist = false;
            bool inputIsFalse = true;
            bool eMailAndLinkExist = false;


            // Adding some default cafes    //

            Cafe myFirstCafe = new Cafe("Centre", "Varshavyan 8", "010 45 58 46", new TimeSpan(08, 30, 00),
                                                         new TimeSpan(22, 30, 00), "**********");
            Cafe mySecondCafe = new Cafe("AHA", "Shiraz 74", "010 22 22 21", new TimeSpan(07, 30, 00),
                                                        new TimeSpan(23, 30, 00), "www.AHA.am", "AHA@mail.ru", "********");

            accs.Add(new Account("LoginA", "12345679888"));

            cafes.Add(myFirstCafe);
            cafes.Add(mySecondCafe);

            // End Adding some dafault cafes    //



            while (true)
            {
                Console.WriteLine("Print \"User\" if you are user. \nPrint \"Admin\" if you are administrator.\nPrint \"Exit\" if you want to exit all.");
                Console.WriteLine("====================================");
                input = Console.ReadLine();
                if (input.ToLower().Equals("admin"))
                    imAdmin = true;
                else if (input.ToLower().Equals("user"))
                    imUser = true;
                else if (input.ToLower().Equals("exit"))
                {
                    foreach (Cafe cafe in cafes)
                    {
                        output.WriteLine(cafe);
                        output.WriteLine("-----------------------------------------");
                    }
                    output.Flush();
                    output.Close();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please,follow instructions!");
                    Console.WriteLine();
                }

                //  Admin Working   //

                while (imAdmin)
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("If you want to add a cafe print \"Add a cafe\".");
                        Console.WriteLine("If you want to make changes to existing cafe print \"Make changes\". ");
                        Console.WriteLine("=================================================================");
                        input = Console.ReadLine();

                        if (input.ToLower().Equals("add a cafe"))
                        {
                            addACafe = true;
                            break;
                        }
                        else if (input.ToLower().Equals("make changes"))
                        {
                            makeChanges = true;
                            break;
                        }
                        else
                            Console.WriteLine("\nPlease,follow instructions!");
                    }

                    // Adding a cafe    //

                    while (addACafe)
                    {
                        Console.WriteLine("=================================================================");
                        Console.Write("Please,type your cafe's name: ");
                        cafeName = Console.ReadLine();
                        Console.Write("Please,type your cafe's address: ");
                        cafeAddress = Console.ReadLine();
                        Console.Write("Please,type your cafe's phone number: ");
                        cafePhoneNumber = Console.ReadLine();

                        while (true)
                        {
                            try
                            {
                                Console.Write("Please,print your cafe's open time (hh:mm): ");
                                hourAndMinute = (Console.ReadLine()).Split(':');
                                openTime = new TimeSpan(Convert.ToInt16(hourAndMinute[0]),
                                    Convert.ToInt16(hourAndMinute[1]), 0);
                                break;
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Incorrect input!");
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                Console.Write("Please,print your cafe's close time (hh:mm): ");
                                hourAndMinute = (Console.ReadLine()).Split(':');
                                closeTime = new TimeSpan(Convert.ToInt16(hourAndMinute[0]),
                                    Convert.ToInt16(hourAndMinute[1]), 0);
                                break;
                            }
                            catch (System.FormatException e)
                            {
                                Console.WriteLine("Incorrect input!");
                            }
                        }

                        while (true)
                        {
                            Console.Write("Do you have link and Email ? (Yes or No): ");
                            input = Console.ReadLine().ToLower();
                            if (input.Equals("yes"))
                            {
                                eMailAndLinkExist = true;
                                while (true)
                                {
                                    Console.Write("Please,type your cafe's link: ");
                                    cafeLink = Console.ReadLine();
                                    if (CheckLink(cafeLink)) { break; }
                                    else { Console.WriteLine("Invalid link (It must be in this from \"http://somewhere.something\")"); }

                                }
                                while (true)
                                {
                                    Console.Write("Please,type your cafe's eMail: ");
                                    cafeEmail = Console.ReadLine();
                                    if (CheckEMailAdress(cafeEmail)) { break; }
                                    else { Console.WriteLine("Invalid eMail address"); }
                                }
                                break;
                            }
                            else if (input.Equals("no"))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please,print Yes or No.");
                            }
                        }

                        Console.Write("You must set password for your cafe.");
                        while (true)
                        {
                            cafePassword = "";
                            Console.WriteLine("\nPlease,enter your password (It must be more than 7 characters): ");

                            key = Console.ReadKey(true);
                            cafePassword += key.KeyChar;
                            Console.Write("*");

                            while (key.Key != ConsoleKey.Enter)
                            {
                                key = Console.ReadKey(true);

                                if (key.Key != ConsoleKey.Backspace)
                                {
                                    cafePassword += key.KeyChar;
                                    Console.Write("*");
                                }
                                else
                                {
                                    Console.Write("\b");
                                }
                            }

                            if (cafePassword.Length >= 9)
                            {
                                break;
                            }
                            Console.WriteLine("Invalid password!");

                        }

                        Console.WriteLine();

                        if (eMailAndLinkExist)
                        {
                            cafes.Add(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                cafeLink, cafeEmail, cafePassword));
                            Console.WriteLine("Cafe added");

                            output.WriteLine("------------------------");

                        }
                        else
                        {
                            cafes.Add(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                 cafePassword));
                            Console.WriteLine("Cafe added");

                            output.WriteLine("------------------------");

                        }

                        Console.WriteLine();
                        Console.WriteLine("=============================================================");

                        while (true)
                        {
                            Console.Write("Do you want to add another cafe? \nAnswer \"Yes\" or \"No\": ");
                            input = Console.ReadLine();
                            if (input.ToLower().Equals("yes"))
                                break;
                            else if (input.ToLower().Equals("no"))
                            {
                                addACafe = false;
                                break;
                            }

                        }

                    }

                    // End Adding cafe  //

                    // Making chanhges as Admin //

                    while (makeChanges)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please,type the name and password of cafe, which you want to change.");
                        Console.Write("Type name: ");
                        cafeName = Console.ReadLine();
                        Console.Write("Type password:  ");
                        cafePassword = "";

                        key = Console.ReadKey(true);
                        cafePassword += key.KeyChar;
                        Console.Write("*");

                        while (key.Key != ConsoleKey.Enter)
                        {
                            key = Console.ReadKey(true);

                            if (key.Key != ConsoleKey.Backspace)
                            {
                                cafePassword += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write("\b");
                            }
                        }

                        Console.WriteLine();
                        cafeExist = false;
                        for (int i = 0; i < cafes.Count; i++)
                        {
                            if (cafes[i].Name.Equals(cafeName) && cafes[i].Password.Equals(cafePassword))
                            {
                                cafeExist = true;
                                bool doingChanges = true;
                                cafeName = input;
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine("You logged in successfully.");
                                Console.WriteLine("Now dear Admin you can....");
                                Console.WriteLine();


                                while (doingChanges)
                                {
                                    Console.WriteLine("Change cafe name                   Type \"Change Name\". ");
                                    Console.WriteLine("Change cafe address                Type \"Change Addres\". ");
                                    Console.WriteLine("Change cafe phone number           Type \"Change Phone Number\". ");
                                    Console.WriteLine("Change cafe Email                  Type \"Change Email\". ");
                                    Console.WriteLine("Change cafe link                   Type \"Change Link\". ");
                                    Console.WriteLine("If end your work with this caffe   Type \"Finish work with this cafe\". ");
                                    Console.WriteLine("If end your work with all changes  Type \"Finish work with changes\". ");
                                    Console.WriteLine("==========================================================================");
                
                                    input = Console.ReadLine().ToLower();

                                    switch (input)
                                    {
                                        case "change name":
                                            {
                                                Console.Write("Type a new name: ");
                                                cafes[i].ChangeCafeName(cafePassword, Console.ReadLine());
                                                Console.WriteLine("The name was changed.");
                                                Console.WriteLine();
                                                break;
                                            }

                                        case "change addres":
                                            {
                                                Console.Write("Type a new address: ");
                                                cafes[i].ChangeCafeAddress(cafePassword, Console.ReadLine());
                                                Console.WriteLine("The address was changed.");
                                                Console.WriteLine();

                                                break;
                                            }

                                        case "change phone number":
                                            {
                                                Console.Write("Type a new phone number: ");
                                                cafes[i].ChangeCafePhoneNumber(cafePassword, Console.ReadLine());
                                                Console.WriteLine("The phone number was changed.");
                                                Console.WriteLine();

                                                break;
                                            }

                                        case "change email":
                                            {
                                                while (true)
                                                {
                                                    Console.Write("Type a new Email: ");
                                                    cafeEmail = Console.ReadLine();
                                                    if (CheckEMailAdress(cafeEmail)) { break; }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Invalid eMail address!!");
                                                        Console.WriteLine();
                                                    }
                                                }
                                                cafes[i].ChangeCafeEmail(cafePassword, cafeEmail);
                                                Console.WriteLine("The Email was changed.");
                                                Console.WriteLine();

                                                break;
                                            }

                                        case "change link":
                                            {
                                                while (true)
                                                {
                                                    Console.Write("Type a new Link: ");
                                                    cafeLink = Console.ReadLine();
                                                    if (CheckLink(cafeLink)) { break; }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Invalid link (It must be in this from \"http://somewhere.something\")");
                                                        Console.WriteLine();
                                                    }

                                                }
                                                cafes[i].ChangeCafeLink(cafePassword, cafeLink);
                                                Console.WriteLine("The link was changed.");
                                                Console.WriteLine();

                                                break;
                                            }

                                        case "finish work with this cafe":
                                            {
                                                Console.WriteLine("Thank you for making changes.");
                                                Console.WriteLine();
                                                doingChanges = false;
                                                break;
                                            }
                                        case ("finish work with changes"):
                                            {
                                                Console.WriteLine("Thank you for making changes.");
                                                Console.WriteLine();
                                                doingChanges = false;
                                                makeChanges = false;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Please, follow the instructions.");
                                                Console.WriteLine();
                                                break;
                                            }
                                    }
                                }
                            }

                            if (cafeExist == false && i == cafes.Count() - 1)
                            {
                                Console.WriteLine("================================================");
                                Console.WriteLine("Invalid name or password");
                                while (true)
                                {
                                    Console.WriteLine("Do you want to try again and countinue changes (type \"Yes\" or \"No\")");
                                    input = Console.ReadLine().ToLower();
                                    if (input.Equals("yes")) { break; }
                                    else if (input.Equals("no")) { makeChanges = false; break; }
                                    Console.WriteLine();
                                }
                            }
                        }
                    }

                    // End Making changes As Admin  //

                    while (true)
                    {
                        Console.WriteLine();
                        Console.Write("Have you finished your work as Administrator? (Yes or No): ");
                        input = Console.ReadLine();
                        if (input.ToLower().Equals("yes"))
                        {
                            imAdmin = false;
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("=========================================================");
                            Console.WriteLine();
                            break;
                        }
                        else if (input.ToLower().Equals("no")) { break; }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please,follow instructions! \nAnswer \"Yes\" or \"No\" ");
                            Console.WriteLine();
                        }
                    }
                }

                // End Working as Admin //
               
                
                //UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
                //EEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRR

                while (imUser)
                {
                    Console.WriteLine();
                    Console.WriteLine("Hello dear user. \nHere are our cafes by decreasing rates...");
                    cafes.Sort();
                    Console.WriteLine("================================================================");
                    for (int i = cafes.Count - 1; i >= 0; i--)
                    {
                        Console.WriteLine(cafes[i].Name);
                    }
                    Console.WriteLine("================================================================");
                    Console.WriteLine();
                    inputIsFalse = true;
                    Console.WriteLine("Now you can:");
                    while (inputIsFalse)
                    {
                        Console.WriteLine("Search cafe by name                                         Type \"Search by name\".");
                        Console.WriteLine("Search cafe by address                                      Type \"Search by address\".");
                        Console.WriteLine("If you want to create an account                            Type \"Create\".");
                        Console.WriteLine("If you want to grade(You must have an account)              Type \"Grade\".");
                        Console.WriteLine("If you want to write a review(You must have an account)     Type \"Review\".");
                        Console.WriteLine("If you finished your work as user                           Type \"Exit\".");
                        Console.WriteLine("================================================================");

                        input = Console.ReadLine().ToLower();
                        switch (input)
                        {
                            case "exit":
                                {
                                    imUser = false;
                                    inputIsFalse = false;
                                    break;
                                }
                            case "search by name":
                                {
                                    imSearchingCafe = true;
                                    inputIsFalse = false;
                                    while (imSearchingCafe)
                                    {
                                        searchingCafeExist = false;
                                        Console.Write("Now, please, enter the name of cafe which you are interested in: ");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)

                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("Here is all information about that cafe...");
                                                Console.WriteLine("================================================================");
                                                Console.WriteLine(cafes[i].ToString());
                                                Console.WriteLine("================================================================");
                                                while (true)
                                                {
                                                    Console.WriteLine("Have you finished searching by name? (Answer \"Yes\" or \"No\")");
                                                    input = Console.ReadLine().ToLower();
                                                    if (input.Equals("yes"))
                                                    {
                                                        imSearchingCafe = false;
                                                        break;
                                                    }
                                                    else if (input.Equals("no"))
                                                        break;
                                                    else
                                                        Console.WriteLine("Please,follow the instructions!");

                                                }
                                            }
                                        }

                                        if (searchingCafeExist == false)
                                        {
                                            Console.WriteLine("Cafe isn't exist");
                                            Console.WriteLine("Here is our cafes by decreasing rates,please choose one:");
                                            for (int i = 0; i < cafes.Count; i++)
                                            {
                                                Console.WriteLine(cafes[i].Name + "\n");
                                            }
                                        }
                                    }
                                    break;
                                }

                            case "search by address":
                                {
                                    inputIsFalse = false;
                                    imSearchingCafe = true;
                                    while (imSearchingCafe)
                                    {
                                        searchingCafeExist = false;
                                        Console.Write("Now, please, enter the address of cafe which you are interested in: ");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Address))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("Here is all information about that cafe:");
                                                Console.WriteLine("================================================================");
                                                Console.WriteLine(cafes[i].ToString());
                                                Console.WriteLine("================================================================");
                                                while (true)
                                                {
                                                    Console.WriteLine("Have you finished? (Answer \"Yes\" or \"No\")");
                                                    input = Console.ReadLine().ToLower();
                                                    if (input.Equals("yes"))
                                                    {
                                                        imSearchingCafe = false;
                                                        break;
                                                    }
                                                    else if (input.Equals("no"))
                                                        break;
                                                    else
                                                        Console.WriteLine("Please,follow the instructions!");

                                                }
                                            }
                                        }

                                        if (searchingCafeExist == false)
                                        {
                                            Console.WriteLine("Cafe doesnt exist.");
                                            Console.WriteLine("Here is our cafes by decreasing rates,please choose one...");
                                            for (int i = 0; i < cafes.Count; i++)
                                            {
                                                Console.WriteLine(cafes[i].Address + "\n");
                                            }
                                        }
                                    }
                                    break;
                                }



                            case "grade":
                                {
                                    bool loginFailed = true;
                                    while (loginFailed)
                                    {
                                        Console.WriteLine("Please,type correct login and password.");
                                        Console.Write("Login: ");
                                        login = Console.ReadLine();
                                        Console.Write("Password: ");
                                        password = "";

                                        key = Console.ReadKey(true);
                                        password += key.KeyChar;
                                        Console.Write("#");

                                        while (key.Key != ConsoleKey.Enter)
                                        {
                                            key = Console.ReadKey(true);

                                            if (key.Key != ConsoleKey.Backspace)
                                            {
                                                password += key.KeyChar;
                                                Console.Write("#");
                                            }
                                            else
                                            {
                                                Console.Write("\b");
                                            }
                                        }

                                        foreach (Account account in accs)
                                            if (account.Login.Equals(login) && account.Password.Equals(password))
                                            {
                                                loginFailed = false;
                                                Console.WriteLine("You logged in succesfully.");
                                                break;
                                            }
                                        Console.WriteLine("Invalid login or password!");

                                    }
                                    imSearchingCafe = true;
                                    while (imSearchingCafe)
                                    {
                                        searchingCafeExist = false;
                                        Console.Write("Now, please, enter the name of cafe which you want to rate: ");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                while (true)
                                                {
                                                    Console.Write("Please,type grade (1 to 10): ");
                                                    input = Console.ReadLine();
                                                    int grade;
                                                    if (int.TryParse(input, out grade) && grade <= 10)
                                                    {
                                                        cafes[i].AddGrade(grade);
                                                        Console.WriteLine("Grade added.");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Follow the instructions!");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            else if (i == cafes.Count - 1 && searchingCafeExist == false)
                                            {
                                                Console.WriteLine("There is no cafe by that name.");
                                                Console.WriteLine();
                                                Console.WriteLine("================================================================");
                                                Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
                                                Console.WriteLine("================================================================");
                                                cafes.Sort();
                                                for (int j = cafes.Count - 1; j > -1; j--)
                                                {
                                                    Console.WriteLine(cafes[j].Name);
                                                }
                                            }
                                        }

                                        if (searchingCafeExist == true)
                                        {
                                            while (true)
                                            {
                                                Console.Write("Do you want rate again? (Answer \"Yes\" or \"No\"): ");
                                                input = Console.ReadLine().ToLower();
                                                if (input.Equals("yes")) { break; }
                                                else if (input.Equals("no"))
                                                {
                                                    imSearchingCafe = false;
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                    break;
                                }


                            case "review":
                                {
                                    bool loginFailed = true;
                                    while (loginFailed)
                                    {
                                        Console.WriteLine("Please,input correct login and password.");
                                        Console.Write("login: ");
                                        login = Console.ReadLine();
                                        Console.Write("password: ");
                                        password = Console.ReadLine();

                                        foreach (Account account in accs)
                                            if (account.Login.Equals(login) && account.Password.Equals(password))
                                            {
                                                loginFailed = false;
                                                Console.WriteLine("You logged in succesfully.");                                          
                                                break;
                                            }

                                    }

                                    imSearchingCafe = true;
                                    while (imSearchingCafe)
                                    {
                                        searchingCafeExist = false;
                                        Console.Write("Now, please, enter the name of cafe which you want to review: ");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("Print the review...");
                                                input = Console.ReadLine();
                                                cafes[i].Review.Add(input);
                                            }
                                            else if (i == cafes.Count - 1 && searchingCafeExist == false)
                                            {
                                                Console.WriteLine("There is no cafe by that name.");
                                                Console.WriteLine();
                                                Console.WriteLine("================================================================");
                                                Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
                                                Console.WriteLine("================================================================");
                                                for (int j = 0; j < cafes.Count; j++)
                                                {
                                                    Console.WriteLine(cafes[j].Name);
                                                }
                                            }
                                        }

                                        if (searchingCafeExist == true)
                                        {
                                            while (true)
                                            {
                                                Console.Write("Do you want to review again? (Answer \"Yes\" or \"No\") ");
                                                input = Console.ReadLine().ToLower();
                                                if (input.Equals("yes")) { break; }
                                                else if (input.Equals("no"))
                                                {
                                                    imSearchingCafe = false;
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                    break;
                                }



                            case ("create"):
                                {
                                    Console.WriteLine("So please pick a login.");
                                    while (true)
                                    {
                                        Console.Write("Login: ");
                                        login = Console.ReadLine();
                                        if (login.Length >= 6)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Login must be at least 6 characters!");
                                            Console.WriteLine();
                                        }
                                    }
                                    password = rnd.Next(10000000, 1000000000) + "";

                                    Console.WriteLine("Here is your password: {0}. Don't loose it.", password);
                                    Console.WriteLine("Your account has been created.");
                                    Console.WriteLine("================================================================");

                                    accs.Add(new Account(login, password));

                                    break;

                                }

                            default:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Please, follow the instructions.");
                                    Console.WriteLine();
                                    break;
                                }
                        }

                    }
                }

            }
        }
        public static bool CheckEMailAdress(string Adress)
        {
            if (Adress.IndexOf('@') == -1) { return false; } // ther is no @
            else
                Adress = Adress.Substring(Adress.IndexOf('@'));

            if (Adress.IndexOf('.') == -1)
                return false;

            switch (Adress.Substring(0, Adress.IndexOf('.')))//between the @ and the . characters
            {
                case "@gmail":
                case "@mail":
                case "@yahoo":
                case "@outlook":
                case "@yandex":
                case "@armsoft":
                    // if it is true , we countinue
                    break;
                default:
                    return false;
            }

            switch (Adress.Substring(Adress.IndexOf('.')))//after .
            {
                case ".com":
                case ".ru":
                case ".org":
                case ".am":
                    // if it is true , we countinue
                    break;
                default:
                    return false;
            }

            //everything is ok
            return true;
        }

        public static bool CheckLink(string link)
        {
            if (link.Length >= 10) //it must be minimum http://a.a 
            {
                if (link.Substring(0, 7).Equals("http://"))
                {
                    if (link.IndexOf('.') == (link.Length - 1) || link.IndexOf('.') == link.Length - 2 || link.IndexOf('.') == -1) { return false; }
                    else { return true; }
                }
                else { return false; }
            }
            else { return false; }

        }
    }

}


