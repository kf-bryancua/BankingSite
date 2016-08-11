using System.Linq;
using System.Web.Mvc;
using BankingSite.Core;
using BankingSite.Domain;

namespace BankingSite.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ICreditCardApplicationScorer _scorer;
        private readonly IApplicationDetailsValidator _validator;

        public ServicesController(IApplicationDetailsValidator validator, ICreditCardApplicationScorer scorer)
        {
            _validator = validator;
            _scorer = scorer;
        }

        public JsonResult SubmitApplication(string applicantName, int applicantAgeInYears, string airlineFrequentFlyerNumber)
        {
            var application = new CreditCardApplication
            {
                ApplicantName = applicantName,
                ApplicantAgeInYears = applicantAgeInYears,
                AirlineFrequentFlyerNumber = airlineFrequentFlyerNumber
            };

            var sr = new SubmissionResult { ValidationErrors = _validator.Validate(application) };

            var isValidApplication = !sr.ValidationErrors.Any();

            if (!isValidApplication)
            {
                return Json(sr, JsonRequestBehavior.AllowGet);
            }

            sr.ReferenceNumber = _scorer.ScoreApplication(application);

            return Json(sr, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSuccesfulApplicantsName(int submissionReferenceResult)
        {
            // Simulate the service calling into the rest of the application
            return Json("Jason", JsonRequestBehavior.AllowGet);
        }
    }
}
