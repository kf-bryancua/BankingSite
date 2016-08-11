using BankingSite.Domain;

namespace BankingSite.Core.ExternalComponentGateways
{
    public interface IBankMainframeGateway
    {
        int CreateNew(CreditCardApplication application);
    }
}