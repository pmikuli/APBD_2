using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Core.Interfaces
{
    public interface IInputValidator
    {
        public bool ValidateName(string firstName, string lastName);
        public bool ValidateEmail(string email);
        public bool ValidateAge(DateTime dateOfBirth);
    }
}
