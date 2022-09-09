using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class DistrictService
    {
        private IDistrictRepository districtRepository { get; set; }
        private ApplicationDbContext dbContext;
        public DistrictService(ApplicationDbContext dbContext, IDistrictRepository districtRepository)
        {
            this.districtRepository = districtRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<District> GetDistrictList(int Id_Province)
        {
            return districtRepository.GetDistrictList(Id_Province);
        }
    }
}
