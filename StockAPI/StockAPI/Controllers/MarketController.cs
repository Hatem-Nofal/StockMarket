using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StockAPI.API.Data;
using StockAPI.API.Models;
using StockAPI.Models;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IHubContext<MarketHub> _hub;
        private readonly MarketRepository _stockRepository = new MarketRepository();
        public MarketController(IHubContext<MarketHub> hub)
        {
            _hub = hub;
        }
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferstockdata", _stockRepository.GetStocks()));
            return Ok(new { Message = "Request Completed" });

        }
       
    }
}
