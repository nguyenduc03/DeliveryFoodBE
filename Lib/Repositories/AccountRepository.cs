using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccount();
       Account GetAccount(string SDT, string Password);
    }
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public Account GetAccount(string SDT,string Password ) {
            try
            {
                var query = _dbcontext.Account.Where(s => s.SDT == SDT && Password == s.Password);
                return (Account)query;
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        Account IAccountRepository.GetAccount()
        {
            throw new NotImplementedException();
        }

        Account IAccountRepository.GetAccount(string SDT, string Password)
        {
            try
            {
                try
                {
                    var query = _dbcontext.Account.FirstOrDefault(s => s.SDT == SDT && Password == s.Password);
                    return (Account)query;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

    }
}
