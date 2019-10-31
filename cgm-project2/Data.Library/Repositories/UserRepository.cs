using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatLib = Data.Library;
using LogLib = Logic.Library;

namespace Data.Library.Repositories
{
    public class UserRepository
    {

        private readonly Entities.ecgbhozpContext _dbContext;

        public UserRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Logic.Library.Models.User> SearchUsers(string firstName = null, string lastName = null)
        {
            IQueryable<Entities.User> users = _dbContext.User.AsNoTracking();//to prevent caching

            if(firstName != null)
            {
                users.Where(u => u.FirstName == firstName);
            }
            if(lastName != null)
            {
                users.Where(u => u.LastName == lastName);
            }

            return users.Select(Mapper.MapUser);//Select automatically runs each item in users through the Mapper.
        }

        public void RegisterNewUser(LogLib.Models.User user)
        {
            DatLib.Entities.User newUser = Mapper.MapUser(user);
            _dbContext.Add(newUser);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }





    }
}
