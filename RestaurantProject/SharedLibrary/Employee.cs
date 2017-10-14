using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SharedLibrary
{
    public class Employee
    {
       public int EmpId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string SIN { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Password { get; set; }

      /*  public string FName
        {
            get { return _fName; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Name must be between 2 and 30 characters long");
                }
                _fName = value;
            }
        }
        public string LName
        {
            get { return _lName; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Name must be between 2 and 30 characters long");
                }
                _lName = value;
            }
        }

        public string Phone {
        get { return _phone; }
            set {
               
                Regex regex = new Regex(@"[0-9]{10}");
                if (regex.IsMatch(value))
                {
                    value = _phone;
                }
               
                else
                {
                    throw new ArgumentOutOfRangeException("Phone must be 10 degit");
                }

            }
        }
        public string SIN
        {
            get { return _sin; }
            set
            {
                Regex regex = new Regex(@"[0-9]{9}");
                Match match = regex.Match(value);
                if (!match.Success)
                {
                    throw new ArgumentOutOfRangeException("Phone must be 9 degit");
                }
                else {
                    value = _sin;
                }
            }
        }*/


    }
}
