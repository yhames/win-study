using DevExpress.XtraGrid.Views.Grid;
using DevExpressApp.ViewModel;

namespace DevExpressApp.View
{
    public partial class PostView : DevExpress.XtraEditors.XtraUserControl
    {
        private static PostView? _instance;

        public static PostView Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PostView();
                }
                return _instance;
            }
        }
        public PostView()
        {
            InitializeComponent();
            if (!mvvmContextMPost.IsDesignMode)
            {
                InitializeMvvmContextMPost();
            }
            if (!mvvmContextDPost.IsDesignMode)
            {
                InitializeMvvmContextDPost();
            }
        }

        void InitializeMvvmContextMPost()
        {
            var mPostViewModel = mvvmContextMPost.OfType<MPostViewModel>();
            mPostViewModel.WithEvent(this, nameof(HandleCreated))
                .EventToCommand(x => x.LoadData);
            mPostViewModel.SetBinding(gridControlPost, gControl => gControl.DataSource, x => x.Posts);

        }

        public int CurrentPostId { get; set; }

        void InitializeMvvmContextDPost()
        {
            CurrentPostId = 10;
            var dPostViewModel = mvvmContextDPost.OfType<DPostViewModel>();
            dPostViewModel.WithEvent<RowCellClickEventArgs>(this, nameof(HandleCreated))
                .EventToCommand(x => x.LoadData, (RowCellClickEventArgs args) => CurrentPostId);
            dPostViewModel.SetBinding(textEditPostId, textEdit => textEdit.Text, x => x.PostId);
            dPostViewModel.SetBinding(memoEditPostContent, memoEdit => memoEdit.Text, x => x.Content);
        }
    }
}
