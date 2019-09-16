using System;
using BAL.BalConstants;
using BAL.DbOperation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagementAPIs.Models;


namespace UserManagementAPIs.Controllers
{
    /// <summary>
    /// Kid Related Action Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KidController : ControllerBase
    {
        private ILog logger;

        //public KidController()
        //{

        //}

        public KidController(ILog logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Add Kid
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="kid">Kid Model</param>
        /// <returns>API status</returns>
        [HttpPut("AddKid/{id}")]
        public BaseResponse AddKid(long id, [FromBody] KidRequest kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddKid(id, kid))
                {
                    if (new UserCRUD().IsUserExists(id))
                    {
                        var kidCrud = new KidCRUD();
                        kid.Kid.UserId = id;
                        kidCrud.AddKid(kid.Kid);
                        if (kid.Kid.Id > 0)
                        {

                            resp.OK();
                        }
                        else
                        {
                            resp.Conflict();
                        }
                    }
                    else
                    {
                        resp.Conflict();
                        resp.HttpStatusMessage = Constants.InValidUser;
                    }
                }
                else
                {
                    resp.BadRequest();
                }
            }
            catch (Exception es)
            {
                string req = JsonConvert.SerializeObject(kid);
                logger.Error(string.Format("AddKid, UserID={0}, Req={1}", id, req));
                logger.Error("AddKid " + es.StackTrace);
                resp.InternalServerError();
            }
            return resp;

        }


        /// <summary>
        /// Update Kid Model against user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="kid">Updated Kid Model</param>
        /// <returns>API status</returns>
        [HttpPut("UpdateKid/{id}")]
        public BaseResponse UpdateKid(long id, KidRequest kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateKid(id, kid))
                {
                    var kidCrud = new KidCRUD();
                    if (new UserCRUD().IsUserExists(id) || kidCrud.IsUserKidExists(kid.Kid.Id))
                    {
                        if (kidCrud.IsUserKidExists(id, kid.Kid.Id))
                        {
                            kid.Kid.UserId = id;
                            kidCrud.UpdateKid(kid.Kid);
                            if (kid.Kid.Id > 0)
                            {
                                resp.OK();
                            }
                            else
                            {
                                resp.Conflict();
                            }
                        }
                        else
                            resp.Unauthorized();

                    }
                    else
                    {
                        resp.Conflict();
                    }
                }
                else
                {
                    resp.BadRequest();
                }
            }
            catch (Exception es)
            {
                string req = JsonConvert.SerializeObject(kid);
                logger.Error(string.Format("UpdateKid, UserID={0}, Req={1}", id, req));
                logger.Error("UpdateKid " + es.StackTrace);
                resp.InternalServerError();
            }
            return resp;

        }

    }
}