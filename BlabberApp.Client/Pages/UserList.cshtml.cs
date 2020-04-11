using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services;

namespace BlabberApp.Client.Pages
{
    public class UserListModel : PageModel
    {
         private readonly IUserService userService;
        public UserListModel(IUserService service)
        {
            userService = service;;
        }
        public void OnGet()
        {
                 
        }
    }
}