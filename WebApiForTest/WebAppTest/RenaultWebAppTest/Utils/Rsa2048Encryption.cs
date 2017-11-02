using Microsoft.Azure.KeyVault;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace RenaultWebAppTest.Utils
{
    public class Rsa2048Encryption
    {
        public async static Task<string> EncryptText(string input)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.EncryptionHelper.GetToken));
            var keyIdentifier = WebConfigurationManager.AppSettings["PfxKeyUri"];



            var encrypted = await kv.EncryptAsync(keyIdentifier, "RSA-OAEP", Encoding.UTF8.GetBytes(input));
            var str = Convert.ToBase64String(encrypted.Result);

            return str;

        }

        public async static Task <string> DecryptText(string input)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.EncryptionHelper.GetToken));
          
            var keyIdentifier = WebConfigurationManager.AppSettings["PfxKeyUri"];
            var decryptedData = await kv.DecryptAsync(keyIdentifier, "RSA-OAEP",Convert.FromBase64String(input));
            var decryptedText = Encoding.UTF8.GetString(decryptedData.Result);

            return decryptedText;
        }
    }

}
