using System.ComponentModel;
using System.ComponentModel.Design;
using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]
    public class DPostViewModel
    {
        private readonly IPostService _postService;
        public DPost PostDetail { get; set; }

        public DPostViewModel(IPostService postService)
        {
            _postService = postService;
            PostDetail = new DPost();
            InitDataLoading();
        }

        private async void InitDataLoading()
        {
            try
            {
                DPost result = await _postService.GetDPostsAsync("postId");
                PostDetail = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading post details: {ex.Message}");
            }
        }
    }
}
