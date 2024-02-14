using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace paint_new
{
    public partial class DocumentForm : Form
    {
        public int width;
        public int height;
        private int x, y;
        private PictureBox pictureBox;
        public string fileName = "";
        public ImageFormat imageFormat = ImageFormat.Bmp;
        public DocumentForm()
        {
            InitializeComponent();
            width = 300;
            height = 200;
            pictureBox = CreatePictureBox(width, height);
        }

        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(pictureBox.Image);
                Pen pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width);
                switch (MyPaintMainForm.Tool)
                {
                    case Tools.pen:
                        g.CompositingMode = CompositingMode.SourceOver;

                        pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width * 2);

                        g.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                        g.FillEllipse(pen.Brush, e.X - MyPaintMainForm.Width, e.Y - MyPaintMainForm.Width, MyPaintMainForm.Width * 2, MyPaintMainForm.Width * 2);

                        x = e.X;
                        y = e.Y;
                        Refresh();
                        break;

                    case Tools.line:
                        Refresh();
                        pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width);
                        g = CreateGraphics();
                        g.DrawLine(pen, x, y, e.X, e.Y);
                        break;

                    case Tools.ellipse:
                        g = CreateGraphics();
                        pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width);
                        g.DrawEllipse(pen, e.X, e.Y, x - e.X, y - e.Y);
                        Refresh();
                        break;

                    case Tools.star:
                        x = e.X;
                        y = e.Y;
                        Refresh();
                        break;
                    case Tools.eraser:

                        g.CompositingMode = CompositingMode.SourceOver;

                        pen = new Pen(Color.White, MyPaintMainForm.Width * 2);

                        if (x != -1 && y != -1)
                        {
                            g.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                        }

                        g.FillEllipse(Brushes.White, e.X - MyPaintMainForm.Width, e.Y - MyPaintMainForm.Width, MyPaintMainForm.Width * 2, MyPaintMainForm.Width * 2);

                        x = e.X;
                        y = e.Y;
                        Refresh();
                        break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(pictureBox.Image, 0, 0);
        }

        public void ChangeCanvasSize(int width, int height)
        {
            Bitmap previousBitmap = new Bitmap(pictureBox.Image);

            pictureBox.Image = CreateBitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(pictureBox.Image))
            {
                graphics.DrawImage(previousBitmap, 0, 0);
            }
            previousBitmap.Dispose();
            Invalidate();
        }

        public void ChangeScale()
        {
            float scale;
            if (MyPaintMainForm.zoom == Zoom.zoomIn)
                scale = 1.25f;
            else
                scale = 0.75f;
            Bitmap zoomPicture = new Bitmap((int)(width * scale), (int)(height * scale));

            using (Graphics g = Graphics.FromImage(zoomPicture))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(
                    pictureBox.Image,
                    new Rectangle(0, 0, (int)(pictureBox.Image.Width * scale), (int)(pictureBox.Image.Height * scale)),
                    new Rectangle(0, 0, width, height),
                    GraphicsUnit.Pixel
                );
            }
            pictureBox.Image = zoomPicture;

            width = zoomPicture.Width;
            height = zoomPicture.Height;

            MyPaintMainForm.Width *= scale;

            Invalidate();
        }

        public Bitmap CreateBitmap(int width, int height)
        {
            var bitmap = new Bitmap((int)(width * MyPaintMainForm.scale), (int)(height * MyPaintMainForm.scale), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
            }
            return bitmap;
        }

        public PictureBox CreatePictureBox(int width, int height)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.Image = CreateBitmap(width, height);
            newPictureBox.Size = new Size(width, height);
            newPictureBox.Dock = DockStyle.None;
            newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            newPictureBox.BackColor = Color.White;

            return newPictureBox;
        }

        public PictureBox GetCanvasBitmap()
        {
            return pictureBox;
        }

        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox.Image);
            Pen pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width);
            switch (MyPaintMainForm.Tool)
            {
                case Tools.pen:
                    g.CompositingMode = CompositingMode.SourceOver;

                    pen = new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width * 2);

                    g.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                    g.FillEllipse(pen.Brush, e.X - MyPaintMainForm.Width, e.Y - MyPaintMainForm.Width, MyPaintMainForm.Width * 2, MyPaintMainForm.Width * 2);

                    x = e.X;
                    y = e.Y;
                    Refresh();
                    break;

                case Tools.line:
                    g.DrawLine(new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width), x, y, e.X, e.Y);
                    x = e.X;
                    y = e.Y;
                    break;

                case Tools.ellipse:
                    g.DrawEllipse(new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width), e.X, e.Y, x - e.X, y - e.Y);

                    x = e.X;
                    y = e.Y;
                    break;

                case Tools.star:
                    int n = MyPaintMainForm.vertexs;
                    double R = MyPaintMainForm.outerRadius, r = MyPaintMainForm.innerRadius;
                    double beta = 0;
                    double x0 = e.X, y0 = e.Y;
                    PointF[] points = new PointF[2 * n + 1];
                    double a = beta, da = Math.PI / n, l;
                    for (int k = 0; k < 2 * n + 1; k++)
                    {
                        l = k % 2 == 0 ? r : R;
                        points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                        a += da;
                    }
                    g.DrawLines(new Pen(MyPaintMainForm.Color, MyPaintMainForm.Width), points);
                    break;

                case Tools.eraser:

                    g.CompositingMode = CompositingMode.SourceOver;

                    pen = new Pen(Color.White, MyPaintMainForm.Width * 2);

                    if (x != -1 && y != -1)
                    {
                        g.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                    }

                    g.FillEllipse(Brushes.White, e.X - MyPaintMainForm.Width, e.Y - MyPaintMainForm.Width, MyPaintMainForm.Width * 2, MyPaintMainForm.Width * 2);

                    x = e.X;
                    y = e.Y;
                    Refresh();
                    break;
            }
            Invalidate();
        }

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Выйти?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            if (this == null)
            {
                Environment.Exit(0);
            }
            else
            {
                DialogResult dlg2 = MessageBox.Show("Сохранить?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (dlg2)
                {
                    case DialogResult.Yes:
                        if (!MyPaintMainForm.Save(this))
                        break;
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        public bool OpenBitmap(Bitmap bmp)
        {
            pictureBox.Image = bmp;
            return true;
        }
    }
}
