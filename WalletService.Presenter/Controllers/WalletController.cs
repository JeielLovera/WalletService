using Microsoft.AspNetCore.Mvc;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Business.Services.Querys.Interfaces;
using WalletService.Domain.Base;
using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Presenter.Controllers
{
    [ApiController]
    [Route("services/wallets")]
    [Produces("application/json")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletServiceCommand _serviceCommand;
        private readonly IWalletServiceQuery _serviceQuery;

        public WalletController(IWalletServiceCommand serviceCommand, IWalletServiceQuery serviceQuery)
        {
            _serviceCommand = serviceCommand;
            _serviceQuery = serviceQuery;
        }


        [HttpPost("create-wallet")]
        public async Task<ActionResult<BaseResponse<WalletDTO>>> CreateWallet([FromBody] CreateWalletDTO createWalletDTO)
        {
            var wallet = await _serviceCommand.CreateWallet(createWalletDTO);
            var baseResponse = new BaseResponse<WalletDTO> { Data = wallet };
            return Ok(baseResponse);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<WalletDTO>>>> GetWallets([FromQuery] string userId)
        {
            var wallets = await _serviceQuery.GetWalletsByUserId(userId);
            var baseResponse = new BaseResponse<IEnumerable<WalletDTO>> { Data = wallets };
            return Ok(baseResponse);
        }

    }
}
