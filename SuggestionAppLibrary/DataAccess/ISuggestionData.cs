
namespace SuggestionAppLibrary.DataAccess
{
    public interface ISuggestionData
    {
        Task CreateSuggestion(SuggestionModel suggestion);
        Task<List<SuggestionModel>> GetAllApprovedSuggestions();
        Task<List<SuggestionModel>> GetAllSuggestionList();
        Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval();
        Task<SuggestionModel> GetSuggestion(string id);
        Task<List<SuggestionModel>> GetUsersSuggestionList(string userId);
        Task UpdateSuggestion(SuggestionModel suggestion);
        Task UpvoteSuggestion(string suggestionId, string userId);
    }
}