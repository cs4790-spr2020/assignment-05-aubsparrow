using System;
using BlabberApp.Domain;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Client.Pages
{
    public class FeedModel : PageModel
    {
        private IBlabService blabService;
        private IUserService userService;
        public void OnGet()
        {
            
        }

        public FeedModel(IBlabService service)
        {
            blabService = service;
        }

        public void OnPost()
        {
            var email = Request.Form["emailAddress"];
            var message = Request.Form["blabMessage"];
            try
            {
                User user = userService.FindUser(email);
                Blab blab = blabService.CreateBlab(message, user);
                blabService.NewBlab(blab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        
        }
    }
}