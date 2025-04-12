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
            if (!mvvmContext.IsDesignMode)
            {
                InitializeBindings();
            }
        }

        void InitializeBindings()
        {
            var mPostViewModel = mvvmContext.OfType<MPostViewModel>();
            mPostViewModel.SetBinding(gridControlPost, gControl => gControl.DataSource, x => x.Posts);
        }
    }
}
