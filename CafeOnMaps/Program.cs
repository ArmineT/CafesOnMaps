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
                (@"C:\Users\Hayk\Documents\Visual Studio 2015\Projects\CafeOnMaps\CafeOnMaps\output.txt");
            //  text File End   //



            List<Cafe> cafes = new List<Cafe>();
            TimeSpan openTime, closeTime;
            Random rnd = new Random();
            List<Account> accs = new List<Account>();
            ConsoleKeyInfo key;

            string input = "";
            string cafeName, cafeAddress, cafePhoneNumber, cafePassword = "";
            string cafeLink = "Cafe don't have a link, sorry.";
            string cafeEmail = "Cafe don't have a eMail, sorry.";
            string[] hourAndMinute = new string[2];
            string login;
            string password;
            bool eMailAndLinkExist = false;
            string pass = "";

            bool imAdmin = false;
            bool imUser = false;
            bool addACafe = false;
            bool makeChanges = false;
            bool cafeExist = false;
            bool imSearchingCafe = true;
            bool searchingCafeExist = false;
            bool inputIsFalse = true;

            bool choosingAccount = true;




            Cafe myFirstCafe = new Cafe("Centre", "Varshavyan 8", "010 45 58 46", new TimeSpan(08, 30, 00),
                                                         new TimeSpan(22, 30, 00), "**********");
            Cafe mySecondCafe = new Cafe("AHA", "Shiraz 74", "010 22 22 21", new TimeSpan(07, 30, 00),
                                                        new TimeSpan(23, 30, 00), "www.AHA.am", "AHA@mail.ru", "********");

            accs.Add(new Account("LoginA", "12345679888"));


            cafes.Add(myFirstCafe);
            cafes.Add(mySecondCafe);



            while (true)
            {
                Console.WriteLine("Print \"User\" if you are user \nPrint \"Admin\" if you are administrator\nPrint \"Exit\" if you want to exit all.");
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
                    Console.WriteLine("Please,follow instructions!");




                while (imAdmin)
                {
                    while (true)
                    {
                        Console.WriteLine("If you want to add a cafe print \"Add a cafe\" ");
                        Console.WriteLine("If you want to make changes to existing cafe print \"Make changes\" ");
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
                            Console.WriteLine("Please,follow instructions!");
                    }

                    while (addACafe)
                    {
                        Console.Write("Please,print your cafe's name: ");
                        cafeName = Console.ReadLine();
                        Console.Write("Please,print your cafe's address: ");
                        cafeAddress = Console.ReadLine();
                        Console.Write("Please,print your cafe's phone number: ");
                        cafePhoneNumber = Console.ReadLine();
                        Console.Write("Please,print your cafe's open time (hh:mm): ");
                        hourAndMinute = (Console.ReadLine()).Split(':');
                        openTime = new TimeSpan(Convert.ToInt16(hourAndMinute[0]),
                            Convert.ToInt16(hourAndMinute[1]), 0);
                        //unhandleds
                        Console.Write("Please,print your cafe's close time (hh:mm): ");
                        hourAndMinute = (Console.ReadLine()).Split(':');
                        closeTime = new TimeSpan(Convert.ToInt16(hourAndMinute[0]),
                            Convert.ToInt16(hourAndMinute[1]), 0);

                        while (true)
                        {
                            Console.WriteLine("Do you have link and mail ? (Yes or No) ");
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
                            else if (input.Equals("no")) { break; }
                            else
                            {
                                Console.WriteLine("Please,print Yes or No");
                            }
                        }

                        Console.Write("You must set password for your cafe:");
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
                            Console.WriteLine("Invalid password");

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



                        while (true)
                        {
                            Console.WriteLine("Do you want add another cafe \nAnswer \"Yes\" or \"No\" :");
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


                    ////// As admin make changes
                    while (makeChanges)
                    {
                        Console.WriteLine("Please,type the name  and password of cafe,which you want to change:");
                        Console.WriteLine("Type name: ");
                        cafeName = Console.ReadLine();
                        Console.WriteLine("Type password:  ");
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
                                Console.WriteLine("You logged in successfully");
                                Console.WriteLine("Now dear Admin you can:");


                                while (doingChanges)
                                {
                                    Console.WriteLine("Change cafe name                   Type \"Change Name\" ");
                                    Console.WriteLine("Change cafe address                Type \"Change Addres\" ");
                                    Console.WriteLine("Change cafe phone number           Type \"Change Phone Number\" ");
                                    Console.WriteLine("Change cafe Email                  Type \"Change Email\" ");
                                    Console.WriteLine("Change cafe link                   Type \"Change Link\" ");
                                    Console.WriteLine("If end your work with this caffe   Type \"Finish work with this cafe\" ");
                                    Console.WriteLine("If end your work with all changes  Type \"Finish work with changes\" ");


                                    input = Console.ReadLine().ToLower();

                                    switch (input)
                                    {
                                        case "change name":
                                            {
                                                Console.Write("Type new name:");
                                                cafes[i].ChangeCafeName(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Name was changed");
                                                break;
                                            }

                                        case "change addres":
                                            {
                                                Console.Write("Type new address:");
                                                cafes[i].ChangeCafeAddress(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Address was changed");

                                                break;
                                            }

                                        case "change phone number":
                                            {
                                                Console.Write("Type new phone number:");
                                                cafes[i].ChangeCafePhoneNumber(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Phone number was changed");

                                                break;
                                            }

                                        case "change email":
                                            {
                                                while (true)
                                                {
                                                    Console.Write("Type new Email:");
                                                    cafeEmail = Console.ReadLine();
                                                    if (CheckEMailAdress(cafeEmail)) { break; }
                                                    else { Console.WriteLine("Invalid eMail address"); }
                                                }
                                                cafes[i].ChangeCafeEmail(cafePassword, cafeEmail);
                                                Console.WriteLine("Email was changed");

                                                break;
                                            }

                                        case "change link":
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Type new Link:");
                                                    cafeLink = Console.ReadLine();
                                                    if (CheckLink(cafeLink)) { break; }
                                                    else { Console.WriteLine("Invalid link (It must be in this from \"http://somewhere.something\")"); }

                                                }
                                                cafes[i].ChangeCafeLink(cafePassword, cafeLink);
                                                Console.WriteLine("Link was changed");

                                                break;
                                            }

                                        case "finish work with this cafe":
                                            {
                                                Console.WriteLine("Thank you for changes");
                                                doingChanges = false;
                                                break;
                                            }
                                        case ("finish work with changes"):
                                            {
                                                Console.WriteLine("Thank you for changes");
                                                doingChanges = false;
                                                makeChanges = false;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Please, follow the instructions.");
                                                break;
                                            }
                                    }

                                }
                            }

                            if (cafeExist == false && i == cafes.Count() - 1)
                            {
                                Console.WriteLine("Invalid name or password");
                                while (true)
                                {
                                    Console.WriteLine("Do you want try again and countinue changes (type \"Yes\" or \"No\")");
                                    input = Console.ReadLine().ToLower();
                                    if (input.Equals("yes")) { break; }
                                    else if (input.Equals("no")) { makeChanges = false; break; }
                                }
                            }
                        }


                    }

                    while (true)
                    {
                        Console.WriteLine("Have you finished your work as Administrator? (Yes or No)");
                        input = Console.ReadLine();
                        if (input.ToLower().Equals("yes"))
                        {
                            imAdmin = false;
                            break;
                        }
                        else if (input.ToLower().Equals("no")) { break; }
                        else
                            Console.WriteLine("Please,follow instructions! \nAnswer \"Yes\" or \"No\" ");
                    }
                }
                //UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRR



                while (imUser)
                {
                    Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
                    cafes.Sort();
                    for (int i = cafes.Count - 1; i >= 0; i--)
                    {
                        Console.WriteLine(cafes[i].Name);
                    }

                    inputIsFalse = true;
                    Console.WriteLine("Now you can:");
                    while (inputIsFalse)
                    {
                        Console.WriteLine("Search cafe by name                                         Type \"Search by name\"");
                        Console.WriteLine("Search cafe by address                                      Type \"Search by address\"");
                        Console.WriteLine("If you want to create an account                            Type \"Create\"");
                        Console.WriteLine("If you want to grade(You must have an account)              Type \"Grade\"");
                        Console.WriteLine("If you want to write a review(You must have an account)     Type \"Review\"");
                        Console.WriteLine("If you finished your work as user                           Type \"Exit\"");


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
                                        Console.WriteLine("Now,please,enter the name of cafe which you are interested in");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)

                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("There is all information about that cafe:");
                                                Console.WriteLine(cafes[i].ToString());
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
                                    while (imSearchingCafe)
                                    {
                                        searchingCafeExist = false;
                                        Console.WriteLine("Now,please,enter the address of cafe which you are interested in");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Address))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("There is all information about that cafe:");
                                                Console.WriteLine(cafes[i].ToString());
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
                                            Console.WriteLine("Cafe isn't exist");
                                            Console.WriteLine("Here is our cafes by decreasing rates,please choose one:");
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
                                        Console.WriteLine("Please,input correct login and password");
                                        Console.WriteLine("Login: ");
                                        login = Console.ReadLine();
                                        Console.WriteLine("Password: ");
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
                                        Console.WriteLine("Now,please,enter the name of cafe which you want to rate");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                while (true)
                                                {
                                                    Console.WriteLine("Please,print grade (1 to 10)");
                                                    input = Console.ReadLine();
                                                    int grade;
                                                    if (int.TryParse(input, out grade) && grade <= 10)
                                                    {
                                                        cafes[i].AddGrade(grade);
                                                        Console.WriteLine("Grade added");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Follow instructions!");
                                                }
                                            }
                                            else if (i == cafes.Count - 1 && searchingCafeExist == false)
                                            {
                                                Console.WriteLine("There is no cafe by that name");
                                                Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
                                                cafes.Sort();
                                                for (int j = cafes.Count - 1 ; j > -1; j--)
                                                {
                                                    Console.WriteLine(cafes[j].Name);
                                                }
                                            }
                                        }

                                        if (searchingCafeExist == true)
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Do you want rate again (Answer \"Yes\" or \"No\")?");
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
                                        Console.WriteLine("Please,input correct login and password");
                                        Console.WriteLine("login: ");
                                        login = Console.ReadLine();
                                        Console.WriteLine("password: ");
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
                                        Console.WriteLine("Now,please,enter the name of cafe which you want to review");
                                        input = Console.ReadLine();
                                        for (int i = 0; i < cafes.Count; i++)
                                        {
                                            if (input.Equals(cafes[i].Name))
                                            {
                                                searchingCafeExist = true;
                                                Console.WriteLine("Print review");
                                                input = Console.ReadLine();
                                                cafes[i].Review.Add(input);
                                            }
                                            else if (i == cafes.Count - 1 && searchingCafeExist == false)
                                            {
                                                Console.WriteLine("There is no cafe by that name");
                                                Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
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
                                                Console.WriteLine("Do you want review again (Answer \"Yes\" or \"No\")?");
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
                                        login = Console.ReadLine();
                                        if (login.Length >= 6) { break; }
                                        else
                                            Console.WriteLine("Login must be at least 6 characters!");
                                    }
                                    password = rnd.Next(10000000, 1000000000) + "";

                                    Console.WriteLine("Here is your password: {0}. Don't loose it", password);
                                    Console.WriteLine("Your account has been created.");


                                    accs.Add(new Account(login, password));

                                    break;

                                }

                            default:
                                {
                                    Console.WriteLine("Please, follow the instructions.");
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


