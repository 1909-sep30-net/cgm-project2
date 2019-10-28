using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    class Users
    {
        static int    UserId    { get; set; }
        static string FirstName { get; set; }
        static string LaststName { get; set; }
        static string Street    { get; set; }
        static string City      { get; set; }
        static string State     { get; set; }
        static string Zip       { get; set; }
        static bool   Admin     { get; set; }

        public Users()
        {

        }

        public Users(int uid, string fn, string ln, string st, string c, string sta, string z)
        {
            UserId = uid;
            FirstName = fn;
            LaststName = ln;
            Street = st;
            City = c;
            State = sta;
            Zip = z;
        }





    }
}
