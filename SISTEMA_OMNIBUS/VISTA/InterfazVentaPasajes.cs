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
    class InterfazVentaPasajes : IInterfazSubMenu
    {

        private static int intIdFkUsuarioCompra = 0;
        private ControladorCompra objControladorCompra;
        private ControladorUsuario objControladorUsuario;
        private ControladorTerminal objControladorTerminal;
        private ControladorItinerario objControladorItinerario;
        private ControladorEstadisticaTerminal objControladorEstadistica;
        

        public void mostrarSubMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Alta de Usuarios.");
            Console.WriteLine("2) Compra de Pasajes.");
            Console.WriteLine("3) Volver");

            elegirOpcionMenu();
        }

        public void elegirOpcionMenu()
        {
            Boolean boolValidarOpcion = true;
            while (boolValidarOpcion)
            {
                string strOpcion = Console.ReadLine();

                switch (strOpcion)
                {
                    case "1":
                        altaDeUsuarios();
                        boolValidarOpcion = false;
                        break;
                    case "2":
                        compraDePasajes();
                        boolValidarOpcion = false;
                        break;
                    case "3":
                        volverMenuPrincipal();
                        boolValidarOpcion = false;
                        break;             
                    default:
                        Console.WriteLine("Opcion Invalida. Seleccione una Opcion Valida.");
                        break;
                }
            }
        }


        /******************************************* ALTA DE USUARIO *******************************************/

        public void altaDeUsuarios()
        {
            objControladorUsuario = new ControladorUsuario();
            List<string> dniUsuarios = objControladorUsuario.traerDniUsuarios();

            Usuario objUsuario = new Usuario();
            objUsuario.Nombre = cargarNombre();
            objUsuario.Apellido = cargarApellido();
            objUsuario.DNI = cargarDNI();
            objUsuario.FechaNacimiento = cargarFechaNacimiento();

            Boolean validarDniUsuarioExistente = objControladorUsuario.validarDniExistenteRegistrado(dniUsuarios, objUsuario.DNI);

            if (validarDniUsuarioExistente)
            {
                objControladorUsuario.agregarUsuario(objUsuario);
                int intNumeroUsuario = objControladorUsuario.traerMaximoIdUsuario();
                Console.WriteLine("El Usuario fue Dado de Alta Correctamente con el Numero: " + intNumeroUsuario);
            }                            
            else
                Console.WriteLine("Ya Existe un Usuario con ese DNI en el Sistema.");

            presioneTeclaParaContinuar();
        }


        /******************************************* COMPRA DE PASAJES *******************************************/

        public void compraDePasajes()
        {
            objControladorUsuario = new ControladorUsuario();
            List<Usuario> usuarios = objControladorUsuario.traerUsuarios();

            int intNumeroUsuario = cargarNumeroUsuario();
            Console.WriteLine();

            string strDniUsuario = cargarDNI();
            Console.WriteLine();

            Boolean validarUsuarioAregistrar = objControladorUsuario.validarUsuarioExistente(usuarios, intNumeroUsuario, strDniUsuario);

            if (validarUsuarioAregistrar)
            {
                intIdFkUsuarioCompra = intNumeroUsuario;
                seleccionTerminales();
            }                
            else
            {
                Console.WriteLine("El Usuario Solicitado no Existe en el Sistema");
                presioneTeclaParaContinuar();
            }                
        }


        private void seleccionTerminales()
        {
            Console.Clear();

            objControladorTerminal = new ControladorTerminal();       
            List<Terminal> terminalesRegistradas = objControladorTerminal.traerTerminales();

            Console.WriteLine("Seleccione la Terminal de Partida");
            Console.WriteLine();
            objControladorTerminal.mostrarNombresTerminales(terminalesRegistradas);
            Terminal objTerminalPartida = seleccionTerminal(terminalesRegistradas);
            Console.Clear();

            Console.WriteLine("Seleccione la Terminal de Arribo");
            Console.WriteLine();
            objControladorTerminal.mostrarNombresTerminales(terminalesRegistradas);
            Terminal objTerminalArribo = seleccionTerminal(terminalesRegistradas);
            Console.Clear();

            validarSeleccionTerminales(objTerminalPartida, objTerminalArribo);
        }


        private void validarSeleccionTerminales (Terminal terminalPartida, Terminal terminalArribo)
        {
            objControladorTerminal = new ControladorTerminal();
            objControladorItinerario = new ControladorItinerario();            

            List<Itinerario> itinerariosRegistrados = objControladorItinerario.traerItinerario();
            List<Recorrido> recorridos = objControladorItinerario.traerRecorridosdeItinerario(); 

            Boolean validarTerminalesSeleccionadas = objControladorTerminal.validarTerminalesSeleccionadas(terminalPartida, terminalArribo);
            Boolean validarTerminalesEnRecorridos = objControladorTerminal.validarTerminalesEnRecorridos(recorridos, terminalPartida, terminalArribo);
     
            if (validarTerminalesSeleccionadas == false)
            {
                Console.WriteLine("Error, la Terminal de Partida y Arribo son las Mismas.");
                presioneTeclaParaContinuar();
            }
            else if (validarTerminalesEnRecorridos == false)
            {
                Console.WriteLine("No Existe Ningun Recorrido con las Terminales de Partida y Arribo Solicitadas.");
                presioneTeclaParaContinuar();
            }
            else
            {
                Console.Clear();
                objControladorEstadistica = new ControladorEstadisticaTerminal();
                EstadisticaTerminal objEstadisticaTerminal = new EstadisticaTerminal(terminalPartida.IdTerminal, terminalArribo.IdTerminal);
                objControladorEstadistica.agregarEstadisticaTerminal(objEstadisticaTerminal);
                seleccionarItinerario(terminalPartida, terminalArribo);
            }                
        }


        private void seleccionarItinerario(Terminal terminalPartida, Terminal terminalArribo)
        {
            objControladorItinerario = new ControladorItinerario();
            DataTable datosItinerario = objControladorItinerario.traerInformacionItinerario();
            
            Console.WriteLine("Seleccione el Itinerario");
            Console.WriteLine();
            objControladorItinerario.mostrarItinerarioDeTerminalesSeleccionadas(datosItinerario, terminalPartida, terminalArribo);

            Console.WriteLine();            
            int intSeleccionItinerario = seleccionItinerario();
            Console.WriteLine();

            seleccionarCompraDePasajes(intSeleccionItinerario);
        }



        private void seleccionarCompraDePasajes(int seleccionItinerario)
        {
            objControladorCompra = new ControladorCompra();

            Console.WriteLine("¿Cuantos Pasajes Desea?");
            Console.WriteLine();            
            try
            {
                Console.Write("Seleccione: ");
                int intCantidadPasajes = int.Parse(Console.ReadLine());

                if (intCantidadPasajes > 0)
                {
                    Compra objCompra = new Compra();
                    objCompra.IdFkItinerario = seleccionItinerario;
                    objCompra.IdFkUsuario = intIdFkUsuarioCompra;
                    objCompra.CantidadPasajes = intCantidadPasajes;

                    objControladorCompra.agregarCompra(objCompra);
                    Console.WriteLine("La Venta se ha Realizado con Exito.");
                }
                else                
                    Console.WriteLine("Error, no se ha Ingresado una Cantidad de Pasajes.");                                    
            }                                      
            catch (FormatException) { Console.WriteLine("Solo se Permite el Ingreso con Numeros."); }
            catch (Exception) { Console.WriteLine("Se ha Producido un Error."); }

            presioneTeclaParaContinuar();
        }



        private int seleccionItinerario()
        {
            objControladorItinerario = new ControladorItinerario();
            int intSeleccion = 0;

            Boolean boolValidar = true;
            while(boolValidar){

                try
                {
                    Console.Write("Seleccione Identificador: ");
                    intSeleccion = int.Parse(Console.ReadLine());

                    if (objControladorItinerario.validarSeleccionItinerario(intSeleccion))
                        boolValidar = false;
                    else
                        throw new ExceptionSeleccionNoValida();                                      
                }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
                catch(ExceptionSeleccionNoValida e) { e.mensajeError(); }
            }
            return intSeleccion;
        }
        


        private Terminal seleccionTerminal(List<Terminal> terminalesRegistradas)
        {
            Terminal objTerminal = null;            

            Boolean boolValidar = true;
            while (boolValidar)
            {
                Console.WriteLine();
                Console.Write("Seleccione Terminal:");
                try
                {
                    int intSeleccion = int.Parse(Console.ReadLine());

                    if (intSeleccion <= terminalesRegistradas.Count && intSeleccion > 0)
                    {
                        objTerminal = terminalesRegistradas[intSeleccion - 1];
                        boolValidar = false;
                    }

                    else if (intSeleccion > terminalesRegistradas.Count || intSeleccion <= 0)
                        throw new ExceptionSeleccionNoValida();           
                }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
            }
            return objTerminal;
        }



        /******************************************* CARGA DE DATOS DE USUARIO *******************************************/


        public string cargarNombre()
        {
            objControladorUsuario = new ControladorUsuario();            
            string strNombre = "";

            bool boolEntrar = true;
            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Nombre: ");
                    strNombre = Console.ReadLine();

                    if (objControladorUsuario.validarNombre(strNombre) && strNombre != "")
                        boolEntrar = false;
                    else if (objControladorUsuario.validarNombre(strNombre) == false)
                        throw new ExceptionTextoInvalido();
                    else if (strNombre == "")
                        throw new ExceptionIngresoTextoVacio();
                }
                catch (ExceptionTextoInvalido e) { e.mensajeError(); }
                catch (ExceptionIngresoTextoVacio e) { e.mensajeError(); }
            }
            return strNombre;
        }

        //****************************************************************************************************************

        public string cargarApellido()
        {
            objControladorUsuario = new ControladorUsuario();            
            string strApellido = "";

            bool boolEntrar = true;
            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Apellido: ");
                    strApellido = Console.ReadLine();

                    if (objControladorUsuario.validarNombre(strApellido) && strApellido != "")
                        boolEntrar = false;
                    else if (objControladorUsuario.validarNombre(strApellido) == false)
                        throw new ExceptionTextoInvalido();
                    else if (strApellido == "")
                        throw new ExceptionIngresoTextoVacio();
                }
                catch (ExceptionTextoInvalido e) { e.mensajeError(); }
                catch (ExceptionIngresoTextoVacio e) { e.mensajeError(); }
            }
            return strApellido;
        }

        //****************************************************************************************************************

        public string cargarDNI()
        {
            string strDni = "";

            bool boolEntrar = true;
            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese DNI: ");
                    int intDni = int.Parse(Console.ReadLine());
                    int cantidadDigitos = intDni.ToString().Length;

                    if (cantidadDigitos > 8)
                        throw new ExceptionCantidadDigitosExcedido();
                    else if (cantidadDigitos < 8)
                        throw new ExceptionCantidadDigitosInsuficientes();
                    else
                    {
                        boolEntrar = false;
                        strDni = intDni.ToString();
                    }
                        
                }
                catch (ExceptionCantidadDigitosInsuficientes e) { e.mensajeIngresoIncorrecto(); }
                catch (ExceptionCantidadDigitosExcedido e) { e.mensajeIngresoIncorrecto(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite el Ingreso de Numeros."); }
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return strDni;
        }

        //****************************************************************************************************************

        public DateTime cargarFechaNacimiento()
        {
            objControladorUsuario = new ControladorUsuario();
            DateTime fecha = new DateTime();            

            bool boolEntrar = true;
            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese Fecha de Nacimiento(DD/MM/AAAA): ");
                    string strFecha = Console.ReadLine();

                    if (objControladorUsuario.validarFechaNacimiento(strFecha))
                    {
                        fecha = Convert.ToDateTime(strFecha);
                        boolEntrar = false;
                    }
                    else
                        Console.WriteLine("Error Vuelva a Ingresar la Fecha de Nacimiento.");

                }                                               
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return fecha;
        }

        //****************************************************************************************************************

        public int cargarNumeroUsuario()
        {
            int intNumeroUsuario = 0;
            bool boolEntrar = true;

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese el Numero de Usuario:");
                    intNumeroUsuario = int.Parse(Console.ReadLine());
                    boolEntrar = false;             
                }           
                catch (FormatException) { Console.WriteLine("Solo se Permite el Ingreso de Numeros."); }
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return intNumeroUsuario;
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
    }
}
