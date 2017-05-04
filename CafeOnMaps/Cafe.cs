using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Cafes

{

    internal class Cafe : IComparable<Cafe>
    {
        private string password = "";
        private string link = "Cafe don't have a link, sorry.";
        private string email = "Cafe don't have an email, sorry.";
        private TimeSpan openTime;
        private TimeSpan closeTime;
        private List<int> grades = new List<int>();


        public string Password
        {
            get
            {
                return password;
            }

            private set
            {
                if (value.Length < 8)
                {
                    throw new Exception("Invalid password");
                }
                else
                {
                    password = value;
                }
            }
        }
        public string Address { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Link { get { return link; } private set { } }
        public string eMail { get { return email; } private set { } }
        public GeoCoordinate Coordinates { get; private set; }




        public Cafe(string name, string adress, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string password)
        {
            Name = name;
            Address = adress;
            phonenumber = PhoneNumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.Password = password;
        }


        public Cafe(string name, string adress, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string link, string eMail,
            string password)
        {
            Name = name;
            Address = adress;
            phonenumber = PhoneNumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.link = link;
            email = eMail;
            this.Password = password;
        }


        public void AddGrade(int grade)
        {
            grades.Add(grade);
        }

        public decimal Rate()
        {
            int sum = 0;
            foreach (int grade in grades)
            {
                sum += grade;
            }
            return (decimal)sum / grades.Count;
        }



        public bool IsOpenNow()
        {
            if (TimeSpan.Compare(openTime, DateTime.Now.TimeOfDay) >= 0 && TimeSpan.Compare(closeTime, DateTime.Now.TimeOfDay) <= 0)
                return true;
            else
                return false;
        }




        public string OpenTimes()
        {
            return openTime + "-" + closeTime;
        }

        public void ChangeCafeName(string password, string newName)
        {

            if (this.Password.Equals(password))
            {
                this.Name = newName;
            }

        }

        public void ChangeCafeAddress(string password, string newAddress)
        {

            if (this.Password.Equals(password))
            {
                this.Address = newAddress;
            }
        }


        public void ChangeCafePhoneNumber(string password, string newPhoneNumber)
        {

            if (this.Password.Equals(password))
            {
                this.PhoneNumber = newPhoneNumber;
            }
        }

        public void ChangeCafeLink(string password, string newLink)
        {

            if (this.Password.Equals(password))
            {
                this.Link = newLink;
            }
        }


        public void ChangeCafeEmail(string password, string newEmail)
        {

            if (this.Password.Equals(password))
            {
                this.eMail = newEmail;
            }

        }



        public void ChangeCafeOpenTime(string password, TimeSpan newOpenTime)
        {

            if (this.Password.Equals(password))
            {
                this.openTime = newOpenTime;
            }
        }


        public void ChangeCafeCloseTime(string password, TimeSpan newCloseTime)
        {
            if (this.Password.Equals(password))
            {
                this.closeTime = newCloseTime;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0} \n  Adress: {1} \n Phone Number: {2}  \n  Link: {3} \n   eMail: {4} \n",
                Name, Address, PhoneNumber, link, email) 
                + String.Format("Open Time: {0} + \n Close Time: {1}", openTime, closeTime);
        }

        public int CompareTo(Cafe other)
        {
            if (Rate() > other.Rate())
                return 1;
            else if (Rate() == other.Rate())
                return 0;
            else
                return -1;
        }
    }
}















