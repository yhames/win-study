using System.ComponentModel;
using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]
    public class MPostViewModel
    {
        private readonly IPostService _postService;

        public BindingList<MPost> Posts { get; }

        public MPostViewModel(IPostService postService)
        {
            _postService = postService;
            Posts = new BindingList<MPost>();
        }

        public async Task LoadData()
        {
            try
            {
                PaginationResponse<MPost> result = await _postService.GetPostsAsync(1, 14);
                Posts.Clear();
                foreach (var post in result.Content.Data)
                {
                    Posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading posts: {ex.Message}");
            }
        }
    }
}
