using BankingSite.Domain;

namespace BankingSite.Core.ExternalComponentGateways
{
    public class BankMainframeGateway : IBankMainframeGateway
    {
        public int CreateNew(CreditCardApplication application)
        {
            // Simulation of interacting with external system
            return 9999999;
        }
    }
}