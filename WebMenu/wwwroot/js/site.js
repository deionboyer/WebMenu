const cart = []; // Array to store cart items

// Function to add an item to the cart
function addToCart(itemId, itemName, itemPrice) {
    const item = {
        id: itemId,
        name: itemName,
        price: itemPrice
    };
    cart.push(item);
   /* x = document.getElementsByID("menu");*/
    // Update UI: Add item to product list
    const productList = document.querySelector('.product-list');
    const listItem = document.createElement('li');
    listItem.textContent = `${itemName} - $${itemPrice}`;
    productList.appendChild(listItem);

    // Update UI: Update total amount and quantity
    const totalAmount = cart.reduce((total, item) => total + item.price, 0);
    const quantity = cart.length;
    document.querySelector('.total-amount').textContent = totalAmount;
    document.querySelector('.quantity').textContent = quantity;

    console.log(`Added ${itemName} to the cart!`);
}

// Event listener for shopping basket click
const shoppingBasket = document.querySelector('.shoppingBasket');
shoppingBasket.onclick = () => {
    body.classList.add("active");
    // Toggle visibility of the cart (show/hide)
    // You can add your own logic here
};


/*<input type="hidden" id="itemId" value="0" />*/

//Items Class
//hard to get java script and razor to work to gether
//value of any item
//document.getelemntbyId
//Think about istead of making exsiting crud have shape it around a specific 
/*overload where I pass a list of int's'*/