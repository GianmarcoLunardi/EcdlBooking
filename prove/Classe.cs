using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LanguageExt.Compositions<A>;


namespace prove
{
    internal class Classe
    {
        /*
        public async Task<Either<int, string>> cc MetodoAsync()
        {

             Either<int, string>.Right("Operazione riuscita");
        }
        */

        Option<int> Uno = Option<int>.Some(1);
        Option<int> Due = Option<int>.None;




        /// Si prova a fare il composto/*
        //Func<int, int> f = (x) => x + 1; // ka funzione somma uno
        //Func<int, int> g = (y) => y + 2; // la funzione moltiplica per due

        /*
       consol.WriteLine( g(f(3)) ); // Stampa 8

        Operator<
        consol.WriteLine( f(3).g(3)); // Stampa 8 usando il composto       
        */
    }
}