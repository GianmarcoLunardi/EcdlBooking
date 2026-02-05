// See https://aka.ms/new-console-template for more information

using LanguageExt;

Either<int, int> Monad;


Monad =Either<int, int>.Right(100); // assume lo stato R con valore 100
Monad = Either<int, int>.Left(-1); // cambia stato in L con valore -1


Monad.Match(
    Right: value => Console.WriteLine($"Success: {value}"),
    Left: error => Console.WriteLine($"Failure: {error}")
);


Console.WriteLine("Prova Del Task");

var esempio = new prove.Classe();

var risultato = await esempio.MetodoAsync();

risultato.Match(
    Right: value => Console.WriteLine($"Success: {value}"),
    Left: error => Console.WriteLine($"Failure: {error}")
);