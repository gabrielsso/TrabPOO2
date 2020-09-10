using System;
using System.Collections.Generic;

namespace POO2Trab
{
    public class Manager
    {
        int store_cod;
        List<Store> str;
        public void Start_Menu(List<Store> stores){
            int choice = 0;
            str = stores;
            while (choice != 3)
            {
                choice = 0;
                do
                {
                    Console.WriteLine("\n---------------------------");
                    Console.WriteLine("Escolha umas das opções a seguir: ");
                    Console.WriteLine("1 - Produtos");
                    Console.WriteLine("2 - Lojas");
                    Console.WriteLine("3 - Voltar");
                    Console.WriteLine("---------------------------");
                    Console.Write("\nEscolha: ");
                    choice = int.Parse(Console.ReadLine());
                } while (choice < 1 || choice > 3);

                switch(choice){
                    case 1:
                        Product_Menu();
                        break;
                    case 2:
                        Store_Menu();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Ocorreu um erro na seleção");
                        break;
                }   
            }
        }
    
        public void Product_Menu(){
            int choice = 0;
             //Verificar se existe alguma loja registrada
            if(str.Count == 0)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Não é possivel adicionar produtos,"
                + " pois nenhuma loja está registrada");
                return;
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Escolha umas das seguites lojas:");
                foreach (var store in str)
                {
                    Console.WriteLine("{0} - {1}", store.GetID(), store.GetName());
                }
                Console.WriteLine("---------------------------");
                Console.Write("\nCódigo: ");
                store_cod = int.Parse(Console.ReadLine());
                store_cod = Store_ID_Verification(store_cod);
            }
            Product_SubMenu(choice);
        }

        private void Product_SubMenu(int choice){
            while (choice != 3)
            {
                //Pega o estoque atual da loja selecionada
                Stock stk = str.Find(x => x.GetID() == store_cod).GetStock();
                //Menu para interações com produtos
                do
                {
                    Console.WriteLine("\n---------------------------");
                    Console.WriteLine("Escolha umas das opções a seguir: ");
                    Console.WriteLine("1 - Adicionar um produto");
                    Console.WriteLine("2 - Mostrar todos os produtos");
                    Console.WriteLine("3 - Voltar");
                    Console.WriteLine("---------------------------");
                    Console.Write("\nEscolha: ");
                    choice = int.Parse(Console.ReadLine());
                } while (choice < 1 || choice > 3);

                switch(choice){
                    case 1:
                        //Registro e verificação de existencia do ID/Código do produto
                        Add_product(stk);
                        break;
                    case 2:
                        //Listando todos os produtos registrados
                        stk.DisplayProducts();
                        break;
                    case 3:
                        //Retorna para o menu anterior
                        break;
                    default:
                        Console.WriteLine("Ocorreu um erro...");
                        break;
                }
            }
        }

        public void Add_product(Stock stk){
            int id = 0;
            do
            {
                Console.WriteLine("\nDigite o código para o produto: ");
                Console.Write("Código: ");
                id = int.Parse(Console.ReadLine());
            } while (stk.CheckForID(id));
            //Registrando o nome do produto
            Console.WriteLine("\nDigite o nome do produto: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            //Registrando o preço do produto
            Console.WriteLine("\nDigite o preço do produto: ");
            Console.Write("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            //Registrando a quantidade de produtos
            Console.WriteLine("\nDigite a quantitade no estoque: ");
            Console.Write("Quantidade: ");
            int quant = int.Parse(Console.ReadLine());
            //Adicionando o produto a lista presente na classe Stock
            stk.AddProductToList(id, nome, preco, quant);
        }

        public void Store_Menu(){
            int choice = 0;
            while (choice != 3)
            {   
                //Executar pelo menos uma vez o circulo antes da verificação para repetição
                do
                {
                    Console.WriteLine("\n---------------------------");
                    Console.WriteLine("Escolha umas das opções a seguir: ");
                    Console.WriteLine("1 - Adicionar uma loja");
                    Console.WriteLine("2 - Listar todas as lojas");
                    Console.WriteLine("3 - Voltar");
                    Console.WriteLine("---------------------------");
                    Console.Write("\nEscolha: ");
                    choice = int.Parse(Console.ReadLine());
                } while (choice < 1 || choice > 3);

                switch(choice){
                    case 1:
                        Create_Store();
                        break;
                    case 2:
                        //Listar todas as lojas registradas
                        Display_AllStores();
                        break;
                    case 3:
                        //Retorna para o menu anterior
                        return;
                }
            }
        }

        private void Create_Store(){
            Console.Write("Digite o código para a loja: ");
            int id = int.Parse(Console.ReadLine());
            //Verificação de IDS registrados anterioremente no sistema.
            //Repetição até informar um id válido.
            id = Check_Store_ID(id);
            
            Console.Write("\nDigite o nome da loja: ");
            string name = Console.ReadLine();
            //Instancia de uma loja e colocando as informações dadas dentro do objeto.
            Store unit = new Store();
            unit.SetID(id);
            unit.SetName(name);
            //Adicionando a loja dentro da lista presente na classe Manager.
            str.Add(unit);
        }

        private void Display_AllStores(){
            if(str.Count == 0){
                Console.WriteLine("Nenhuma loja registrada no sistema.");
            }else{
                //Pega todas as lojas registradas no sistema.
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("Lojas registradas:");
                foreach (var store in str)
                {
                    Console.WriteLine("ID: {0} - Nome: {1}", store.GetID(), store.GetName());
                }
            }
                Console.WriteLine("---------------------------\n");
        }

        private int Check_Store_ID(int ID){
            bool check = true;
            while (check)
            {
                if(str.Count == 0){
                    check = false;   
                }

                foreach (var item in str)
                {
                    if(item.GetID() == ID){
                        check = true;
                        break;
                    }else{
                        check = false;
                    }
                }

                if (check == true)
                {
                    Console.WriteLine("Código já existe no sistema.");
                    Console.WriteLine("\nDigite o código da loja: ");
                    Console.Write("\nCódigo:");
                    ID = int.Parse(Console.ReadLine());
                }
            }

            return ID;
        }

        private int Store_ID_Verification(int ID){
            bool check = true;
            while (check)
            {
                foreach (var item in str)
                {
                    if (item.GetID() == ID)
                    {
                        check = false;  
                    }else{
                        check = true;
                        Console.WriteLine("Loja inválida.");
                    }
                }
                
                if (check)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Escolha umas das seguites lojas:");
                    foreach (var store in str)
                    {
                        Console.WriteLine("{0} - {1}", store.GetID(), store.GetName());
                    }
                    Console.WriteLine("---------------------------");
                    Console.Write("\nCódigo: ");
                    store_cod = int.Parse(Console.ReadLine());
                }
            }
            
            return ID;
        }
    
        private bool Check_For_Products(Store store){
            Stock stk = store.GetStock();
            if(stk.AmountOfProducts() == 0){
                Console.WriteLine("A loja não possui produtos registrados.");
                return false;
            }

            return true;
        }
    }
}