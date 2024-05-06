using System;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class CanvasSizeForm : Form
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public DocumentForm Form { get; set; }
        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void button_SaveSize_Click(object sender, EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Form.ChangeCanvasSize(Width, Height);
                Form.Invalidate();
                this.Close();
            }
        }

        private void button_CancelSize_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Width_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckWidthValue())
                    Width = int.Parse(textBox_Width.Text);

                e.Handled = true;
            }
        }

        private void textBox_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Height_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckHeightValue())
                    Height = int.Parse(textBox_Height.Text);

                e.Handled = true;
            }
        }
        public bool CheckHeightValue()
        {
            label_Height.Text = "Высота:";
            if (textBox_Height.Text == "")
            {
                label_Height.Text += " (Введите высоту!)";
                return false;
            }
            return true;
        }
        public bool CheckWidthValue()
        {
            label_Width.Text = "Ширина:";
            if (textBox_Width.Text == "")
            {
                label_Width.Text += " (Введите ширину!)";
                return false;
            }
            return true;
        }

        private void textBox_Height_Leave(object sender, EventArgs e)
        {
            if (CheckHeightValue())
                Height = int.Parse(textBox_Height.Text);
        }

        private void textBox_Width_Leave(object sender, EventArgs e)
        {
            if (CheckWidthValue())
                Width = int.Parse(textBox_Width.Text);
        }

        private void CanvasSizeForm_Load(object sender, EventArgs e)
        {
            textBox_Width.Text = Form.Width.ToString();
            textBox_Height.Text = Form.Height.ToString();
        }
    }
}
