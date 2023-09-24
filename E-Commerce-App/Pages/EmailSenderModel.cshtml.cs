using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using E_Commerce_App.Models;

namespace E_Commerce_App.Pages
{
    public class EmailSenderModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserInterface> _userManager;

        public EmailSenderModel(
            IConfiguration configuration,
            UserManager<UserInterface> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var apiKey = _configuration["SendGrid:EmailKey"]; // Retrieve SendGrid API key from appsettings.json
            var user = await _userManager.GetUserAsync(User); // Get the currently authenticated user

            if (user != null)
            {
                var from = new EmailAddress("abboodooa@gmail.com", "Your Name");
                var to = new EmailAddress(user.Email, user.UserName); // Use the user's email address as the recipient
                var subject = "Hello from SendGrid";
                var plainTextContent = "Hello, this is a test email from SendGrid.";
                var htmlContent = "<strong>Hello, this is a test email from SendGrid.</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var client = new SendGridClient(apiKey);

                try
                {
                    var response = await client.SendEmailAsync(msg);

                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        // Email sent successfully
                        return RedirectToPage("EmailSenderModel");
                    }
                    else
                    {
                        // Handle the error
                        // You can add logging or show an error message
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., SendGrid API errors
                    // You can add logging or show an error message
                    return Page();
                }
            }
            else
            {
                // User is not authenticated, handle accordingly (e.g., redirect to login page)
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
