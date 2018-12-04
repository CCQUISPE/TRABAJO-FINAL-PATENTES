using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace TRABAJO_FINAL_PATENTES
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            int valido = 0;
            Stack miPila = new Stack();
            int opcion;//opcion del menu 
            do
            {

                Console.Clear();//se limpia consola
                opcion = menu();//muestra menu y espera opción
                switch (opcion)
                {
                    case 1:

                        if (valido == 0)
                        {
                            mensaje("\n ============= LA PILA SE CREO EXITOSAMENTE!");
                            valido = 1;
                        }
                        else
                            mensaje("\n ============= LA PILA ya esta creada, no se puede volver a crear");

                        break;
                    case 2:

                        if (valido == 1)                    // valida si la pila esta creada
                        {
                            Borrar_Pila(ref miPila);       // borra pila 
                            valido = 0;
                        }
                        else
                            Console.WriteLine("\n ============= LA PILA No esta creada, no se puede eliminar");
                        Console.ReadKey();
                        break;
                    case 3:                            // agregar patente valido previo que la lista este creada
                        if (valido == 1)
                        {
                            Agregar_Patente(ref miPila); // agregar patente
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");
                        break;
                    case 4:
                        if (valido == 1)
                        {
                            Eliminar_Patente(ref miPila);    //borrar patente
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");
                        break;
                    case 5:
                        if (valido == 1)
                        {
                            Listar_Todas_Patentes(miPila); // listas todas las patentes
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");
                        break;
                    case 6:
                        if (valido == 1)
                        {
                            Listar_ultima_Patente(ref miPila);  // lista ultima patente
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");

                        break;
                    case 7:
                        if (valido == 1)
                        {
                            Listar_primera_Patente(ref miPila);  // lista primera patente
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");
                        break;
                    case 8:
                        if (valido == 1)
                        {
                            Cantidad_Patentes(ref miPila);       // indica cantidad de petentes
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");

                        break;
                    case 9:
                        if (valido == 1)
                        {
                            BUSCAR_Patente(ref miPila);    //busca patente
                        }
                        else
                            mensaje("\n ============= LA PILA No esta creada");
                        break;
                    case 10:
                        mensaje("\n 1_ Los valores a ingresar deben ser compuesto por 6 valores, los tres primeros corresponden" +
                            " a letras y los 3 ultimo corresponden a numeros, separados por un espacio, el ingreso puedo ser compuesto por mayusculas y/o minusculas" +
                            " sin omitir el espacio. \n" +
                            " 2_ No se caeptan numeros negativos, ni valores que no contemplen los 3 caractes, ejemplo si la parte numerica de nuestra patente es 23," +
                            " esta debe ser completada por cero por lo que queda:   023\n"+
                            " 3_ Primero se debe crear la pila, que es nuestro conetenedor, para ello utilice la opcion correcta del menu.\n" +
                            " 4_ Recuerde que puede contactar al administrador ante dudas y/o consultas, no omitir ser claro en la descripcion que plantee. \n");
                        break;
                    case 11:
                        mensaje("\n Este programa fue realizado por alumno Camila Quispe, alumno de terciario IFTS18." +
                            " Ante dudas y/o consultas, favor contacte al admnistrador" +
                           " casilla e-mail: cami_84278@hotmail.com ");
                        break;
                    case 12: break; //salir
                    default:
                        Console.WriteLine("ERROR: la opción no es valida. Intente de nuevo.");
                        break;

                }
            }
            while (opcion != 12);
            Console.WriteLine("El programa a finalizado.");
            Console.WriteLine("Saludos.");
            Console.ReadKey();
        }

        /** muestra menu y retorna opción */
        static int menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     \n                   ============================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                      ░▒▓||||   ** SISTEMA DE REGISTRO DE PATENTES - V 1.0 -**N   ||||▓▒░ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                   ============================================================================ \n\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                             ╔══════════════════════════════════════╗ ");
            Console.WriteLine("                             ║    1) -        CREAR PILA            ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    2) -        BORRAR PILA           ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    3) -      AGREGAR PATENTE         ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    4) -       BORRAR PATENTE         ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    5) -   LISTAR TODAS LAS PATENTES  ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    6) -    LISTAR ULTIMA PATENTE     ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    7) -    LISTAR PRIMERA PATENTE    ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    8) - INDICAR CANTIDAD DE PATENTES ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    9) -     BUSCAR PATENTE           ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    10) -         MANUAL              ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    11) -         CONTACTO            ║ ");
            Console.WriteLine("                             ╠══════════════════════════════════════╣ ");
            Console.WriteLine("                             ║    12) -         SALIR               ║ ");
            Console.WriteLine("                             ╚══════════════════════════════════════╝ \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  »»»» Ingresa opcion: ");
            try
            {
                int valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                return 0;
            }
        }
        /** mensaje de creacion de pila */
        static void mensaje(String texto)
        {
            if (texto.Length > 0)
            {
                Console.WriteLine("\n=======================================================");
                Console.WriteLine(" {0}", texto);
                Console.WriteLine(" =======================================================");
                Console.WriteLine("\n .............Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }

        /** Elimina todo los elementos de la pila */
        static void Borrar_Pila(ref Stack pila)
        {
            pila.Clear();
            mensaje("Pila eliminada exitosamente");

        }

        /** añade un nuevo elemento a la pila */
        static void Agregar_Patente(ref Stack pila)
        {

            string letra;
            Console.Write("ingresa patente, con siguiente formato 'RV0 456': ");
            letra = Convert.ToString(Console.ReadLine());
            string[] partNumbers = { letra };
            Regex rgx = new Regex(@"^[aA-zZ]{3}\s[0-9]{3}$");
            foreach (string partNumber in partNumbers)
                if (rgx.IsMatch(partNumber))
                {
                    pila.Push(letra);
                    mensaje("   La patente se ingreso correctamente....");
                }

                else
                    mensaje(".......Patente no valida, el formato debe ser 'RV0 456' ");

        }

        /** Elimina elemento de la pila */
        static void Eliminar_Patente(ref Stack pila)
        {

            if (pila.Count != 0)         // valida que la pila posea elementos
            {
                string valor = (string)pila.Pop();              // de ser correcto elimina elemento con pop       
                mensaje("Elemento " + valor + " eliminado");
                Console.ReadKey();
            }
            else
            {
                Listar_Todas_Patentes(pila);
            }
        }

        /** Imprime pila */
        static void Listar_Todas_Patentes(Stack pila)
        {
            if (pila.Count != 0)                         //valida que la pila tenga elementos
            {
                int i = pila.Count;
                Console.WriteLine("");
                foreach (string dato in pila)           //recorre la pila e imprime por pantalla
                {

                    Console.WriteLine("|          ");
                    Console.WriteLine("|{0}- {1}      ", i, dato);
                    Console.WriteLine("|______________");
                    i--;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar ...");
                Console.ReadKey();
            }
            else if (pila.Count == 0)
            {
                mensaje("....La Pila esta vacia");

            }
        }
        /** Listar ultima patente**/
        static void Listar_ultima_Patente(ref Stack pila)
        {

            if (pila.Count != 0)             // validacion de que la pila posea elementos
            {

                Console.WriteLine("El el ultimo valor es");
                Console.WriteLine("\n| {0} - {1}", pila.Count,pila.Peek());  //el valor que esta en el tope de la pila
                Console.WriteLine("|______________");
                Console.ReadKey();
            }
            else
            {
                mensaje("La pila no posees elementos");

            }
        }

        /** Listar primera patente**/
        static void Listar_primera_Patente(ref Stack pila)
        {

            if (pila.Count != 0)
            {
                int i = 1;
                Console.WriteLine("");
                foreach (string dato in pila)
                {
                    if (i == pila.Count)
                    {
                        Console.WriteLine("|          ");
                        Console.WriteLine("|1- {0}      ", dato);
                        Console.WriteLine("|______________");
                        Console.ReadKey();
                    }
                    i++;
                }
                mensaje("");
            }
            else
            {
                mensaje("La pila no posees elementos");

            }
        }

        /**Indica cantidad de elementos que posee la pila**/
        static void Cantidad_Patentes(ref Stack pila)
        {
            if (pila.Count != 0)
            {
                Console.WriteLine("La cantidad de elementos cargados en la pila es:{0}", pila.Count);
                Console.ReadKey();
            }
            else
            {
                mensaje("La pila no posees elementos");

            }

        }

        /** Busca valor cargado por pantalla en nuestra pila**/
        static void BUSCAR_Patente(ref Stack pila)
        {
            if (pila.Count != 0)        // validamos que la pila posea elementos
            {
                int T = 0;              // bandera para validacion de dato encontrado
                string letra;
                Console.Write("ingresa patente a buscar, con siguiente formato 'RV0 456': ");
                letra = Convert.ToString(Console.ReadLine());
                string[] partNumbers = { letra };
                Regex rgx = new Regex(@"^[aA-zZ]{3}\s[0-9]{3}$");    
                foreach (string partNumber in partNumbers)
                    if (rgx.IsMatch(partNumber))      // valida si el valor ingresado este en formato correcto
                    {
                        int i = pila.Count;             //iniciamos la variable igual a la cantidad de elementos
                        foreach (string dato in pila)   // recorremos la pila
                        {
                            if (letra == dato)           // buscamos conincidencia y la imprimos
                            {
                                Console.WriteLine("\n Busqueda exitosa!:         ");
                                Console.WriteLine("\n posicion de la patente {0} - valor encontradp {1} ", i, dato);
                                Console.WriteLine("|______________________________________________________");
                                Console.ReadKey();
                                T = 1;                    // si encuentra el dato cambia mi bandera a 1
                            }
                            i++;
                        }
                        if (T ==0)   // si no se encontro el dato la bandera queda en 0 e indica no encontrado       
                        {
                           
                            mensaje("..........Patente no encontrada, por favor" +
                                    " verifique que realmete este cargada en la pila");
                           
                        }
                    }
                    
                    else
                        mensaje(".......Patente no valida, el formato debe ser 'RV0 456' ");
            }
            else if (pila.Count == 0)
            {
                mensaje("....La Pila esta vacia");

            }




        }





    }
}
