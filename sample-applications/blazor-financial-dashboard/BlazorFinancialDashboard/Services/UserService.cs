using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services
{
    public class UserService
    {
        private List<User> Data { get; set; } = new();

        private User DefaultUser { get; set; }= new()
        {
            Id = 1,
            FirstName = "Maria",
            LastName = "Johnson",
            BirthDate = DateTime.Today.AddYears(-28),
            Email = "maria.johnson@email.com",
            Address = "124 James Dean St.",
            PostalCode = "1000",
            Country = "USA",
            Tag = "@Mhjd.J09i"
        };

        public async Task<User> Read(int userId)
        {
            await Task.CompletedTask;

            PopulateDummyData();

            return Data.First(x => x.Id == userId);
        }

        public async Task<bool> Update(User updatedUser)
        {
            await Task.CompletedTask;

            DefaultUser = updatedUser;

            return true;
        }

        private void PopulateDummyData()
        {
            Data = new List<User>()
            {
                new User()
                {
                    Address = DefaultUser.Address,
                    BirthDate = DefaultUser.BirthDate,
                    Country = DefaultUser.Country,
                    Email = DefaultUser.Email,
                    FirstName = DefaultUser.FirstName,
                    Id = DefaultUser.Id,
                    LastName = DefaultUser.LastName,
                    PostalCode = DefaultUser.PostalCode,
                    Tag = DefaultUser.Tag
                }
            };
        }
    }
}
