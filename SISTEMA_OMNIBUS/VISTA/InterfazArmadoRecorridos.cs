using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using CONTROLADOR;
using System.Data;

namespace VISTA
{
    class InterfazArmadoRecorridos: IInterfazSubMenu
    {

        ControladorTerminal objControladorTerminal;
        ControladorOmnibus objControladorOmnibus;
        ControladorRecorrido objControladorRecorrido;



        /************************************************ MENU ARMADO DE RECORRIDOS  ***********************************************/

        public void mostrarSubMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Alta de Terminales.");
            Console.WriteLine("2) Alta de Omnibus.");
            Console.WriteLine("3) Alta de Recorridos");
            Console.WriteLine("4) Volver");

            elegirOpcionMenu();
        }


        /********************************************** ELECCION DE LA OPCION DEL MENU  *********************************************/
        public void elegirOpcionMenu()
        {                        
            Boolean boolValidarOpcion = true;

            while (boolValidarOpcion)
            {                
                string strOpcion = Console.ReadLine();

                switch (strOpcion)
                {
                    case "1":
                        altaDeTerminal();
                        boolValidarOpcion = false;
                        break;
                    case "2":
                        altaDeOmnibus();
                        boolValidarOpcion = false;
                        break;
                    case "3":
                        altaDeRecorridos();
                        boolValidarOpcion = false;
                        break;
                    case "4":
                        volverMenuPrincipal();
                        boolValidarOpcion = false;
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida. Seleccione una Opcion Valida.");
                        break;
                }
            }            
        }


        /********************************************** ALTA DE TERMINAL *********************************************/
        private void altaDeTerminal()
        {
            objControladorTerminal = new ControladorTerminal();           
            Terminal objTerminal = new Terminal();

            Console.Write("Ingrese Nombre de la Terminal: ");
            objTerminal.NombreTerminal = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese Nombre de la Ciudad: ");
            objTerminal.NombreCiudad = Console.ReadLine();
            Console.WriteLine();

            if (objControladorTerminal.validarAltaTerminal(objTerminal))
            {
                objControladorTerminal.agregarTerminal(objTerminal);
                Console.WriteLine("La Terminal fue Dada de Alta Correctamente.");
                presioneTeclaParaContinuar();
            }
            else
            {
                Console.WriteLine("No se Pudo Dar de Alta la Terminal. Debe Completar Todos los Datos.");
                presioneTeclaParaContinuar();
            }            
        }


        /********************************************** ALTA DE OMNIBUS *********************************************/

        private void altaDeOmnibus()
        {
            objControladorOmnibus = new ControladorOmnibus();
            Omnibus objOmnibus = new Omnibus();
            
            objOmnibus.Marca = cargarMarca();
            Console.WriteLine();
            
            objOmnibus.Modelo = cargarModelo();
            Console.WriteLine();

            objOmnibus.Capacidad = cargarCapacidad();
            Console.WriteLine();

            objOmnibus.Tipo = cargarTipo();
            Console.WriteLine();

            if (objControladorOmnibus.validarAltaOmnibus(objOmnibus))
            {
                objControladorOmnibus.agregarOmnibus(objOmnibus);
                Console.WriteLine("El Omnibus Fue Dado de Alta Correctamente. Se asigno a la Unidad: " + objControladorOmnibus.obtenerNumeroUnidadIngresado());                
            }
            else            
                Console.WriteLine("No se Pudo Dar de Alta el Omnibus. Debe Completar Todos los Datos.");

            presioneTeclaParaContinuar();
        }


        /********************************************** ALTA DE RECORRIDOS *******************************************/


        private void altaDeRecorridos()
        {
            objControladorTerminal = new ControladorTerminal();
            objControladorRecorrido = new ControladorRecorrido();

            List<Terminal> terminalesDisponibles = objControladorTerminal.traerTerminales();
            List<Terminal> terminalesSeleccionadas = new List<Terminal>();

            Boolean entrar = true;
            while (entrar)
            {                
                mostrarTerminales(terminalesDisponibles, terminalesSeleccionadas);
                int intSeleccion = seleccionTerminal(terminalesDisponibles);

                if (terminalesSeleccionadas.Count > 0 && intSeleccion == 0)
                {
                    Console.WriteLine("El Recorrido se ha Dado de Alta Correctamente.");
                    objControladorRecorrido.agregarRecorrido(terminalesSeleccionadas);
                    entrar = false;                    
                }

                else if (intSeleccion <= terminalesDisponibles.Count && intSeleccion > 0)
                {
                    terminalesSeleccionadas.Add(terminalesDisponibles[intSeleccion - 1]);
                    terminalesDisponibles.RemoveAt(intSeleccion - 1);
                }
       
                else if (intSeleccion == 0 && terminalesSeleccionadas.Count == 0)
                {
                    Console.WriteLine("No se ha Seleccionado Ninguna Terminal");
                    entrar = false;
                }                                    
            }
            presioneTeclaParaContinuar();            
        }



        private void mostrarTerminales (List<Terminal> terminalesDisponibles, List<Terminal> terminalesSeleccionadas)
        {
            Console.Clear();

            Console.WriteLine("Seleccione las Terminales del Recorrido, Ingrese 0 para Finalizar");
            Console.WriteLine();
            objControladorTerminal.mostrarNombresTerminales(terminalesDisponibles);

            Console.WriteLine("Terminales Seleccionadas: ");
            Console.WriteLine();
            objControladorTerminal.mostrarNombresTerminales(terminalesSeleccionadas);

            Console.WriteLine();            
        }


        private int seleccionTerminal(List<Terminal> terminales)
        {
            int intSeleccion = 0;
            Boolean boolValidar = true;
            while (boolValidar)
            {
                try
                {
                    Console.Write("Seleccione una Terminal:");
                    intSeleccion = int.Parse(Console.ReadLine());

                    if (intSeleccion > terminales.Count)
                        throw new ExceptionSeleccionNoValida();
                    else
                        boolValidar = false;
                }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
            }
            return intSeleccion;
        }





        /********************************************** VOLVER MENU PRINCIPAL *********************************************/

        public void volverMenuPrincipal()
        {
            Console.Clear();
            InterfazPrincipal.mostrarMenuPrincipal();            
        }


        /********************************************** TECLA PARA CONTINUAR *********************************************/

        public void presioneTeclaParaContinuar()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una Tecla para Continuar.");
            Console.ReadKey();
            Console.Clear();
            mostrarSubMenu();
        }



        /******************************************* CARGA DE DATOS DE OMNIBUS *******************************************/

        public string cargarMarca()
        {
            objControladorOmnibus = new ControladorOmnibus();

            bool boolEntrar = true;
            string strMarca = "";

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Marca: ");
                    strMarca = Console.ReadLine();

                    if (strMarca == "")
                        throw new ExceptionIngresoTextoVacio();
                    else
                        boolEntrar = false;
                }
                catch (ExceptionIngresoTextoVacio e) { e.mensajeError(); }
            }
            return strMarca;
        }

        //****************************************************************************************************************


        public string cargarModelo()
        {
            objControladorOmnibus = new ControladorOmnibus();

            bool boolEntrar = true;
            string strModelo = "";

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Modelo: ");
                    strModelo = Console.ReadLine();

                    if (strModelo == "")
                        throw new ExceptionIngresoTextoVacio();
                    else
                        boolEntrar = false;
                }
                catch (ExceptionIngresoTextoVacio e) { e.mensajeError(); }
            }
            return strModelo;
        }


        //****************************************************************************************************************


        public string cargarTipo()
        {
            objControladorOmnibus = new ControladorOmnibus();

            bool boolEntrar = true;
            string strTipo = "";

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Tipo: ");
                    strTipo = Console.ReadLine();

                    if (objControladorOmnibus.validarTipoOmnibus(strTipo))
                        boolEntrar = false;
                    else
                        throw new ExceptionTipoOmnibusNoValido();
                }
                catch (ExceptionCapacidadNoValida e) { e.mensajeError(); }
                catch (ExceptionTipoOmnibusNoValido e) { e.mensajeError(); }
            }
            return strTipo;
        }

        //****************************************************************************************************************

        public int cargarCapacidad()
        {
            objControladorOmnibus = new ControladorOmnibus();

            bool boolEntrar = true;
            int intCapacidad = 0;

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Capacidad: ");
                    intCapacidad = int.Parse(Console.ReadLine());

                    if (objControladorOmnibus.validarCapacidadOmnibus(intCapacidad))
                        boolEntrar = false;
                    else
                        throw new ExceptionCapacidadNoValida();
                }
                catch (ExceptionCapacidadNoValida e) {e.mensajeError() ; }
                catch (FormatException) { Console.WriteLine("Solo se Permite el Ingreso de Numeros."); }
            }

            return intCapacidad;
        }


        //****************************************************************************************************************

    }
}
