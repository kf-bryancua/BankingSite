using BankingSite.Domain;

namespace BankingSite.Core
{
    public interface ICreditCardApplicationScorer
    {
        int? ScoreApplication(CreditCardApplication application);
    }
}