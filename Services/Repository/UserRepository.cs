using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Threading.Tasks;
namespace EcdlBooking.Services.Repository
{
    public class   UserRepository : GenericRepo<ApplicationUser>, IUserRepository
    {

        private readonly ApplicationDbContext _db;


        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        
        }


        public List<SelectListItem> DownList_Rule_User(IList<string> Ruoli)
        {

            //string NomeRuolo = Ruoli.First();

            List<SelectListItem> Lista = new List<SelectListItem>();

            //if (IdUser == null)
            //   .Roles

            Lista = _db.Ruoli.Distinct().Select(Ruolo => new SelectListItem
            {
                Text = Ruolo.Name,
                Value = Ruolo.Id,
                //Selected = Ruolo.Name == NomeRuolo ///funziona ma non servw

            })


                .ToList();

            return Lista;

           // throw new NotImplementedException();
        }

        // Funzione che ritorna tutta la lista degli utenti
        // implementata nel geniric
        /*
        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> filter = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null, string includeProperties = null)
        {
            IQueryable<ApplicationUser> ListaUtenti ;
            ListaUtenti = _db.Users ;

            if (includeProperties != null)
            {
                ListaUtenti.Include(includeProperties);
            }

            return ListaUtenti.ToList();
            //throw new NotImplementedException();
        }
        */

        public async Task<ApplicationUser> GetAsync(string IdUtente) {
            var utente = await _db.Users.FirstOrDefaultAsync(u => u.Id == IdUtente);

 
            return utente;
        }

        public async Task<IList<string>> GetRulesIdAsync(ApplicationUser Utente) {


            IList<string> ListaIdRuoli = new List<string>();

            // Selezionare un sottoinsieme del insieme UserRoles
            IList<string> IdRuoliUtenti= _db.UserRoles.Where(ur => ur.UserId == Utente.Id).Select(ur => ur.RoleId.ToString()).ToList();
            // _db rapprenta la una copia in memoria della base
            //Attributo UserRole è una tabella , quindi una collezione di elementi
            //IdRuoliUtenti ⊂ UserRoles = { ur | ur∈UserRoles and ur.UserId == Utente.Id }  
            return IdRuoliUtenti;
        }




        public async Task<List<SelectListItem>> ListaEsaminatori()
        {
            return null;
        }

        public Task<IEnumerable<ApplicationUser>> All_School(PageInfo page = null)
        {
            throw new NotImplementedException();
        }
        public Task<ApplicationUser> FindInclude(Guid id, string Inclu = null)
        {
            throw new NotImplementedException();
        }

        public Task add(ApplicationUser Entity)
        {
            throw new NotImplementedException();
        }

        public Task delete(ApplicationUser Entity)
        {
            throw new NotImplementedException();
        }



        public ApplicationUser GetFirstOrDefault(Expression<Func<ApplicationUser, bool>> filter = null, string includeProperties = null)
        {


            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> Get_Role_ListForDropDown(Guid? IdUser)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser user)
        {

             _db.ApplicationUsers.Update(user);
            //throw new NotImplementedException();
        }




    }
}
