using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.Commands;
using Application.Features.CompanyFeatures.Queries;
using Application.Features.OrderFeatures.Commands;
using Application.Features.OrderFeatures.Queries;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineShop.ApiControllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : BaseApiController
    {
        /// <summary>
        /// Creates a New Order.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            Product pr = await Mediator.Send(new GetProductByIdQuery { ProductId = command.ProductId });
            Company company = await Mediator.Send(new GetCompanyByIdQuery { CompanyId = pr.CompanyId });
            bool inWorkingTime = DateTime.Now.TimeOfDay - company.OperationStartTime.Value.TimeOfDay >= TimeSpan.Zero && DateTime.Now.TimeOfDay - company.OperationEndTime.Value.TimeOfDay <= TimeSpan.Zero;
            if (company.IsValid && inWorkingTime )
            {
                await Mediator.Send(command);
                return Ok();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (!company.IsValid)
                {
                    sb.AppendLine("The compant not validated by the website owner");
                }
                if (!inWorkingTime)
                {
                    sb.Append("Currently company doesn't accepting orders. It's out of working time");
                }
                return BadRequest(sb.ToString());
            }
                
            
        }
        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }
        /// <summary>
        /// Gets Company Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { OrderId = id }));
        }
        /// <summary>
        /// Deletes Order Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result=await Mediator.Send(new DeleteOrderByIdCommand { OrderId = id });
            if (result == default) { return StatusCode(500); } else { return Ok(); }
            
        }
        /// <summary>
        /// Updates the Company Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateOrderCommand command)
        {
            if (id != command.OrderId)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return Ok();
        }
    }
}