namespace WebProject.Models.AddToCart
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int Id_User {  get; set; }
        public int Quantity { get; set; } 

        public CartItem() { }
        public CartItem(int productId, int quantity, int id)
        {
            Id = productId;
            Quantity = quantity;
            Id_User = id;
        }
    }
}