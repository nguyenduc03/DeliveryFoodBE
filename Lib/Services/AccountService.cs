using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class AccountService
    {
        private IAccountRepository AccountRepository { get; set; }
        private ApplicationDbContext dbContext;
        public AccountService(ApplicationDbContext dbContext, IAccountRepository AccountRepository) {
            this.AccountRepository = AccountRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        
        public Account Login(string SDT,string password)
        {
            return AccountRepository.GetAccount(SDT, HashMD5(password));
        }

        private string HashMD5 (string input)
        {
            try
            {

                MD5 mh = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = mh.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertAccount(Account st) {
            try
            {
                st.Password = HashMD5(st.Password);
                dbContext.Account.Add(st);
                Save();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public string UpdateAccount(Account st)
        {
            try
            {
           //     st.Password = HashMD5(st.Password);

               Account temp =  dbContext.Account.Find(st.SDT);
               if (temp == null)
                {
                    return "false";
                }else
                {

                    temp.Address = st.Address;
                    temp.Avatar = st.Avatar;
                    temp.Password = st.Password;
                    temp.Name = st.Name;
                    Save();
                    return "Done";
                }
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
    }
}
