using System;
using System.Collections;
using System.Linq;
using BlabberApp.Services;
using BlabberApp.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Client.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService userService;
        public RegisterModel(IUserService service)
        {
            userService = service;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {

            var email = Request.Form["emailaddress"];
            try
            {
                userService.AddNewUser(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}