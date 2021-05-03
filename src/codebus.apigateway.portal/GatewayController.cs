using Microsoft.AspNetCore.Mvc;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Configuration.Setter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codebus.apigateway.portal
{
    [Route("[Controller]/[Action]")]
    public class GatewayController:ControllerBase
    {
        private readonly IFileConfigurationRepository _repo;
        private readonly IFileConfigurationSetter _setter;

        public GatewayController(IFileConfigurationRepository repo, IFileConfigurationSetter setter, IServiceProvider provider)
        {
            _repo = repo;
            _setter = setter;
        }

        public async Task<IActionResult> Get()
        {
            var response = await _repo.Get();

            if (response.IsError)
            {
                return new BadRequestObjectResult(response.Errors);
            }

            return new OkObjectResult(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FileConfiguration fileConfiguration)
        {
            try
            {
                var response = await _setter.Set(fileConfiguration);

                if (response.IsError)
                {
                    return new BadRequestObjectResult(response.Errors);
                }

                return new OkObjectResult(fileConfiguration);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult($"{e.Message}:{e.StackTrace}");
            }
        }
    }
}
