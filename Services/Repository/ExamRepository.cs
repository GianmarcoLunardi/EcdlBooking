using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcdlBooking.Services.Repository
{
    public class ExamRepository : GenericRepo<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _db;

        public ExamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void IExamRepository.Update(Exam esame)
        {
            _db.Exams.Update(esame);
        }

        List<Exam> IExamRepository.VisualizzaEsami()
        {
            List<Exam> ListaEsami =

            _db.Exams
                .Include(esaminatore => esaminatore.Esaminatore)
                .Include(scuole => scuole.School)
                .ToList();
            return ListaEsami;  
        }

        List<Exam> IExamRepository.VisualizzaEsamiDaSostenere()
        {
            List<Exam> ListaEsami =

            _db.Exams
                .Include(esaminatore => esaminatore.Esaminatore)
                .Include(scuole => scuole.School)
                .OrderBy(x => x.Data)
                .ToList();
            return ListaEsami;
        }


    }
}
