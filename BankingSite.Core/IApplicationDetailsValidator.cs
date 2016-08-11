using System.Collections.Generic;
using BankingSite.Domain;

namespace BankingSite.Core
{
    public interface IApplicationDetailsValidator
    {
        List<string> Validate(CreditCardApplication application);
    }
}