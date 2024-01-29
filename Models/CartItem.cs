namespace OnlineShopCMS.Models
{
	public class CartItem : OrderItem
	{
		public Product Product { get; set; }
		public string imageSrc { get; set; }
	}
}
