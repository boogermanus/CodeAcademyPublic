## Setup
1. Fork the project repo from github.com/AustinCodingAcademy/NG421_wk1_day1_ToDoApp
1. Navigate to a your developer folder or create a new : `mkdir AngularAppsFolder`
1. git clone your fork into this folder
1. cd into folder
1. `npm install`
1. Open the project in your text editor so we can see what we're doing with each of these steps: `code .`
1. Take a moment to look at the folders and files you created with that one command: `e2e`, `node_modules`, `src`, `environment`, config files and 7 `.json` files, as well as a `.gitignore` file which means this directory has been initialized as a git repo!
1. Before we get off and running let's get our project bootstrapped so it's a little more visually appealing and intuitive. Run `npm install bootstrap --save`
1. Now that we have bootstrap installed we'll need to make a tweak to the `angular.json` file to allow bootstrap to be applied to the project. Add to the styles attribute
	  * Navigate to the `angular.json` files and find the key `"architect":` 
    * Inside that object find the `"styles":` key.
    * Right now that array should like like:

    ```json
      "styles": [
        "src/styles.scss"
      ]
    ```

    * But you'll need to add this path `"node_modules/bootstrap/dist/css/bootstrap.min.css",`, so the file will look like this instead:

    ```json
      "styles": [
        "node_modules/bootstrap/dist/css/bootstrap.min.css",
        "src/styles.scss"
      ]
    ```

    * This is telling Angular that when it builds the app to look for styles FIRST in the node_modules folder and find the bootstrap code which will tell the browser how to render our components.

1. run `npm start` to serve your application through localhost:4200 and open it in your browser. Since we haven't done anything yet, the page should be blank.



## Code
1. We're now going to create a static list of Items and display them as a list.
1. open `app.component.ts` and initialize an empty array called `todoList`
  
    ```typescript
      export class AppComponent {
        title = 'Todos';
        todoList: any [] = [];
      }
    ```
    <!-- todoList: any [] = []; -->
    
1. If you remember from the pre-course work, our component have a lifecycle method called: `ngOnInit`. Let's declare this method and initialize the todoList variable with an item: `{ title: 'Install Angular CLI', isDone: false }`. After the component mounts we'll have this item in our array of TodoItems! [Angular Docs on LifeCycle Hooks: ngOnInit()](https://angular.io/guide/lifecycle-hooks).
    
    ```typescript
      ngOnInit() {
        this.todoList = [
          // example of how to make an item in todo list
          { title: 'Install Angular CLI', isDone: false },
        
        ];
      }
    ```

1. Once we've completed a todo we'll obviously need to remove it from our list. Create a function that will let us remove items from the todo list once it's called.

    ```typescript
      // a method to delete an item
      deleteTodo(todo:any) {
        const index = this.todoList.findIndex(todoItem => todoItem === todo);
        this.todoList.splice(index, 1);
      }
    ```

1. Since we want to be able to see these items in our browser let's create some visual representation of this list...
1. In the app template: `app.component.html` start on line 9
1. Add a header: `<h1 align="center">Todo List</h1>`
1. Next we need to iterate over the todoList we created in the `app.component.ts`. This is accomplished using `*ngFor` directive we covered in the pre-course work.
1. Below the Todo List `h1` header paste in this code:

    ```html
    <ul align="center" class="list-group">
      <li class="list-group-item" *ngFor="let todo of todoList">
          <div class="view">
            <label>{{todo.title}}</label>
            <div class="float-right">
              <button type="button" class="btn btn-danger btn-sm">Delete</button>
            </div>
          </div>
        </li>
      </ul>
    ```

    * NOTE: **We made use of some *fancy* bootstrap styling here including: `"list group"`, `"list-group-item"`, `"float-right"`, and `"btn btn-danger btn-small"` styling. These classnames come from Bootstrap which make it incredibly quick for us to markup and style our applications. Basically, Bootstrap is a very long CSS file with loads of pre-styled pieces and all we have to do is apply the class name to the element we want to have that styling. Check out the [Angular Bootstrap Documentation](https://ng-bootstrap.github.io/#/getting-started) to learn more.**

1. Next we need to capture the click event of the delete button (*which currently does nothing*) and attach it to the delete method we created in the `app.component.ts`. Adjust the button element to look like this:

    ```html
      <button type="button" (click)= deleteTodo(todo) class="btn btn-danger btn-sm">Delete</button>
    ```  

1. Now by clicking the delete button it should remove that item from the list. But wait, how did it do this??? Step through the functionality of your app class, `app.component.ts`, and see if you can figure it out. Remember, Angular bundles templates, styles, and classes of each component together.
1. After you've worked through what's happening let's focus our attention on adding to our list!
1. Above the list of todos add an input. So in your app template, `app.component.html`

    ```html
    <input type="text" class="todo-input" placeholder="Add next todo here">
    ```

1. Now we can type in text on the screen but we'll need to capture the event and save the input! So let's import a module called: FormsModule to help us get the input and make it available to our component's class. In the `app.module.ts` file under the `import { NgModule } from '@angular/core'` line write: `import { FormsModule } from '@angular/forms'`.
1. Then in the `@NgModule.imports` array add in `FormsModule` under `AppRoutingModule,` *Be sure to add the `,` in.*
1. Now that we have this helper module in place let's use it! Back in our `app.component.html` template file add this attribute to your `<input>` tag: `[(ngModel)]="todoTitle"`. *This will use the Model from our FormsModule import to talk to our component's class.*

    ```html
    <input type="text" class="todo-input" placeholder="Add next todo here" [(ngModel)]="todoTitle">
    ```

1. Since these two files can talk to each other, let's create a variable called `todoTitle` in our component's class so we can use it when we create a new todo.
1. In `app.component.ts` initiate a variable called `todoTitle: string;` to make your class look like this:

    ```typescript
      export class AppComponent {
        title = 'Todos';
        todoList: any [] = [];
        todoTitle: string;
      }
    ```

1. Then set it as an empty string when the component is loaded. Add in this line: `this.todoTitle = '';`

    ```typescript
      ngOnInit() {
        this.todoTitle = '';
        this.todoList = [
          // example of how to make an item in todo list
          { title: 'Install Angular CLI', isDone: false },
        ];
      }
    ```

1. Now you should be able to open up your **devTools panel**, click the **Augury tab**, then click on **AppComponent** and see the state of your component which includes: `title`, `todoList`, and `todoTitle`. If you type in the input it should change the value of `todoTitle`.
1. Just like we created a `deleteTodo` method, we now need to create an `addTodo` method. In your class, `app.component.ts` add this method above your `deleteTodo` method:

    ```typescript
      // adds a todo to our list
      addTodo():void {
        this.todoList.push({
          title: this.todoTitle,
          isDone: false
        });
        
        // resets our todoTitle variable to an empty string
        this.todoTitle = '';
      }
    ```

1. Wonderful! Now we have a method that we can call upon when needed. So, let's allow the user to type in the todo and the press **ENTER** to add the todo to the list. In your template, add this nifty event listener: `(keyup.enter)=addTodo()` to the end of the `<input>` tag. This will listen for the press of **ENTER** and call our `addTodo` method when it does. [Angular Docs on User Input](https://angular.io/guide/user-input).

    ```html
    <input type="text" class="todo-input" placeholder="Add next todo here" [(ngModel)]="todoTitle" (keyup.enter)=addTodo()>
    ```

