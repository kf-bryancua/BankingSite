namespace BankingSite.Core
{
    public interface IAirlineMembershipNumberValidator
    {
        bool IsValid(string membershipNumber);
    }
}