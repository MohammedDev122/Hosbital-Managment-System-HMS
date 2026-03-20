using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace HosbitalBussinessLayer
{
    static public class clsProtect1
    {


        static public string Compute(string input)
        {


            using (SHA256 Hashing = SHA256.Create()) {


                byte[] HashedInput=Hashing.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(HashedInput).Replace("-","").ToLower();
            
            
            
            }
        }










    }
}
