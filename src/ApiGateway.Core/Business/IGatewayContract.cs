using ApiGateway.Core.Model;
using Ocelot.Configuration.File;
using System.Threading.Tasks;

namespace ApiGateway.Core.Business
{
    public interface IGatewayContract
    {
        Task<OperationResult> Get();

        Task<OperationResult> Post(FileConfiguration fileConfiguration);
    }
}
