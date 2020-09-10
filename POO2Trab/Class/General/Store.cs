using System;
using System.Collections.Generic;

namespace POO2Trab
{
    public class Store
    {
        private int store_id;
        private string store_name;
        Stock store_stock = new Stock();

        public void SetID(int id){
            store_id = id;
        }

        public void SetName(string name){
            store_name = name;
        }

        public int GetID(){
            return store_id;
        }

        public string GetName(){
            return store_name;
        }

        public Stock GetStock(){
            return store_stock;
        }
    }
}