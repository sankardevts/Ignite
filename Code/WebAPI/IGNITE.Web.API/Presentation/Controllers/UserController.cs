using IGNITE.Services.User;
using IGNITE.Web.API.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace IGNITE.Web.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [ActionName ("UserRegistration")]
        [AcceptVerbs("GET","POST")]
        public HttpResponseMessage Post(UserModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var user = model.ToEntity();
            int userId = userService.UserRegistrationAndUpdation("insert",user);
            if (model.Image != null)
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        string lastPart = Path.GetExtension(httpPostedFile.FileName);
                        string fileName = string.Format("{0}_{1}.{2}", httpPostedFile.FileName, userId, lastPart);
                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/User"), httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
                    }
                }
            }
            response.Content = new StringContent("Registration Successfully", Encoding.Unicode);
            return response;
        }
    }
}
