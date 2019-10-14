using Gwent.FormModels;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using Gwent.Security;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

namespace Gwent.Controllers
{   
    [Authorize]
    public class AuthenticationController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Create()
        {
            CreateUser user = new CreateUser();
            return View("Create", user);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(CreateUser user)
        {
            AuthenticationRepository repository = new AuthenticationRepository(context);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            try
            {
                User newUser = new User(0, user.FirstName, user.LastName, user.EmailAddress, hashedPassword);
                repository.Insert(newUser);
                return RedirectToAction("Login");
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex);
            }
            return View("Create", user);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login (LoginModel model)
        {
            AuthenticationRepository repository = new AuthenticationRepository(context);
            if (ModelState.IsValidField("EmailAddress")&& ModelState.IsValidField("Password"))
            {
                User currentUser = repository.GetByEmail(model.EmailAddress);
                if (currentUser == null || !BCrypt.Net.BCrypt.Verify(model.Password, currentUser.HashedPassword))
                {
                    ModelState.AddModelError("", "Login Failed. You Shall Not Pass!!!");
                }
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }

        private void HandleDbUpdateException(DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.InnerException != null)
            {
                SqlException sqlException = ex.InnerException.InnerException as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken.");
                }
            }
        }
    }
}