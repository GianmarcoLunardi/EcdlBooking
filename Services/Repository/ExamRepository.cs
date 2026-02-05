using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.Services.Repository
{
    public class ExamRepository : GenericRepo<Exam>, IExamRepository 
    {
        private readonly ApplicationDbContext _db;

        public ExamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Exam esame)
        {
            _db.Exams.Update(esame);
        }

        public User_Studente_PrenotaEsame ViewModel(ApplicationUser studente, Exam Esame)
        {

            return new User_Studente_PrenotaEsame
            {
               DataPrenotazione = DateTime.Now,
               Studente = studente, 


                IdEsame = Esame.id,
                Exam =Esame,

               IdModulo = null,
               Modulo = null,
               // il menu dropdown non dovrebbe contenere i moduli già fatt
               ListaModuli =  _db.Moduli
                                    .Select(m => new SelectListItem
                                    {
                                        Text = m.Nome,
                                        Value = m.Id.ToString()
                                    }).ToList()

            };
            //throw new NotImplementedException();
        }

        Exam IExamRepository.GetExam(Guid guid)
        {
            // viene selezionanato un il primo valore che 
            // soddisfa il predicaro oppure Nulla
            return _db.Exams.FirstOrDefault(e => e.id == guid);

            // Primo Elemento({e ∈ Exams | e.id == guid })
            // altrimenti Null 

        }
        public List<Exam> VisualizzaEsami()
        {

            List<Exam> ListaEsami =
        // c# core è dotato di Lazy londing dei dati
        // o meglio i dati associati alle relazioni non vengono acaricati
        // fino a quando non viene chiesto esplicitamente

            _db.Exams
            // A = { Exam X Utenti  | e ∈ Esaminatore , u ∈ Utenti
            //  and esaminatore.id = Utenti.IdEsamitare }
                .Include(esaminatore => esaminatore.Esaminatore)
                .Include(scuole => scuole.School)
                .ToList();

            return ListaEsami;  

        }

        public List<Exam> VisualizzaEsamiDaSostenere()
        {
            /*
            List<Exam> ListaEsami =

            _db.Exams
                .Include(esaminatore => esaminatore.Esaminatore)
                .Include(scuole => scuole.School)
                .OrderBy(x => x.Data)
                .ToList();
            return ListaEsami;
            */

            return null;
        }


        Exam GetExam(Guid guid)
        {
            return _db.Exams.FirstOrDefault(e => e.id == guid);
        }



        void IExamRepository.Update(Exam esame)
        {
            throw new NotImplementedException();
        }

        User_Studente_PrenotaEsame IExamRepository.ViewModel(ApplicationUser studente, Exam Esame)
        {
            throw new NotImplementedException();
        }
        /*
        List<Exam> IExamRepository.VisualizzaEsami()
        {
            throw new NotImplementedException();
        }
        */
        List<Exam> IExamRepository.VisualizzaEsamiDaSostenere()
        {
            throw new NotImplementedException();
        }
    }
}
