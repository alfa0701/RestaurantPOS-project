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
        private string _fName;
        private string _lName;
        private string _phone;
        private string _street;
        private string _city;
        private string _postal;
        private string _SIN;
        public string Password { get; set; }

        
        public string FName
        {
            get { return _fName; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                  
                    throw new ArgumentOutOfRangeException("FirstName must be between 2 and 50 characters long");
                    
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
                    throw new ArgumentOutOfRangeException("LastName must be between 2 and 50 characters long");
                }
                _lName = value;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if ((Regex.Match(value, @"^(\+[0-9]{10})$").Success))
                {
                    throw new ArgumentOutOfRangeException("Phone number must be 10 digit");
                }

                _phone = value;
            }
        }
        public string Postal
        {
            get { return _postal; }
            set
            {
                if (Regex.Match(value, @"^\d[A-Z][0-9][A-Z][0-9][A-Z][0-9]$").Success)
                {
                    throw new ArgumentOutOfRangeException("Postal Code must be 10 digit");
                }

                _postal = value;
            }
        }
        public string SIN
        {
            get { return _SIN; }
            set
            {
                if ((Regex.Match(value, @"^(\+[0-9]{9})$").Success) )
                {
                    throw new ArgumentOutOfRangeException("Sin number must be 9 digit");
                }

                _SIN = value;
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Street must be between 2 and 50 characters long");
                }
                _city = value;
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Street must be between 2 and 50 characters long");
                }
                _street = value;
            }
        }



    }

}

