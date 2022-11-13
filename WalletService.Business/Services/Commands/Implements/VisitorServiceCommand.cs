using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Domain.Entities;
using WalletService.Domain.Models.Users.Responses;
using WalletService.Persistence.Repositories.Interfaces;

namespace WalletService.Business.Services.Commands.Implements
{
    public class VisitorServiceCommand : IVisitorServiceCommand
    {
        private readonly IVisitorRepository _repository;

        public VisitorServiceCommand(IVisitorRepository repository)
        {
            _repository = repository;
        }


        public async Task<VisitorDTO> CreateVisitor()
        {
            try
            {
                var uuid = Guid.NewGuid().ToString();
                var newUser = new Visitor { UserId = uuid, CreatedDate = DateTime.UtcNow };
                await _repository.CreateVisitor(newUser);
                var userCreated = new VisitorDTO { UserId = newUser.UserId };
                return userCreated;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
