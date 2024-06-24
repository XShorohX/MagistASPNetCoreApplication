using Corpa4Sem4.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraktASPApp.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly Database.ApplicationContext _context;

        public ApplicationService()
        
        {
            _context = new Database.ApplicationContext();
        }

        // Account CRUD
        public async Task<Account> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccountAsync(int id, Account account)
        {
            var  accountDb = await _context.Accounts.FindAsync(id);
            if (accountDb == null) {
                _context.Accounts.Update(account);
            }
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

        // AccountType CRUD
        public async Task<AccountType> CreateAccountTypeAsync(AccountType accountType)
        {
            await _context.AccountType.AddAsync(accountType);
            await _context.SaveChangesAsync();
            return accountType;
        }

        public async Task<AccountType> GetAccountTypeByIdAsync(int id)
        {
            return await _context.AccountType.FindAsync(id);
        }

        public async Task<List<AccountType>> GetAllAccountTypeAsync()
        {
            return await _context.AccountType.ToListAsync();
        }

        public async Task<AccountType> UpdateAccountTypeAsync(int id, AccountType accountType)
        {
            var  accountTypeDb = await _context.AccountType.FindAsync(id);
            if (accountTypeDb == null) {
                _context.AccountType.Update(accountType);
            }
            await _context.SaveChangesAsync();
            return accountType;
        }

        public async Task DeleteAccountTypeAsync(int id)
        {
            var accountType = await _context.AccountType.FindAsync(id);
            if (accountType != null)
            {
                _context.AccountType.Remove(accountType);
                await _context.SaveChangesAsync();
            }
        }

        // Loan CRUD
        public async Task<Loan> CreateLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> UpdateLoanAsync(int id, Loan loan)
        {
            var  loanDb = await _context.Loans.FindAsync(id);
            if (loanDb == null) {
                _context.Loans.Update(loan);
            }
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

        // LegalPerson CRUD
        public async Task<LegalPerson> CreateLegalPersonAsync(LegalPerson legalPerson)
        {
            _context.LegalPersons.Add(legalPerson);
            await _context.SaveChangesAsync();
            return legalPerson;
        }

        public async Task<LegalPerson> GetLegalPersonByIdAsync(int id)
        {
            return await _context.LegalPersons.FindAsync(id);
        }

        public async Task<List<LegalPerson>> GetAllLegalPersonsAsync()
        {
            return await _context.LegalPersons.ToListAsync();
        }

        public async Task<LegalPerson> UpdateLegalPersonAsync(int id, LegalPerson legalPerson)
        {
            var  legalPersonDb = await _context.LegalPersons.FindAsync(id);
            if (legalPersonDb == null) {
                _context.LegalPersons.Update(legalPerson);
            }
            await _context.SaveChangesAsync();
            return legalPerson;
        }

        public async Task DeleteLegalPersonAsync(int id)
        {
            var legalPerson = await _context.LegalPersons.FindAsync(id);
            if (legalPerson != null)
            {
                _context.LegalPersons.Remove(legalPerson);
                await _context.SaveChangesAsync();
            }
        }

        // NaturalPerson CRUD
        public async Task<NaturalPerson> CreateNaturalPersonAsync(NaturalPerson naturalPerson)
        {
            _context.NaturalPersons.Add(naturalPerson);
            await _context.SaveChangesAsync();
            return naturalPerson;
        }

        public async Task<NaturalPerson> GetNaturalPersonByIdAsync(int id)
        {   
            return _context.NaturalPersons
            .Include(np => np.Sex)
            .Include(np => np.Status)
            .Include(np => np.InStaff)
            .FirstOrDefault(np => np.Id == id);
        }

        public async Task<List<NaturalPerson>> GetAllNaturalPersonsAsync()
        {
            return await _context.NaturalPersons
            .Include(np => np.Sex)
            .Include(np => np.Status)
            .Include(np => np.InStaff)
            .ToListAsync();
        }

        public async Task<NaturalPerson> UpdateNaturalPersonAsync(int id, NaturalPerson naturalPerson)
        {
            var  naturalPersonDb = await _context.NaturalPersons.FindAsync(id);
            if (naturalPersonDb == null) {
                _context.NaturalPersons.Update(naturalPerson);
            }
            await _context.SaveChangesAsync();
            return naturalPerson;
        }

        public async Task DeleteNaturalPersonAsync(int id)
        {
            var naturalPerson = await _context.NaturalPersons.FindAsync(id);
            if (naturalPerson != null)
            {
                _context.NaturalPersons.Remove(naturalPerson);
                await _context.SaveChangesAsync();
            }
        }

        // ClientStatus CRUD
        public async Task<ClientStatus> CreateClientStatusAsync(ClientStatus clientStatus)
        {
            _context.ClientStatuses.Add(clientStatus);
            await _context.SaveChangesAsync();
            return clientStatus;
        }

        public async Task<ClientStatus> GetClientStatusByIdAsync(int id)
        {
            return await _context.ClientStatuses.FindAsync(id);
        }

        public async Task<List<ClientStatus>> GetAllClientStatusesAsync()
        {
            return await _context.ClientStatuses.ToListAsync();
        }

        public async Task<ClientStatus> UpdateClientStatusAsync(int id, ClientStatus clientStatus)
        {
            var  clientStatusDb = await _context.ClientStatuses.FindAsync(id);
            if (clientStatusDb == null) {
                _context.ClientStatuses.Update(clientStatus);
            }
            await _context.SaveChangesAsync();
            return clientStatus;
        }

        public async Task DeleteClientStatusAsync(int id)
        {
            var clientStatus = await _context.ClientStatuses.FindAsync(id);
            if (clientStatus != null)
            {
                _context.ClientStatuses.Remove(clientStatus);
                await _context.SaveChangesAsync();
            }
        }

        // Gender CRUD
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            return await _context.Genders.FindAsync(id);
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> UpdateGenderAsync(int id, Gender gender)
        {
            var  genderDb = await _context.Genders.FindAsync(id);
            if (genderDb == null) {
                _context.Genders.Update(gender);
            }
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task DeleteGenderAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender != null)
            {
                _context.Genders.Remove(gender);
                await _context.SaveChangesAsync();
            }
        }

        // Ownership CRUD
        public async Task<Ownership> CreateOwnershipAsync(Ownership ownership)
        {
            _context.Ownerships.Add(ownership);
            await _context.SaveChangesAsync();
            return ownership;
        }

        public async Task<Ownership> GetOwnershipByIdAsync(int id)
        {
            return await _context.Ownerships.FindAsync(id);
        }

        public async Task<List<Ownership>> GetAllOwnershipsAsync()
        {
            return await _context.Ownerships.ToListAsync();
        }

        public async Task<Ownership> UpdateOwnershipAsync(int id, Ownership ownership)
        {
            var  ownershipDb = await _context.Ownerships.FindAsync(id);
            if (ownershipDb == null) {
                _context.Ownerships.Update(ownership);
            }
            await _context.SaveChangesAsync();
            return ownership;
        }

        public async Task DeleteOwnershipAsync(int id)
        {
            var ownership = await _context.Ownerships.FindAsync(id);
            if (ownership != null)
            {
                _context.Ownerships.Remove(ownership);
                await _context.SaveChangesAsync();
            }
        }

        // StaffStatus CRUD
        public async Task<StaffStatus> CreateStaffStatusAsync(StaffStatus staffStatus)
        {
            _context.StaffStatuses.Add(staffStatus);
            await _context.SaveChangesAsync();
            return staffStatus;
        }

        public async Task<StaffStatus> GetStaffStatusByIdAsync(int id)
        {
            return await _context.StaffStatuses.FindAsync(id);
        }

        public async Task<List<StaffStatus>> GetAllStaffStatusesAsync()
        {
            return await _context.StaffStatuses.ToListAsync();
        }

        public async Task<StaffStatus> UpdateStaffStatusAsync(int id, StaffStatus staffStatus)
        {
            var  staffStatusDb = await _context.StaffStatuses.FindAsync(id);
            if (staffStatusDb == null) {
                _context.StaffStatuses.Update(staffStatus);
            }
            await _context.SaveChangesAsync();
            return staffStatus;
        }

        public async Task DeleteStaffStatusAsync(int id)
        {
            var staffStatus = await _context.StaffStatuses.FindAsync(id);
            if (staffStatus != null)
            {
                _context.StaffStatuses.Remove(staffStatus);
                await _context.SaveChangesAsync();
            }
        }
    }
}