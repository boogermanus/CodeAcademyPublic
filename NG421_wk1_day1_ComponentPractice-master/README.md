
# Intro
The purpose of this project is to practice coding Angular components. We will use our knowledge from the pre-work and the practices to reorganize this website into components. We are going to experience what might happen on the job. You may be tasked with working an existing website in which all the Html is crammed into one file. Your job is to implement Angular and decide how you can organize the existing Html into components. In this project, you are told what the components should be, but in real life, you might have to decide this for yourself.

# Setup
* Fork the repo, clone your repo to your computer, npm i, npm start. Observe the browser open at http://localhost:4200.

## Part 1
Let's reorganize our project code into components. There is one file `src\app\app.component.html`, that has all the html in it. We need to seperate this all out into individual components.


### Create components
* Use ng generate or manually create the files necessary for your components
* Refer to the list of components to make
* In `src\app\app.component.html`, do a find for the name of the component you want to make. i.e. `TopNav`
* You will find comments that look like `<!-- TopNav  -->  <!-- TopNav  -->`
* Search for the name of the component you are attempting to make
* This will indicate where the component should start and end
* Or use the expand/collapse feature of the editor to find the start and end
* Cut out the code between the comments and put in the component .html file.
* Decide what is in the component that should not be hard coded
* Remove hard coded info and move it to a class property. There is no right or wrong answer to this. Try your best to figure it out.
* Make sure to populate the class property in the ngOnInit lifecycle method
* Use template syntax `{{}}` to then show that information in the html
* Make sure to use the component tag back in place of the html that you removed from `src\app\app.component.html`


### Components to make (create in order)
* DateTime
* MessagePreview
* TaskItem
* TopNav
* SideNav
* Comments
* Tasks
* Orders
* Tickets
* AreaChart
* DonutChart
* TasksPanel
* TransactionsPanel
* Dashboard

### Use components where appropriate
* Wherever you cut out the html, you need to replace it with the tag of the component
* Replace the comments with the actual usage of the components (custom element), i.e. `<app-top-nav></app-top-nav>`

## Part 2
Let's use our data to dynamically make some html and components show up in our page.

### Dynamic elements
* TransactionsPanel (transaction-panel.component.ts)
  * Import the orders array into this component from `./src/app/orders.ts`
  * In the `OnNgInit`method, assign this array to a class property called `orders` 
  * In `transaction-panel.component.html` use `ngFor` on the `<tr>` element in the `tbody`
  * `<tr *ngFor="let order of orders"></tr>`
  * Populate the hard coded information with dynamic data from the `order` variable
  * We should now see multiple rows in the transaction panel.
* TaskPanel (task-panel.component.ts)
  * Import the tasks array into this component from `./src/app/tasks.ts`
  * In the `OnNgInit`method, assign this array to a class property called `tasks` 
  * In `task-panel.component.html` use `ngFor` on the `<app-task-item>` element
  * `<app-task-item *ngFor="let task of tasks"></app-task-item>`
  * We shoudl now see multiple rows in the task panel.
* TopNav (top-nav.component.ts)
  * Import the messages array into this component from `./src/app/messages.ts`
  * In the `OnNgInit`method, assign this array to a class property called `messages` 
  * In `top.nav.component.html` use `ngFor` on the `<app-message-preview>` element
  * `<app-message-preview *ngFor="let message of messages"></app-message-preview>`
  * We should now see multiple messages in the top nav menu item for messages

### Conditional Rendering
Use NgIf in the TransactionPanel component. If the order amount is greater than $1000, make the `<tr>` red.


### Input
Use the Input decorator to allow our components to accept data through an attribute.
* TaskItem
  * In `task-item.component.ts`, create a class property named `taskItem` and decorate it with `Input()`
  * Use this property to populate the html with the data `taskItem.task`
  * In `task-panel.component.html` pass in the task to the task item component `<app-task-item *ngFor="let task of tasks" [taskItem]="task"></app-task-item>`
* MessagePreview
  * In `message-preview.component.ts`, create a class property named `message` and decorate it with `Input()`
  * Use this property to populate the html with the data `{{message.message}}`
  * In `top-nav.component.html` pass in the task to the task item component `<app-message-preview *ngFor="let message of messages" [message]="message"></app-message-preview>`