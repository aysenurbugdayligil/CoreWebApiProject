using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers {

    [ApiController]
    [Route ("api/[controller]")]
    public class UserController : ControllerBase {

        [HttpGet ("getusers")]
        public ActionResult GetUsers () {
            var users = GetUserList ().ToList ();
            return Ok (users);
        }

        [HttpGet ("getuser")] // TODO: bu şekilde yazılırsa path --> https://localhost:5001/api/user/getuser?id=2
        //[HttpGet ("getuser/{id}")] // TODO:  bu şekilde de yazılabilir. path bu şekilde olmalıdır --> https://localhost:5001/api/user/getuser/2
        //[Route ("getuser/{id}")] // TODO: bu şekilde de yazılabilir.
        public ActionResult GetUser (int id) {
            var user = GetUserList ().Where (c => c.Id == id).FirstOrDefault ();
            return Ok (user);
        }

        [HttpPost ("setuser")]
        //[Route("setuser")]
        public ActionResult SetUser ([FromForm] UserRequestModel model) {
            // TODO: json data post edildiği zaman parametreleri tek tek alamayız. Class içerisinde property olarak tanımlayıp o şekilde almalıyız.
            //örneğin UserRequestModel model

            //TODO: form-data yada x-www-form-urlencoded post edileceği zaman [FromForm]UserRequestModel model bu şekilde almalıyız.

            var users = GetUserList ();

            User userItem = new User () {
                Id = model.Id,
                Name = model.Name,
                Company = model.Company
            };

            users.Add (userItem);
            return Ok (users);
        }

        [HttpPut ("putuser/{id}")]
        public IActionResult PutUser (int Id, UserRequestModel model) {
            var response = GetUserList ().Find (b => b.Id == Id);
            if (response == null) {
                return NotFound ();
            }
            response.Name = model.Name;
            return Ok (response);
        }

        [HttpDelete ("deleteuser/{id}")]
        public IActionResult DeleteUser (int id) {
            var response = GetUserList ().Find (b => b.Id == id);
            if (response == null) {
                return NotFound ();
            }
            GetUserList ().Remove (response);
            return Ok (response);
        }

        public List<User> GetUserList () {
            List<User> users = new List<User> ();

            users.Add (new User () {
                Id = 1,
                    Name = "Ahmet",
                    Company = "Company 1"
            });
            users.Add (new User () {
                Id = 2,
                    Name = "Mehmet",
                    Company = "Company 2"
            });
            users.Add (new User () {
                Id = 3,
                    Name = "Ali",
                    Company = "Company 3"
            });
            users.Add (new User () {
                Id = 4,
                    Name = "Hüseyin",
                    Company = "Company 4"
            });

            return users;
        }
    }
}