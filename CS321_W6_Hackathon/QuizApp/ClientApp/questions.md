Which of the following is a correct example of an interface in C#?

```csharp
public int IToDoRepository
{
    ToDo Add(ToDo todo);
    void Remove(ToDo todo);
}
```

```csharp
public interface IToDoRepository
{
    ToDo Add(ToDo todo);
    void Remove(ToDo todo);
}
```

```csharp
public interface IToDoRepository
{
    Add(ToDo todo);
    Remove(ToDo todo);
}
```

In ASP.NET Core, in which class and method do you register items for dependency injection?

> Startup.Configure()
> Program.Main()
> Startup.ConfigureServices()

How do you ensure that only authenticated and authorized users are able to access API routes?

> Add the [Authorize] attribute the controller
> In each controller action, check the user's credential
> The caller must pass username and password on the route

