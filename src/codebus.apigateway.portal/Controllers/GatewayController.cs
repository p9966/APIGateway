using codebus.apigateway.core.Business;
using codebus.apigateway.core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using codebus.apigateway.core.Common;
using Ocelot.Configuration.File;

namespace codebus.apigateway.portal.Controllers
{
    [Route("[Controller]/[Action]")]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayContract _gatewayContract;

        public GatewayController(IServiceProvider serviceProvider)
        {
            _gatewayContract = serviceProvider.GetService<IGatewayContract>();
        }

        [HttpGet]
        public async Task<AjaxResult> Get()
        {
            var result = await _gatewayContract.Get();
            return result.ToAjaxResult();
        }

        [HttpPost]
        public async Task<AjaxResult> Post([FromBody] FileConfiguration fileConfiguration)
        {
            var result = await _gatewayContract.Post(fileConfiguration);
            return result.ToAjaxResult();
        }
    }
}
