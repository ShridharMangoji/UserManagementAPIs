using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPIs.Models
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// on API Success
        /// </summary>
        /// <param name="resp">Successful API status</param>
        public static void OK(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.OK;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.OK.ToString();

        }
        /// <summary>
        /// Mis Match of data
        /// </summary>
        /// <param name="resp">Conflict API status</param>
        public static void Conflict(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.Conflict.ToString();

        }


        /// <summary>
        /// Unauthorization of data
        /// </summary>
        /// <param name="resp">Unauthorized API status</param>
        public static void Unauthorized(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.Unauthorized.ToString();

        }
        /// <summary>
        ///If request didn't meet the standards
        /// </summary>
        /// <param name="resp">Badrequest API status</param>
        public static void BadRequest(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.BadRequest.ToString();

        }

        /// <summary>
        ///On server side errors
        /// </summary>
        /// <param name="resp">Internal server error API status</param>
        public static void InternalServerError(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.InternalServerError.ToString();

        }

        /// <summary>
        /// If required element is not present
        /// </summary>
        /// <param name="resp">Not found API status</param>

        public static void NotFound(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.NotFound.ToString();

        }



        /// <summary>
        /// If there are no values to display
        /// </summary>
        /// <param name="resp">No Content API status</param>
        public static void NoContent(this BaseResponse resp)
        {
            resp.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
            resp.HttpStatusMessage = System.Net.HttpStatusCode.NoContent.ToString();

        }
    }
}
