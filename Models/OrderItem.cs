namespace OnlineShopCMS.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductID { get; set; }
		public int Amount { get; set; }
		public int SubTotal { get; set; }

	}
}
