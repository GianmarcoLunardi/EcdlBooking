namespace EcdlBooking.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public ISchoolRepository School { get; }
        public IUserRepository Utente { get;}
        public IExamRepository Esami { get; }
        public ISchedulerEcdlRepository SchedulerEcdl { get;}
        public IModuliRepository Moduli { get; }
        Task Save();
    }
}
