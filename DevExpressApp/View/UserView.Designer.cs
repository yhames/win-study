namespace DevExpressApp.View
{
    partial class UserView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            gridControlDUser = new DevExpress.XtraGrid.GridControl();
            gridViewDUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControlMUser = new DevExpress.XtraGrid.GridControl();
            gridViewMUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlMUser = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlDUser = new DevExpress.XtraLayout.LayoutControlItem();
            mvvmContextMUser = new DevExpress.Utils.MVVM.MVVMContext(components);
            mvvmContextDUser = new DevExpress.Utils.MVVM.MVVMContext(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlDUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewDUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlMUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlDUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContextMUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContextDUser).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(gridControlDUser);
            layoutControl.Controls.Add(gridControlMUser);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new Point(0, 0);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1270, 336, 650, 400);
            layoutControl.Root = Root;
            layoutControl.Size = new Size(1000, 600);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // gridControlDUser
            // 
            gridControlDUser.Location = new Point(312, 12);
            gridControlDUser.MainView = gridViewDUser;
            gridControlDUser.Name = "gridControlDUser";
            gridControlDUser.Size = new Size(676, 576);
            gridControlDUser.TabIndex = 5;
            gridControlDUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewDUser });
            // 
            // gridViewDUser
            // 
            gridViewDUser.GridControl = gridControlDUser;
            gridViewDUser.Name = "gridViewDUser";
            // 
            // gridControlMUser
            // 
            gridControlMUser.Location = new Point(12, 12);
            gridControlMUser.MainView = gridViewMUser;
            gridControlMUser.Name = "gridControlMUser";
            gridControlMUser.Size = new Size(296, 576);
            gridControlMUser.TabIndex = 4;
            gridControlMUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewMUser });
            // 
            // gridViewMUser
            // 
            gridViewMUser.GridControl = gridControlMUser;
            gridViewMUser.Name = "gridViewMUser";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlMUser, layoutControlDUser });
            Root.Name = "Root";
            Root.Size = new Size(1000, 600);
            Root.TextVisible = false;
            // 
            // layoutControlMUser
            // 
            layoutControlMUser.Control = gridControlMUser;
            layoutControlMUser.Location = new Point(0, 0);
            layoutControlMUser.Name = "layoutControlMUser";
            layoutControlMUser.Size = new Size(300, 580);
            layoutControlMUser.TextVisible = false;
            // 
            // layoutControlDUser
            // 
            layoutControlDUser.Control = gridControlDUser;
            layoutControlDUser.Location = new Point(300, 0);
            layoutControlDUser.Name = "layoutControlDUser";
            layoutControlDUser.Size = new Size(680, 580);
            layoutControlDUser.TextVisible = false;
            // 
            // mvvmContextMUser
            // 
            mvvmContextMUser.ContainerControl = this;
            // 
            // mvvmContextDUser
            // 
            mvvmContextDUser.ContainerControl = this;
            // 
            // UserView
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl);
            Name = "UserView";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlDUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewDUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlMUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlDUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContextMUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContextDUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControlDUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDUser;
        private DevExpress.XtraGrid.GridControl gridControlMUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlMUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDUser;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextMUser;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextDUser;
    }
}
