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
                    response.HttpStatusCode = HttpStatusCode.NoContent;
                    response.HttpStatusMessage = HttpStatusCode.NoContent.ToString();
                }
                else
                {
                    response.HttpStatusCode = HttpStatusCode.OK;
                    response.HttpStatusMessage = HttpStatusCode.OK.ToString();
                    response.User = result;
                }
            }
            catch
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                response.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return response;
        }

        // GET: api/Users/5
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
                        response.HttpStatusCode = HttpStatusCode.NotFound;
                        response.HttpStatusMessage = HttpStatusCode.NotFound.ToString();
                    }
                    else
                    {
                        response.HttpStatusCode = HttpStatusCode.OK;
                        response.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        response.User = result;
                    }
                }
                else
                {
                    response.HttpStatusCode = HttpStatusCode.BadRequest;
                    response.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                response.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return response;
        }


        [Route("AddUser")]
        [HttpPost]
        public BaseResponse AddUser(User user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddUser(user))
                {
                    new UserCRUD().AddUser(user);
                    if (user.Id > 0)
                    {
                        resp.HttpStatusCode = HttpStatusCode.OK;
                        resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("AddKid")]
        [HttpPost("{id}")]
        public BaseResponse AddKid(long id, Kid kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddKid(id, kid))
                {
                    if (new UserCRUD().IsUserExists(id))
                    {
                        new KidCRUD().AddKid(kid);
                        if (kid.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = Constants.InValidUser;
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("AddHome")]
        [HttpPost("{id}")]
        public BaseResponse AddHome(long id, Home home)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddHome(id, home))
                {
                    if (new UserCRUD().IsUserExists(id))
                    {
                        new HomeCRUD().AddHome(home);
                        if (home.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = Constants.InValidUser;
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }


        [Route("UpdateUser")]
        [HttpPost]
        public BaseResponse UpdateUser(User user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateUser(user))
                {
                    new UserCRUD().UpdateUser(user);
                    if (user.Id > 0)
                    {
                        resp.HttpStatusCode = HttpStatusCode.OK;
                        resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("UpdateKid")]
        [HttpPost("{id}")]
        public BaseResponse UpdateKid(long id, Kid kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateKid(id, kid))
                {
                    var kidCrud = new KidCRUD();
                    if (new UserCRUD().IsUserExists(id) || kidCrud.IsUserKidExists(kid.Id))
                    {
                        kidCrud.UpdateKid(kid);
                        if (kid.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("UpdateHome")]
        [HttpPost("{id}")]
        public BaseResponse UpdateHome(long id, Home home)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateHome(id, home))
                {
                    var homeCrud=new HomeCRUD();
                    if (new UserCRUD().IsUserExists(id) || homeCrud.IsUserHomeExists(home.Id))
                    {
                        homeCrud.UpdateHome(home);
                        if (home.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = Constants.InValidUser;
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }



        [Route("DeleteUser")]
        [HttpPost]
        public BaseResponse DeleteUser(User user)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateUser(user))
                {
                    new UserCRUD().UpdateUser(user);
                    if (user.Id > 0)
                    {
                        resp.HttpStatusCode = HttpStatusCode.OK;
                        resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("DeleteKid")]
        [HttpPost("{id}")]
        public BaseResponse DeleteKid(long id, Kid kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateKid(id, kid))
                {
                    var kidCrud = new KidCRUD();
                    if (new UserCRUD().IsUserExists(id) || kidCrud.IsUserKidExists(kid.Id))
                    {
                        kidCrud.UpdateKid(kid);
                        if (kid.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }

        [Route("DeleteHome")]
        [HttpPost("{id}")]
        public BaseResponse DeleteHome(long id, Home home)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.UpdateHome(id, home))
                {
                    var homeCrud = new HomeCRUD();
                    if (new UserCRUD().IsUserExists(id) || homeCrud.IsUserHomeExists(home.Id))
                    {
                        homeCrud.UpdateHome(home);
                        if (home.Id > 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.OK;
                            resp.HttpStatusMessage = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.Conflict;
                            resp.HttpStatusMessage = HttpStatusCode.Conflict.ToString();
                        }
                    }
                    else
                    {
                        resp.HttpStatusCode = HttpStatusCode.Conflict;
                        resp.HttpStatusMessage = Constants.InValidUser;
                    }
                }
                else
                {
                    resp.HttpStatusCode = HttpStatusCode.BadRequest;
                    resp.HttpStatusMessage = HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                resp.HttpStatusCode = HttpStatusCode.InternalServerError;
                resp.HttpStatusMessage = HttpStatusCode.InternalServerError.ToString();
            }
            return resp;

        }


    }
}
