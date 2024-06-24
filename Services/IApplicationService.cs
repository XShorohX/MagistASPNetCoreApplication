using Corpa4Sem4.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraktASPApp.Services
{
    public interface IApplicationService
    {
        // Account CRUD
        Task<Account> CreateAccountAsync(Account account);
        Task<Account> GetAccountByIdAsync(int id);
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> UpdateAccountAsync(int id, Account account);
        Task DeleteAccountAsync(int id);

        // AccountType CRUD
        Task<AccountType> CreateAccountTypeAsync(AccountType accountType);
        Task<AccountType> GetAccountTypeByIdAsync(int id);
        Task<List<AccountType>> GetAllAccountTypeAsync();
        Task<AccountType> UpdateAccountTypeAsync(int id, AccountType accountType);
        Task DeleteAccountTypeAsync(int id);

        // Loan CRUD
        Task<Loan> CreateLoanAsync(Loan loan);
        Task<Loan> GetLoanByIdAsync(int id);
        Task<List<Loan>> GetAllLoansAsync();
        Task<Loan> UpdateLoanAsync(int id, Loan loan);
        Task DeleteLoanAsync(int id);

        // LegalPerson CRUD
        Task<LegalPerson> CreateLegalPersonAsync(LegalPerson legalPerson);
        Task<LegalPerson> GetLegalPersonByIdAsync(int id);
        Task<List<LegalPerson>> GetAllLegalPersonsAsync();
        Task<LegalPerson> UpdateLegalPersonAsync(int id, LegalPerson legalPerson);
        Task DeleteLegalPersonAsync(int id);

        // NaturalPerson CRUD
        Task<NaturalPerson> CreateNaturalPersonAsync(NaturalPerson naturalPerson);
        Task<NaturalPerson> GetNaturalPersonByIdAsync(int id);
        Task<List<NaturalPerson>> GetAllNaturalPersonsAsync();
        Task<NaturalPerson> UpdateNaturalPersonAsync(int id, NaturalPerson naturalPerson);
        Task DeleteNaturalPersonAsync(int id);

        // ClientStatus CRUD
        Task<ClientStatus> CreateClientStatusAsync(ClientStatus clientStatus);
        Task<ClientStatus> GetClientStatusByIdAsync(int id);
        Task<List<ClientStatus>> GetAllClientStatusesAsync();
        Task<ClientStatus> UpdateClientStatusAsync(int id, ClientStatus clientStatus);
        Task DeleteClientStatusAsync(int id);

        // Gender CRUD
        Task<Gender> CreateGenderAsync(Gender gender);
        Task<Gender> GetGenderByIdAsync(int id);
        Task<List<Gender>> GetAllGendersAsync();
        Task<Gender> UpdateGenderAsync(int id, Gender gender);
        Task DeleteGenderAsync(int id);

        // Ownership CRUD
        Task<Ownership> CreateOwnershipAsync(Ownership ownership);
        Task<Ownership> GetOwnershipByIdAsync(int id);
        Task<List<Ownership>> GetAllOwnershipsAsync();
        Task<Ownership> UpdateOwnershipAsync(int id, Ownership ownership);
        Task DeleteOwnershipAsync(int id);

        // StaffStatus CRUD
        Task<StaffStatus> CreateStaffStatusAsync(StaffStatus staffStatus);
        Task<StaffStatus> GetStaffStatusByIdAsync(int id);
        Task<List<StaffStatus>> GetAllStaffStatusesAsync();
        Task<StaffStatus> UpdateStaffStatusAsync(int id, StaffStatus staffStatus);
        Task DeleteStaffStatusAsync(int id);
    }
}