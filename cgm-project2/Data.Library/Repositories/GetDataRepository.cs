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
    public class GetDataRepository : IGetDataRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public GetDataRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public bool IfUserExists(int userId)
        {
            return _dbContext.User.Find(userId) != null;
        }

        public bool IfTitleExists(int userId)
        {
            return _dbContext.Title.Find(userId) != null;
        }


        public int GetLastTitleId(int creatorId)
        {
            return _dbContext.Title.Where(t => t.CreatorId == creatorId).ToList().LastOrDefault().TitleId;
        }

        public int GetNumberOfCategories(int titleId)
        {
            return _dbContext.Category.Where(c => c.TitleId == titleId).Count();
        }

    }
}
