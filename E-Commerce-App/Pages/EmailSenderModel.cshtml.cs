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

        public async Task<IActionResult> OnPost(Product product)
        {
            var apiKey = _configuration["SendGrid:Key"]; // Retrieve SendGrid API key from appsettings.json
            var user = await _userManager.GetUserAsync(User); // Get the currently authenticated user

            if (user != null)
            {
                var from = new EmailAddress("abboodooa@gmail.com", "Your Name");
                var to = new EmailAddress(user.Email, user.UserName); // Use the user's email address as the recipient
                var subject = "Hello from SendGrid";
                var plainTextContent = "You just bought a "+ product.Name;
                var htmlContent = "<strong>Hello,You just bought a" + product.Name+ "</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var client = new SendGridClient(apiKey);

                try
                {
                    var response = await client.SendEmailAsync(msg);

                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        // Email sent successfully
                        TempData["SuccessMessage"] = "Email sent successfully!";

                        return ViewComponent("Cart");
                    }
                    else
                    {
                        // Handle the error
                        TempData["ErrorMessage"] = "An error occurred while sending the email.";
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., SendGrid API errors
                    TempData["ErrorMessage"] = "Failed to send the email.";

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
