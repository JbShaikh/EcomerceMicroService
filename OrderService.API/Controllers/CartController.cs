using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs.CartDTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly OrderDbContext db;
        private readonly ICartRepository repo;
        private readonly IMapper mapper;
        public CartController(OrderDbContext db, ICartRepository repo, IMapper mapper)
        {
            this.db = db;
            this.repo = repo;
            this.mapper = mapper;
        }
        // Adding Cart
        [HttpPost("Add")]
        public async Task<IActionResult> AddToCart(AddToCartDTO dto) {
            // check Product Exist
            //var product = await db.Product.FindAsync(dto.ProductId);
            //if (product == null) {
            //    return NotFound("Product Not Found");
            //}
            //// ADD STOCK VALIDATION HERE
            //if (product.Stock < dto.Quantity)
            //{
            //    return BadRequest(
            //        $"Only {product.Stock} items available in stock");
            //}
            // get Customer Cart
            var cart = await repo.GetCartByCustomerId(dto.CustomerId);
            // create cart if not exit
            if (cart == null) {

                cart = new Cart
                {
                    CustomerId = dto.CustomerId,
                    CreateDate = DateTime.Now
                };
                await repo.Add(cart);
            }
            // check procut is already exit
            var existcartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == dto.ProductId);
            if (existcartItem != null)
            {
                // increase product quantity if you want
                existcartItem.Quantity += dto.Quantity;
            }
            else {
                //create new ProductItem
                cart.CartItems.Add(new CartItem
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                   // Price = product.Price
                });
            }
            await repo.Update(cart);
            return Ok("Cart Added Successfully");
        }

        [HttpGet("customerId")]
        public async Task<IActionResult> GetCart(int customerId) {
            var custCart = await repo.GetCartByCustomerId(customerId);
            if (custCart == null) {
                return NotFound();
            }
            var cartMap = mapper.Map<CartDTO>(custCart);
            // totsl smount
            cartMap.TotolAmount = custCart.CartItems.Sum(x => x.Price * x.Quantity);

            return Ok(cartMap);
        }
        // Update Quantity
        [HttpPut("cartItemId")]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, UpdatCartItemDTO dto) {
            var item = await repo.GetCartItemById(cartItemId);
            if (item == null) {
                return NotFound();
            }
            item.Quantity = dto.Quantity;
            await db.SaveChangesAsync();
            return Ok("Quantity Updated Sucessfully");
        }
        [HttpDelete("Item/id")]
        public async Task<IActionResult> RemoveCartItem(int id) {
            var cart = await repo.GetCartItemById(id);
            if (cart == null) {
                return NotFound();
            }
            await repo.RemoveCartItem(cart);
            return Ok("Cart Item Deleted");
        }
        //Delete Complete Cart
        [HttpDelete("Cart/custemerId")]
        public async Task<IActionResult> RemoveCart(int customerId) {
            var cart = await repo.GetCartByCustomerId(customerId);
            if (cart == null) {

                return NotFound();
            }
            await repo.Delete(cart);
            return Ok("Cart Deleted");
        }
        [HttpPost("checkout/customerId")]
        public async Task<IActionResult> Checkout(int customerId) { 
        var cartData = await repo.GetCartByCustomerId(customerId);
            if (cartData == null || !cartData.CartItems.Any()) {
                return BadRequest("Cart is empty");
            }
            // stock Validation
            foreach (var item in cartData.CartItems)
            {
                //var product = await db.Products.FindAsync(item.ProductId);

                //if (product == null)
                //{
                //    return BadRequest($"Product {item.ProductId} not found");
                //}

                //if (product.Stock < item.Quantity)
                //{
                //    return BadRequest(
                //        $"{product.Name} stock not available");
                //}

                // Reduce stock
               // product.Stock -= item.Quantity;
            }

            // creating order
            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount =
            cartData.CartItems.Sum(x => x.Price * x.Quantity),
                OrderItems =
            cartData.CartItems.Select(x =>
            new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price
            }).ToList()

            };
            // save order
            await db.Orders.AddAsync(order);
            // remove CartItem
             db.CartItems.RemoveRange(cartData.CartItems);
            await db.SaveChangesAsync();
            return Ok("Order Added Successfully");
        }
    }
}
