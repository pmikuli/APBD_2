using System;
using LegacyApp.Core.DAL.Services;
using LegacyApp.Core.Interfaces;
using LegacyApp.Models;

namespace LegacyApp.Core;

public class UserFactory : IUserFactory
{
    private readonly IUserCreditService _userCreditService;
    
    public UserFactory(IUserCreditService userCreditService)
    {
        this._userCreditService = userCreditService;
    }

    public User createUser(Client client, DateTime dateOfBirth, string email, string firstName, string lastName)
    {
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
        
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (client.Type == "ImportantClient")
        {
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }
        else
        {
            user.HasCreditLimit = true;
          
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }

        return user;
    }
}