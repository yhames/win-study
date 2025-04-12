using System.ComponentModel;
using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]

    public class DUserViewModel
    {
        private readonly IUserService _userService;
        public BindingList<DUser> Users { get; }

        public DUserViewModel(IUserService userService)
        {
            _userService = userService;
            Users = new BindingList<DUser>();
            InitDataLoading();
        }

        private async void InitDataLoading()
        {
            try
            {
                PaginationResponse<DUser> result = await _userService.GetDUsersAsync(1, 14);
                Users.Clear();
                foreach (var user in result.Content.Data)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user details: {ex.Message}");
            }
        }
    }
}
