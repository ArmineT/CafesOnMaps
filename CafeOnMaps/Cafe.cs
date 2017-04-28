using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace CafeOnMaps
{
    class Cafe
    {
        private string link = "Cafe don't have a link, sorry.";
        private string email = "Cafe don't have an email, sorry.";
        private TimeSpan openTime;
        private TimeSpan closeTime;
        private List<int> grades = new List<int>();
        private string password;


        public string Adress { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        private static List<Cafe> Cafes { get; set; }
        public string Link { get { return link; } private set { } }
        public string eMail { get { return email; } private set { } }
        public GeoCoordinate Coordinates { get; set; }


        static Cafe()
        {
            Cafes = new List<Cafe>();
        }

        public Cafe(string name, string adress, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string password)
        {
            Name = name;
            Adress = adress;
            phonenumber = PhoneNumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.password = password;
            Cafes.Add(new Cafe(name, adress, phonenumber, openTime, closeTime, password));
        }

        public Cafe(string name, string adress, string phonenumber, TimeSpan openTime, TimeSpan closeTime, string link, string eMail,
            string password)
        {
            Name = name;
            Adress = adress;
            phonenumber = PhoneNumber;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.link = link;
            email = eMail;
            this.password = password;
            Cafes.Add(new Cafe(name, adress, phonenumber, openTime, closeTime, link, eMail, password));
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

        public Cafe SearchCafeByName(string name)
        {
            foreach (Cafe cafe in Cafes)
            {
                if (cafe.Name.Equals(name))
                {
                    return cafe;
                }
            }
            return null;
        }

        public bool IsOpenNow()
        {
            if (TimeSpan.Compare(openTime, DateTime.Now.TimeOfDay) >= 0 && TimeSpan.Compare(closeTime, DateTime.Now.TimeOfDay) <= 0)
                return true;
            else
                return false;
        }

        public void SetLinkAndMail(string link, string eMail)
        {
            Link = link;
            this.eMail = eMail;

        }

        public List<Cafe> ShowAllCafes()
        {
            return Cafes;
        }

        public string OpenTimes()
        {
            return openTime + "-" + closeTime;
        }

        public static void ChangeCafeName(string cuurentName, string password, string newName)
        {
            foreach (Cafe cafe in Cafes)
            {
                if (cafe.Name.Equals(cuurentName))
                {
                    if (cafe.password.Equals)
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0} \n  Adress: {1} \n Phone Number: {2}  \n  Link: {3} \n   eMail: {4} \n",
                Name, Adress, PhoneNumber, link, email) + String.Format("Open Time: {0} + \n Close Time: {1}", openTime, closeTime);
        }
    }
}















