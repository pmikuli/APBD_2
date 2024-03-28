using LegacyApp.Models;

namespace LegacyApp.Core.Interfaces;

public interface IClientRepository
{
    public Client GetById(int clientId);
}