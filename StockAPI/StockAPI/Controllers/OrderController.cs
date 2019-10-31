using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StockAPI.API.Data;
using StockAPI.API.Models;
using StockAPI.Models;
using StockAPI.Repository;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IHubContext<OrderHub> _hub;
        private DataContext _context = new DataContext();

        private readonly OrderRepository _orderRepository = new OrderRepository();
        public OrderController(IHubContext<OrderHub> hub)
        {
            _hub = hub;
        }
        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {

            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferorderdata", _orderRepository.Add()));

            return Ok(_orderRepository.getOrders());

        }







    }
}
