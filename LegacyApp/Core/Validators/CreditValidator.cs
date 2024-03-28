using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validators;

public class CreditValidator : ICreditValidator
{
    public bool ValidateCredit(bool hasLimit, int limit)
    {
        if (hasLimit && limit < 500)
        {
            return false;
        }

        return true;
    }
}