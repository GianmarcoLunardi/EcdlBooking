using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Linq;
using EcdlBooking.Services.Interfaces;



namespace EcdlBooking.Services.Repository
{
    public class ModulilRepository : GenericRepo<Modulo>, IModuliRepository    {
        private readonly ApplicationDbContext _db;
        public ModulilRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

        public Modulo Find(Guid id)
        {
            Modulo modulo = _db.Moduli.Find(id);
            return modulo;
        }

        public List<SelectListItem> GetModuliListForDropDown()
        {
            // servizio che data la tabella delle scuole restitutisce
            // una collezione di selectlistitem per la visualizzazione di tutte le scuole
            // il valore deve essere sempre nullo

            IQueryable<SelectListItem> lista = _db.Moduli
                .Select(i =>
                 new SelectListItem
                 {
                     Text = i.Nome,
                     Value = i.Id.ToString(),
                     Selected = false
                 });



            var primo = lista.First();
            primo.Selected = true;

            var ListaMenu = lista.ToList();

            return ListaMenu;
            
        }


        public void Update(Modulo moduli)
        {
            _db.Moduli.Update(moduli);
        }
    }

}
