﻿using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]
    public class DPostViewModel(IPostService postService)
    {
        public string PostId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public async Task LoadData()
        {
            try
            {
                DPost result = await postService.GetDPostsAsync("postId");
                PostId = result.PostId.ToString();
                Content = result.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading post details: {ex.Message}");
            }
        }
    }
}
