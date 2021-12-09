using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace ToDos.MinimalAPI;

public static class ToDoRequests   // klasa odpowiedzialna za endpointy
{
    public static WebApplication RegisterEndpoints(this WebApplication app) // builder.Build();
    {
        //app.MapGet("/todos", (IToDoService service) => service.GetAll());
        //app.MapGet("/todos/{id}", ([FromServices]IToDoService service, [FromRoute]Guid id) => service.GetById(id));
        //app.MapPost("/todos", (IToDoService service, ToDo toDo) => service.Create(toDo)); // może być z [FromBody]
        //app.MapPut("/todos/{id}", (IToDoService service, Guid id, ToDo toDo) => service.Update(toDo));
        //app.MapDelete("/todos/{id}", (IToDoService service, Guid id) => service.Delete(id));

        app.MapGet("/todos", ToDoRequests.GetAll)
            .Produces<List<ToDo>>()    // domyślny kod - 200, informacja np do swaggera co zwraca bo IResult nie przyjmuje typów generycznych
            .WithTags("To Dos")
            .RequireAuthorization();    // można dodać konkretne polityki poprzez parametry

        app.MapGet("/todos/{id}", ToDoRequests.GetById)
            .Produces<ToDo>()
            .Produces(404)  // .Produces(StatusCodes.Status404NotFound);
            .WithTags("To Dos");

        app.MapPost("/todos", ToDoRequests.Create)
            .Produces<ToDo>(201)    // .Produces(StatusCodes.Status201Created);
            .Accepts<ToDo>("application/json")  // application/json żeby powiedzieć metodzie Accepts jaki format danych przyjmuje (tj. json)
            .WithTags("To Dos")
            .WithValidator<ToDo>();

        app.MapPut("/todos/{id}", ToDoRequests.Update)
            .Produces<ToDo>(204)    // .Produces(StatusCodes.Status204NoContent);
            .Produces(404)
            .Accepts<ToDo>("application/json")
            .WithTags("To Dos")
            .WithValidator<ToDo>();

        app.MapDelete("/todos/{id}", ToDoRequests.Delete)
            .Produces(204)
            .Produces(404)
            .WithTags("To Dos")
            .ExcludeFromDescription();


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

    [Authorize]
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

