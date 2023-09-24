using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace IPS_MAS_SALUD_Y_VIDA
{
    public class MenuPrincipal
    {
        private Liquidacion produto;
        private LiquidacionService productoService = new LiquidacionService();
        public MenuPrincipal(Liquidacion produto)
        {
            this.produto = produto;
        }

        public int menuPrincipal()
        {
            int OPC;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(101, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(102, 7); Console.WriteLine("IPS");
            Console.SetCursorPosition(94, 8); Console.WriteLine("SOFTWARE DE IPS");
            Console.SetCursorPosition(102, 9); Console.WriteLine("M E N U  P R I N C I P A L");
            Console.SetCursorPosition(101, 13); Console.WriteLine("1. REGISTRO DE PACIENTE");
            Console.SetCursorPosition(101, 14); Console.WriteLine("2. CONSULTA DE PACIENTE");
            Console.SetCursorPosition(101, 16); Console.WriteLine("3. ELIMINAR PACIENTE");
            Console.SetCursorPosition(101, 18); Console.WriteLine("4. SALIR");
            do
            {
                Console.SetCursorPosition(101, 21); Console.WriteLine("Seleccione una opcion: ");
                Console.SetCursorPosition(124, 21); OPC = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(124, 21); Console.WriteLine("         ");
                Console.SetCursorPosition(124, 26); Console.WriteLine("Opcion no valida");
            } while ((OPC < 1) || (OPC > 4));
            Console.SetCursorPosition(124, 21); Console.WriteLine("                                     ");
            Console.SetCursorPosition(124, 26); Console.WriteLine("                                     ");
            return OPC;
        }
        public void menuPrincipal_()
        {

            int MENU_;
            char OP = 'S';
            while (OP == 'S')
            {
                MENU_ = menuPrincipal();
                switch (MENU_)
                {
                    case 1:
                        Console.Clear();
                        registro();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarRegistro();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        EliminarRegistro();
                        Console.Clear();
                        break;
                    case 4:
                        OP = 'N';
                        break;
                }
            }
        }
        public void registro()
        {
            string idl;
            string idp;
            char tipa;
            double salade;
            double valho;
            
            

            char OP = 'S';
            while (OP == 'S')
            {
                try
                {
                    titulos();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID LIQUIDACION        : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("ID DEL PACIENTE       : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("SALARIO DEVENGADO     : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("VALOR HOSPITALIZACION : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("TIPO DE AFILIACION    : ");
                    

                    Console.SetCursorPosition(62, 11); idl = Console.ReadLine();
                    Console.SetCursorPosition(62, 12); idp = Console.ReadLine().ToUpper();
                    do
                    {
                        Console.SetCursorPosition(62, 13); salade = Convert.ToDouble(Console.ReadLine());
                    } while (salade < 0);
                    do
                    {
                        Console.SetCursorPosition(62, 14); valho = Convert.ToDouble(Console.ReadLine());
                    } while (valho < 0);
                   
                    do
                    {
                        Console.SetCursorPosition(35, 25); Console.WriteLine("Digite S: Subsidiado C: Contributivo");
                        Console.SetCursorPosition(62, 15); tipa = Convert.ToChar(Console.ReadLine().ToUpper());
                    } while ((tipa != 'S') && (tipa != 'C'));


                    Liquidacion producto = new Liquidacion(idl, idp, tipa, salade, valho);
                    
                    
                    Console.SetCursorPosition(34, 25); Console.WriteLine(productoService.GuardarRegistros(producto));
                    {
                        Console.SetCursorPosition(34, 18); Console.WriteLine("¿Desea continuar? S/N : ");
                        Console.SetCursorPosition(58, 18); OP = Convert.ToChar(Console.ReadLine());
                        OP = char.ToUpper(OP);
                        Console.Clear();
                    } while ((OP != 'S') && (OP != 'N')) ;
                }
                catch (IOException)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Ingresa un dato valido");
                }
            }
        }
        public void titulos()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(116, 7); Console.WriteLine("IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LIQUIDACION");
            
        }
    }
}
