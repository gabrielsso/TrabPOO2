namespace POO2Trab
{
    public class Products
    {
        private int product_id;
        private string product_name;
        private float product_cost;

        public string GetName(){
            return product_name;
        }

        public float GetCost(){
            return product_cost;
        }

        public int GetID(){
            return product_id;
        }

        public void SetId(int id){
            product_id = id;
        }

        public void SetName(string name){
            product_name = name;
        }
        public void SetCost(float price){
            product_cost = price;
        }
        
    }
}