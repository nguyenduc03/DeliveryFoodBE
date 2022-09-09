using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class ProvinceService
    {
        private IProvinceRepository ProvinceRepository { get; set; }
        private ApplicationDbContext dbContext;
        public ProvinceService(ApplicationDbContext dbContext, IProvinceRepository ProvinceRepository)
        {
            this.ProvinceRepository = ProvinceRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Province> GetProvinceList()
        {
            return ProvinceRepository.GetProvinceList();
        }
    }
}
