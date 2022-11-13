using WalletService.Domain.Models.Users.Responses;

namespace WalletService.Business.Services.Commands.Interfaces
{
    public interface IVisitorServiceCommand
    {
        Task<VisitorDTO> CreateVisitor();
    }
}
