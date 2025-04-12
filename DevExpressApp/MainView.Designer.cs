namespace DevExpressApp
{
    partial class MainView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            accordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlMainMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlUsers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlPosts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            ((System.ComponentModel.ISupportInitialize)accordionControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager).BeginInit();
            SuspendLayout();
            // 
            // container
            // 
            container.Dock = DockStyle.Fill;
            container.Location = new Point(260, 31);
            container.Name = "container";
            container.Size = new Size(762, 608);
            container.TabIndex = 0;
            // 
            // accordionControl
            // 
            accordionControl.Dock = DockStyle.Left;
            accordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlMainMenu });
            accordionControl.Location = new Point(0, 31);
            accordionControl.Name = "accordionControl";
            accordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl.Size = new Size(260, 608);
            accordionControl.TabIndex = 1;
            accordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlMainMenu
            // 
            accordionControlMainMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlUsers, accordionControlPosts });
            accordionControlMainMenu.Expanded = true;
            accordionControlMainMenu.Name = "accordionControlMainMenu";
            accordionControlMainMenu.Text = "MainMenu";
            // 
            // accordionControlUsers
            // 
            accordionControlUsers.Name = "accordionControlUsers";
            accordionControlUsers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlUsers.Text = "Users";
            accordionControlUsers.Click += accordionControlUsers_Click;
            // 
            // accordionControlPosts
            // 
            accordionControlPosts.Name = "accordionControlPosts";
            accordionControlPosts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlPosts.Text = "Posts";
            accordionControlPosts.Click += accordionControlPosts_Click;
            // 
            // fluentDesignFormControl
            // 
            fluentDesignFormControl.FluentDesignForm = this;
            fluentDesignFormControl.Location = new Point(0, 0);
            fluentDesignFormControl.Manager = fluentFormDefaultManager;
            fluentDesignFormControl.Name = "fluentDesignFormControl";
            fluentDesignFormControl.Size = new Size(1022, 31);
            fluentDesignFormControl.TabIndex = 2;
            fluentDesignFormControl.TabStop = false;
            // 
            // fluentFormDefaultManager
            // 
            fluentFormDefaultManager.Form = this;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 639);
            ControlContainer = container;
            Controls.Add(container);
            Controls.Add(accordionControl);
            Controls.Add(fluentDesignFormControl);
            FluentDesignFormControl = fluentDesignFormControl;
            Name = "MainView";
            NavigationControl = accordionControl;
            Text = "DevExpress Tutorial App";
            ((System.ComponentModel.ISupportInitialize)accordionControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlMainMenu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlPosts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlUsers;
    }
}