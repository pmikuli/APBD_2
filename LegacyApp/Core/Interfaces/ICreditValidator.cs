namespace LegacyApp.Core.Interfaces;

public interface ICreditValidator
{
    public bool ValidateCredit(bool hasLimit, int limit);
}