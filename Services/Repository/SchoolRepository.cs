using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Repository
{
    public class SchoolRepository : GenericRep<School>, ISchoolRepository
    {
        private readonly ApplicationDbContext _db;
        public SchoolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Schools.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.id.ToString()
            });
        }
        public void Update(School school)
        {
            _db.Schools.Update(school);
        }
    }

}
