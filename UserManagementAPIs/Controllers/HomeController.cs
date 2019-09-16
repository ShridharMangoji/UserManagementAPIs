using System;
using BAL.BalConstants;
using BAL.DbOperation;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPIs.Models;

namespace UserManagementAPIs.Controllers
{
    /// <summary>
    /// Home Related Action Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Add Home data related to User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="home">Home Model</param>
        /// <returns>API Status</returns>
        [HttpPut("AddHome/{id}")]
        public BaseResponse AddHome(long id, HomeRequest home)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddHome(id, home))
                {

                    if (new UserCRUD().IsUserExists(id))
                    {
                        var homeCrud = new HomeCRUD();
                        home.Home.UserId = id;
                        homeCrud.AddHome(home.Home);
                        if (home.Home.Id > 0)
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
                resp.InternalServerError();
            }
            return resp;

        }


        /// <summary>
        /// Update Home model against user id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="home">Updated Home Model</param>
        /// <returns></returns>
        [HttpPut("UpdateHome/{id}")]
        public BaseResponse UpdateHome(long id, HomeRequest home)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateHome(id, home))
                {
                    var homeCrud = new HomeCRUD();
                    if (new UserCRUD().IsUserExists(id) || homeCrud.IsUserHomeExists(home.Home.Id))
                    {
                        home.Home.UserId = id;
                        homeCrud.UpdateHome(home.Home);
                        if (home.Home.Id > 0)
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
                resp.InternalServerError();
            }
            return resp;

        }

    }
}