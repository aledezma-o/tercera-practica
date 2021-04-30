using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerceraPracticaWEBAPIConfiguration.Controllers
{
    [ApiController]
    [Route("/api/info")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _config; // variables de config comienzan con "_"
        public InfoController(IConfiguration config) 
        // le inyectamos la configuracion que utlilizaremos
        {
            _config = config;
        }

        [HttpGet]
        public string GetInfo()
        {
            // 9. The created method should write in the console the “Connection string”.
            Console.WriteLine(_config.GetConnectionString("Database"));
            // 8. The created method should return a string with: “Project Title”
            // and “Environment Name” from settings.
            return _config.GetSection("Project")
                .GetSection("Title").Value +
                _config.GetSection("Environment")
                .GetSection("Name").Value;
        }
    }
}
