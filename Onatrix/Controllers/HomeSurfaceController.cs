using Microsoft.AspNetCore.Mvc;
using Onatrix.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Onatrix.Services;
using Umbraco.Cms.Core.Events;

namespace Onatrix.Controllers
{
    public class HomeSurfaceController : SurfaceController
    {
        private readonly EmailService _emailService;

        public HomeSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, EmailService emailService) 
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _emailService = emailService;
        }

        public async Task <IActionResult> HandleSubmit(HomePageFormModel form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["name"] = form.Name;
                ViewData["email"] =form.Email;
                ViewData["phone"] =form.Phone;
                
                
                if (string.IsNullOrEmpty(form.Name))
                {
                    ViewData["error-name"] = "You must enter your name";
                }
                else if (ModelState.ContainsKey(nameof(form.Name)) && ModelState[nameof(form.Name)]?.Errors.Count > 0)
                {
                    ViewData["error-name"] = "Your name must contain at least two characters";
                }



                if (string.IsNullOrEmpty(form.Email))
                {
                    ViewData["error-email"] = "You must enter a valid email";
                }
                else if (ModelState.ContainsKey(nameof(form.Email)) && ModelState[nameof(form.Email)]?.Errors.Count > 0)
                {
                    ViewData["error-email"] = "Invalid email address";
                }

               

                if (string.IsNullOrEmpty(form.Phone))
                {
                    ViewData["error-phone"] = "You must enter your phone number";
                }
                else if (ModelState.ContainsKey(nameof(form.Phone)) && ModelState[nameof(form.Phone)]?.Errors.Count > 0)
                {
                    ViewData["error-phone"] = "Your phone number must be a valid phone number";
                }

                return CurrentUmbracoPage();
            }
            string subject = "Bekräftelse: Vi har mottagit din information";
            string plainTextContent = $"Hej {form.Name}, tack för att du kontaktade oss.";
            string htmlContent = $@"
                                    <html>
                                    <head></head>
                                    <body style='background-color: #a3b3af; color: #3c2f26; font-family: Arial, sans-serif;'>
                                        <div style='background-color: #a3b3af; padding: 20px; border-radius: 5px; max-width: 600px; margin: 0 auto; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
                                            <div style='text-align: center; margin-bottom: 20px;'>
                                                <img src='https://onatrix20240923143448.azurewebsites.net/media/v5vdjmxw/onatrixlogobrand.svg' alt='Företagslogotyp' style='width: 150px;' /> <!-- Publik URL till logotypen -->
                                            </div>
                                            <div style='text-align: left; font-size: 16px;'>
                                                <p style='font-size:16px; color:#3c2f26;'><strong>Hej {form.Name},</strong></p>
                                                <p style='font-size:16px; color:#3c2f26;'>Tack för att du kontaktade oss. Vi har mottagit din information och kommer att återkomma så snart som möjligt.</p>
                                            </div>
                                            <div style='text-align: center; font-size: 12px; color: #777777; margin-top: 30px;'>
                                                <p>&copy; {DateTime.Now.Year} Onatrix. Alla rättigheter förbehållna.</p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";


            await _emailService.SendMessageAsync(form.Email, form.Name, subject, plainTextContent, htmlContent);

            TempData["submitted"] = "A confirmation email has been sent to you";
            return  RedirectToCurrentUmbracoPage();
        }
    }
}
