namespace codebus.apigateway.core.DependencyInjection
{
    public class GatewayConfiguration
    {
        public bool AutoUpdate { get; set; } = false;

        public int UpdateInterval { get; set; }
    }
}
