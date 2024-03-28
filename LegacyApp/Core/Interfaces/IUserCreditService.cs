using System;

namespace LegacyApp.Core.Interfaces;

public interface IUserCreditService
{
    public int GetCreditLimit(string lastName, DateTime dateOfBirth);
}