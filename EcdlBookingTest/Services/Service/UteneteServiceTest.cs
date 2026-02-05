using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.Service;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EcdlBookingTest;
[TestFixture]
public class UteneteServiceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description="Ritorna gli utenti che sono insegnanti")]
    public async Task DownList_Esaminatori_Esame()
    {
        //Arrange

        var mockManager = new Mock<UserManager<ApplicationUser>>();
        //var mockIsRule = new Mock<UserManager<ApplicationUser>>();

        // Arrange Inizializzazione del servizio 
        // Si vuole simulare un servizio che invia una mail 
        // e si vuole conficurare il metodi setup(strin indirizzo, string soggetto, string corpo)
        // It.IsAny<T> un qualsiasi valore di tipo T
        mockManager.Setup(m => m.Users).Returns(
            new List<ApplicationUser>
            {
                new ApplicationUser { Name = "Name1", Surname = "Surname1", Id="1" },
                new ApplicationUser { Name = "Name2", Surname = "Surname2", Id="2" },
                new ApplicationUser { Name = "Name3", Surname = "Surname3", Id="3" }
                }.AsQueryable()

            );
        mockManager.Setup(m => m.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(true);

        UteneteService uteneteService = new UteneteService(mockManager.Object);
        // Act

        //var result = await uteneteService.

        //Result =

        //Assert.Pass();
    }
}
