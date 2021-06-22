## Intro
This project is our Todo app as we should have completed it from the last project. We are now going to continue building it out to practice the skills we've learned this week. We need to break up our app into components. We need to share data between those components with a service. We have a senstive situation in allowing users to delete todos. We need to confirm that they really want the delete to happen. A modal to the rescue.


## Setup
1. Fork, clone, npm i, npm start

## Code a Model

1. Create a new Interface using the CLI toolkit: `ng generate interface interfaces/ITodo`. This will ask the `ng` toolkit to `generate` a new `interface` inside a new folder called `interfaces/` called `Todo`.
1. Now let's shape our todo items in way that captures more data and helps us rendering them later. Create a few keys for the new `interface ITodo`

    ```typescript
      export interface ITodo {
        id: number;
        title: string;
        description: string;
      }
    ```

1. Then find your app class and change your `todoList` array from an array of `any` to only accept objects the fit the shape of `ITodo`:

    ```typescript
      export class AppComponent {
        title = "Todos";
        todoId: number = 0;
        todoList: ITodo [] = [];
        todoTitle: string;
      }
      // code continues
    ```

1. If VScode didn't automatically import `ITodo` for you, make sure you write import statement at the top of the file so you have access to it.
1. By now your todo app should be broken! You should get an error that says something like: "...is not assignable to parameter of type 'ITodo'."
1. To fix this adjust your `addTodo` method:

    ```typescript
      addTodo():void {
        this.todoList.push({
          id: this.todoId,
          title: this.todoTitle,
          description: ''
        });

        this.todoTitle = '';
        this.todoId++;

      }
    ```

1. You might want to change what is in your `ngOnInit()` method too...
1. We need to change all references of a todo to utilize this interface. Class properties, function arguments and return types

## Code a Service
1. Create a service folder and file in you Todo App: `ng generate service services/todo`
1. Refactor your code so that all functionality of todos is moved to the service
1. The `todoList` array, `addTodo(todo)`, `deleteTodo(todo)`, `getTodos`
1. We will now need to use depedency injection in the components to use this service.

## Make Components
1. We shouldn't be coding todo functionality in the app component
1. Create three components: `Todo`, `CreateTodo` and `TodoList`
1. `Todo` should handle everything for one todo
```
<div class="view">
    <label>{{todo.title}}</label>
    <div class="float-right">
        <button type="button" (click)= deleteTodo(todo) class="btn btn-danger btn-sm">Delete</button>
    </div>
</div>
```
1. `CreateTodo` should be the input 
```
<input type="text" class="todo-input" placeholder="Add next todo here" [(ngModel)]="todoTitle" (keyup.enter)=addTodo()>
```
1. Make sure `CreateTodo` handles creating a new todo
1. `TodoList` should be the ul and li
```
<ul align="center" class="list-group">
  <li class="list-group-item" *ngFor="let todo of todoList">
  </li>
</ul>
```
1. Adjust all code to use the todo service and the account for @Input().
1. Make sure the components appear in the webpage by using them where appropriate.
1. When completed, the app component should do nothing but decide where components appear. (No code in app.component.ts)

## Code a Modal
1. We need to remember how to code an Angular Bootstrap modal that should appear when the delete button is clicked.
1. Use your notes from the pre work videos or your own project as a reference. 
1. You could even use the source documentation.  [Docs](https://ng-bootstrap.github.io/#/getting-started)
1. Complete the steps to setup
    1. Install the `@ng-bootstrap/ng-bootstrap` package.
    1. Make sure `NgbModule` is in the imports array.
    1. The css is already installed from last time.
1. Use Angular CLI to create a component called: " ConfirmationModal ". We'll use this modal to confirm a user want's to **delete** the todo item. `ng generate component ConfirmationModal --spec=false`. (*the last argument tells Angular we don't want a .spec file created as well.*)
1. Copy/paste everything from inside `<ng-template #content let-modal>` [template at Bootstrap](https://ng-bootstrap.github.io/#/components/modal/examples) into your `ConfirmationModal` template.
1. Make sure you don't include the `<ng-template>` tag.
1. Edit the modal to be what you'd like when a user wants to delete a todo item. Work carefully to comment-out and delete lines slowly. Remember, you can always pull the code back from [ng-bootstrap](https://ng-bootstrap.github.io/#/components/modal/examples).
1. Use the bootstrapped `confirmation-modal` to create a pop up modal for **deleting** items from the todo list. The modal should ask user if they are sure they want to **delete** the item when they click the **delete** button.

1. You might try something like this in your `confirmation-modal.component.html` template file:
    ```html
      <div class="form-group">
        <!-- You will want to change this label later on but for now it can stay as-is -->
        <label for="dateOfBirth">Are you sure you want to delete this item?</label>
        <div class="input-group">
          <div class="input-group-append">
              <button type="button" class="btn btn-danger btn-sm">Yes, delete</button>
          </div>
        </div>
      </div>
      <!-- ...... -->
      <!-- more code is here -->
      <!-- ...... -->
    ```
1. Give the ConfirmationModal the ability to control itself with a property `modalInstance`
1. When the yes button is clicked, close the modal and send a result of "yes". `this.modalInstance.close("yes")`
1. Code `todo.component.ts`
    1. Import `NgbModal` and use dependency injection on it.
    1. Make `deleteTodo` an async method.
    1. Open the modal when `deleteTodo is called`
    1. Assign the `NgbModalRef` to  `modalInstance`
    1. Get the result from the modal with `await`
    1. Only delete the todo if the user confirms that is what they want.
1. At this point you should be able to still add todo items, and delete them through the modal window. If not, you'll need to step through your program and see what's going on. **THIS IS PROGRAMMING** You have to figure out how things are wired together, throw breadcrumbs (*console.logs*) when you don't know, and comment out sections of code until you, **YOU**, internalize and understand how the app works. Get used to this!
1. Since you've got your app up and going with adding and deleting, let's get those update functions working. Follow the video below and get your double-clicking and updating functions going.

******

### Follow-up Video

[Passing Data From Your Modal](https://player.vimeo.com/video/364364863)

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/nbFmHD4T04k/0.jpg)](https://youtu.be/nbFmHD4T04k?t=1345)



 
