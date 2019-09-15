using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.DbModels;
using BAL.DbOperation;
using UserManagementAPIs.Models;
using System.Net;
using BAL.BalConstants;
using System;

namespace UserManagementAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public UserListResponse GetUser()
        {
            UserListResponse response = new UserListResponse();
            try
            {
                var result = new UserCRUD().GetUsers();
                if (result.Count == 0)
                {
                    response.NoContent();
                }
                else
                {
                    response.OK();
                    response.User = result;
                }
            }
            catch
            {
                response.InternalServerError();
            }
            return response;
        }

        [HttpGet("{id}")]
        public UserResponse GetUser(long id)
        {
            UserResponse response = new UserResponse();
            try
            {
                if (ValidateRequest.GetUser(id))
                {
                    var result = new UserCRUD().GetUser(id);
                    if (result == null)
                    {
                        response.NotFound();
                    }
                    else
                    {
                        response.OK();
                        response.User = result;
                    }
                }
                else
                {
                    response.BadRequest();
                }
            }
            catch
            {
                response.InternalServerError();
            }
            return response;
        }

        [HttpPost("AddUser")]
        public BaseResponse AddUser(UserRequest user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddUser(user))
                {
                    new UserCRUD().AddUser(user.User);
                    if (user.User.Id > 0)
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
                    resp.BadRequest();
                }
            }
            catch(Exception es)
            {
                resp.InternalServerError();
            }
            return resp;

        }

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
                        kidCrud.AddKid(kid.Kid);
                        if (kid.Kid.Id > 0)
                        {
                            kidCrud.MapUserKid(kid.Kid.Id, id);
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
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }

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
                        homeCrud.AddHome(home.Home);
                        if (home.Home.Id > 0)
                        {
                            homeCrud.MapUserHome(home.Home.Id, id);
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
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }


        [HttpPost("UpdateUser")]
        public BaseResponse UpdateUser(UserRequest user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateUser(user))
                {
                    new UserCRUD().UpdateUser(user.User);
                    if (user.User.Id > 0)
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
                    resp.BadRequest();
                }
            }
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }

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
                    {
                        resp.Conflict();
                    }
                }
                else
                {
                    resp.BadRequest();
                }
            }
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }

        [HttpPut("UpdateHome{id}")]
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
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }



        [HttpPut("DeleteUser/{id}")]
        public BaseResponse InActivateUser(long id)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.InActivateUser(id))
                {
                    var userCrud = new UserCRUD();
                    if (userCrud.IsUserExists(id))
                    {
                        var status = userCrud.InActivateUser(id);
                        if (status > 0)
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
                    }

                }
                else
                {
                    resp.BadRequest();
                }
            }
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }


        [HttpPut("Search/{id}")]
        public UserListResponse Search(long id, SearchRequest req)
        {
            UserListResponse resp = new UserListResponse();
            try
            {
                if (ValidateRequest.SearchRequest(req))
                {
                    var userCrud = new UserCRUD();
                    if (userCrud.IsUserExists(id))
                    {
                        List<string> states = req.Filters.Where(x => x.Filters == eFilters.States).Select(x => x.Values).FirstOrDefault();
                        List<string> homeType = req.Filters.Where(x => x.Filters == eFilters.HomeType).Select(x => x.Values).FirstOrDefault();
                        List<string> homeZipCode = req.Filters.Where(x => x.Filters == eFilters.HomeZipCode).Select(x => x.Values).FirstOrDefault();
                        List<string> numberOfKids = req.Filters.Where(x => x.Filters == eFilters.NumberOfKids).Select(x => x.Values).FirstOrDefault();
                        int minAge = req.Filters.Where(x => x.Filters == eFilters.Age).Select(x => x.MinAge).FirstOrDefault();
                        int maxAge = req.Filters.Where(x => x.Filters == eFilters.Age).Select(x => x.MaxAge).FirstOrDefault();
                        bool isAgeFilterExists = req.Filters.Any(x => x.Filters == eFilters.Age);

                        var userList = userCrud.GetUsers(states, homeType, homeZipCode, numberOfKids, isAgeFilterExists, minAge, maxAge);
                        if (userList.Count > 0)
                        {
                            resp.OK();
                        }
                        else
                        {
                            resp.NotFound();
                        }
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
            catch
            {
                resp.InternalServerError();
            }
            return resp;

        }




    }
}
