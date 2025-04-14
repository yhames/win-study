using DevExpress.XtraGrid.Views.Base;
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
                InitializeMUserBinding();
            }
            if (!mvvmContextDUser.IsDesignMode)
            {
                InitializeDUserBinding();
            }
        }

        void InitializeMUserBinding()
        {
            var mUserViewModel = mvvmContextMUser.OfType<MUserViewModel>();
            mUserViewModel.WithEvent(this, nameof(HandleCreated))
                .EventToCommand(x => x.LoadUserMaster);
            mUserViewModel.SetBinding(gridControlMUser, gControl => gControl.DataSource, x => x.Users);
        }

        void InitializeDUserBinding()
        {
            var dUserViewModel = mvvmContextDUser.OfType<DUserViewModel>();
            dUserViewModel.WithEvent<FocusedRowChangedEventArgs>(gridViewMUser, nameof(gridViewMUser.FocusedRowChanged))
                .EventToCommand(x => x.LoadUserDetail, e => e.FocusedRowHandle);
            dUserViewModel.SetBinding(textEditUserId, textEdit => textEdit.Text, x => x.UserId);
            dUserViewModel.SetBinding(textEditEmail, textEdit => textEdit.Text, x => x.Email);
            dUserViewModel.SetBinding(textEditAddress, textEdit => textEdit.Text, x => x.Address);
            dUserViewModel.SetBinding(textEditPhoneNumber, textEdit => textEdit.Text, x => x.PhoneNumber);
            dUserViewModel.SetBinding(textEditDateOfBirth, dateEdit => dateEdit.EditValue, x => x.DateOfBirth);
            dUserViewModel.SetBinding(textEditGender, dateEdit => dateEdit.EditValue, x => x.Gender);
            dUserViewModel.SetBinding(textEditOccupation, textEdit => textEdit.Text, x => x.Occupation);
            dUserViewModel.SetBinding(textEditNationality, textEdit => textEdit.Text, x => x.Nationality);
            dUserViewModel.SetBinding(pictureEditProfile, pictureEdit => pictureEdit.Image, x => x.Profile);
        }
    }
}
