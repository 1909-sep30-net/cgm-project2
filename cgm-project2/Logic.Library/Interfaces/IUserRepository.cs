using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<Logic.Library.Models.User> SearchUsers(string firstName = null, string lastName = null);

        public void RegisterNewUser(LogLib.Models.User user);
        public void Save();
    }
}
