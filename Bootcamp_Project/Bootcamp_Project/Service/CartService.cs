using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using Bootcamp_Project.Models.Cart;

namespace Bootcamp_Project.Service
{
    public class CartService
    {

        private readonly EF_DataContext _context;
        private readonly ILogger _logger;
        private readonly ProductService _productService;

        public CartService(EF_DataContext context, ILogger logger)
        {
            
            _context = context;
            _logger = logger;
            _productService = new ProductService(context,logger);
        }

        public string AddCartItem(CartItemAddRequest cartItem)
        {
            _logger.LogInformation("Inside AddCartItem");

            // First create or fetch cart
            Cart cart = _context.Carts
                .FirstOrDefault(p => p.status && p.user.Id == cartItem.userId);

            int cartId;
            // if no cart, create and save it and then fetch it again to retrieve id
            if (cart == null)
            {
                User user = _context.Users.FirstOrDefault(p => p.status && p.Id == cartItem.userId);
                if (user == null)
                {
                    return $"User with id: {cartItem.userId} is either not present or not active";
                }
                cart = new Cart();
                cart.user = user;
                _context.Carts.Add(cart);
                _context.SaveChanges();
                cartId = cart.Id;
                _logger.LogInformation($"Cart created for user: {user.Id}");
            }
            else
            {
                _logger.LogInformation("Cart fetched");
                cartId = cart.Id;
            }

            //check if product id is valid
            Product product = _context.Products.FirstOrDefault(p => p.status && p.Id == cartItem.productId);
            if(product == null)
            {
                return "Invalid product Id";
            }
            _logger.LogInformation("Product fetched");

            // check if the product is already in cart or not
            CartItem alreadyPresentItem = _context.CartItems
                .FirstOrDefault(p => p.status && p.cartId == cart.Id && p.productId == cartItem.productId);
            if(alreadyPresentItem != null)
            {
                return "The product is already added to your cart";
            }

            // Then create entry in cart item
            CartItem newCartItem = new CartItem();
            newCartItem.productId = product.Id;
            newCartItem.cartId = cart.Id;
            newCartItem.quantity = cartItem.quantity;
            _context.CartItems.Add(newCartItem);
            _context.SaveChanges();

            return "Product added to cart successfully";
        }

        public string RemoveCartItem(int cartItemId)
        {
            _logger.LogInformation("Inside RemoveCartItem");
            CartItem cartItem = FetchCartItem(cartItemId);
            if(cartItem == null)
            {
                return "Invalid cart item id";
            }
            cartItem.status = false;
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
            return "Product has been removed from cart";
        }

        public string ModifyCartItem(CartItemModifyRequest cartItemModifyRequest)
        {
            _logger.LogInformation("Inside ModifyCartItem");
            CartItem cartItem = FetchCartItem(cartItemModifyRequest.cartItemId);
            if (cartItem == null)
            {
                return "Invalid cart item id";
            }

            Product product = FetchProductByCartItem(cartItem);
            if(product != null && product.quantity < cartItemModifyRequest.quantity)
            {
                return "Quantity is not in stock";
            }

            cartItem.quantity = cartItemModifyRequest.quantity;
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
            return "Product has been updated in the cart";
        }

        public CartResponse GetCartDetail(int userId)
        {
            _logger.LogInformation("Inside GetCartDetail");
            User user = _context.Users.FirstOrDefault(p => p.Id == userId);
            if(user == null)
            {
                throw new BadHttpRequestException("UserId is invalid");
            }
            _logger.LogInformation("User fetched");

            Cart cart = _context.Carts.FirstOrDefault(p => p.user.Id == userId);
            if (cart == null)
            {
                throw new BadHttpRequestException("Cart is empty or not created");
            }
            _logger.LogInformation("Cart fetched");

            List<CartItem> cartItems = _context.CartItems.Where(p => p.cartId == cart.Id).ToList();
            List<int> prodIds = new List<int>();

            foreach(var item in cartItems)
            {
                prodIds.Add(item.productId);
            }
            var products = _context.Products.Where(p => prodIds.Contains(p.Id)).ToList();
            List<ProductCartItemAggResponse> productCartItemAggResponses = new List<ProductCartItemAggResponse>();
            for (var i=0;i<products.Count; i++)
            {
                productCartItemAggResponses.Add(new ProductCartItemAggResponse() { cartItem = cartItems[0], product = products[i] });
            }
            List<CartItemResponse> cartItemResponse = new List<CartItemResponse>();
            foreach (ProductCartItemAggResponse cartItem in productCartItemAggResponses)
            {
                Console.WriteLine(cartItem.cartItem.Id);
                Console.WriteLine(cartItem.product.description);
                Console.WriteLine(cartItem.product.name);
                Console.WriteLine(cartItem.product.basePrice);
                Console.WriteLine(cartItem.product.quantity);
                Console.WriteLine(cartItem.cartItem.quantity);
                Console.WriteLine(_productService.ProductDeliveryPriceForCart(cartItem.product, cartItem.product.basePrice.ToString(), cartItem.cartItem.quantity));
                Console.WriteLine(_productService.TaxEstimationForProductInCart(cartItem.cartItem, cartItem.cartItem.quantity));
                cartItemResponse.Add(new CartItemResponse()
                {
                    cartItemId = cartItem.cartItem.Id,
                    productDescription = cartItem.product.description,
                    productName = cartItem.product.name,
                    productPrice = cartItem.product.basePrice,
                    quantity = cartItem.cartItem.quantity,
                    totalDeliveryPrice = _productService.ProductDeliveryPriceForCart(cartItem.product, cartItem.product.basePrice.ToString(), cartItem.cartItem.quantity),
                    totalTax = _productService.TaxEstimationForProductInCart(cartItem.cartItem, cartItem.cartItem.quantity),
                    productImage = cartItem.product.productImage
                });
            }

            
            //Console.WriteLine(cartItems.Count);
            //foreach(var cartItem in cartItems)
            //{
            //    Console.WriteLine(cartItem.product.SKU);
            //    cartItemResponse.Add(new CartItemResponse()
            //    {
            //        cartItemId = cartItem.Id,
            //        productDescription = cartItem.product.description,
            //        productName = cartItem.product.name,
            //        productPrice = cartItem.product.basePrice,
            //        quantity = cartItem.quantity,
            //        totalDeliveryPrice = _productService.ProductDeliveryPriceForCart(cartItem.product, cartItem.product.basePrice.ToString(), cartItem.quantity),
            //        totalTax = _productService.TaxEstimationForProductInCart(cartItem, cartItem.quantity)
            //    });
            //}
            _logger.LogInformation("CarItemsResponse list created");

            CartResponse cartResponse = new CartResponse();
            cartResponse.cartId = cart.Id;
            cartResponse.userId = userId;
            cartResponse.cartItems = cartItemResponse;
            _logger.LogInformation("CartResponse created");

            foreach (CartItemResponse item in cartResponse.cartItems)
            {
                item.totalPrice = item.productPrice + item.totalTax + item.totalDeliveryPrice;
                cartResponse.totalProductAmount += item.productPrice;
                cartResponse.totalCartAmount += item.totalPrice;
                cartResponse.totalTaxAmount += item.totalTax;
                cartResponse.totalDeliveryAmount += item.totalDeliveryPrice;
            }
            _logger.LogInformation("Total cost details filled");
            return cartResponse;
        }

        private CartItem FetchCartItem(int cartItemId)
        {
            _logger.LogInformation("Inside FetchCartItem");
            return  _context.CartItems
               .FirstOrDefault(p => p.status && p.Id == cartItemId);
        }

        private Product FetchProductByCartItem(CartItem cartItem)
        {
            _logger.LogInformation("Inside FetchProductByCartItem");
            return _context.Products
                .FirstOrDefault(p => p.status && p.Id == cartItem.productId);
        }
    }
}
