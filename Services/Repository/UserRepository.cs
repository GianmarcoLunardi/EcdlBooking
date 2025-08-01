using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcdlBooking.Services.Repository
{
    public class   UserRepository : GenericRepo<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;


        public UserRepository(ApplicationDbContext db 
                             ) : base(db)
        {
            _db = db;
        }


        public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null)
        {



            List<SelectListItem> Lista = new List<SelectListItem>();

            //if (IdUser == null)
            //   .Roles
            
            Lista = _db.Ruoli.Select(Ruolo => new SelectListItem
            {
                Text = Ruolo.Name,
                Value = Ruolo.Id
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







        public async Task<List<SelectListItem>> ListaEsaminatori()
        {
            List<SelectListItem> Lista = new List<SelectListItem>();

            //if (IdUser == null)
            //   .Roles

            Lista = _db.Ruoli
                .Where(utente => utente.Name == "Esaminatore")
                .Select(Ruolo => new SelectListItem
            {
                Text = Ruolo.Name,
                Value = Ruolo.Id
            })


                .ToList();

            return Lista;
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

             _db.Utenti.Update(user);
            //throw new NotImplementedException();
        }

        public List<SelectListItem> DownList_Esaminatore()
        {
            throw new NotImplementedException();
        }



    }
}
