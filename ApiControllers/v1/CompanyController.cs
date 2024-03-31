using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.Commands;
using Application.Features.CompanyFeatures.Queries;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.ApiControllers.v1
{
    [ApiVersion("1.0")]
    public class CompanyController : BaseApiController
    {
        /// <summary>
        /// Creates a New Company.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            await Mediator.Send(command);
            return Ok();
            
        }
        /// <summary>
        /// Gets all Company.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCompaniesQuery()));
        }
        /// <summary>
        /// Gets Company Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCompanyByIdQuery { CompanyId = id }));
        }
        /// <summary>
        /// Deletes Company Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result=await Mediator.Send(new DeleteCompanyByIdCommand { CompanyId = id });
            if (result == default) { return StatusCode(500); } else { return Ok(); }
            
        }
        /// <summary>
        /// Updates the Company Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateCompanyCommand command)
        {
            if (id != command.CompanyId)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return Ok();
        }
    }
}