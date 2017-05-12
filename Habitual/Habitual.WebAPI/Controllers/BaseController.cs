using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Habitual.WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected static readonly string CONNECTION_STRING = "Database=habitual;Data Source=us-cdbr-azure-central-a.cloudapp.net;User Id=b3b19672531a6d;Password=2c9a3200";
        protected HttpResponseMessage BuildSuccessResult(HttpStatusCode statusCode)
        {
            return this.Request.CreateResponse(statusCode);
        }

        protected HttpResponseMessage BuildSuccessResult(HttpStatusCode statusCode, object data)
        {
            return data != null ? this.Request.CreateResponse(statusCode, data) : this.Request.CreateResponse(statusCode);
        }
        
        protected HttpResponseMessage BuildSuccessResultList<T>(HttpStatusCode statusCode, IEnumerable<T> data)
        {
            return data != null ? this.Request.CreateResponse<IEnumerable<T>>(statusCode, data) : this.Request.CreateResponse(statusCode);
        }

        protected HttpResponseMessage BuildErrorResult(HttpStatusCode statusCode, string message = "Error")
        {
            return BuildErrorResult(statusCode, message);
        }
    }
}
