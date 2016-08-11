namespace BankingSite.Core.ExternalComponentGateways
{
    public interface ICreditCheckerGateway
    {
        bool HasGoodCreditHistory(string personsName);
    }
}