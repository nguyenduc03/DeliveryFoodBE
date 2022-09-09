using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class WardService
    {
        private IWardRepository WardRepository { get; set; }
        private ApplicationDbContext dbContext;
        public WardService(ApplicationDbContext dbContext, IWardRepository WardRepository)
        {
            this.WardRepository = WardRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Ward> GetWardList(int id)
        {
            return WardRepository.GetWardList( id);
        }
    }
}
