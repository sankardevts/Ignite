using IGNITE.Services.User;
using IGNITE.Web.API.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;

namespace IGNITE.Web.API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserService userService;

        public LoginController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [AcceptVerbs("GET","POST")]
        public HttpResponseMessage Post(UserModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (model != null)
            {
                try
                {
                    var result = userService.GetUserDetails(model.Username, model.Password, DateTime.UtcNow);
                    response.Content = new ObjectContent<UserModel>(
                                new UserModel()
                                {
                                    Id = result.Id,
                                    Username = result.Username,
                                    FirstName = result.FirstName,
                                    LastName = result.LastName,
                                    Status = result.Status,
                                    StatusMessage = result.StatusMessage,
                                    LastLoggedIN = result.LastLoggedIN,
                                    Image = result.Image,
                                    PhoneNumber = result.PhoneNumber,
                                    TcAcceptedDate = result.TcAcceptedDate,
                                    UserType = result.UserType,
                                    DateOfBirth = result.DateOfBirth,
                                },
                                new JsonMediaTypeFormatter(), "application/json");
                }
                catch (Exception ex)
                {
                    response.Content = new StringContent(ex.Message, Encoding.UTF8);
                }
            }
            else
            {
                response.Content = new StringContent("fail", Encoding.UTF8);
            }
            return response;
        }
    }
}
