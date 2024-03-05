using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopCMS.Data;
using OnlineShopCMS.Helpers;
using OnlineShopCMS.Models;

namespace OnlineShopCMS.Controllers
{
    public class OrderController : Controller
    {

        private readonly OnlineShopContext _context;

        public OrderController(OnlineShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            if (SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart") == null)
            {
                return RedirectToAction("Index", "Cart");
            }

            var myOrder = new Order()
            {
                //UserId = User.GetUserId(User),     //取得訂購人ID
                //UserName = _userManager.GetUserName(User), //取得訂購人帳號
                OrderItem = SessionHelper.    
                //取得購物車資料
                    GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart")
            };
            myOrder.Total = myOrder.OrderItem.Sum(m => m.SubTotal); //計算訂單總額

            ViewBag.CartItems = SessionHelper.
                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");        //從Session取得json字串，並轉成指定的型別<CartItem>

            if (HttpContext.Session.GetString("UserSession") != null)           //判斷 登入變logout、登出變login
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View(myOrder);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;    //取得當前時間
                order.isPaid = false;              //付款狀態預設為False
                order.OrderItem = SessionHelper.   //綁定訂單內容
                    GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");

                _context.Add(order);               //將訂單寫入資料庫
                await _context.SaveChangesAsync();
                SessionHelper.Remove(HttpContext.Session, "cart");

                //完成後畫面移轉至ReviewOrder()
                return RedirectToAction("ReviewOrder", new { Id = order.Id });
            }
            return View("Checkout");
        }

        public async Task<IActionResult> ReviewOrder(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            //從資料庫取得訂單資料
            var order = await _context.Order.FirstOrDefaultAsync(m => m.Id == Id);
            //if (order.UserId != _userManager.GetUserId(User))
            //{
            //    return NotFound();
            //}
            //else
            //{
                //取得訂單內容
                order.OrderItem = await _context.OrderItems
                    .Where(p => p.OrderId == Id).ToListAsync();
            ViewBag.orderItems = GetOrderItems(order.Id);           //

  
            //}

            if (HttpContext.Session.GetString("UserSession") != null)           //判斷 登入變logout、登出變login
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }

            //取得訂單內容
            //ViewBag.CartItems = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");


            return View(order);
        }

        // 取得商品詳細資料
        private List<CartItem> GetOrderItems(int orderId)
        {
            var OrderItems = _context.OrderItems.Where(p => p.OrderId == orderId).ToList();
            List<CartItem> orderItems = new List<CartItem>();
            foreach (var orderitem in OrderItems)
            {
                CartItem item = new CartItem();
                item.Product = _context.Product.Single(x => x.Id == orderitem.Id);              //
                orderItems.Add(item);
                ViewBag.orderItems = orderItems;
            }

            ViewBag.CartItems = SessionHelper.
      GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            return orderItems;
        }
    }


}
