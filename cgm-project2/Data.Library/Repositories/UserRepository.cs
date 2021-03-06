﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatLib = Data.Library;
using LogLib = Logic.Library;
using Logic.Library.Interfaces;

namespace Data.Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public UserRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// This function takes the First and Last names of a User, searches the Users Table and returns an IEnumerable of User Objects.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public IEnumerable<LogLib.Models.User> SearchUsers(string firstName = null, string lastName = null)
        {
            IQueryable<Entities.User> users = _dbContext.User.AsNoTracking();//'AsNoTracking()' is used to prevent caching

            if(firstName != null)
            {
                users = users.Where(u => u.FirstName == firstName);
            }
            if(lastName != null)
            {
                users = users.Where(u => u.LastName == lastName);
            }
            return users.Select(Mapper.MapUser);//Select automatically runs each item in users through the Mapper.
        }

        /// <summary>
        /// This function takes a User, searches the Users Table and inserts it into the DB.
        /// </summary>
        /// <param name="user"></param>
        public void RegisterNewUser(LogLib.Models.User user)
        {
            Entities.User newUser = Mapper.MapUser(user);
            _dbContext.Add(newUser);
        }

        public LogLib.Models.User CreateUser(string firstName, string lastName, string street, string city, string state, string zip, bool admin)
        {
            return new LogLib.Models.User(0, firstName, lastName, street, city, state, zip, admin);
        }

        /// <summary>
        /// This saves the state of the DB
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            
            var user = _dbContext.User.Where(u => u.UserId == id).FirstOrDefault();
            try
                { _dbContext.User.Remove(user); }
            catch(ArgumentNullException ex)
                { throw new ArgumentNullException(); }

        }
    }
}
