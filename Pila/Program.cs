

using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.InteropServices;

public class Program
{

    //Interfaccia 
    // Implementa i metodi gli attributi che deve implementare una pila
    // L interfaccia serve poi a fare lo stubbing  

    public interface IPila<T>
    {
        Boolean PilaVuota(); // verifica se la pila è vuota
        T LeggiPila(); // legge l'elemento in cima alla pila senza rimuoverlo
        void FuoriElemento(); // rimuove l'elemento in cima alla pila
        void InPila(T elemento); // inserisce un elemento in cima alla pila
    }

    public class Pila : IPila<int>
    {
        int ultimo_elemento = 9;
        int[] pila = new int[9];
        int indice = 0;

        public void FuoriElemento()
        {
            if (!PilaVuota()) { indice = indice - 1; }
            ;
        }

        public void InPila(int elemento)
        {
            if (indice < ultimo_elemento)
            {
                pila[indice] = elemento;
                indice++;


            }

        }

        public int LeggiPila()
        {
            return pila[indice];
        }

        public bool PilaVuota()
        {
            return indice == 0;
        }
    }

    public static void Main(string[] args)
    {
        int i = 200;

        void FunzioneRicorsiva (int a)
        {
            if (a==5)  //condizione d arresto
                {
                    //Corpo
                    Console.WriteLine(a);
                }
            else
                {
                // corpo che viene ripetuto
                Console.WriteLine(a);

                FunzioneRicorsiva(a + 1);

               // Console.WriteLine(a);
            }
        }


        FunzioneRicorsiva(1);



        Console.WriteLine(i);



  





    }

}


