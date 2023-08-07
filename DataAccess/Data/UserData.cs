using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISQLDataAccess _db;

    public UserData(ISQLDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            "dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }
    public async Task InsertUser(UserModel user)
    {
        await _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });
    }

    public async Task DeleteUser(int id)
    {
        await _db.SaveData("dbo.spUser_Delete", new { Id = id });
    }
    public async Task UpdateUser(int id, string FirstName, string LastName)
    {
        await _db.SaveData("dbo.spUser_Update", new { Id = id, NewFirstName = FirstName, NewLastName = LastName });
    }
}
