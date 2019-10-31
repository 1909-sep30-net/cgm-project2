using System;
using System.Collections.Generic;
using System.Text;
using DatLib = Data.Library;
using LogLib = Logic.Library;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Library.Repositories
{
    public class TitleRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;

        public TitleRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public void AddNewTitle(LogLib.Models.Title title) // Create New Title and Add into DB
        {
            DatLib.Entities.Title newTitle = Mapper.MapTitle(title);
            _dbContext.Add(newTitle);
        }
        public List<LogLib.Models.Title> DisplayAllTitles() //This will be called to Display all Titles
        {
            IQueryable<DatLib.Entities.Title> titles = _dbContext.Title
                .AsNoTracking();

            return titles.Select(Mapper.MapTitle).ToList();

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
