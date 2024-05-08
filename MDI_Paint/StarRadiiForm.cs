using System;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class StarRadiiForm : Form
    {
        public int InnerRadii { get; set; }
        public int OuterRadii { get; set; }
        public StarRadiiForm()
        {
            InitializeComponent();
            InnerRadii = MyPaintMainForm.innerRadii;
            OuterRadii = MyPaintMainForm.outerRadii;

            textBox_InnerRadii.Text = InnerRadii.ToString();
            textBox_OuterRadii.Text = OuterRadii.ToString();
        }

        private void button_SaveRadii_Click(object sender, EventArgs e)
        {
            if (InnerRadii != 0 && OuterRadii != 0)
            {
                MyPaintMainForm.innerRadii = InnerRadii;
                MyPaintMainForm.outerRadii = OuterRadii;
                this.Close();
            }
        }

        private void button_CancelRadii_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_InnerRadii_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_InnerRadii_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int radios = InnerRadii;
                if (CheckRadiiValue(textBox_InnerRadii, ref radios))
                    textBox_InnerRadii.Text = InnerRadii.ToString();
                InnerRadii = radios;
                e.Handled = true;
            }
        }

        private void textBox_OuterRadii_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_OuterRadii_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int radios = OuterRadii;
                if (CheckRadiiValue(textBox_OuterRadii, ref radios))
                    textBox_OuterRadii.Text = OuterRadii.ToString();
                OuterRadii = radios;

                e.Handled = true;
            }
        }

        private bool CheckRadiiValue(TextBox textBox, ref int radius)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"Пожалуйста, введите значение радиуса для {textBox.Tag}.");
                textBox.Focus();
                return false;
            }

            radius = int.Parse(textBox.Text);
            return true;
        }

        private void TextBox_Leave(TextBox textBox, ref int radius)
        {
            if (CheckRadiiValue(textBox, ref radius))
                textBox.Text = radius.ToString();
        }

        private void textBox_OuterRadii_Leave(object sender, EventArgs e)
        {
            int radios = OuterRadii;
            TextBox_Leave(textBox_OuterRadii, ref radios);
            OuterRadii = radios;
        }

        private void textBox_InnerRadii_Leave(object sender, EventArgs e)
        {
            int radios = InnerRadii;
            TextBox_Leave(textBox_InnerRadii, ref radios);
            InnerRadii = radios;
        }
    }
}
