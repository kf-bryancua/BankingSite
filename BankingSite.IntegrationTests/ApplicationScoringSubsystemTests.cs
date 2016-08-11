using BankingSite.Core;
using BankingSite.Core.ExternalComponentGateways;
using BankingSite.Domain;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    [Category("subsystem_application_scoring")]
    public class ApplicationScoringSubsystemTests
    {
        [Test]
        public void ShouldScoreApplicationCorrectly()
        {
            // Create and configure our fakes that we want to use
            var fakeMainframe = new Mock<IBankMainframeGateway>();
            fakeMainframe.Setup(x => x.CreateNew(It.IsAny<CreditCardApplication>())).Returns(42);

            // Create our DI container
            var container = new UnityContainer();

            // Tell the DI container to use the real CreditCheckerGateway
            container.RegisterType<ICreditCheckerGateway, CreditCheckerGateway>();

            // Tell the DI container to use the fake IBankMainframeGateway
            container.RegisterType<IBankMainframeGateway>(new InjectionFactory(u => fakeMainframe.Object));
            
            // Use the DI container to create the object graph, rather than new keyword
            var sut = container.Resolve<CreditCardApplicationScorer>();

            var a = new CreditCardApplication
                        {
                            ApplicantName = "Jason",
                            ApplicantAgeInYears = 44,
                            AirlineFrequentFlyerNumber = "A1234567"
                        };

            var result = sut.ScoreApplication(a);

            Assert.That(result, Is.Not.Null);

            // Note that this seems more complex than the below. For this example this is true,
            // but if we were creating a larger/complex subsystem object graph, then using a DI container
            // actually simplifies things.
        }
    }
}
