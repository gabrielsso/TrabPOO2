using System;
using System.Collections.Generic;
using System.IO;

namespace POO2Trab
{
    public class SaveArquives
    {
        public void Save(DeliverSector ds, List<Store> strs, List<Orders> ords){
            TextWriter tw = new StreamWriter("Dados.txt");

            if(strs.Count == 0)
            {
                tw.WriteLine("Nenhuma loja registrada.");
            }
            else
            {
                foreach (var item in strs)
                {
                    Stock stk = item.GetStock();
                    tw.WriteLine("ID: {0}, Nome da loja: {1}",item.GetID(), item.GetName());
                    tw.WriteLine("-------------------------------");
                    tw.WriteLine("Produtos registrado na loja:");
                    
                    if(stk.GetListOfProducts().Count == 0)
                    {
                        tw.WriteLine("Nenhum produto registrado na loja.");
                    }
                    else
                    {
                        foreach (var product in stk.GetListOfProducts())
                        {
                            tw.WriteLine("ID: {0}, Nome do Produto: {1}, Valor: {2}, Quantidade: {3}",
                                        product.GetProduct().GetID(), product.GetProduct().GetName(),
                                        product.GetProduct().GetCost(), product.GetQuant());
                        }
                    }
                    
                    tw.WriteLine("\n-------------------------------");
                    
                    tw.WriteLine("Pedidos registrado na loja:");
                    int i = 0;
                    foreach (var order in ords)
                    {
                        
                        if(order.getOrderStoreID() == item.GetID()){
                            i++;
                            tw.WriteLine("ID: {0}, Nome do Cliente: {1}, Preço do pedido: {2}, Quando foi Pedido: {3}",
                                        order.GetOrderId(), order.GetClientName(),
                                        order.GetPrice(), order.GetDate());
                        }
                    }
                    if(i == 0)
                    {
                        i = 0;
                        tw.WriteLine("Nenhum pedido registrado na loja.");
                    }

                    tw.WriteLine("-------------------------------\n");
                }
            }

            tw.WriteLine("\n-------------------------------");
            tw.WriteLine("Pedidos no Setor de entrega:");
            tw.WriteLine("-------------------------------");
            tw.WriteLine("Incompletos:");
            
            if(ds.Send_Incomplete_Orders_to_Save().Count == 0)
            {
                tw.WriteLine("Nenhum pedido incompleto.");
            }
            else
            {
                foreach (var item in ds.Send_Incomplete_Orders_to_Save())
                {
                    tw.WriteLine("ID: {0}, Nome do Cliente: {1}, Preço do pedido: {2}, Quando foi Pedido: {3}",
                                        item.GetOrderId(), item.GetClientName(),
                                        item.GetPrice(), item.GetDate());
                }
            }
            
            tw.WriteLine("\n-------------------------------");
            tw.WriteLine("Completos:");
            
            if(ds.Send_Complete_Orders_to_Save().Count == 0)
            {
                tw.WriteLine("Nenhum pedido completo.");
            }
            else
            {
                foreach (var item in ds.Send_Complete_Orders_to_Save())
                {
                    tw.WriteLine("ID: {0}, Nome do Cliente: {1}, Preço do pedido: {2}, Quando foi Pedido: {3}",
                                        item.GetOrderId(), item.GetClientName(),
                                        item.GetPrice(), item.GetDate());
                }
            }

            tw.Close();
        }
        
    
    }
}