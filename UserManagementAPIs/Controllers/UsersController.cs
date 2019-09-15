using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.DbModels;
using BAL.DbOperation;
using UserManagementAPIs.Models;
using System.Net;

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

        // POST: api/Users
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
        [HttpPost]
        public BaseResponse AddKid(Kid kid)
        {
            BaseResponse resp = new BaseResponse();
            try
            {
                if (ValidateRequest.AddKid(kid))
                {
                    new UserCRUD().AddKid(kid);
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




        private readonly Entities _context;

        public UsersController(Entities context)
        {
            _context = context;
        }



        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(long id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

      
        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(long id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
