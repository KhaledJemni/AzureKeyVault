using Microsoft.Azure.KeyVault;
using RenaultWebAppTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace RenaultWebAppTest.Controllers
{
    public class EncryptionController : ApiController
    {
        //This Method will do a symetric decryption
        [HttpPost]
        [Route("api/Encryption/Symdecrypt")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Symdecrypt(DecryptInput input)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.EncryptionHelper.GetToken));

            var sec = await kv.GetSecretAsync(WebConfigurationManager.AppSettings["SecretUri"]);

            var decryptedValue = Aes256Encryption.DecryptText(input.Value, sec.Value);

            return Json(new DecryptInput() { Value = decryptedValue });
        }

        //This Method will do a symetric encryption
        [HttpPost]
        [Route("api/Encryption/Symencrypt")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Symencrypt(DecryptInput input)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.EncryptionHelper.GetToken));

            var sec = await kv.GetSecretAsync(WebConfigurationManager.AppSettings["SecretUri"]);

            var decryptedValue = Aes256Encryption.EncryptText(input.Value, sec.Value);

            return Json(new DecryptInput() { Value = decryptedValue });
        }

        //This Method will do an asymetric decryption
        [HttpPost]
        [Route("api/Encryption/Asymdecrypt")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Asymdecrypt(DecryptInput input)
        {
            var encrypted = input.Value;
            string decryptedValue = await Rsa2048Encryption.DecryptText(encrypted);

            return Json(new DecryptInput() { Value = decryptedValue });
        }

        //This Method will do an asymetric encryption
        [HttpPost]
        [Route("api/Encryption/Asymencrypt")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Asymencrypt(DecryptInput input)
        {
            var encrypted = input.Value;
            string decryptedValue = await Rsa2048Encryption.EncryptText(encrypted);

            return Json(new DecryptInput() { Value = decryptedValue });
        }
    }

    public class DecryptInput
    {
        public string Value { get; set; }
    }
}