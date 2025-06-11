namespace SuggestionAppUI.Pages
{
    public partial class SampleData
    {
        private bool categoriesCreated = false;
        private bool statusesCreated = false;

        private async Task GenerateSampleData()
        {
            UserModel user = new()
            {
                FirstName = "Tim",
                LastName = "Corey",
                EmailAddress = "tim@test.com",
                DisplayName = "Sample Tim Corey",
                ObjectIdentifier = "abc-123",
            };

            await userData.CreateUser(user);

            var foundUser = await userData.GetUserFromAuthentication("abc-123");
            var categories = await categoryData.GetAllCategoryList();
            var statuses = await statusData.GetAllStatusList();

            HashSet<string> votes = new();
            votes.Add("1");
            votes.Add("2");
            votes.Add("3");

            SuggestionModel suggestion = new()
            {
                Author = new BasicUserModel(foundUser),
                Category = categories[0],
                Suggestion = "Our First Suggestion",
                Description = "This is suggestion created by the sample data generation method."
            };

            await suggestionData.CreateSuggestion(suggestion);

            suggestion = new()
            {
                Author = new BasicUserModel(foundUser),
                Category = categories[1],
                Suggestion = "Our Second Suggestion",
                Description = "This is suggestion created by the sample data generation method.",
                SuggestionStatus = statuses[0],
                OwnerNotes = "This is the note for the status."
            };

            await suggestionData.CreateSuggestion(suggestion);

            suggestion = new()
            {
                Author = new BasicUserModel(foundUser),
                Category = categories[2],
                Suggestion = "Our Third Suggestion",
                Description = "This is suggestion created by the sample data generation method.",
                SuggestionStatus = statuses[1],
                OwnerNotes = "This is the note for the status."
            };

            await suggestionData.CreateSuggestion(suggestion);

            suggestion = new()
            {
                Author = new BasicUserModel(foundUser),
                Category = categories[3],
                Suggestion = "Our Fourth Suggestion",
                Description = "This is suggestion created by the sample data generation method.",
                SuggestionStatus = statuses[2],
                UserVotes = votes,
                OwnerNotes = "This is the note for the status."
            };

            await suggestionData.CreateSuggestion(suggestion);

            votes.Add("4");

            suggestion = new()
            {
                Author = new BasicUserModel(foundUser),
                Category = categories[4],
                Suggestion = "Our Fifth Suggestion",
                Description = "This is suggestion created by the sample data generation method.",
                SuggestionStatus = statuses[3],
                UserVotes = votes,
                OwnerNotes = "This is the note for the status."
            };

            await suggestionData.CreateSuggestion(suggestion);
        }

        private async Task CreateCategories()
        {
            var categories = await categoryData.GetAllCategoryList();

            if (categories?.Count > 0)
            {
                categoriesCreated = true;
                return;
            }

            CategoryModel cat = new()
            {
                CategoryName = "Courses",
                CategoryDescription = "Full paid courses."
            };

            await categoryData.CreateCategory(cat);

            cat = new()
            {
                CategoryName = "Dev Questions",
                CategoryDescription = "Advice on being a developer."
            };

            await categoryData.CreateCategory(cat);

            cat = new()
            {
                CategoryName = "In-Depth Tutorials",
                CategoryDescription = "A deep-dive video on how to use a topic."
            };

            await categoryData.CreateCategory(cat);

            cat = new()
            {
                CategoryName = "10-Minute Training",
                CategoryDescription = "A quick \"How do I use this?\" video."
            };

            await categoryData.CreateCategory(cat);

            cat = new()
            {
                CategoryName = "Other",
                CategoryDescription = "Not sure which category this fits in."
            };

            await categoryData.CreateCategory(cat);

            categoriesCreated = true;
        }

        private async Task CreateStatuses()
        {
            var statuses = await statusData.GetAllStatusList();

            if (statuses?.Count > 0)
            {
                statusesCreated = true;
                return;
            }

            StatusModel status = new()
            {
                StatusName = "Completed",
                StatusDescription = "The suggestion was accepted and the corresponding item was created."
            };

            await statusData.CreateStatus(status);

            status = new()
            {
                StatusName = "Watching",
                StatusDescription = "The suggestion is interesting. We are watching to see how much interest there is in fit."
            };

            await statusData.CreateStatus(status);

            status = new()
            {
                StatusName = "Upcoming",
                StatusDescription = "The suggestion was accepted and it will be released soon."
            };

            await statusData.CreateStatus(status);

            status = new()
            {
                StatusName = "Dismissed",
                StatusDescription = "The suggestion was not something that we are going to undertake."
            };

            await statusData.CreateStatus(status);

            statusesCreated = true;
        }
    }
}