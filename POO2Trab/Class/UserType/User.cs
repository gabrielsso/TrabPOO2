using System;
using System.Collections.Generic;
namespace POO2Trab
{
    public class User
    {

        List<Store> str;
        List<Orders> ordrs;
        DeliverSector deliverSector;
        int user_choice = 0;
        
        public void Start_Menu(List<Store> stores, List<Orders> orders, DeliverSector ds)
        {
            str = stores;
            deliverSector = ds;
            ordrs = orders;
            if (str.Count == 0)
            {
                Console.WriteLine("Lojas devem ser registradas no aplicativo antes de ser utilizado.");
                return;
            }else{
                while (user_choice != 5)
                {
                    user_choice = 0;
                    do
                    {
                        Console.WriteLine("\n---------------------------");
                        Console.WriteLine("Escolha umas das opções a seguir: ");
                        Console.WriteLine("1 - Adicionar Pedido");
                        Console.WriteLine("2 - Visualizar Pedidos");
                        Console.WriteLine("3 - Despachar Pedido");
                        Console.WriteLine("4 - Ir para setor de entrega");
                        Console.WriteLine("5 - Voltar");
                        Console.WriteLine("---------------------------");
                        Console.Write("\nEscolha: ");
                        user_choice = int.Parse(Console.ReadLine());
                    } while (user_choice < 1 || user_choice > 5);

                    switch(user_choice){
                        case 1:
                            Add_Order();
                            break;
                        case 2:
                            Show_Orders();
                            break;
                        case 3:
                            Send_Order();
                            break;
                        case 4:
                            deliverSector.Deliver_Menu();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Ocorreu um erro na seleção");
                            break;
                    } 
                }
            }
        }

        public void Add_Order()
        {
            Orders current_order = new Orders();

            Console.WriteLine("---------------------------");
            Console.WriteLine("Digite o código do pedido: ");
            Console.Write("\nCódigo:");
            int order_id = int.Parse(Console.ReadLine());
            order_id = Check_If_OrderID_Valid(order_id);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Digite qual loja gostaria de comprar:");
            foreach (var store in str)
            {
                Console.WriteLine("{0} - {1}", store.GetID(), store.GetName());
            }
            Console.WriteLine("---------------------------");
            Console.Write("\nCódigo: ");
            int chosen_store = int.Parse(Console.ReadLine());

            chosen_store = Check_Store_ID(chosen_store);

            Stock stk = str.Find(x => x.GetID() == chosen_store).GetStock();

            if(stk.AmountOfProducts() == 0){
                Console.WriteLine("A loja não possui produtos atualmente.");
                return;
            }else{
                current_order.SetID(order_id);

                int moreProducts = 1;
                while (moreProducts != 2)
                {
                    int quant = 0;
                    int prod_cod = 0;


                    Console.WriteLine("Qual produto gostaria: ");
                    stk.DisplayProducts();
                    Console.WriteLine("Código: ");
                    prod_cod = int.Parse(Console.ReadLine());

                    while (!stk.CheckForID(prod_cod))
                    {
                        Console.WriteLine("Código informado é inválido..");
                        Console.WriteLine("Qual produto gostaria: ");
                        stk.DisplayProducts();
                        Console.WriteLine("Código: ");
                        prod_cod = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Digite a quantidade que deseja: ");
                    quant = int.Parse(Console.ReadLine());

                    while (quant < 0)
                    {
                        Console.WriteLine("Quantidade digitada inválida.");
                        Console.WriteLine("Digite a quantidade que deseja: ");
                        quant = int.Parse(Console.ReadLine());
                    }
                    quant = stk.UpdateProductQuantity(prod_cod, quant);
                    current_order.Add_Product(prod_cod, quant);

                    Console.WriteLine("Gostaria de adicionar outro produto?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    moreProducts = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Digite o nome do cliente: ");
                string name = Console.ReadLine();
                current_order.SetClientName(name);
                current_order.Set_Store_ID(chosen_store);
                current_order.SetDate(DateTime.Today);
                current_order.SetSituation(false);
                current_order.SetPrice(stk);
                ordrs.Add(current_order);

                Console.WriteLine("Pedido adicionado com sucesso.");
                return;
            }
        }

        public void Show_Orders()
        {
            if (ordrs.Count > 0)
            {
                Console.WriteLine("Pedidos atuais: ");
                foreach (var item in ordrs)
                {
                    Console.WriteLine("ID: {0}, Cliente: {1}, Data: {2}, Preço: {3}", item.GetOrderId(), 
                    item.GetClientName(), item.GetDate(), item.GetPrice());
                    Console.WriteLine("---------------------------\n");
                    Stock stk = str.Find(x => x.GetID() == item.getOrderStoreID()).GetStock();
                    item.GetProductsInOrder(stk);
                }
            }
            else
            {
                Console.WriteLine("Não existe pedidos registrado no sistema");
            }
            
        }

        public void Send_Order()
        {
            if (ordrs.Count > 0)
            {
                Console.WriteLine("Pedidos registrados:");
                foreach (var order in ordrs)
                {
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Código: {0} - Cliente: {1} - Data: {2}", order.GetOrderId(), order.GetClientName(), order.GetDate());
                }
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("Digite o código: ");
                int cod = int.Parse(Console.ReadLine());
                
                Orders selected_order = ordrs.Find(x => x.GetOrderId() == cod);
                deliverSector.ReceiveOrders(selected_order);
                ordrs.Remove(selected_order);
            }
            else
            {
                Console.WriteLine("Não há nenhum pedido registrado.");
            }
        }

        //Verificação se existe a loja no sistema
        private int Check_Store_ID(int ID)
        {
            bool check = false;
            while (!check)
            {
                foreach (var item in str)
                {
                    if(item.GetID() == ID){
                        check = true;
                        break;
                    }else{
                        check = false;
                    }
                }

                if (check == false)
                {
                    Console.WriteLine("Código não encontrado no sistema.");
                    Console.WriteLine("\nDigite o código da loja: ");
                    Console.Write("\nCódigo:");
                    ID = int.Parse(Console.ReadLine());
                }
            }

            return ID;
        }

        //Verificação se o ID do pedido já está registrado no sistema.
        private int Check_If_OrderID_Valid(int order_id)
        {
            bool check = true;
            while (check)
            {
                if(ordrs.Count == 0){
                    check = false;   
                }

                foreach (var item in ordrs)
                {
                    if(item.GetOrderId() == order_id){
                        check = true;
                        break;
                    }else{
                        check = false;
                    }
                }

                if (check)
                {
                    Console.WriteLine("Código já existe no sistema.");
                    Console.WriteLine("Digite o código do pedido: ");
                    Console.Write("\nCódigo:");
                    order_id = int.Parse(Console.ReadLine());
                    
                }
            }

            return order_id;
        }
    }
}