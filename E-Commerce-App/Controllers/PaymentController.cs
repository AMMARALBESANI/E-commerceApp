using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;

namespace E_Commerce_App.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IConfiguration _configuration;

        private readonly ICart _cart;

        public PaymentController(IConfiguration configuration, ICart cart)
        {
            _configuration = configuration;
            _cart = cart;

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
                {
                    Name = "Abdallah",
                    City = "Irbid",
                    PhoneNumber = "122323343243",
                    PostalCode = "1234",
                    UserId = 1,
                    StreetAddress = "Irbid 100 St"

                }

            };


            foreach (var item in cartViewModel.CartItems)
            {
                cartViewModel.OrderTotal += (item.ProductPrice * item.Quantity);
            }

            return View(cartViewModel);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var _items = _cart.GetCartItems(User.Identity.Name);
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = _items,
                OrderInformation = new Order()
                {
                    Name = "Abdallah",
                    City = "Irbid",
                    PhoneNumber = "122323343243",
                    PostalCode = "1234",
                    UserId = 1,
                    StreetAddress = "Irbid 100 St"

                }
            };

            foreach (var item in cartViewModel.CartItems)
            {
                cartViewModel.OrderTotal += (item.ProductPrice * item.Quantity);
            }

            cartViewModel.OrderInformation.OrderDate = DateTime.Now;


            StripeConfiguration.ApiKey = _configuration.GetSection("StripeAPI:SecretKey").Get<string>();

            var domain = "https://localhost:7123/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "Payment/OrderConfirmation",
                CancelUrl = domain + "Payment/Index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in cartViewModel.CartItems)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(item.ProductPrice * 100), // 20.50 => 2050
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = item.ProductName
                        }
                    },
                    Quantity = item.Quantity
                };

                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            var session = service.Create(options);

            var sessionId = session.Id;

            TempData["sessionId"] = sessionId;


            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);

        }

        public IActionResult OrderConfirmation(int OrderId = 5)
        {
            ///var order = OrderService.GetOrderInformation(OrderId);
            /// var sessionId = order.SessionId

            var sessionId = TempData["sessionId"].ToString();

            var service = new SessionService();

            Session session = service.Get(sessionId);

            if (session != null)
            {
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    return View();
                }
            }

            return Content("Not completed suucessfully");

        }
    }

}
