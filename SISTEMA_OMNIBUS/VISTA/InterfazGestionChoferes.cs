using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODELO;
using CONTROLADOR;

namespace VISTA
{
    class InterfazGestionChoferes : IInterfazSubMenu
    {

        ControladorDia objControladorDia;
        ControladorChofer objControladorChofer;
        ControladorOmnibus objControladorOmnibus;
        ControladorRecorrido objControladorRecorrido;              
        ControladorItinerario objControladorItinerario;


        public void mostrarSubMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Alta de Choferes.");
            Console.WriteLine("2) Asignacion de recorridos.");          
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
                        altaChofer();
                        boolValidarOpcion = false;
                        break;
                    case "2":
                        asignacionDeRecorridos();
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


        /******************************************* ALTA DE CHOFER *******************************************/

        public void altaChofer()
        {
            objControladorChofer = new ControladorChofer();            
            Chofer objChofer = new Chofer();

            objChofer.Nombre = cargarNombre();
            objChofer.Apellido = cargarApellido();
            objChofer.DNI = cargarDNI();

            List<string> dniExistentes = objControladorChofer.traerDNIChoferes();

            if (objControladorChofer.validarDniExistenteRegistrado(dniExistentes, objChofer.DNI))
            {                
                objControladorChofer.agregarChofer(objChofer);
                Console.WriteLine();
                Console.WriteLine("El Chofer se ha Dado de Alta Correctamente.");
            }                
            else            
                Console.WriteLine("Ya Existe un Chofer con ese DNI en la Empresa.");
                                                
            presioneTeclaParaContinuar();
        }


        /******************************************* ASIGNACION DE RECORRIDOS *******************************************/

        public void asignacionDeRecorridos()
        {
            Console.Clear();
            objControladorChofer = new ControladorChofer();
            objControladorOmnibus = new ControladorOmnibus();
            objControladorRecorrido = new ControladorRecorrido();

            int intCantidadChoferesAlta = objControladorChofer.traerChoferes().Count;
            int intCantidadOmnibusAlta = objControladorOmnibus.traerOmnibus().Count;
            int intCantidadRecorridosAlta = objControladorRecorrido.traerRecorridos().Count;

            if (intCantidadChoferesAlta > 0 && intCantidadOmnibusAlta > 0 && intCantidadRecorridosAlta > 0)
                asignarRecorridos();
            else
            {
                Console.WriteLine("Error Debe dar de Alta un Chofer - Omnibus - Recorrido Para Asignar un Recorrido.");
                presioneTeclaParaContinuar();
            }             
        }



        public void asignarRecorridos()
        {
            objControladorDia = new ControladorDia();
            objControladorChofer = new ControladorChofer();
            objControladorOmnibus = new ControladorOmnibus();
            objControladorRecorrido = new ControladorRecorrido();                                                                         

            Console.WriteLine("Seleccione el Chofer");
            Console.WriteLine();
            List<Chofer> choferesRegistrados = objControladorChofer.traerChoferes();
            objControladorChofer.mostrarChoferes(choferesRegistrados);
            Console.WriteLine();            
            Chofer objChofer = seleccionChofer(choferesRegistrados);
            Console.Clear();

            Console.WriteLine("Seleccione el Omnibus");
            Console.WriteLine();
            List<Omnibus> omnibusRegistrados = objControladorOmnibus.traerOmnibus();
            objControladorOmnibus.mostrarOmnibus(omnibusRegistrados);
            Console.WriteLine();
            Omnibus objOmnibus = seleccionOmnibus(omnibusRegistrados);
            Console.Clear();

            Console.WriteLine("Seleccione el Recorrido");
            Console.WriteLine();
            List<Recorrido> recorridos = objControladorRecorrido.traerRecorridos();            
            objControladorRecorrido.mostrarRecorridos(recorridos);
            Console.WriteLine();
            Recorrido objRecorrido = seleccionRecorrido(recorridos);            
            Console.Clear();

            Console.WriteLine("Seleccione el Dia del Recorrido");
            Console.WriteLine();
            List<Dia> dias = objControladorDia.traerDias();
            objControladorDia.mostrarDias(dias);
            Console.WriteLine();
            Dia objDia = seleccionDia(dias);            

            Itinerario objItinerario = new Itinerario();
            objItinerario.IdChofer = objChofer.NumeroLegajo;
            objItinerario.IdOmnibus = objOmnibus.NumeroUnidad;
            objItinerario.IdRecorrido = objRecorrido.IdRecorrido;
            objItinerario.IdDia = objDia.IdDia;

            agregarAsignacionRecorrido(objItinerario);
        }


        private void agregarAsignacionRecorrido(Itinerario itinerario)
        {
            objControladorItinerario = new ControladorItinerario();
            List<Itinerario> itinerariosRegistrados = objControladorItinerario.traerItinerario();

            Boolean validarDiaChofer = objControladorItinerario.validarDiadelViajeChofer(itinerariosRegistrados, itinerario);
            Boolean validarDiaOmnibus = objControladorItinerario.validarDiadeReservaOmnibus(itinerariosRegistrados, itinerario);

            if (validarDiaChofer == true && validarDiaOmnibus == true)
            {
                objControladorItinerario.agregarItinerario(itinerario);
                Console.WriteLine("La Asignacion del Recorrido fue Dado de Alta Correctamente.");
            }
            else if (validarDiaChofer == false && validarDiaOmnibus == true)
                Console.WriteLine("El Chofer ya Realiza un Viaje ese Dia.");
            else if (validarDiaChofer == true && validarDiaOmnibus == false)
                Console.WriteLine("El Omnibus ya esta Reservado ese Dia.");
            else
                Console.WriteLine("El Chofer y el Omnibus no estan Disponible para ese Dia.");

            presioneTeclaParaContinuar();
        }


        /*********************************** SELECCION DE DATOS PARA ASIGNACION DE RECORRIDO ***********************************/

        public Chofer seleccionChofer(List<Chofer> choferesRegistrados)
        {
            Chofer objChofer = null;       
            bool boolEntrar = true;

            while (boolEntrar) {

                Console.Write("Seleccion:");                
                try
                {
                    int intSeleccion = int.Parse(Console.ReadLine());

                    if (intSeleccion > choferesRegistrados.Count || intSeleccion <= 0)
                        throw new ExceptionSeleccionNoValida();                    
                    else
                    {                        
                        objChofer = choferesRegistrados[intSeleccion - 1];
                        boolEntrar = false;
                    }
                }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
            }
            return objChofer;
        }

        //****************************************************************************************************************

        public Omnibus seleccionOmnibus(List<Omnibus> omnibusRegistrados)
        {
            Omnibus objOmnibus = null;       
            bool boolEntrar = true;

            while (boolEntrar) {
                Console.Write("Seleccion:");                
                try
                {
                    int intSeleccion = int.Parse(Console.ReadLine());

                    if (intSeleccion > omnibusRegistrados.Count || intSeleccion <= 0)
                        throw new ExceptionSeleccionNoValida();                    
                    else
                    {                        
                        objOmnibus = omnibusRegistrados[intSeleccion - 1];
                        boolEntrar = false;
                    }
                }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
            }
            return objOmnibus;
        }

        //****************************************************************************************************************

        public Recorrido seleccionRecorrido(List<Recorrido> recorridos)
        {
            objControladorRecorrido = new ControladorRecorrido();
            Recorrido objRecorrido = null;

            bool boolEntrar = true;
            while (boolEntrar)
            {
                Console.Write("Seleccion:");               
                try
                {
                    int intSeleccion = int.Parse(Console.ReadLine());
                    Boolean boolValidar = objControladorRecorrido.validarRecorrido(recorridos, intSeleccion);

                    if (boolValidar)
                    {
                        objRecorrido = recorridos[intSeleccion - 1];
                        boolEntrar = false;
                    }                        
                    else
                        throw new ExceptionSeleccionNoValida();
                }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return objRecorrido;
        }

        //****************************************************************************************************************

        public Dia seleccionDia(List<Dia> dias)
        {
            objControladorDia = new ControladorDia();
            Dia objDia = null;

            bool boolEntrar = true;
            while (boolEntrar)
            {
                Console.Write("Seleccion:");
                try
                {
                    int intSeleccion = int.Parse(Console.ReadLine());
                    Boolean boolValidar = objControladorDia.validarDia(intSeleccion);

                    if (boolValidar)
                    {
                        objDia = dias[intSeleccion - 1];
                        boolEntrar = false;
                    }
                    else
                        throw new ExceptionSeleccionNoValida();
                }
                catch (ExceptionSeleccionNoValida e) { e.mensajeError(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite la Seleccion con Numeros."); }
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return objDia;
        }



        /******************************************* CARGA DE DATOS DE CHOFER *******************************************/


        public string cargarNombre()
        {
            objControladorChofer = new ControladorChofer();
            bool boolEntrar = true;
            string strNombre = "";

            while (boolEntrar)
            {              
                try
                {
                    Console.Write("Ingrese Nombre: ");
                    strNombre = Console.ReadLine();

                    if (objControladorChofer.validarNombre(strNombre) && strNombre != "")
                        boolEntrar = false;
                    else if (objControladorChofer.validarNombre(strNombre) == false)
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
            bool boolEntrar = true;
            string strApellido = "";

            while (boolEntrar)
            {                
                try
                {
                    Console.Write("Ingrese Apellido: ");
                    strApellido = Console.ReadLine();

                    if (objControladorChofer.validarNombre(strApellido) && strApellido != "")
                        boolEntrar = false;
                    else if (objControladorChofer.validarNombre(strApellido) == false)
                        throw new ExceptionTextoInvalido();
                    else if (strApellido == "")
                        throw new ExceptionIngresoTextoVacio();
                }
                catch(ExceptionTextoInvalido e) { e.mensajeError(); }
                catch(ExceptionIngresoTextoVacio e) { e.mensajeError(); }                                                                          
            }
            return strApellido;
        }

        //****************************************************************************************************************

        public string cargarDNI()
        {
            int intDNI = 0;
            bool boolEntrar = true;

            while (boolEntrar)
            {
                try
                {
                    Console.Write("Ingrese DNI: ");
                    intDNI = int.Parse(Console.ReadLine());
                    int cantidadDigitos = intDNI.ToString().Length;

                    if (cantidadDigitos > 8)
                        throw new ExceptionCantidadDigitosExcedido();
                    else if (cantidadDigitos < 8)
                        throw new ExceptionCantidadDigitosInsuficientes();
                    else
                        boolEntrar = false;
                }
                catch (ExceptionCantidadDigitosInsuficientes e) { e.mensajeIngresoIncorrecto(); }
                catch (ExceptionCantidadDigitosExcedido e) { e.mensajeIngresoIncorrecto(); }
                catch (FormatException) { Console.WriteLine("Solo se Permite el Ingreso de Numeros."); }
                catch (Exception) { Console.WriteLine("Error Vuelva a Ingresar."); }
            }
            return intDNI.ToString();
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
