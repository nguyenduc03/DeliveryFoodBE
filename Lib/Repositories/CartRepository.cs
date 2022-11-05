using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Services;
using IronBarCode;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Account = CloudinaryDotNet.Account;

namespace Lib.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        List<Cart> GetCartlList();
        List<Cart> GetCartlList(string SDT);
        string GetQR(string userName,string passwork );
    }
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<Cart> GetCartlList()
        {
            
            throw new NotImplementedException();
        }

        public List<Cart> GetCartlList(string SDTInput)
        {
            try
            {

                var query = _dbcontext.Cart.Where(s => s.SDT == SDTInput);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void CleanCart (string sdt)
        {
            List<Cart> carts = GetCartlList(sdt);
            foreach (var item in carts)
            {
                _dbcontext.Cart.Remove(item);
                _dbcontext.SaveChanges();
            }
        }

        public string GetQR(string username,string passwork )
        {

            // create QR code 

            string code = "Hoten: Nguyen duc tri";
            var qrCode = QRCodeWriter.CreateQrCodeWithLogo(code, "E:\\QRCode\\logo.png");
            string path = "E:\\QRCode\\QR"+ DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()+".png";
            qrCode.SaveAsImage(path);
            // up QR code to clound
            return UploadIMG(path);
        }
        public static Cloudinary cloudinary;
        public const string CLOUD_NAME = "dtri2001";
        public const string API_KEY = "765345259495324";
        public const string API_SECRET = "xZYbElrhPLq784iYKHPNllFOY_8";

        private string UploadIMG(string path)
        {
            string link = "";
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(path)
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                 link = uploadResult.Uri.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return link;
        }
    }
}
