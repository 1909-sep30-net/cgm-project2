using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class User
    {
        static int    UserId    { get; set; }
        static string FirstName { get; set; }
        static string LastName { get; set; }
        static string Street    { get; set; }
        static string City      { get; set; }
        static string State     { get; set; }
        static string Zip       { get; set; }
        static bool   Admin     { get; set; }

        public User()
        {

        }

        public User(int uid, string fn, string ln, string st, string c, string sta, string z)
        {
            UserId = uid;
            FirstName = fn;
            LastName = ln;
            Street = st;
            City = c;
            State = sta;
            Zip = z;
        }





    }
}
