using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Kakao.ViewModels
{
    [ObservableObject]
    public partial class LoginViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> _emails;

        public LoginViewModel()
        {
            Emails =
            [
                "test1@test1.com",
                "test2@test2.com"
            ];
        }
    }
}