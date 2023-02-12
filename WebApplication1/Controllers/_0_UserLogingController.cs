using CMS_Projekt_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/UsersAuth")]
    public class _0_UserLogingController : Controller
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;

        public _0_UserLogingController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._response = new();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model) 
        {
            var loginResponse = await _userRepo.Login(model);
            if(loginResponse.User ==null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool ifUserNameUnique = _userRepo.IsUniqueUser(model.user_name);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            var user = await _userRepo.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
