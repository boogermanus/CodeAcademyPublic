## Intro
We need to build the front end web app of an ecommerce store. This project is based on an existing website that has no functionality. If you worked for this company, they may ask you to fix their current website that doesn't do anything and make it functional so that people can buy products on it. You might make the decision to use Angular to do this. Converting normal websites to use Angular components is a very common thing to do in the industry.

Our simple site will list out some hard coded products. Is this realistic? Would a small company only sell the same 10 items in a year? A user needs to be able to add a product to their shopping cart by clicking a button. How do you actually code the act of adding a product to the a digital shopping cart? Let's see.


https://blackrockdigital.github.io/startbootstrap-shop-homepage/

<img src="421-OnlineStoreGifDemo.gif">

## Setup
* Fork, clone, npm i, npm start

## Part 1 - Building Components
### The components
 * Organize this web page into appropriate components
   * ProductDetail
   * Header
   * Footer
   * Carousel
   * Think of some other components you could make
* Look in index.html for the existing html to use for the components
* Use the comments and the expand/collapse feature of the editor to make sure you get the correct html. Normally you would need to figure this out yourself but we are learning.
* We should be familiar with this process from a previous project

### app.component.html 
* Cut out the entire `<div id="root">` div from index.html and put it in `app.component.html`.
* Make sure not to remove `<app-root></app-root>` from index.html.
* Nothing will show up until you complete this step.

### Model
* create an interface for what a `product` should look like
* look at products.ts to get an idea of what properties a product should have and what types
```
 {
      "id": 1,
      "name": "Body Luxuries Sweet Lavender Hand Sanitizer",
      "description": "Cleans your hands",
      "reviews": 46,
      "rating": 2,
      "imgUrl": "http://dummyimage.com/136x167.bmp/cc0000/ffffff",
      "price": "$95.11"
  }
```
* Use this interface where appropriate

### TypeScript
* Apply types to appropriate places: argument types, function return types, class property types
* Import and use the Product interface where needed

### ProductService
* Create a new service for `product`
* Create a property on this class for `shoppingCart` which is an Array of Product
* Create a property on this class for `products` which is an Array of Product
* Import products from `products.ts` and assign it into the products property
* Create a method for `getProducts` with return type `Array<Product>`
* Create a method for `getShoppingCart` with return type `Array<Product>`
* Create a method for `addToCart` that takes an argument product of type `Product` and pushes it to the shopping cart array
* Make sure to import the service and add to the providers array in `app.module.ts`. The generator might not do this.

### app.component.ts
* Create a property called products of type `Array<Product>`
* Implement a constructor and `ngOnInit`
* Implement dependency injection to get the `ProductService` into a property called `productService`
* In `ngOnInit` call `this.productService.getProducts` and assign it into the `products` property.


### ProductDetail
* The ProductDetail should repesent only one single product.
* The ProductDetail component class should have a property `product` which is an object of type `Product`, and use it to populate price, name, description reviews and stars.
* Make this property an `@Input()` so that a parent component can send in information.
* Remove all hard coded information.
* Make the star images represent the number rating from data. (You might have to research how to do this).
* Bonus. Notice the grey stars. `<span class="glyphicon glyphicon-star-empty"></span>`


### Header
* The Header component should have a property `shoppingCart` that is an array of Product.
* Implement a constructor and `ngOnInit`.
* Implement dependency injection to get the `ProductService` into a property called `productService`.
* In `ngOnInit` call `this.productService.getShoppingCart` and assign it into the `shoppingCart` property.
* Use template interpolation to show `shoppingCart.length` intead of the hard coded 0. The 0 will still show up since the shopping cart is empty! 

### app.component.html 
* Use `ngFor` on the ProductDetail component to show a new `<app-product-detail>` per product.
* Send in each product from the products array into the attribute `product`



## Part 2 - Events and Component Comm

### Add Item To Cart
* Add a button to ProductDetail component "Add To Cart"
* Add an EventEmitter to ProductDetail called `productAdded`
* Handle the clicking of the button with event binding
* When the button is clicked it should emit the event sending in the product object

### app.component.ts
* Add an event handler method called `productWasAdded` that takes one argument, `product` of type `Product`
* In this method call `addToCart` on the productService sending in the product.

### app.component.html 
* Apply event binding on `<app-product-detail>` for the `productAdded` event. The handler method should be `productWasAdded`
* Don't forget `$event`

### Does it work
* Click the Add to Cart button. Is the header changing the number of items?
* Push yourself further. How could you show which products are actually in the cart?
  

# Extra Credit
### Server
* Create a database for this project
* Create a web server for ths project
* Create routes for products and orders

### Fetch
* Use fetch to retrieve products from your web api
* Where should the fetch call be made?
