using DataAccess.Data;
using System.Reflection.Metadata.Ecma335;

namespace MinAPIDemo;

public static class API
{
    public static void ConfigureApi(this WebApplication app)
    {
        //All of my endpoint mappings
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try 
        {
            var users = await data.GetUser(id);
            if(users == null) return Results.NotFound();
            return Results.Ok(users);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IUserData data, UserModel user)
    {
        try
        {
            await data.UpdateUser(user.Id, user.FirstName, user.LastName);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
}
