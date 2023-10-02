using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Newtonsoft.Json;
using System.Text;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Security.Claims;
using EllipticCurve.Utils;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce_App.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IConfiguration _configuration;

        private readonly ICart _cart;

        private readonly IOrder _order;


        public PaymentController(IConfiguration configuration, ICart cart, IOrder order)
        {
            _configuration = configuration;
            _cart = cart;
            _order = order;
        }
        public IActionResult Index()
        {
            if (User.Identity.Name == null)
            {
                return View();
            }
            else
            {

                var _items = _cart.GetCartItems(User.Identity.Name);

                if (_items.Count == 0)
                {
                    return View();
                }
                else
                {
                    CartViewModel cartViewModel = new CartViewModel()
                    {
                        CartItems = _items
                    };

                    foreach (var item in cartViewModel.CartItems)
                    {
                        cartViewModel.OrderTotal += (item.ProductPrice * item.Quantity);
                    }


                    return View(cartViewModel);
                }
            }

        }

        public IActionResult Summary()
        {
            var _items = _cart.GetCartItems(User.Identity.Name);

            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = _items,
                OrderInformation = new Order()
            };


            foreach (var item in cartViewModel.CartItems)
            {
                cartViewModel.OrderTotal += (item.ProductPrice * item.Quantity);
            }

            return View(cartViewModel);
        }

        [HttpPost]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPOST(CartViewModel cart)
        {
            cart.CartItems = _cart.GetCartItems(User.Identity.Name);

            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = cart.CartItems,
                OrderInformation = new Order()
                {
                    Name = cart.OrderInformation.Name,
                    City = cart.OrderInformation.City,
                    PhoneNumber = cart.OrderInformation.PhoneNumber,
                    PostalCode = cart.OrderInformation.PostalCode,
                    Username = cart.OrderInformation.Username,
                    StreetAddress = cart.OrderInformation.StreetAddress,
                    Items = cart.CartItems

                }
            };



            foreach (var item in cartViewModel.CartItems)
            {
                cartViewModel.OrderTotal += (item.ProductPrice * item.Quantity);
            }

            cartViewModel.OrderInformation.TotalPrice = cartViewModel.OrderTotal;

            cartViewModel.OrderInformation.OrderDate = DateTime.Now;




            StripeConfiguration.ApiKey = _configuration.GetSection("StripeAPI:SecretKey").Get<string>();

            var protocol = HttpContext.Request.Scheme;
            var host = HttpContext.Request.Host;

            // Build the dynamic domain using the protocol and host
            var domain = $"{protocol}://{host}";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"Payment/OrderConfirmation",
                CancelUrl = domain + "Payment/Index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                Metadata = new Dictionary<string, string>
                {
                    { "OrderID", cartViewModel.OrderInformation.ID.ToString() }
                }
            };

            foreach (var item in cartViewModel.CartItems)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(item.ProductPrice * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = item.ProductName
                        },



                    },
                    Quantity = item.Quantity
                };

                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            var session = service.Create(options);

            var sessionId = session.Id;

            // adding the seesion id to the order 
            cartViewModel.OrderInformation.SessionID = sessionId;

            cartViewModel.OrderInformation.Status = "Completed";

            await _order.AddOrder(cartViewModel.OrderInformation);

            TempData["sessionId"] = sessionId;


            Response.Headers.Add("Location", session.Url);


            return new StatusCodeResult(303);

        }

        private async Task<bool> SendConfirmationEmailAsync(ClaimsPrincipal user, Order order)
        {
            try
            {
                var apiKey = _configuration["SendGrid:Key"];
                var from = new EmailAddress("abboodooa@gmail.com", $"Sir: {User.Identity.Name}");

                // Retrieve the email claim from the ClaimsPrincipal
                var emailClaim = user.FindFirst(ClaimTypes.Email); // Adjust the claim type as needed

                if (emailClaim != null)
                {
                    var to = new EmailAddress(emailClaim.Value, user.Identity.Name);
                    var subject = "Order Confirmation";

                    // Include order details in the email content
                    var plainTextContent = $"Your order ({order.ID}) has been confirmed.";
                    var htmlContent = $"<strong>Your order ({order.ID}) has been confirmed.</strong><br><br>";

                    // Add order details
                    htmlContent += "<strong>Order Details:</strong><br>";
                    foreach (var item in order.Items)
                    {
                        htmlContent += $"Product: {item.ProductName}, Quantity: {item.Quantity}, Price: {item.ProductPrice}<br>";
                    }
                    htmlContent += $"<strong>TotalPrice: {order.TotalPrice}</strong>";
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                    var client = new SendGridClient(apiKey);
                    var response = await client.SendEmailAsync(msg);

                    return response.StatusCode == System.Net.HttpStatusCode.Accepted;
                }
                else
                {
                    // Handle the case where the email claim is not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., SendGrid API errors
                return false;
            }
        }

        public async Task<IActionResult> OrderConfirmation()
        {
            var sessionId = TempData["sessionId"]?.ToString();

            if (string.IsNullOrEmpty(sessionId))
            {
                return Content("Session Id not found.");
            }

            var service = new SessionService();
            Session session = service.Get(sessionId);

                    var order = await _order.GetOrderBySessionId(sessionId);
            if (session != null)
            {
                if (session.PaymentStatus.ToLower() == "paid")
                {

                    if (order != null)
                    {
                        // Payment was successful, and the order is marked as completed.
                        _cart.RemoveAllCart(User.Identity.Name);

                        // Send the email using the separate method with order details
                        var emailSent = await SendConfirmationEmailAsync(User, order);

                        if (emailSent)
                        {
                            TempData["SuccessMessage"] = "Email sent successfully!";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "An error occurred while sending the email.";
                        }

                        return View(order);
                    }

                    order.Status = "Failed";

                    await _order.UpdateOrder(sessionId, order);

                }
            }

            return Content("Not completed successfully");
        }
        [Authorize]
        public async Task<IActionResult> AllSuccessOrders()
        {
            var order = await _order.GetAllSuccessOrders();

            return View(order);
        }

    }

}
