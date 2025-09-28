using EcdlBooking.Data;
using EcdlBooking.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


// https://www.youtube.com/watch?v=VBT9CR9sl-A

// Schema Relazionale
// https://dbdiagram.io/d/Diagramma-Booking-ECDL-68cc48c45779bb7265234be5

namespace EcdlBookingTest.Data
{
    [TestFixture]
    [Category("seeding")]
    internal class ContextTest
    {
        private ApplicationDbContext _context;
        
        
        [SetUp]
        
        public void Setup()
        {

            //Arrang
            //Act
            //Assertion

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Tabella")
                .Options;
            _context= new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
           
            
        }


        [Category("seeding")]
        [Test(Description =" verifica dell seedind dulla tabella scuole")]
        public void School_Seeding_IteFalconeIsInsertedi()
        {
            // test di verifica se l ita falcone è stato inserito 
            var reult = _context.Schools.Find(Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181"));
            Assert.That(reult.Name, Is.EqualTo("ITE LICEO Falcone Borsellino"));
     
        }

        [Category("seeding")]
        [Test(Description = "verifica dell seedind dulla IdentityRuole")]
        public void IdentityRole_Seeding_StudenteIsInserted()
        {
            //Act
            IdentityRole? result = _context.Ruoli.Find("2a1447a0-8c6a-46e9-b187-25a28e8da50e");
            Assert.That(result.Name, Is.EqualTo("Admin"));


        }
        [Category("seeding")]   
        [Test(Description = "verifica dell seedind dulla utente Gianmarco_Lunardi")]
        public void ApplicationUser_Seeding_GianmarcoLunardiIsInserted()
        {
            //Act
            ApplicationUser? result = _context.Utenti.Find("9f5de216-b03f-43d2-b0a1-4f9d6bb5c126");
            Assert.That(result.UserName, Is.EqualTo("Gianmarco_Lunardi"));


        }

        [Category("Relazioni")]
        [Test(Description = "Verifica Delle Relazioni che ha la classe ApplicationUser con School")]
        public void ApplicationUser_RelactionShcool_Ite()
        {
            //Arrange
            ApplicationUser? Utente = _context.Utenti.Find("9f5de216-b03f-43d2-b0a1-4f9d6bb5c126");
            School? SFalcone = _context.Schools.Find(Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181"));
            Utente.School = SFalcone;
            _context.SaveChanges();
            //Act 
            var result = _context.Utenti.Find("9f5de216-b03f-43d2-b0a1-4f9d6bb5c126");

            //Asssert
            Assert.Multiple(() =>
            {
               
                Assert.That(result.School.Name, Is.EqualTo("ITE LICEO Falcone Borsellino"));
                Assert.That(result.IdSchool, Is.EqualTo(SFalcone.Id) , "Partecipa : Utenti->School");
                Assert.That(result, Is.EqualTo(SFalcone.ApplicationUsers[0]),"Partecipa: School.ApplicationUsers -> Utente");
            });







        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}


/*
 * Test Sulle Relazione degli oggetti 
 */