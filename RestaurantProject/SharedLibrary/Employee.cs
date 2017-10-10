using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Employee
    {
       public int EmpId { get; set; }
        public string _fName;
        public string _lName;
        public string Phone { get; set; }
        public string SIN { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Password { get; set; }

        public string FName
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


    }
}
