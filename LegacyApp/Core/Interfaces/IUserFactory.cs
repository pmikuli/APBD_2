using System;
using LegacyApp.Models;

namespace LegacyApp.Core.Interfaces;

public interface IUserFactory
{
    public User createUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName);
}