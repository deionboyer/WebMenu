<button type="button" onclick="addToCart(@item.ItemID)">Add To Cart</button>


function addToCart(itemId) {
    fetch('@Url.Action("AddToCart", "Home")', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': '@GetAntiForgeryToke()' // Add this if you have CSRF protection enabled
        },
        body: JSON.stringify({ itemId: itemId })
    })
    .then(response => {
        if (response.ok) {
            // Handle success (e.g., show a message or update the cart count)
            console.log('Item added to cart');
        } else {
            // Handle errors (e.g., show an error message)
            console.error('Error adding item to cart');
        }
    })
    .catch(error => {
        // Handle network errors
        console.error('Network error:', error);
    });
}
