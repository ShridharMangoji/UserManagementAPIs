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
    /// <summary>
    /// User Related Action Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Get All Active Users
        /// </summary>
        /// <returns>User List</returns>
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
        /// <summary>
        /// Get User data
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>User Data</returns>
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

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">User Model</param>
        /// <returns>API Status</returns>
        [HttpPost("AddUser")]
        public BaseResponse AddUser(UserRequest user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddUser(user))
                {
                    var userCrud = new UserCRUD();

                    if (!userCrud.IsUserExists(user.User.PhoneNumber, user.User.Email) && !userCrud.IsUserExists(user.User.Id))
                    {
                        user.User.Id = 0;
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
                resp.InternalServerError();
            }
            return resp;

        }
      
        /// <summary>
        /// Update User Information
        /// </summary>
        /// <param name="user">Updated User Model</param>
        /// <returns>API Status</returns>
        [HttpPost("UpdateUser")]
        public BaseResponse UpdateUser(UserRequest user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateUser(user))
                {
                    if (new UserCRUD().IsUserExists(user.User.Id))
                    {
                        user.User.IsActive = true;
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
        /// Inactivate User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>API Status</returns>
        [HttpDelete("DeleteUser/{id}")]
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


        /// <summary>
        /// User List based on the search criteria 
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="req">Search filter model</param>
        /// <returns>User list as response based on search model</returns>
        [HttpPost("Search/{id}")]
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
                        List<string> states = req.Filters.Where(x => x.Filters == EFilters.States).Select(x => x.Values).FirstOrDefault();
                        List<string> homeType = req.Filters.Where(x => x.Filters == EFilters.HomeType).Select(x => x.Values).FirstOrDefault();
                        List<string> homeZipCode = req.Filters.Where(x => x.Filters == EFilters.HomeZipCode).Select(x => x.Values).FirstOrDefault();
                        List<string> numberOfKids = req.Filters.Where(x => x.Filters == EFilters.NumberOfKids).Select(x => x.Values).FirstOrDefault();
                        int minAge = req.Filters.Where(x => x.Filters == EFilters.Age).Select(x => x.MinAge).FirstOrDefault();
                        int maxAge = req.Filters.Where(x => x.Filters == EFilters.Age).Select(x => x.MaxAge).FirstOrDefault();
                        bool isAgeFilterExists = req.Filters.Any(x => x.Filters == EFilters.Age);

                        var userList = userCrud.GetUsers(states, homeType, homeZipCode, numberOfKids, isAgeFilterExists, minAge, maxAge);
                        if (userList.Count > 0)
                        {
                            resp.User = userList;
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
