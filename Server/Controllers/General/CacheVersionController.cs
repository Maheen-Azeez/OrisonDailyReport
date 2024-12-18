using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheVersionController : ControllerBase
    {
        private readonly IConfiguration _config;
        public CacheVersionController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetVersion")]
        public async Task<string> GetVersion()
        {
            string Version = _config.GetValue<string>("Version:VersionNo");
            return Version;
        }
    }
}
