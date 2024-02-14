using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace paint_new
{
    public partial class StarRadiosForm : Form
    {
        private static int Width { get; set; }
        private static int Height { get; set; }
        public StarRadiosForm()
        {
            InitializeComponent();
            textBox_Width.Text = MyPaintMainForm.innerRadius.ToString();
            textBox_Height.Text = MyPaintMainForm.outerRadius.ToString();
        }

        private void button_SaveRadios_Click(object sender, EventArgs e)
        {
            if (Width != 0 && Height != 0)
            {
                MyPaintMainForm.innerRadius = Width;
                MyPaintMainForm.outerRadius = Height;
                this.Close();
            }
        }

        private void button_CancelRadios_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_Inner_Radios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Inner_Radios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckInnerRadiosValue())
                    Width = int.Parse(textBox_Width.Text);

                e.Handled = true;
            }
        }

        private void textBox_Outer_Radios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Outer_Radios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckOuterRadiosValue())
                    Height = int.Parse(textBox_Height.Text);

                e.Handled = true;
            }
        }
        public bool CheckOuterRadiosValue()
        {
            label_Height.Text = "Внешний радиус:";
            if (textBox_Height.Text == "")
            {
                label_Height.Text += " (Введите внешний радиус!)";
                return false;
            }
            return true;
        }
        public bool CheckInnerRadiosValue()
        {
            label_Width.Text = "Внутренний радиус:";
            if (textBox_Width.Text == "")
            {
                label_Width.Text += " (Введите внутренний радиус!)";
                return false;
            }
            return true;
        }

        private void textBox_Outer_Radios_Leave(object sender, EventArgs e)
        {
            if (CheckOuterRadiosValue())
                Height = int.Parse(textBox_Height.Text);
        }

        private void textBox_Inner_Radios_Leave(object sender, EventArgs e)
        {
            if (CheckInnerRadiosValue())
                Width = int.Parse(textBox_Width.Text);
        }
    }
}
