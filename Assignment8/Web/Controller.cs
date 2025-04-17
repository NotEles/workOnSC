using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderApp;
using Microsoft.EntityFrameworkCore;

namespace control
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        OrderService orderService;
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderService.Orders;
        }//ods没连上
    
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            return orderService.GetOrder(id);
        }
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }
    }
}