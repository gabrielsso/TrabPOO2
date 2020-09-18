using System;
using System.Collections.Generic;

namespace POO2Trab
{
    public class DeliverSector
    {
        List<Orders> orders_to_deliver = new List<Orders>();
        List<Orders> orders_complete = new List<Orders>();
        Dictionary<int, IDeliveryService> list_of_services = new Dictionary<int, IDeliveryService>();

        int user_choice = 0;
       public void AddServices()
       {
           IDeliveryService service_1 = new foodDev();
           service_1.name = "FoodDev";
           IDeliveryService service_2 = new LiberEat();
           service_2.name = "LiberEat";
           list_of_services.Add(list_of_services.Count + 1, service_1);
           list_of_services.Add(list_of_services.Count + 1, service_2);
           Console.WriteLine(list_of_services.Count);
       }

       public void ReceiveOrders(Orders new_ords)
       {
           orders_to_deliver.Add(new_ords);
       }

       public void Deliver_Menu(){    
           Console.WriteLine(list_of_services.Count);
           while (user_choice != 4)
           {
                user_choice = 0;
                do
                {
                        Console.WriteLine("\n---------------------------");
                        Console.WriteLine("Escolha umas das opções a seguir: ");
                        Console.WriteLine("1 - Enviar pedidos");
                        Console.WriteLine("2 - Pedidos no setor");
                        Console.WriteLine("3 - Ver serviços registrados.");
                        Console.WriteLine("4 - Voltar");
                        Console.WriteLine("---------------------------");
                        Console.Write("\nEscolha: ");
                        user_choice = int.Parse(Console.ReadLine());
                } while (user_choice < 1 || user_choice > 4);
           
                switch(user_choice){
                        case 1:
                            Deliver_Order();
                            break;
                        case 2:
                            Display_OrdsIn_DeliverSector();
                            break;
                        case 3:
                            Display_Services();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Ocorreu um erro na seleção");
                            break;
                    } 
           }
       }
    
        public void Deliver_Order(){
            Display_Ords_NotDeliver();
            int choice = 0;
            Console.Write("Digite o código: ");
            choice = int.Parse(Console.ReadLine());
            Orders currentOder = Verify_Order(choice);
            if (currentOder != null)
            {
                Console.Write("Escolha um dos serviços a seguir: ");
                Display_Services();
                Console.Write("Código do serviço: ");
                choice = int.Parse(Console.ReadLine());
                foreach (var service in list_of_services)
                {
                    if (service.Key == choice)
                    {
                        service.Value.Deliver(currentOder.GetOrderId(), "Rua blabla", currentOder.GetClientName());
                        orders_to_deliver.Remove(currentOder);
                        orders_complete.Add(currentOder);
                    }
                }
            }
            else
            {
                Console.WriteLine("Código de pedido inválido.");
            }
        }

        public void Display_Ords_NotDeliver(){
            Console.WriteLine("\n---------------------------");
            int index = 0;
            Console.WriteLine("Pedidos não enviados:");
            foreach (var ords in orders_to_deliver)
            {
                index++;
                Console.WriteLine("{0} - Cliente: {1}", ords.GetOrderId(), ords.GetClientName());
            }
            Console.WriteLine("\n---------------------------");
        }

        public void Display_Ords_Delivered(){
            Console.WriteLine("\n---------------------------");
            int index = 0;
            Console.WriteLine("Pedidos enviados:");
            foreach (var ords in orders_complete)
            {
                index++;
                Console.WriteLine("{0} - Cliente: {1}", ords.GetOrderId(), ords.GetClientName());
            }
            Console.WriteLine("\n---------------------------");
        }

        public void Display_OrdsIn_DeliverSector(){
           Display_Ords_NotDeliver();
           Display_Ords_Delivered(); 
        }

        public void Display_Services(){
            Console.WriteLine("\n---------------------------");
            int index = 0;
            foreach (var service in list_of_services)
            {
                index++;
                Console.WriteLine("{0} - Nome: {1}", index, service.Value.name);
            }
            Console.WriteLine("\n---------------------------");
        }
    
        public Orders Verify_Order(int id){
            return orders_to_deliver.Find(x => x.GetOrderId() == id);
        }

        //Manda lista de pedidos incompletos para registro
        public List<Orders> Send_Incomplete_Orders_to_Save(){
            return orders_to_deliver;
        }

        //Manda lista dos pedidos já entreges para registro
        public List<Orders> Send_Complete_Orders_to_Save(){
            return orders_complete;
        }
    }
}