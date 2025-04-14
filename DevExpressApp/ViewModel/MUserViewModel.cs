using System.ComponentModel;
using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]
    public class MUserViewModel
    {
        private readonly IUserService _userService;

        public BindingList<MUser> Users { get; }

        public MUserViewModel(IUserService userService)
        {
            _userService = userService;
            Users = new BindingList<MUser>();
        }

        public async Task LoadUserMaster()
        {
            try
            {
                PaginationResponse<MUser> result = await _userService.GetMUsersAsync(1, 14);
                Users.Clear();
                foreach (var user in result.Content.Data)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
            }
        }
    }
}
