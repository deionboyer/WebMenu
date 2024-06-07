const cart = []; // Array to store cart items
let totalAmount = 0;

// Function to add an item to the cart
function addToCart(itemId, itemName, itemPrice) {
    const item = {
        id: itemId,
        name: itemName,
        price: itemPrice
    };
    cart.push(item);
    totalAmount += itemPrice;
    updateCartUI();
}

// Function to remove an item from the cart
function removeFromCart(itemId) {
    const index = cart.findIndex(item => item.id === itemId);
    if (index !== -1) {
        const removedItem = cart.splice(index, 1)[0];
        totalAmount -= removedItem.price;
        updateCartUI();
    }
}

// Function to update the cart UI
function updateCartUI() {
    const productList = document.querySelector('.product-list');
    productList.innerHTML = ''; // Clear existing items
    cart.forEach(item => {
        const listItem = document.createElement('li');
        listItem.textContent = `${item.name} - $${item.price}`;
        productList.appendChild(listItem);

        // Add a delete button for each item
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.onclick = () => removeFromCart(item.id);
        listItem.appendChild(deleteButton);
    });

    // Update the total amount
    const totalAmountSpan = document.getElementById('totalAmount');
    totalAmountSpan.textContent = totalAmount.toFixed(2);
}

// Other functions (e.g., clearCart) can be added as needed

// Initialize the UI
updateCartUI();





/*<input type="hidden" id="itemId" value="0" />*/

//Items Class
//hard to get java script and razor to work to gether
//value of any item
//document.getelemntbyId
//Think about istead of making exsiting crud have shape it around a specific
/*overload where I pass a list of int's'*/

//let ArrProducts = [
//    {
//        id = 1,
//        name: "Mac & Cheese,
//        image: "https://i.ibb.co/5W9Y8D0/66n17n0s.jpg",
//        price: "4.60",
//    },
//    {
//        id = 2
//        name: "BBQ Wings,
//        image: "https://i.ibb.co/fCMvrMH/bwnzplfg.png"
//        price: "16.00",
//    },
//    {
//        id = 4
//        name: "Sewwt Potatoe Pie",
//        image: "https://i.ibb.co/fFrxk9Q/y6x7d1hg.png"
//        price: "10.25",
//    },
//    {
//        id = 5
//        name: "Fried Chicken Sandwich",
//        image: "https://i.ibb.co/kxNVZ4y/ncq6zoki.png"
//        price: "16.00",
//    },
//    {
//        id = 6
//        name: "BBQ Ribs",
//        image: "https://i.ibb.co/gjrCs6c/o9jqmtge.png"
//        price: "23.00",
//    },
//    {
//        id = 8
//        name: "Strawberry Shortcake",
//        image: "https://i.ibb.co/YDskgMK/7u8emxd7.png"
//        price: "6.50",
//    },
//];
//const productList = document.querySelector('.product-list');
//const listItem = document.createElement('li');
//const shoppingBasket = document.querySelector('.shoppingBasket');

//function onInIT() {
//    ArrProducts.forEach((item, key) => {
//        let div = document.createElement("div");
//        div.classList.add("item);
        
        
//    });
//}

//function addToCart(Id) {
//    console.log(ArrProducts[id]);
//    if (checkOutList[Id] == null) {
//        checkOutList[Id] = ArrProducts[Id];
//    }
//}



