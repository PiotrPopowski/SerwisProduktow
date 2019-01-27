using SerwisProduktow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SerwisProduktow.WebUI.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(ExceptionHandlerContext context)
        {
            string reason="BadRequest";
            string message = context.Exception.Message;
            foreach (PropertyInfo nestedProp in typeof(WojtekCodes).GetProperties())
            {
                if(nestedProp.GetValue(null,null).ToString()==message)
                {
                    reason = nestedProp.Name;
                }
            }

            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = message,
                ReasonPhrase = reason
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }
            public string ReasonPhrase { get; set; }
            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                response.ReasonPhrase = ReasonPhrase;
                return Task.FromResult(response);
            }
        }
    }
}