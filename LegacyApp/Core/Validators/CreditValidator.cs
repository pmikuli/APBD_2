using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validators;

public class CreditValidator : ICreditValidator
{
    public bool ValidateCredit(bool hasLimit, int limit)
    {
        return !hasLimit || limit >= 500;
    }
}