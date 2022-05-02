using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EjerciciosCanterosFlorencia
{
    class Program
    {
        /*Implementar un diccionario que contendrá los siguientes valores:
        values.Add("Juan", "55423412");
        values.Add("Ernesto", "56985623");
        values.Add("Mariana", "54787451");
        Realice las siguientes operaciones:
        a.Revisar en el diccionario si existe un índice llamado “Juan”. En caso de que exista,
        mostrar su valor(utilice el método ContainsKey)
        b.Revisar en el diccionario si existe un índice llamado “Pedro”. En caso de que exista,
        mostrar su valor, si no existe imprimir por pantalla “No contiene la llave” (utilice el
        método TryGetValue)
        c.Recorrer el diccionario y mostrar todos sus datos(índice y valor).
        d.Alterar el valor cuyo índice es “Mariana” por “58251425”. Imprimir el nuevo valor.*/


        public void Diccionario()
        {
            //inicialización y crear a valores
            Dictionary<string, string> values = new Dictionary<string, string>();

            //añadir valores
            values.Add("Juan", "55423412");
            values.Add("Ernesto", "56985623");
            values.Add("Mariana", "54787451");


            Console.WriteLine("");

            if (values.ContainsKey("Juan"))
            {
                Console.WriteLine(values["Juan"]);
            }
            else
            {
                Console.WriteLine("No contiene la llave");
            }


            Console.WriteLine("");

            string key = "";
            if (values.TryGetValue("Pedro", out key))
            {
                Console.WriteLine("Su valor es:" + key);
            }
            else
            {
                Console.WriteLine("No contiene la llave");
            }


            Console.WriteLine("");

            foreach (var value in values)
            {
                Console.WriteLine(value.Key + " " + value.Value);
            }


            Console.WriteLine("");

            values["Mariana"] = "58251425";

            Console.WriteLine("El nuevo teléfono de Mariana:" + " " + values["Mariana"]);

        }




        private static readonly string[] colors = { "MAGENTA", "RED", "WHITE", "BLUE", "CYAN" };
        private static readonly string[] removeColors = { "RED", "WHITE", "BLUE" };

        public void Imprimir(List<string> lista)
        {
            foreach (var item in lista)
            {
                Console.Write(item + " ");
            }
        }

        public void AgregarLista(string[] addToList, List<string> listaNueva)
        {
            for (int iterador = 0; iterador < addToList.Length; iterador++)
            {
                listaNueva.Add(addToList[iterador]);
            }

            Console.WriteLine("");
        }


        public void DobleLista()
        {
            /*a. Armar dos listas, una con los valores del vector “colors” y otra con los valores del
            vector “removeColors”.
            b. Mostrar la lista de colores por pantalla.
            c. De la lista de colores eliminar los colores listados en la otra lista (removeColors).
            d. Volver a mostrar la lista de colores por pantalla.*/

            List<string> listOne = new List<string>();

            AgregarLista(colors, listOne);

            Console.WriteLine("");

            List<string> listTwo = new List<string>();

            AgregarLista(removeColors, listTwo);

            Console.WriteLine("list:");

            Imprimir(listOne);

            Console.WriteLine("");


            foreach (var item in listTwo)
            {
                listOne.Remove(item);
            }

            Console.WriteLine("List después de llamar a RemoveColores:");

            Imprimir(listOne);

            Console.WriteLine("");
        }



        /*Realizar un software que solicite al usuario que ingrese un párrafo por teclado y el software 
          cuente la cantidad de ocurrencias de cada palabra. Asimismo, deberá indicar la cantidad de 
          palabras distintas que existen en el párrafo ingresado por el usuario. Para resolver usar diccionario*/

        public void Parrafo()
        {
            Console.WriteLine("");

            Dictionary<string, int> parrafo = new Dictionary<string, int>();

            Console.WriteLine("Ingrese un parrafo = ");
            string unParrafo = Console.ReadLine();
            Console.WriteLine(" ");

            string[] palabra = unParrafo.Split(' ');


            for (int iterador = 0; iterador < palabra.Length; iterador++)
            {
                if (parrafo.ContainsKey(palabra[iterador]))
                {
                    parrafo[palabra[iterador]] += 1; //cuenta y  sumar1
                }
                else
                {
                    parrafo.Add(palabra[iterador], 1);
                }

            }

            foreach (var valor in parrafo)
            {
                Console.WriteLine(valor.Key + " " + valor.Value);
            }

        }



        public void Netflix()
        {
            /*En el archivo “ratings.txt” se encuentran las puntuaciones realizadas por los usuarios de Netflix 
            para cada película. El formato del archivo es el siguiente:
            <identificador de película>,<identificador de usuario>,<puntaje asignado>,<fecha del puntaje>
            Se solicita realizar un top 10 de los usuarios que más puntuaciones hicieron en Netflix*/

            StreamReader texto = new StreamReader("C:\\Users\\FNC\\Desktop\\ratings.txt");

            string line;

            Dictionary<string, int> usuarios = new Dictionary<string, int>();

            Console.WriteLine("top 10 de usuarios");


            
             while ((line= texto.ReadLine())  != null)
             {
                
                 string[] puntajes = line.Split(',');


                     if (usuarios.ContainsKey(puntajes[1]))
                     {
                        usuarios[puntajes[1]] += 1; //cuenta y  sumar1
                     }
                     else
                     {
                         usuarios.Add(puntajes[1], 1);
                     }

             }


            var sortedDict = from usuario in usuarios orderby usuario.Value descending select usuario;

            int topTen = 0;
            foreach (var value in sortedDict)
            {
                topTen++;
                Console.WriteLine(value.Key + " " + value.Value);

                if (topTen == 10)
                {
                    break;
                }
            }

            texto.Close();

        }



        static void Main(string[] args)
        {
            Program f = new Program();
             f.Diccionario();
             f.DobleLista();
             f.Parrafo();
             f.Netflix();
        }


    }
}