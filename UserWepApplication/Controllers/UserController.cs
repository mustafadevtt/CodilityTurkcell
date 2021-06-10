using System;
using Microsoft.AspNetCore.Mvc;
using UserWepApplication.Models.DataModels;
using UserWepApplication.Models.ViewModels;
using UserWepApplication.Services;

namespace UserWepApplication.Controllers
{
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string login, string firstName, string lastName)
        {
            var userViewModel = new UserViewModel
            {
                Title = "Create a new user",
                CreationMode = true
            };

            if (string.IsNullOrEmpty(login))
            {
                userViewModel.ErrorMessage = "Invalid Data!";
                return View(userViewModel);
            }

            var createdUserId = _service.Create(new User
            {
                Login = login,
                FirstName = firstName,
                LastName = lastName
            });

            userViewModel.Id = createdUserId;
            userViewModel.Login = login;
            userViewModel.FirstName = firstName;
            userViewModel.LastName = lastName;

            return View(userViewModel);
        }

        [HttpPut]
        [Route("User/Index/{id}")]
        public IActionResult Index([FromRoute] Guid id, string login, string firstName, string lastName)
        {
            var userViewModel = new UserViewModel
            {
                Title = "Edit a user",
                CreationMode = false
            };

            if (string.IsNullOrEmpty(login))
            {
                userViewModel.ErrorMessage = "Invalid Data!";
                return View(userViewModel);
            }

            var user = _service.Get(id);
            if (user == null)
            {
                userViewModel.ErrorMessage = $"User '{id}' was not found!";
                return View(userViewModel);
            }

            user.Login = login;
            user.FirstName = firstName;
            user.LastName = lastName;

            var isUpdated = _service.Update(user);

            var createdUserId = _service.Create(new User
            {
                Login = login,
                FirstName = firstName,
                LastName = lastName
            });

            userViewModel.Id = createdUserId;
            userViewModel.Login = login;
            userViewModel.FirstName = firstName;
            userViewModel.LastName = lastName;

            return View(userViewModel);
        }

    }
}
