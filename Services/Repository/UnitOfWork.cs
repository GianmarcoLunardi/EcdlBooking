using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace EcdlBooking.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        //private readonly RoleManager<IdentityRole> _roleManager;
        // bprivate readonly A

        public UnitOfWork(ApplicationDbContext db )
        {
            _db = db;
            School = new SchoolRepository(_db);
            Utente = new UserRepository(_db);
            Esami = new ExamRepository(_db);
            SchedulerEcdl = new SchedulerEcdlRepository(_db);


        }

        

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ISchoolRepository School { get; private set; }
        public IUserRepository Utente { get; private set;  }
        public IExamRepository Esami { get; private set; }
        public ISchedulerEcdlRepository SchedulerEcdl { get; private set; }
    }
    
}
