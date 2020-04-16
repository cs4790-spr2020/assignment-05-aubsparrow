using System;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Client.Pages
{
    public class FeedModel : PageModel
    {
        private IBlabService blabService;
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
                blabService.NewBlab(message, email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        
        }
    }
}