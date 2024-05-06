namespace MDI_Paint
{
    partial class StarRadiiForm
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
            this.label_InnerRadii = new System.Windows.Forms.Label();
            this.label_OuterRadii = new System.Windows.Forms.Label();
            this.textBox_InnerRadii = new System.Windows.Forms.TextBox();
            this.textBox_OuterRadii = new System.Windows.Forms.TextBox();
            this.button_SaveRadii = new System.Windows.Forms.Button();
            this.button_CancelRadii = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_InnerRadii
            // 
            this.label_InnerRadii.AutoSize = true;
            this.label_InnerRadii.Location = new System.Drawing.Point(24, 8);
            this.label_InnerRadii.Name = "label_InnerRadii";
            this.label_InnerRadii.Size = new System.Drawing.Size(87, 16);
            this.label_InnerRadii.TabIndex = 0;
            this.label_InnerRadii.Text = "Внутренний";
            // 
            // label_OuterRadii
            // 
            this.label_OuterRadii.AutoSize = true;
            this.label_OuterRadii.Location = new System.Drawing.Point(142, 8);
            this.label_OuterRadii.Name = "label_OuterRadii";
            this.label_OuterRadii.Size = new System.Drawing.Size(65, 16);
            this.label_OuterRadii.TabIndex = 1;
            this.label_OuterRadii.Text = "Внешний";
            // 
            // textBox_InnerRadii
            // 
            this.textBox_InnerRadii.Location = new System.Drawing.Point(27, 38);
            this.textBox_InnerRadii.Name = "textBox_InnerRadii";
            this.textBox_InnerRadii.Size = new System.Drawing.Size(100, 22);
            this.textBox_InnerRadii.TabIndex = 2;
            this.textBox_InnerRadii.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_InnerRadii_KeyDown);
            this.textBox_InnerRadii.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_InnerRadii_KeyPress);
            this.textBox_InnerRadii.Leave += new System.EventHandler(this.textBox_InnerRadii_Leave);
            // 
            // textBox_OuterRadii
            // 
            this.textBox_OuterRadii.Location = new System.Drawing.Point(145, 38);
            this.textBox_OuterRadii.Name = "textBox_OuterRadii";
            this.textBox_OuterRadii.Size = new System.Drawing.Size(100, 22);
            this.textBox_OuterRadii.TabIndex = 3;
            this.textBox_OuterRadii.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_OuterRadii_KeyDown);
            this.textBox_OuterRadii.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_OuterRadii_KeyPress);
            this.textBox_OuterRadii.Leave += new System.EventHandler(this.textBox_OuterRadii_Leave);
            // 
            // button_SaveRadii
            // 
            this.button_SaveRadii.Location = new System.Drawing.Point(27, 77);
            this.button_SaveRadii.Name = "button_SaveRadii";
            this.button_SaveRadii.Size = new System.Drawing.Size(100, 23);
            this.button_SaveRadii.TabIndex = 4;
            this.button_SaveRadii.Text = "Сохранить";
            this.button_SaveRadii.UseVisualStyleBackColor = true;
            this.button_SaveRadii.Click += new System.EventHandler(this.button_SaveRadii_Click);
            // 
            // button_CancelRadii
            // 
            this.button_CancelRadii.Location = new System.Drawing.Point(145, 77);
            this.button_CancelRadii.Name = "button_CancelRadii";
            this.button_CancelRadii.Size = new System.Drawing.Size(100, 23);
            this.button_CancelRadii.TabIndex = 5;
            this.button_CancelRadii.Text = "Отменить";
            this.button_CancelRadii.UseVisualStyleBackColor = true;
            this.button_CancelRadii.Click += new System.EventHandler(this.button_CancelRadii_Click);
            // 
            // StarRadiiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 115);
            this.Controls.Add(this.button_CancelRadii);
            this.Controls.Add(this.button_SaveRadii);
            this.Controls.Add(this.textBox_OuterRadii);
            this.Controls.Add(this.textBox_InnerRadii);
            this.Controls.Add(this.label_OuterRadii);
            this.Controls.Add(this.label_InnerRadii);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarRadiiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Радиусы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_InnerRadii;
        private System.Windows.Forms.Label label_OuterRadii;
        private System.Windows.Forms.TextBox textBox_InnerRadii;
        private System.Windows.Forms.TextBox textBox_OuterRadii;
        private System.Windows.Forms.Button button_SaveRadii;
        private System.Windows.Forms.Button button_CancelRadii;
    }
}