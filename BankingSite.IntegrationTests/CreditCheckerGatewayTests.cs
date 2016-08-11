using BankingSite.Core.ExternalComponentGateways;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class CreditCheckerGatewayTests
    {
        // These are examples of integration testing that our internal code (in this case)
        // the gateway, works correctly with the external component that it "wraps".

        [Test]
        public void ShouldCreditCheckGoodPerson()
        {
            var sut = new CreditCheckerGateway();

            var isGoodCredit = sut.HasGoodCreditHistory("Jason");

            Assert.That(isGoodCredit, Is.True);
        }

        [Test]
        public void ShouldCreditCheckBadPerson()
        {
            var sut = new CreditCheckerGateway();

            var isGoodCredit = sut.HasGoodCreditHistory("Amrit");

            Assert.That(isGoodCredit, Is.False);
        }
    }
}
