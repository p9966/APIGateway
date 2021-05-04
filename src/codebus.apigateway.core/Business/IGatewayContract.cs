using codebus.apigateway.core.Model;
using Ocelot.Configuration.File;
using System.Threading.Tasks;

namespace codebus.apigateway.core.Business
{
    public interface IGatewayContract
    {
        Task<OperationResult> Get();

        Task<OperationResult> Post(FileConfiguration fileConfiguration);
    }
}
