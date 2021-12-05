﻿namespace ToDos.MinimalAPI;

public static class ToDoRequests   // klasa odpowiedzialna za endpointy
{
    public static WebApplication RegisterEndpoints(this WebApplication app) // builder.Build();
    {
        //app.MapGet("/todos", (IToDoService service) => service.GetAll());
        app.MapGet("/todos", ToDoRequests.GetAll);

        //app.MapGet("/todos/{id}", ([FromServices]IToDoService service, [FromRoute]Guid id) => service.GetById(id));
        app.MapGet("/todos/{id}", ToDoRequests.GetById);

        //app.MapPost("/todos", (IToDoService service, ToDo toDo) => service.Create(toDo)); // może być z [FromBody]
        app.MapPost("/todos", ToDoRequests.Create);

        //app.MapPut("/todos/{id}", (IToDoService service, Guid id, ToDo toDo) => service.Update(toDo));
        app.MapPut("/todos/{id}", ToDoRequests.Update);

        //app.MapDelete("/todos/{id}", (IToDoService service, Guid id) => service.Delete(id));
        app.MapDelete("/todos/{id}", ToDoRequests.Delete);

        return app;
    }

    public static IResult GetAll(IToDoService service)
    {
        var todos = service.GetAll();
        return Results.Ok(todos);
    }

    public static IResult GetById(IToDoService service, Guid id)
    {
        var todo = service.GetById(id);
        if(todo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(todo);
    }

    public static IResult Create(IToDoService service, ToDo toDo)
    {
        service.Create(toDo);
        return Results.Created($"/todos/{toDo.Id}", toDo);
    }

    public static IResult Update(IToDoService service, Guid id, ToDo toDo)
    {
        var todo = service.GetById(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        service.Update(toDo);
        return Results.NoContent();
    }

    public static IResult Delete(IToDoService service, Guid id)
    {
        var todo = service.GetById(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        service.Delete(id);
        return Results.NoContent();
    }
}

