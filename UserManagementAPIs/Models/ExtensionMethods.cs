using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPIs.Models
{
    public static class ExtensionMethods
    {
        public static void OK(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.OK;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.OK.ToString();

        }

        public static void Conflict(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.Conflict.ToString();

        }
        public static void BadRequest(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.BadRequest.ToString();

        }

        public static void InternalServerError(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.InternalServerError.ToString();

        }

        public static void NotFound(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.NotFound.ToString();

        }

        public static void NoContent(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.NoContent.ToString();

        }
    }
}
