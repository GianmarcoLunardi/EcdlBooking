using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace EcdlBooking.Services.Repository
{
    public class SchoolRepository : GenericRepo<School>, ISchoolRepository
    {
        private readonly ApplicationDbContext _db;
        public SchoolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

        public School Find(Guid id)
        {
            School scuola = _db.Schools.Find(id);
            return scuola;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown(Guid? idSchool)
        {
            // servizio che data la tabella delle scuole restitutisce
            // una collezione di selectlistitem per la visualizzazione di tutte le scuole
            // il valore deve essere sempre nullo

            IQueryable<SelectListItem> lista = _db.Schools
                .Select(i =>
                 new SelectListItem
                 {
                     Text = i.Name,
                     Value = i.id.ToString(),
                     Selected = false
                 })

                ;

            var ListaMenu = lista.ToList();


            // Caso in cui è già stato selezionato una scuola con il suo id 
            // loci vuole fare appararire come prioma scelta nel menu a tendina

            
            if (idSchool != null) {

                var ScuolaSelezionata = ListaMenu.Where(s => Guid.Parse(s.Value) == idSchool); 
               // ScuolaSelezionata.Selected = true;


               

            
                }
            
                //    new SelectListItem()


                 
          
            // controllo se id non è nullo allora l emeneto esiste e viene selezionato
            /*




            if (idSchool != null)
            {
                SelectListItem eleneto = lista.FirstOrDefault(x => x.Value == idSchool.ToString());
                eleneto.Selected = true;    
            }
            */
            return ListaMenu ;
;
            
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
      
        {
            throw new NotImplementedException();
        }

        public void Update(School school)
        {
            _db.Schools.Update(school);
                   // il metodo update non è implementato in generic repo
            // quindi lo implemento io
            // _db.Entry(school).State = EntityState.Modified;
            // _db.SaveChanges();
            // oppure
            // _db.Schools.Update(school);
            // _db.SaveChanges();
        }
    }

}
