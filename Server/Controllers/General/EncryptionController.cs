using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityService;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase, IDisposable
    {
        IWebHostEnvironment _environment;
        public EncryptionController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
                //_repository.Dispose();
            }
        }
        [HttpGet]
        [Route("Encrypt")]
        public Task<string> GetEncryption(string Text)
        {
            Security security = new Security();
            return Task.FromResult(security.Encrypt(Text));
        }
        [HttpGet]
        [Route("Decrypt")]
        public Task<string> GetDecryption(string Text)
        {
            Security security = new Security();
            return Task.FromResult(security.Decrypt(Text));
        }
        [HttpGet]
        [Route("ConEncrypt")]
        public Task<string> GetConEncryption(string Text)
        {
            return Task.FromResult(ClsEncrypt.Encrypt(Text, "", true));
        }
        [HttpGet]
        [Route("ConDecrypt")]
        public Task<string> GetConDecryption(string Text)
        {
            return Task.FromResult(ClsEncrypt.Decrypt(Text, "", true));
        }
    }
}
