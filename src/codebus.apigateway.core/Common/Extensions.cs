using codebus.apigateway.core.Model;

namespace codebus.apigateway.core.Common
{
    public static class Extensions
    {
        public static AjaxResult ToAjaxResult(this OperationResult result)
        {
            if (result.Succeeded)
                return AjaxResult.Success(result.Message, result.Data);
            return AjaxResult.Error(result.Message, result.Data);
        }
    }
}
