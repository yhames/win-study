using DevExpressApp.View;

namespace DevExpressApp
{
    public partial class MainView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void accordionControlUsers_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(UserView.Instance))
            {
                container.Controls.Add(UserView.Instance);
                UserView.Instance.Dock = DockStyle.Fill;
            }
            UserView.Instance.BringToFront();
        }

        private void accordionControlPosts_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(PostView.Instance))
            {
                container.Controls.Add(PostView.Instance);
                PostView.Instance.Dock = DockStyle.Fill;
            }
            PostView.Instance.BringToFront();
        }
    }
}
