using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeVault.Core.Services.Implementations;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Model.Dtos.Company;
using ResumeVaultBE.Core.Context;
using ResumeVaultBE.Core.Entities;

namespace ResumeVaultBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;
        private readonly ResumeVaultDbContext resumeVaultDbContext;

        public CompanyController(ICompanyService companyService, IMapper mapper, ResumeVaultDbContext resumeVaultDbContext)
        {
            this.companyService = companyService;
            this.mapper = mapper;
            this.resumeVaultDbContext = resumeVaultDbContext;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto companyCreateDto)
        {
            await companyService.CreateCompanyAsync(companyCreateDto);
            return Ok("Company created successfully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await companyService.GetCompaniesAsync();
            return Ok(companies);           
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<CompanyGetDto>> GetCompanyById(long ID)
        {
            return await companyService.GetCompanyByIdAsync(ID);         

        }
       
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<CompanyCreateDto>> UpdateCompany(long ID, [FromBody] CompanyCreateDto companyCreateDto)
        {
            await companyService.UpdateCompanyAsync(ID, companyCreateDto);
            return Ok("Updated Successfully");           
        }



        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeleteCompany(long ID)
        {
            await companyService.DeleteAsync(ID);
            return Ok("Deleted successfully");
        }
    }
}
