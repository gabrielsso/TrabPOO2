using System;
using System.Collections.Generic;

namespace POO2Trab{
    public class Orders
    {
        private int order_id;
        private DateTime order_time;
        private int store_id;
        private List<Tuple<int, int>> products_order = new List<Tuple<int, int>>(); 
        private float order_price;
        private string client_name;
        private bool order_situation;
        private bool order_send = false;

        public void SetID(int id){
            order_id = id;
        }

        public void Set_Store_ID(int s_id){
            store_id = s_id;
        }
        
        public void Add_Product(int prod_id, int quant_order){
            if (products_order.Count != 0)
            {
                foreach (var item in products_order)
                {
                    if (item.Item1 == prod_id)
                    {
                        Console.WriteLine("Quantidade registrada: {0}", item.Item2);
                        int newQuant = item.Item2 + quant_order;
                        products_order.RemoveAll(ind => ind.Item1 == prod_id);
                        products_order.Add(Tuple.Create(prod_id, newQuant));
                        Console.WriteLine("Testando add_product");
                        return;
                    }
                }
            }
            products_order.Add(Tuple.Create(prod_id, quant_order));
            return;
        }

        public void SetPrice(Stock stk){
            order_price = 0;
            foreach (var item in products_order)
            {
                ProductsInStock prod = stk.GetProducts(item.Item1);
                order_price += (float) ((prod.GetProduct().GetCost()) * item.Item2);
            }
        }

        public void SetDate(DateTime date){
            order_time = date;
        }

        public void SetClientName(string name){
            client_name = name;
        }

        public void SetSituation(bool current_situ){
            order_situation = current_situ;
        }

        public DateTime GetDate(){
            return order_time;
        }

        public int GetOrderId(){
            return order_id;
        }

        public int getOrderStoreID(){
            return store_id;
        }

        public void GetProductsInOrder(Stock stk){
            Console.WriteLine("Produtos no pedido:");
            Console.WriteLine("---------------------------\n");
            foreach (var item in products_order)
            {
                ProductsInStock pis = stk.GetProducts(item.Item1);
                Console.WriteLine("Produto: {0}, Preço: {1}, Quantidade: {2}", pis.GetProduct().GetName(), 
                pis.GetProduct().GetCost(), item.Item2);
            }
        }

        public string GetClientName(){
            return client_name;
        }

        public float GetPrice(){
            return order_price;
        }

        public bool GetSituation(){
            return order_situation;
        }

        //O pedido foi enviado para o setor de entregas
        public void SendOrder(){
            order_send = true;
        }
    }
}