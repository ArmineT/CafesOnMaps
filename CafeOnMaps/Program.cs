using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string cafeName, cafeAddress, cafePhoneNumber, cafePassword, cafeLink, cafeEmail;
            string[] hourAndMinute = new string[2];
            TimeSpan openTime, closeTime;
            bool eMailAndLinkExist = false;


            while (true)
            {
                Console.WriteLine("Print \"User\" if you are user \nPrint \"Admin\" if you are administrator ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "Admin":
                        {
                            Console.WriteLine("If you want to add a cafe print \"Add a cafe\" ");
                            Console.WriteLine("If you want to make changes to existing cafe print \"Make changes\" ");
                            input = Console.ReadLine();

                            switch (input)
                            {
                                case "Add a cafe":
                                    {
                                        Console.Write("Please,print your cafe's name: ");
                                        cafeName = Console.ReadLine();
                                        Console.Write("Please,print your cafe's address: ");
                                        cafeAddress = Console.ReadLine();
                                        Console.Write("Please,print your cafe's phone number: ");
                                        cafePhoneNumber = Console.ReadLine();
                                        Console.Write("Please,print your cafe's open time (hh:mm): ");
                                        hourAndMinute = (Console.ReadLine()).Split(':');
                                        openTime = new TimeSpan(Convert.ToInt32(hourAndMinute[0]),
                                            Convert.ToInt32(hourAndMinute[1]), 0);
                                        Console.Write("Please,print your cafe's close time (hh:mm): ");
                                        hourAndMinute = (Console.ReadLine()).Split(':');
                                        closeTime = new TimeSpan(Convert.ToInt32(hourAndMinute[0]),
                                            Convert.ToInt32(hourAndMinute[1]), 0);
                                        Console.Write("Do you have link and mail ? ");
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

                                        Console.Write("You must set password for your cafe.You cann't change it \nPlease,enter your password (It must be more than 7 character): ");
                                    a:
                                        input = Console.ReadLine();
                                        if (input.Length >= 8)
                                        {
                                            cafePassword = input;
                                        }
                                        else
                                        {
                                            Console.Write(" Please,enter your password (It must be at least 7 character):");
                                            goto a;
                                        }
                                        if (eMailAndLinkExist)
                                        {

                                            
                                        }
                                          break;
                                    }
                            }
                            break;
                        }
                    case "User":
                        {

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please,follow instructions!");
                            break;
                        }
                }
            }
        }
    }
}