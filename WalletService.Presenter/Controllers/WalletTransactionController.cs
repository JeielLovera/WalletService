using Microsoft.AspNetCore.Mvc;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Domain.Base;
using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Presenter.Controllers
{
    [ApiController]
    [Route("services/transactions")]
    [Produces("application/json")]
    public class WalletTransactionController : ControllerBase
    {
        private readonly IWalletTransactionServiceCommand _serviceCommand;

        public WalletTransactionController(IWalletTransactionServiceCommand serviceCommand)
        {
            _serviceCommand = serviceCommand;
        }


        [HttpPost("execute-transaction")]
        public async Task<ActionResult<BaseResponse<WalletDTO?>>> ExecuteTransaction(TransactionDTO transactionDTO)
        {
            var wallet = await _serviceCommand.ExcuteTransaction(transactionDTO);
            var baseResponse = new BaseResponse<WalletDTO?> { Data = wallet };
            return Ok(baseResponse);
        }
    }
}
