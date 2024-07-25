const cart = []; // Array to store cart items
let totalAmount = 0.00;

// Function to add an item to the cart
function addToCart(itemId, itemName, itemPrice) {
    const item = {
        id: itemId,
        name: itemName,
        price: itemPrice.toFixed(2)
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
