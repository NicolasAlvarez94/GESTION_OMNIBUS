using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONTROLADOR;

namespace VISTA
{
    class InterfazEstadisticas : IInterfazSubMenu
    {

        ControladorCompra objControladorCompra;
        ControladorEstadisticaTerminal objControladorEstadistica;

        public void mostrarSubMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Consultar Total de Pasajes Vendidos.");
            Console.WriteLine("2) Consultar Usuarios.");
            Console.WriteLine("3) Consultar Terminal como Partida.");
            Console.WriteLine("4) Consultar Terminal como Arribo.");
            Console.WriteLine("5) Volver");

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
                        consultarTotalPasajesVendidos();
                        boolValidarOpcion = false;
                        break;
                    case "2":
                        consultarUsuarios();
                        boolValidarOpcion = false;
                        break;
                    case "3":
                        consultarTerminalPartida();
                        boolValidarOpcion = false;
                        break;
                    case "4":
                        consultarTerminalArribo();
                        boolValidarOpcion = false;
                        break;
                    case "5":
                        volverMenuPrincipal();
                        boolValidarOpcion = false;
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida. Seleccione una Opcion Valida.");
                        break;
                }
            }
        }


        /******************************************* CONSULTA DE PASAJES VENDIDOS TOTALES *******************************************/

        public void consultarTotalPasajesVendidos()
        {
            Console.WriteLine();
            objControladorCompra = new ControladorCompra();
            int intCantidadPasajesTotales = objControladorCompra.traerCantidadPasajesVendidosTotal();

            Console.WriteLine("En Total se han Vendido " + intCantidadPasajesTotales + " Pasajes.");
            presioneTeclaParaContinuar();
        }



        /******************************************* CONSULTA DE PASAJES VENDIDOS POR USUARIOS *******************************************/

        public void consultarUsuarios()
        {
            Console.WriteLine();
            objControladorCompra = new ControladorCompra();
            DataTable comprasPorUsuarios = objControladorCompra.traerCantidadPasajesVendidosPorUsuario();

            Console.WriteLine("Listado de Ventas Por Usuario: ");
            Console.WriteLine();
            objControladorCompra.mostrarComprasPorUsuario(comprasPorUsuarios);

            presioneTeclaParaContinuar();
        }


        /******************************************* CONSULTA DE TERMINAL DE PARTIDA *******************************************/

        public void consultarTerminalPartida()
        {
            Console.WriteLine();
            objControladorEstadistica = new ControladorEstadisticaTerminal();
            DataTable terminalesComoPartida = objControladorEstadistica.traerTerminalescomoPartida();

            Console.WriteLine("Listado de Terminales como Partida");
            Console.WriteLine();
            objControladorEstadistica.mostrarEstadisticaTerminales(terminalesComoPartida);

            Console.WriteLine();
            presioneTeclaParaContinuar();
        }


        /******************************************* CONSULTA DE TERMINAL DE ARRIBO *******************************************/

        public void consultarTerminalArribo()
        {
            Console.WriteLine();
            objControladorEstadistica = new ControladorEstadisticaTerminal();
            DataTable terminalesComoArribo = objControladorEstadistica.traerTerminalescomoArribo();

            Console.WriteLine("Listado de Terminales como Arribo");
            Console.WriteLine();
            objControladorEstadistica.mostrarEstadisticaTerminales(terminalesComoArribo);

            Console.WriteLine();
            presioneTeclaParaContinuar();
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
