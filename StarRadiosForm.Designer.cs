namespace paint_new
{
    partial class StarRadiosForm
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
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Height = new System.Windows.Forms.Label();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.button_SaveSize = new System.Windows.Forms.Button();
            this.button_CancelSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(24, 8);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(87, 16);
            this.label_Width.TabIndex = 0;
            this.label_Width.Text = "Внутренний";
            // 
            // label_Height
            // 
            this.label_Height.AutoSize = true;
            this.label_Height.Location = new System.Drawing.Point(142, 8);
            this.label_Height.Name = "label_Height";
            this.label_Height.Size = new System.Drawing.Size(65, 16);
            this.label_Height.TabIndex = 1;
            this.label_Height.Text = "Внешний";
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(27, 38);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(100, 22);
            this.textBox_Width.TabIndex = 2;
            this.textBox_Width.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Inner_Radios_KeyDown);
            this.textBox_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Inner_Radios_KeyPress);
            this.textBox_Width.Leave += new System.EventHandler(this.textBox_Inner_Radios_Leave);
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(145, 38);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(100, 22);
            this.textBox_Height.TabIndex = 3;
            this.textBox_Height.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Outer_Radios_KeyDown);
            this.textBox_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Outer_Radios_KeyPress);
            this.textBox_Height.Leave += new System.EventHandler(this.textBox_Outer_Radios_Leave);
            // 
            // button_SaveSize
            // 
            this.button_SaveSize.Location = new System.Drawing.Point(27, 77);
            this.button_SaveSize.Name = "button_SaveSize";
            this.button_SaveSize.Size = new System.Drawing.Size(100, 23);
            this.button_SaveSize.TabIndex = 4;
            this.button_SaveSize.Text = "Сохранить";
            this.button_SaveSize.UseVisualStyleBackColor = true;
            this.button_SaveSize.Click += new System.EventHandler(this.button_SaveRadios_Click);
            // 
            // button_CancelSize
            // 
            this.button_CancelSize.Location = new System.Drawing.Point(145, 77);
            this.button_CancelSize.Name = "button_CancelSize";
            this.button_CancelSize.Size = new System.Drawing.Size(100, 23);
            this.button_CancelSize.TabIndex = 5;
            this.button_CancelSize.Text = "Отменить";
            this.button_CancelSize.UseVisualStyleBackColor = true;
            this.button_CancelSize.Click += new System.EventHandler(this.button_CancelRadios_Click);
            // 
            // StarRadiosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 115);
            this.Controls.Add(this.button_CancelSize);
            this.Controls.Add(this.button_SaveSize);
            this.Controls.Add(this.textBox_Height);
            this.Controls.Add(this.textBox_Width);
            this.Controls.Add(this.label_Height);
            this.Controls.Add(this.label_Width);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarRadiosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Радиусы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Label label_Height;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.Button button_SaveSize;
        private System.Windows.Forms.Button button_CancelSize;
    }
}