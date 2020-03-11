using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace VISTA
{
    abstract class InterfazPrincipal
    {

        public static void mostrarMenuPrincipal()
        {
            Console.WriteLine("¿A que Modulo Desea Ingresar?");
            Console.WriteLine();
            Console.WriteLine("1) Armado de Recorridos.");
            Console.WriteLine("2) Gestion de Choferes.");
            Console.WriteLine("3) Venta de Pasajes.");
            Console.WriteLine("4) Estadisticas.");
            Console.WriteLine("5) Salir del Sistema");

            Console.WriteLine();
            seleccionarSubMenu();
        }


        public static void seleccionarSubMenu()
        {
            Boolean validar = true;
            while (validar)
            {               
                try
                {
                    Console.Write("Seleccione: ");
                    int intSeleccion = int.Parse(Console.ReadLine());

                    if (intSeleccion == 5)                   
                        Environment.Exit(1);
                    
                    else if (intSeleccion >= 1 && intSeleccion <= 4)
                    {
                        IInterfazSubMenu objFabricaInterfaz = FabricaInterfazMenuPrincipal.crearInterfaz(intSeleccion);
                        validar = false;
                        objFabricaInterfaz.mostrarSubMenu();
                    }

                    else                    
                        throw new ExceptionSeleccionNoValida();                                                                                                 
                }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros"); }
                catch(ExceptionSeleccionNoValida e) { e.mensajeError(); }
            }            
        }



    }
}
