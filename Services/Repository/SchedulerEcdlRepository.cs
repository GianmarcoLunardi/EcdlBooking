using AspNetCoreGeneratedDocument;
using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using LanguageExt;

using static LanguageExt.Prelude;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EcdlBooking.Services.Repository
{
    public class SchedulerEcdlRepository : GenericRepo<SchedulerEcdl>, ISchedulerEcdlRepository

    {
        private readonly ApplicationDbContext _db;

        public SchedulerEcdlRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SchedulerEcdl esame)
        {
            _db.SchedulerExams.Update(esame);
        }


        public List<SchedulerEcdl> VisualizzaEsami()
        {
            /*
            List<SchedulerEcdl> ListaEsami =
            
            _db.Exams
                .Include(esaminatore => esaminatore.Esaminatore)
                .Include(scuole => scuole.School)
                .ToList();
            return ListaEsami; 
            */
            return null; 
        }

        public async Task<Unit> PremotaEsami(SchedulerEcdl prenotazione)
        {





        await _db.SchedulerExams.AddAsync(prenotazione);
            await _db.SaveChangesAsync();


            return  Unit.Default; ;
        }


        // inserimento fumziomale

        public async Task<int> PrenotazioneAsync(SchedulerEcdl prenotazione)
        {

           await _db.SchedulerExams.AddAsync(prenotazione);
           return await _db.SaveChangesAsync();    
        }



        public List<Exam> VisualizzaEsamiDaSostenere()
        {/*
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

     
    }
}
