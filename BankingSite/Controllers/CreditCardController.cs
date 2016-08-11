using System.Linq;
using System.Web.Mvc;
using BankingSite.Core;
using BankingSite.Domain;
using BankingSite.Models;

namespace BankingSite.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardApplicationScorer _scorer;
        private readonly IApplicationDetailsValidator _validator;

        public CreditCardController(IApplicationDetailsValidator validator, ICreditCardApplicationScorer scorer)
        {
            _validator = validator;
            _scorer = scorer;
        }

        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(CreditCardForm form)
        {
            var application = new CreditCardApplication
            {
                ApplicantName = form.Name,
                ApplicantAgeInYears = form.Age,
                AirlineFrequentFlyerNumber = form.AirlineRewardNumber
            };

            var result = new SubmissionResult { ValidationErrors = _validator.Validate(application) };
            var isValidApplication = !result.ValidationErrors.Any();
            if (isValidApplication)
            {
                result.ReferenceNumber = _scorer.ScoreApplication(application);
            }
            
            if (result.ValidationErrors.Any())
            {
                ViewBag.ValidationErrors = result.ValidationErrors;
                return View(form);
            }

            if (result.ReferenceNumber.HasValue)
            {
                return RedirectToAction("Accepted", "CreditCard", new { Number = result.ReferenceNumber.Value });
            }

            return RedirectToAction("Failed", "CreditCard");
        }

        public ActionResult Accepted(string number)
        {
            ViewBag.ReferenceNumber = number;
            ViewBag.ApplicantName = "Jason";
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}