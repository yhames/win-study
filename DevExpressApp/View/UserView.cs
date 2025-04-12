using DevExpressApp.ViewModel;

namespace DevExpressApp.View
{
    public partial class UserView : DevExpress.XtraEditors.XtraUserControl
    {
        private static UserView? _instance;

        public static UserView Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserView();
                }
                return _instance;
            }
        }

        public UserView()
        {
            InitializeComponent();
            if (!mvvmContextMUser.IsDesignMode)
            {
                InitializeMvvmContextMUser();
            }
            if (!mvvmContextDUser.IsDesignMode)
            {
                InitializeMvvmContextDUser();
            }
        }

        void InitializeMvvmContextMUser()
        {
            var mUserViewModel = mvvmContextMUser.OfType<MUserViewModel>();
            //mUserViewModel.WithEvent(this, nameof(HandleCreated))
            //    .EventToCommand(x => x.OnCreate);
            //mUserViewModel.WithEvent(this, nameof(HandleDestroyed))
            //    .EventToCommand(x => x.OnDestroy);
            mUserViewModel.SetBinding(gridControlMUser, gControl => gControl.DataSource, x => x.Users);

        }

        private void InitializeMvvmContextDUser()
        {
            var dUserViewModel = mvvmContextDUser.OfType<DUserViewModel>();
            //dUserViewModel.WithEvent(this, nameof(HandleCreated))
            //    .EventToCommand(x => x.OnCreate);
            //dUserViewModel.WithEvent(this, nameof(HandleDestroyed))
            //    .EventToCommand(x => x.OnDestroy);
            dUserViewModel.SetBinding(gridControlDUser, gControl => gControl.DataSource, x => x.Users);

        }
    }
}
