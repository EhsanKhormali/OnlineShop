using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Repository;
using OnlineShop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace OnlineShop.ApiControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyRepository companyRepository;

        public CompaniesController()
        {
            this.companyRepository = new CompanyRepository();
        }

        // GET: api/v1/companies
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            CompanyRepository companies = new CompanyRepository();
            return (IEnumerable<Company>)companies.GetAll();
        }

        // GET api/v1/companies/id
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            CompanyRepository companies = new CompanyRepository();
                var company = companies.GetById(id);

                if (company == null)
                    throw new Exception($"Company with Id = {id} not found");
                return company;
            
        }

        // POST api/v1/companies
        [HttpPost]
        public void Post([FromBody] Company company)
        {
            companyRepository.Add(company);

        }

        // PUT api/v1/companies/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] Company company)
        {
            try
            {
                if (id != company.CompanyId)
                    return BadRequest("CompanyId mismatch");

                var employeeToUpdate =  companyRepository.GetById(id);

                if (employeeToUpdate == null)
                    return NotFound($"Company with Id = {id} not found");

                companyRepository.Update(company);
                return Ok(employeeToUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        // DELETE api/v1/companies/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CompanyRepository companies = new CompanyRepository();
            try
            {
                var employeeToDelete = companies.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Company with Id = {id} not found");
                }

                companies.Delete(id);
                return Ok(employeeToDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
