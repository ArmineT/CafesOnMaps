using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Cafes
{

    class Cafe : IComparable<Cafe>
    {
       
        //  Fields  //

        private string password = "";
        private string link = "Cafe doesn't have a link, sorry.";
        private string email = "Cafe doesn't have an email, sorry.";
        private List<decimal> grades = new List<decimal>();
        public List<string> Review = new List<string>();
        public GeoCoordinate Geo { get; set; }
        public TimeSpan openTime { get; private set; }
        public TimeSpan closeTime { get; private set; }

        // End Fields   //

        // Proparties   //

        public string Password
        {
            get
            {
                return password;
            }

            private set
            {
                if (value.Length < 7)
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
        public string Link { get { return link; } private set { link = value; } }
        public string eMail { get { return email; } private set { email = value; } }
        public GeoCoordinate Coordinates { get; private set; }

        // End Proparties   //

        // Constructors //

        public Cafe(string name, string adress, GeoCoordinate place, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string password)
        {
            Name = name;
            Address = adress;
            PhoneNumber = phonenumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.Password = password;
            this.Geo = place;
        }


        public Cafe(string name, string adress, GeoCoordinate place, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string link, string eMail,
            string password)
        {
            Name = name;
            Address = adress;
            PhoneNumber = phonenumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.link = link;
            email = eMail;
            this.Password = password;
            Geo = place;
        }

        //  End Constructors    //

        //  Methods //

        public void AddGrade(decimal grade)
        {
            grades.Add(grade);
        }

        public decimal Rate()
        {
            decimal sum = 0;
            if (grades.Count == 0)
                return 0;
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
                this.link = newLink;
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

        public void ChangeGeoCoordinates(string password, GeoCoordinate newGeo)
        {
            if (this.Password.Equals(password))
            {
                this.Geo = newGeo;
            }
        }

        public void ChangeCafePassword(string oldPassword, string newPassword)
        {
            if (this.Password.Equals(oldPassword))
            {
                this.Password = newPassword;
            }
        }

        public override string ToString()
        {
            string returnValue = String.Format("Name: {0} \nAdress: {1} \nPhone Number: {2}  \nLink: {3} \neMail: {4} \n",
                Name, Address, PhoneNumber, link, email)
                + String.Format("Open Time: {0}  \nClose Time: {1} \nRate: {2}\nAll reviews", openTime, closeTime, this.Rate());

            foreach (String rev in Review)
            {
                returnValue += "\n" + rev;
            }
            return returnValue;
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

        //  End Methods //
    }
}















