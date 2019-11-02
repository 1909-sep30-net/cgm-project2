using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// This function takes the First and Last names of a User, searches the Users Table and returns an IEnumerable of User Objects.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public IEnumerable<Logic.Library.Models.User> SearchUsers(string firstName = null, string lastName = null);

        /// <summary>
        /// This function takes a User, searches the Users Table and inserts it into the DB.
        /// </summary>
        /// <param name="user"></param>
        public void RegisterNewUser(LogLib.Models.User user);

        public LogLib.Models.User CreateUser(string firstName, string lastName, string street, string city, string state, string zip, bool admin);

        /// <summary>
        /// This saves the state of the DB
        /// </summary>
        public void Save();

        public void DeleteUser(int id);
    }
}
