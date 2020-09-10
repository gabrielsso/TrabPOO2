namespace POO2Trab
{
    public class ProductsInStock
    {
        private Products product;
        private int quant;

        public void SetProduct(Products prod){
            product = prod;
        }
        
        public void SetQuant(int new_quant){
            quant = new_quant;
        }

        public Products GetProduct(){
            return product;
        }

        public int GetQuant(){
            return quant;
        }
    }
}