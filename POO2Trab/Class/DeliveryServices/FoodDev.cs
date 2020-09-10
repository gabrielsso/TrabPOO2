using System;
namespace POO2Trab
{
    public class foodDev : IDeliveryService
    {
        public string name{get; set;}

        public void Deliver(int cod_ped, string destination, string client_name){
            Console.WriteLine("O pedido foi entregue utilizando FoodDev ao cliente {0} no destinario {1}.", client_name, destination);
            return;
        }
    }
}