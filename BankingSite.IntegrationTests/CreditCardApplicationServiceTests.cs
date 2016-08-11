using System.Net;
using System.Text;
using BankingSite.Domain;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class CreditCardApplicationServiceTests
    {
        private const string ApplicantName = "Jason";

        [Test]
        [Category("smoke")]
        public void ShouldSubmitValidApplication()
        {

            // Before running this test for the first time you should run the website to 
            // ensure IIS is running and the service is ready to receive requests


            var submissionResult = SubmitAValidApplication();

            Assert.That(submissionResult.ValidationErrors, Is.Empty);
            Assert.That(submissionResult.ReferenceNumber, Is.Not.Null);

            // We can test the workflow by executing the next logical service that a client would call...
            var applicantNameForReferenceNumber = GetApplicantName(submissionResult.ReferenceNumber.Value);
            
            // Here we are testing that the system has stored the correct applicant (name) against the reference number
            Assert.That(applicantNameForReferenceNumber, Is.EqualTo(ApplicantName));
        }

        private SubmissionResult SubmitAValidApplication()
        {
            var client = new WebClient();
            var data = client.DownloadData($"http://localhost:51357/services/SubmitApplication?applicantName={ApplicantName}&applicantAgeInYears=30&airlineFrequentFlyerNumber=A1234567");
            var json = Encoding.ASCII.GetString(data);
            return JsonConvert.DeserializeObject<SubmissionResult>(json);
        }

        private string GetApplicantName(int refNumber)
        {
            var client = new WebClient();
            var data = client.DownloadData($"http://localhost:51357/services/GetSuccesfulApplicantsName?submissionReferenceResult={refNumber}");
            var json = Encoding.ASCII.GetString(data);
            return JsonConvert.DeserializeObject<string>(json);
        }
    }
}
