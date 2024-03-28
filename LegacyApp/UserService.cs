using LegacyApp.Core.DAL.Repositories;
using LegacyApp.Core.DAL.Services;
using LegacyApp.Core.Interfaces;
using LegacyApp.Core.Validators;
using LegacyApp.Models;
using System;
using LegacyApp.Core;

namespace LegacyApp
{
    public class UserService
    {

        private readonly IInputValidator _inputValidator;
        private readonly IClientRepository _clientRepository;
        private readonly ICreditValidator _creditValidator;
        private readonly IUserFactory _userFactory;

        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _creditValidator = new CreditValidator();
            var userCreditService = new UserCreditService();
            _userFactory = new UserFactory(userCreditService);
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_inputValidator.ValidateName(firstName, lastName)
                || !_inputValidator.ValidateEmail(email)
                || !_inputValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);

            var user = _userFactory.createUser(client, dateOfBirth, email, firstName, lastName);

            if (!_creditValidator.ValidateCredit(user.HasCreditLimit, user.CreditLimit))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
