using System;
using System.Collections.Generic;

namespace POO2Trab
{
    public class Stock
    {
        List<ProductsInStock> products_list = new List<ProductsInStock>();
        
        public void AddProductToList(int id, string name, float price, int quant)
        {
            Products item = new Products();
            item.SetId(id);
            item.SetName(name);
            item.SetCost(price);
            ProductsInStock prod = new ProductsInStock();
            prod.SetProduct(item);
            prod.SetQuant(quant);
            products_list.Add(prod);
            Console.WriteLine("Produto adicionado com sucesso!");
            Console.WriteLine("---------------------------\n");
        }

        public void DisplayProducts()
        {
            if(products_list.Count == 0)
            {
                    Console.WriteLine("Nenhum Produto registrado na lista.");
                    return;
            }
            else
            {
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("Produtos registrados:");
                foreach (var item
                 in products_list)
                {
                    if(item.GetQuant() == 0){
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código: {0}, Nome do produto: {1}, Valor: R${2} , Quantidade no estoque: {3}", 
                        item.GetProduct().GetID(), item.GetProduct()
                        .GetName(), item.GetProduct()
                        .GetCost(), item.GetQuant());
                    }
                }
                Console.WriteLine("---------------------------");
            }
        }

        public void SearchProduct(int ID)
        {
            foreach (var item
             in products_list)
            {
                if(CheckForID(ID))
                {
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Código: {0}, Nome do produto: {1}, Valor: {2}, Quantidade no estoque: {3}", 
                    item
                    .GetProduct().GetID(), item
                    .GetProduct().GetName(), item
                    .GetProduct().GetCost(), item
                    .GetQuant());
                    Console.WriteLine("---------------------------\n");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }
    
        public Boolean CheckForID(int ID)
        {
            foreach (var item in products_list)
            {
                if (item.GetProduct().GetID() == ID)
                {
                    return true;
                }
            }

            return false;
        }
    
        public int AmountOfProducts(){
            return products_list.Count;
        }

        public ProductsInStock GetProducts(int id){
            foreach (var item in products_list)
            {
                if(item.GetProduct().GetID() == id){
                    return item;
                }
            }

            return null;
        }

        public int UpdateProductQuantity(int prod_id, int quant){
            ProductsInStock prod = products_list.Find(x => x.GetProduct().GetID() == prod_id);
            int currentQuant = prod.GetQuant();
            if((currentQuant - quant) <= 0){
                prod.SetQuant(0);
                return currentQuant;
            }else{
                prod.SetQuant(currentQuant - quant);
                return quant;
            }
        }
    }
}