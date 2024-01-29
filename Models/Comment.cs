namespace OnlineShopCMS.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }    //留言者
        public string Content { get; set; }         //留言內容
        public DateTime Time { get; set; }      //留言時間
        public int ProductID { get; set; }			//商品編號
    }
}
