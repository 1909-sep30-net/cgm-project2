using System;
using System.Collections.Generic;
using System.Text;
//using System.Collections.IEnumerable;

namespace Logic.Library.Models
{
    public class User
    {
        public int    UserId    { get; set; }

        private string _firstName;
        public string FirstName 
        { 
            get => _firstName;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First Name must not be empty.", nameof(value));
                }
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _firstName;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last Name must not be empty.", nameof(value));
                }
                _firstName = value;
            }
        }
        public string Street    { get; set; }
        public string City      { get; set; }
        public string State     { get; set; }
        public string Zip       { get; set; }
        public bool   Admin     { get; set; }

        //public User()
        //{

        //}

        //public User(int uid, string fn, string ln, string st, string c, string sta, string z)
        //{
        //    UserId = uid;
        //    FirstName = fn;
        //    LastName = ln;
        //    Street = st;
        //    City = c;
        //    State = sta;
        //    Zip = z;
        //}





    }
}
