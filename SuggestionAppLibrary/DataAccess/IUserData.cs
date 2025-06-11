namespace SuggestionAppLibrary.DataAccess;

public interface IUserData
{
    Task CreateUser(UserModel user);
    Task<UserModel> GetUserAsync(string id);
    Task<UserModel> GetUserFromAuthentication(string objectId);
    Task<List<UserModel>> GetUserListAsync();
    Task UpdateUser(UserModel user);
}