﻿namespace DevExpressApp.View
{
    partial class PostView
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            gridControlPost = new DevExpress.XtraGrid.GridControl();
            gridViewPost = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlPost = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlPost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlPost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContext).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(layoutControl1);
            layoutControl.Controls.Add(gridControlPost);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new Point(0, 0);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1270, 308, 650, 400);
            layoutControl.Root = Root;
            layoutControl.Size = new Size(1000, 600);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(memoEdit1);
            layoutControl1.Controls.Add(textEdit1);
            layoutControl1.Location = new Point(312, 12);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1111, 244, 650, 400);
            layoutControl1.Root = layoutControlGroup1;
            layoutControl1.Size = new Size(676, 576);
            layoutControl1.TabIndex = 5;
            layoutControl1.Text = "layoutControl1";
            // 
            // memoEdit1
            // 
            memoEdit1.Location = new Point(12, 100);
            memoEdit1.Name = "memoEdit1";
            memoEdit1.Size = new Size(652, 464);
            memoEdit1.StyleController = layoutControl1;
            memoEdit1.TabIndex = 4;
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(12, 38);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(652, 20);
            textEdit1.StyleController = layoutControl1;
            textEdit1.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, layoutControlItem3, emptySpaceItem1, emptySpaceItem2, simpleSeparator1 });
            layoutControlGroup1.Name = "Root";
            layoutControlGroup1.Size = new Size(676, 576);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = textEdit1;
            layoutControlItem2.CustomizationFormText = "layoutControlItemPostId";
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(656, 50);
            layoutControlItem2.Text = "PostId";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new Size(69, 14);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = memoEdit1;
            layoutControlItem3.CustomizationFormText = "layoutControlItemPostContent";
            layoutControlItem3.Location = new Point(0, 71);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(656, 485);
            layoutControlItem3.Text = "PostContent";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem3.TextSize = new Size(69, 14);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 50);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(656, 10);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 61);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(656, 10);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new Point(0, 60);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new Size(656, 1);
            // 
            // gridControlPost
            // 
            gridControlPost.Location = new Point(12, 12);
            gridControlPost.MainView = gridViewPost;
            gridControlPost.Name = "gridControlPost";
            gridControlPost.Size = new Size(296, 576);
            gridControlPost.TabIndex = 4;
            gridControlPost.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewPost });
            // 
            // gridViewPost
            // 
            gridViewPost.GridControl = gridControlPost;
            gridViewPost.Name = "gridViewPost";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlPost, layoutControlItem1 });
            Root.Name = "Root";
            Root.Size = new Size(1000, 600);
            Root.TextVisible = false;
            // 
            // layoutControlPost
            // 
            layoutControlPost.Control = gridControlPost;
            layoutControlPost.Location = new Point(0, 0);
            layoutControlPost.Name = "layoutControlPost";
            layoutControlPost.Size = new Size(300, 580);
            layoutControlPost.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = layoutControl1;
            layoutControlItem1.Location = new Point(300, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(680, 580);
            layoutControlItem1.TextVisible = false;
            // 
            // mvvmContext
            // 
            mvvmContext.ContainerControl = this;
            // 
            // PostView
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl);
            Name = "PostView";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlPost).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPost).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlPost).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContext).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControlPost;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPost;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPost;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
    }
}
