using System;
using System.Collections.Generic;

namespace POO2Trab
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager mng = new Manager();
            User user = new User();
            DeliverSector deliverSector = new DeliverSector();
            deliverSector.AddServices();
            List<Store> strs = new List<Store>();
            List<Orders> ords = new List<Orders>();

            int user_type = 0;

            while (user_type != 3)
            {
                user_type = 0;

                Console.WriteLine("---------------------------");
                Console.WriteLine("Qual tipo de usuário:");
                Console.WriteLine("1 - Gerente");
                Console.WriteLine("2 - Usuário");
                Console.WriteLine("3 - Sair");
                Console.WriteLine("---------------------------");
                
                Console.Write("\nDigite o tipo: ");
                user_type = int.Parse(Console.ReadLine());

                while((user_type < 1 || user_type > 3)){
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Tipo não encontrado..");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Qual tipo de usuário:");
                    Console.WriteLine("1 - Gerente");
                    Console.WriteLine("2 - Usuário");
                    Console.WriteLine("3 - Sair");
                    Console.WriteLine("---------------------------");
                    Console.Write("\nDigite novamente: ");
                    user_type = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                }

                if(user_type == 1)
                {
                    Console.WriteLine("\nBem vindo gerente!!");
                    mng.Start_Menu(strs);
                }
                else if(user_type == 2)
                {
                    Console.WriteLine("\nBem vindo usuário!!");
                    user.Start_Menu(strs, ords, deliverSector);
                }
                else if(user_type < 1 || user_type > 3)
                {
                    Console.WriteLine("Ocorreu um erro ao selecionar um tipo de conta...");
                } 
            
            }

            SaveArquives sa = new SaveArquives();
            sa.Save(deliverSector, strs, ords);
        }
    }
}
