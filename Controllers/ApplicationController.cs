using Corpa4Sem4.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraktASPApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly Services.IApplicationService _service;

        public ApplicationController(Services.IApplicationService service)
        {
            _service = service;
        }

        // Account CRUD endpoints
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            try
            {
                var createdAccount = await _service.CreateAccountAsync(account);
                return Ok(createdAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAccount/{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            try
            {
                var account = await _service.GetAccountByIdAsync(id);
                if (account == null)
                    return NotFound($"Account with ID {id} not found");

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<List<Account>>> GetAllAccounts()
        {
            try
            {
                var accounts = await _service.GetAllAccountsAsync();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateAccount/{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(int id, Account account)
        {
            try
            {
                var updatedAccount = await _service.UpdateAccountAsync(id, account);
                return Ok(updatedAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                await _service.DeleteAccountAsync(id);
                return Ok("Account deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // AccountType CRUD endpoints
        [HttpPost("CreateAccountType")]
        public async Task<ActionResult<AccountType>> CreateAccountType(AccountType accountType)
        {
            try
            {
                var createdAccountType = await _service.CreateAccountTypeAsync(accountType);
                return Ok(createdAccountType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAccountType/{id}")]
        public async Task<ActionResult<AccountType>> GetAccountType(int id)
        {
            try
            {
                var accountType = await _service.GetAccountTypeByIdAsync(id);
                if (accountType == null)
                    return NotFound($"Account Type with ID {id} not found");

                return Ok(accountType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetAllAccountTypes")]
        public async Task<ActionResult<List<AccountType>>> GetAllAccountTypes()
        {
            try
            {
                var accountTypes = await _service.GetAllAccountTypeAsync();
                return Ok(accountTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateAccountType/{id}")]
        public async Task<ActionResult<AccountType>> UpdateAccountType(int id, AccountType accountType)
        {
            try
            {
                var updatedAccountType = await _service.UpdateAccountTypeAsync(id, accountType);
                return Ok(updatedAccountType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteAccountType/{id}")]
        public async Task<ActionResult> DeleteAccountType(int id)
        {
            try
            {
                await _service.DeleteAccountTypeAsync(id);
                return Ok("Account Type deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Loan CRUD endpoints
        [HttpPost("CreateLoan")]
        public async Task<ActionResult<Loan>> CreateLoan(Loan loan)
        {
            try
            {
                var createdLoan = await _service.CreateLoanAsync(loan);
                return Ok(createdLoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetLoan/{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            try
            {
                var loan = await _service.GetLoanByIdAsync(id);
                if (loan == null)
                    return NotFound($"Loan with ID {id} not found");

                return Ok(loan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllLoans")]
        public async Task<ActionResult<List<Loan>>> GetAllLoans()
        {
            try
            {
                var loans = await _service.GetAllLoansAsync();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateLoan/{id}")]
        public async Task<ActionResult<Loan>> UpdateLoan(int id, Loan loan)
        {
            try
            {
                var updatedLoan = await _service.UpdateLoanAsync(id, loan);
                return Ok(updatedLoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLoan/{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            try
            {
                await _service.DeleteLoanAsync(id);
                return Ok("Loan deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // LegalPerson CRUD endpoints
        [HttpPost("CreateLegalPerson")]
        public async Task<ActionResult<LegalPerson>> CreateLegalPerson(LegalPerson legalPerson)
        {
            try
            {
                var createdLegalPerson = await _service.CreateLegalPersonAsync(legalPerson);
                return Ok(createdLegalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetLegalPerson/{id}")]
        public async Task<ActionResult<LegalPerson>> GetLegalPerson(int id)
        {
            try
            {
                var legalPerson = await _service.GetLegalPersonByIdAsync(id);
                if (legalPerson == null)
                    return NotFound($"Legal Person with ID {id} not found");

                return Ok(legalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllLegalPersons")]
        public async Task<ActionResult<List<LegalPerson>>> GetAllLegalPersons()
        {
            try
            {
                var legalPersons = await _service.GetAllLegalPersonsAsync();
                return Ok(legalPersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateLegalPerson/{id}")]
        public async Task<ActionResult<LegalPerson>> UpdateLegalPerson(int id, LegalPerson legalPerson)
        {
            try
            {
                var updatedLegalPerson = await _service.UpdateLegalPersonAsync(id, legalPerson);
                return Ok(updatedLegalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLegalPerson/{id}")]
        public async Task<ActionResult> DeleteLegalPerson(int id)
        {
            try
            {
                await _service.DeleteLegalPersonAsync(id);
                return Ok("Legal Person deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // NaturalPerson CRUD endpoints
        [HttpPost("CreateNaturalPerson")]
        public async Task<ActionResult<NaturalPerson>> CreateNaturalPerson(NaturalPerson naturalPerson)
        {
            try
            {
                var createdNaturalPerson = await _service.CreateNaturalPersonAsync(naturalPerson);
                return Ok(createdNaturalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetNaturalPerson/{id}")]
        public async Task<ActionResult<NaturalPerson>> GetNaturalPerson(int id)
        {
            try
            {
                var naturalPerson = await _service.GetNaturalPersonByIdAsync(id);
                if (naturalPerson == null)
                    return NotFound($"Natural Person with ID {id} not found");

                return Ok(naturalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllNaturalPersons")]
        public async Task<ActionResult<List<NaturalPerson>>> GetAllNaturalPersons()
        {
            try
            {
                var naturalPersons = await _service.GetAllNaturalPersonsAsync();
                return Ok(naturalPersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateNaturalPerson/{id}")]
        public async Task<ActionResult<NaturalPerson>> UpdateNaturalPerson(int id, NaturalPerson naturalPerson)
        {
            try
            {
                var updatedNaturalPerson = await _service.UpdateNaturalPersonAsync(id, naturalPerson);
                return Ok(updatedNaturalPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteNaturalPerson/{id}")]
        public async Task<ActionResult> DeleteNaturalPerson(int id)
        {
            try
            {
                await _service.DeleteNaturalPersonAsync(id);
                return Ok("Natural Person deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // ClientStatus CRUD endpoints
        [HttpPost("CreateClientStatus")]
        public async Task<ActionResult<ClientStatus>> CreateClientStatus(ClientStatus clientStatus)
        {
            try
            {
                var createdClientStatus = await _service.CreateClientStatusAsync(clientStatus);
                return Ok(createdClientStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetClientStatus/{id}")]
        public async Task<ActionResult<ClientStatus>> GetClientStatus(int id)
        {
            try
            {
                var clientStatus = await _service.GetClientStatusByIdAsync(id);
                if (clientStatus == null)
                    return NotFound($"Client Status with ID {id} not found");

                return Ok(clientStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllClientStatuses")]
        public async Task<ActionResult<List<ClientStatus>>> GetAllClientStatuses()
        {
            try
            {
                var clientStatuses = await _service.GetAllClientStatusesAsync();
                return Ok(clientStatuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateClientStatus/{id}")]
        public async Task<ActionResult<ClientStatus>> UpdateClientStatus(int id, ClientStatus clientStatus)
        {
            try
            {
                var updatedClientStatus = await _service.UpdateClientStatusAsync(id, clientStatus);
                return Ok(updatedClientStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteClientStatus/{id}")]
        public async Task<ActionResult> DeleteClientStatus(int id)
        {
            try
            {
                await _service.DeleteClientStatusAsync(id);
                return Ok("Client Status deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Gender CRUD endpoints
        [HttpPost("CreateGender")]
        public async Task<ActionResult<Gender>> CreateGender(Gender gender)
        {
            try
            {
                var createdGender = await _service.CreateGenderAsync(gender);
                return Ok(createdGender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("GetGender/{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            try
            {
                var gender = await _service.GetGenderByIdAsync(id);
                if (gender == null)
                    return NotFound($"Gender with ID {id} not found");

                return Ok(gender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllGenders")]
        public async Task<ActionResult<List<Gender>>> GetAllGenders()
        {
            try
            {
                var genders = await _service.GetAllGendersAsync();
                return Ok(genders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateGender/{id}")]
        public async Task<ActionResult<Gender>> UpdateGender(int id, Gender gender)
        {
            try
            {
                var updatedGender = await _service.UpdateGenderAsync(id, gender);
                return Ok(updatedGender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteGender/{id}")]
        public async Task<ActionResult> DeleteGender(int id)
        {
            try
            {
                await _service.DeleteGenderAsync(id);
                return Ok("Gender deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Ownership CRUD endpoints
        [HttpPost("CreateOwnership")]
        public async Task<ActionResult<Ownership>> CreateOwnership(Ownership ownership)
        {
            try
            {
                var createdOwnership = await _service.CreateOwnershipAsync(ownership);
                return Ok(createdOwnership);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetOwnership/{id}")]
        public async Task<ActionResult<Ownership>> GetOwnership(int id)
        {
            try
            {
                var ownership = await _service.GetOwnershipByIdAsync(id);
                if (ownership == null)
                    return NotFound($"Ownership with ID {id} not found");

                return Ok(ownership);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllOwnerships")]
        public async Task<ActionResult<List<Ownership>>> GetAllOwnerships()
        {
            try
            {
                var ownerships = await _service.GetAllOwnershipsAsync();
                return Ok(ownerships);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateOwnership/{id}")]
        public async Task<ActionResult<Ownership>> UpdateOwnership(int id, Ownership ownership)
        {
            try
            {
                var updatedOwnership = await _service.UpdateOwnershipAsync(id, ownership);
                return Ok(updatedOwnership);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteOwnership/{id}")]
        public async Task<ActionResult> DeleteOwnership(int id){
            try
            {
                await _service.DeleteOwnershipAsync(id);
                return Ok("Ownership deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // StaffStatus CRUD endpoints
        [HttpPost("CreateStaffStatus")]
        public async Task<ActionResult<StaffStatus>> CreateStaffStatus(StaffStatus staffStatus)
        {
            try
            {
                var createdStaffStatus = await _service.CreateStaffStatusAsync(staffStatus);
                return Ok(createdStaffStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetStaffStatus/{id}")]
        public async Task<ActionResult<StaffStatus>> GetStaffStatus(int id)
        {
            try
            {
                var staffStatus = await _service.GetStaffStatusByIdAsync(id);
                if (staffStatus == null)
                    return NotFound($"Staff Status with ID {id} not found");

                return Ok(staffStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllStaffStatuses")]
        public async Task<ActionResult<List<StaffStatus>>> GetAllStaffStatuses()
        {
            try
            {
                var staffStatuses = await _service.GetAllStaffStatusesAsync();
                return Ok(staffStatuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateStaffStatus/{id}")]
        public async Task<ActionResult<StaffStatus>> UpdateStaffStatus(int id, StaffStatus staffStatus)
        {
            try
            {
                var updatedStaffStatus = await _service.UpdateStaffStatusAsync(id, staffStatus);
                return Ok(updatedStaffStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteStaffStatus/{id}")]
        public async Task<ActionResult> DeleteStaffStatus(int id)
        {
            try
            {
                await _service.DeleteStaffStatusAsync(id);
                return Ok("Staff Status deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
        