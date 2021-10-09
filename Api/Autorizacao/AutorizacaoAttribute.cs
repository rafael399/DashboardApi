using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace Api.Autorizacao
{
    public class AutorizacaoAttribute : ActionFilterAttribute
    {
        public const string Key = "f90453ec712ce4505cc425e7e881e1d58ea274c3";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string reasonPhrase;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues headerValues);

            if (!string.IsNullOrEmpty(headerValues) && headerValues.FirstOrDefault().ToLower().StartsWith("bearer"))
            {
                var token = headerValues.FirstOrDefault().Substring(7);
                if (token != Key)
                    reasonPhrase = "Chave de acesso é inválida";
                else
                    return;
            }
            else
            {
                reasonPhrase = "Autenticação não encontrada";
            }

            context.Result = new BadRequestObjectResult(reasonPhrase);
        }
    }
}
