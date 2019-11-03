using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatLib = Data.Library;
using LogLib = Logic.Library;
using Logic.Library.Interfaces;


namespace Data.Library.Repositories
{
    public class TakeAQuizRepository : ITakeAQuizRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public TakeAQuizRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<LogLib.Models.Title> GetQuizByNameOrId(int Id = -1, string title = null)
        {
            IQueryable<Entities.Title> titles = _dbContext.Title.AsNoTracking();

            if (Id != -1)
            {
                titles = titles.Where(i => i.TitleId == Id);
            }
            if (title != null)
            {
                titles = titles.Where(i => i.TitleString == title);
            }

            return titles.Select(Mapper.MapTitle);
        }


        /// <summary>
        /// This saves the state of the DB
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
