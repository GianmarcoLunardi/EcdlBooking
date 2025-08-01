namespace EcdlBooking.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ISchoolRepository School { get; }
        public IUserRepository Utente { get;}
        IExamRepository Esami { get; }
        Task Save();
    }
}
