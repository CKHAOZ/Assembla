namespace UI_Support
{
    partial class EnrollmentForm
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
			System.Windows.Forms.Button CloseButton;
			this.EnrollmentControl = new DPFP.Gui.Enrollment.EnrollmentControl();
			CloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CloseButton
			// 
			CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			CloseButton.Location = new System.Drawing.Point(394, 327);
			CloseButton.Name = "CloseButton";
			CloseButton.Size = new System.Drawing.Size(75, 23);
			CloseButton.TabIndex = 1;
			CloseButton.Text = "Close";
			CloseButton.UseVisualStyleBackColor = true;
			// 
			// EnrollmentControl
			// 
			this.EnrollmentControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.EnrollmentControl.EnrolledFingerMask = 0;
			this.EnrollmentControl.Location = new System.Drawing.Point(1, -3);
			this.EnrollmentControl.MaxEnrollFingerCount = 10;
			this.EnrollmentControl.Name = "EnrollmentControl";
			this.EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
			this.EnrollmentControl.Size = new System.Drawing.Size(492, 314);
			this.EnrollmentControl.TabIndex = 2;
			this.EnrollmentControl.OnDelete += new DPFP.Gui.Enrollment.EnrollmentControl._OnDelete(this.OnDelete);
			this.EnrollmentControl.OnEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnEnroll(this.OnEnroll);
			// 
			// EnrollmentForm
			// 
			this.AcceptButton = CloseButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = CloseButton;
			this.ClientSize = new System.Drawing.Size(495, 362);
			this.Controls.Add(this.EnrollmentControl);
			this.Controls.Add(CloseButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EnrollmentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fingerprint Enrollment";
			this.ResumeLayout(false);

        }

        #endregion

		private DPFP.Gui.Enrollment.EnrollmentControl EnrollmentControl;
    }
}