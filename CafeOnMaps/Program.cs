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
                ("output.txt");

            //  text File End   //

            List<Cafe> cafes = new List<Cafe>();
            string input = "";
            string cafeName, cafeAddress, cafePhoneNumber, cafePassword;
            string cafeLink = "Cafe don't have a link, sorry.";
            string cafeEmail = "Cafe don't have a eMail, sorry.";
            TimeSpan openTime, closeTime;
            string[] hourAndMinute = new string[2];
            bool eMailAndLinkExist = false;
            bool imAdmin = false;
            bool imUser = false;
            bool addACafe = false;
            bool makeChanges = false;
            bool cafeExist = false;
            bool imSearchingCafe = true;
            bool searchingCafeExist = false;
            bool inputIsFalse = true;
            string login;
            Random rnd = new Random();
            string password;
            List<Account> accs = new List<Account>();
            bool choosingAccount = true;




            Cafe myFirstCafe = new Cafe("Armine", "Varshavyan 8", "010 45 58 46", new TimeSpan(08, 30, 00),
                                                         new TimeSpan(22, 30, 00), "**********");
            Cafe mySecondCafe = new Cafe("AHA", "Shiraz 74", "010 22 22 21", new TimeSpan(07, 30, 00),
                                                        new TimeSpan(23, 30, 00), "www.AHA.am", "AHA@mail.ru", "********");


            cafes.Add(myFirstCafe);
            cafes.Add(mySecondCafe);
            output.WriteLine(myFirstCafe);
            output.Flush();
            //output.Close();
            output.WriteLine("--------------------------");
            output.WriteLine(mySecondCafe);
            output.Flush();


            while (true)
            {
                Console.WriteLine("Print \"User\" if you are user \nPrint \"Admin\" if you are administrator ");
                input = Console.ReadLine();
                if (input.ToLower().Equals("admin"))
                    imAdmin = true;
                else if (input.ToLower().Equals("user"))
                    imUser = true;
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
                        Console.Write("Please,print your cafe's close time (hh:mm): ");
                        hourAndMinute = (Console.ReadLine()).Split(':');
                        closeTime = new TimeSpan(Convert.ToInt16(hourAndMinute[0]),
                            Convert.ToInt16(hourAndMinute[1]), 0);
                        Console.Write("Do you have link and mail ? (Yes or No) ");
                        input = Console.ReadLine();
                        if (input.Equals("Yes"))
                        {
                            eMailAndLinkExist = true;
                            Console.Write("Please,print your cafe's link: ");
                            cafeLink = Console.ReadLine();
                            Console.Write("Please,print your cafe's eMail: ");
                            cafeEmail = Console.ReadLine();
                        }
                        else if (input.Equals("No")) { }
                        else
                        {
                            Console.Write("Please,print Yes or No");
                        }


                        Console.Write("You must set password for your cafe.You cann't change it \nPlease,enter your password (It must be more than 7 characters): ");

                        input = Console.ReadLine();
                        while (input.Length < 8)
                        {
                            Console.Write("Your password has less than 8 characters. Please,enter your password (It must be at least 7 characters):");
                            input = Console.ReadLine();

                        }

                        cafePassword = input;


                        if (eMailAndLinkExist)
                        {
                            cafes.Add(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                cafeLink, cafeEmail, cafePassword));
                            Console.WriteLine("Cafe added");

                            output.WriteLine("------------------------");
                            output.WriteLine(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                cafeLink, cafeEmail, cafePassword));
                            output.Flush();
                        }
                        else
                        {
                            cafes.Add(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                 cafePassword));
                            Console.WriteLine("Cafe added");

                            output.WriteLine("------------------------");
                            output.WriteLine(new Cafe(cafeName, cafeAddress, cafePhoneNumber, openTime, closeTime,
                                cafeLink, cafeEmail, cafePassword));
                            output.Flush();
                        }



                        while (true)
                        {
                            Console.WriteLine("Do you want add another cafe \n Answer \"Yes\" or \"No\" :");
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
                        Console.WriteLine("Please,print the name  and password of cafe,which you want to change:");
                        cafeName = Console.ReadLine();
                        cafePassword = Console.ReadLine();
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
                                    Console.WriteLine("Change cafe name                   Print \" Change Cafe Name\" ");
                                    Console.WriteLine("Change cafe address                Print \"Change Cafe Addres\" ");
                                    Console.WriteLine("Change cafe phone number           Print \"Change Cafe Phone Number\" ");
                                    Console.WriteLine("Change cafe Email                  Print \"Change Email\" ");
                                    Console.WriteLine("Change cafe link                   Print \"Change Link\" ");
                                    Console.WriteLine("If end your work with this caffe   Print \"Finished work with this cafe\" ");
                                    Console.WriteLine("If end your work with all changes  Print \"Finished work with changes\" ");


                                    input = Console.ReadLine().ToLower();

                                    switch (input)
                                    {
                                        case "change cafe name":
                                            {
                                                Console.Write("Print new name:");
                                                cafes[i].ChangeCafeName(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Name was changed");
                                                break;
                                            }

                                        case "change cafe addres":
                                            {
                                                Console.Write("Print new address:");
                                                cafes[i].ChangeCafeAddress(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Address was changed");

                                                break;
                                            }

                                        case "change cafe phone number":
                                            {
                                                Console.Write("Print new phone number:");
                                                cafes[i].ChangeCafePhoneNumber(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Phone number was changed");

                                                break;
                                            }

                                        case "change email":
                                            {
                                                Console.Write("Print new Email:");
                                                cafes[i].ChangeCafeEmail(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Email was changed");

                                                break;
                                            }

                                        case "change link":
                                            {
                                                Console.WriteLine("Print new Link:");
                                                cafes[i].ChangeCafeLink(cafePassword, Console.ReadLine());
                                                Console.WriteLine("Link was changed");

                                                break;
                                            }
                                        case "finished work with this cafe)":
                                            {
                                                Console.WriteLine("Thank you for changes");
                                                doingChanges = false;
                                                break;
                                            }
                                        case ("finished work with changes"):
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
                                Console.WriteLine("Invalid name or password");
                        }


                    }


                    Console.WriteLine("Have you finished your work as Administrator? (Yes or No)");
                    input = Console.ReadLine();
                    if (input.ToLower().Equals("yes"))
                    {
                        imAdmin = false;
                        output.Close();
                    }
                    else if (input.ToLower().Equals("no")) { }
                    else
                        Console.WriteLine("Please,follow instructions! \nAnswer \"Yes\" or \"No\" ");
                }
                //UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRR



                while (imUser)
                {
                    Console.WriteLine("Hello dear user \nHere is our cafes by decreasing rates:");
                    for (int i = 0; i < cafes.Count; i++)
                    {
                        Console.WriteLine(cafes[i].Name);
                    }

                    inputIsFalse = true;
                    Console.WriteLine("Now you can:");
                    while (inputIsFalse)
                    {
                        Console.WriteLine("Search cafe by name                                         Print \"Search by name\"");
                        Console.WriteLine("Search cafe by address                                      Print \"Search by address\"");
                        Console.WriteLine("If you want to create an account                            Print \"Create\"");
                        Console.WriteLine("If you want to grade(You must have an account)              Print \"Grade\"");
                        Console.WriteLine("If you want to write a review(You must have an account)     Print \"Review\"");


                        input = Console.ReadLine().ToLower();
                        switch (input)
                        {
                            case "search by name":
                                {
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
                                                    Console.WriteLine("Do you finish? (Answer \"Yes\" or \"No\")");
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
                                                    Console.WriteLine("Do you finish? (Answer \"Yes\" or \"No\")");
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



                    while (true)
                    {
                        Console.WriteLine("Have you finished your work as user? (Yes or No)");
                        input = Console.ReadLine();
                        if (input.ToLower().Equals("yes"))
                        {
                            imUser = false;
                            break;
                        }
                        else if (input.ToLower().Equals("no")) { break; }
                        else
                            Console.WriteLine("Please,follow instructions! \nAnswer \"Yes\" or \"No\" ");
                    }

                }

            }

        }
    }
}

