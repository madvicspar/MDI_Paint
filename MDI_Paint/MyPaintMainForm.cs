using PluginInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MDI_Paint
{
    public enum Tools
    {
        pen, line, ellipse, eraser, star
    }

    public enum Zoom
    {
        zoomIn, zoomOut
    }

    public partial class MyPaintMainForm : Form
    {
        public static Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public static Color Color { get; set; }
        public static float Width { get; set; }
        public static Tools Tool { get; set; }
        public static float scale;
        public static Zoom zoom { get; set; }
        public static int vertexs { get; set; }
        public static int innerRadii { get; set; }
        public static int outerRadii { get; set; }

        public static string PluginNames = "ReversePlugin,ToGrayPlugin,MedianPlugin,PrewittPlugin,DataStringPlugin";

        public float Scale
        {
            get => scale;
            set
            {
                scale = value;
                MyOnPropertyChanged();
            }
        }

        public MyPaintMainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Color = Color.Black;
            Scale = 1;
            Width = 3;
            Tool = Tools.pen;
            vertexs = 5;
            innerRadii = 25;
            outerRadii = 50;
            toolStripTextBox_BrushSize.Text = Width.ToString();
            BlackToolStripMenuItem.Checked = true;
            каскадомToolStripMenuItem.Checked = true;
            toolStripButton1.Checked = true;
            toolStripTextBox2.Text = vertexs.ToString();
            CheckActiveForms();
            FindPlugins();
            CreatePluginsMenu();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        public bool Exit()
        {
            DialogResult dlg = MessageBox.Show("Выйти?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == DialogResult.No)
                return false;
            if (!(ActiveMdiChild is DocumentForm form))
            {
                Environment.Exit(0);
            }
            else
            {
                DialogResult dlg2 = MessageBox.Show("Сохранить?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (dlg2)
                {
                    case DialogResult.Yes:
                        if (!Save(form))
                            return false;
                        break;
                    case DialogResult.No:
                        Environment.Exit(0);
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAbout = new AboutForm();
            formAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var documentForm = new DocumentForm
            {
                MdiParent = this
            };
            documentForm.Show();
            CheckActiveForms();
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var canvassSize = new CanvasSizeForm
            {
                MdiParent = this,
                Form = ActiveMdiChild as DocumentForm
            };
            canvassSize.Show();
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Red;
            DeleteColorChecking();
            RedToolStripMenuItem.Checked = true;
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Blue;
            DeleteColorChecking();
            BlueToolStripMenuItem.Checked = true;
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Green;
            DeleteColorChecking();
            GreenToolStripMenuItem.Checked = true;
        }

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Black;
            DeleteColorChecking();
            BlackToolStripMenuItem.Checked = true;
        }

        private void WhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.White;
            DeleteColorChecking();
            WhiteToolStripMenuItem.Checked = true;
        }

        private void OtherColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color = cd.Color;
                DeleteColorChecking();
                OtherColorToolStripMenuItem.Checked = true;
            }
        }

        private void toolStripTextBox_BrushSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStripTextBox_BrushSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toolStripTextBox_BrushSize.Text == "")
                    return;
                Width = int.Parse(toolStripTextBox_BrushSize.Text) * scale;
                e.Handled = true;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(ActiveMdiChild as DocumentForm);
        }

        public static bool Save(DocumentForm documentForm)
        {
            if (documentForm.fileName == "")
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "Windows Bitmap (*.bmp)|*.bmp|Файлы JPEG (*.jpg)|*.jpg",
                    FileName = "Безымянный"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat imageFormat;

                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            imageFormat = ImageFormat.Bmp;
                            break;
                        case 2:
                            imageFormat = ImageFormat.Jpeg;
                            break;
                        default:
                            imageFormat = ImageFormat.Bmp;
                            break;
                    }

                    documentForm.GetCanvasBitmap().Image.Save(dialog.FileName, imageFormat);
                    documentForm.fileName = dialog.FileName;
                    documentForm.imageFormat = imageFormat;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                try
                {
                    documentForm.GetCanvasBitmap().Image.Save(documentForm.fileName);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Нельзя сохранить изображение. Сохраните с другими параметрами");
                    documentForm.fileName = "";
                    Save(documentForm);
                    return true;
                }
            }
        }
        private void вФорматеBMPbmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is DocumentForm form)
            {
                DocumentForm documentForm = form;

                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "Windows Bitmap (*.bmp)|*.bmp",
                    FileName = "Безымянный.bmp"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    documentForm.GetCanvasBitmap().Image.Save(dialog.FileName, ImageFormat.Bmp);
                    documentForm.fileName = dialog.FileName;
                    documentForm.imageFormat = ImageFormat.Bmp;
                }
            }
        }

        private void сохранитьToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void сохранитьКакToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            вФорматеBMPbmpToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            вФорматеJPGToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            рисунокToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void вФорматеJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is DocumentForm form)
            {
                DocumentForm documentForm = form;

                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    documentForm.GetCanvasBitmap().Image.Save(dialog.FileName, ImageFormat.Jpeg);
                    documentForm.fileName = dialog.FileName;
                    documentForm.imageFormat = ImageFormat.Jpeg;
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы ()*.*|*.*"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap openedBitmap = new Bitmap(dlg.FileName);
                DocumentForm document = new DocumentForm
                {
                    MdiParent = this,

                    fileName = dlg.FileName
                };
                document.CreatePictureBox(openedBitmap.Width, openedBitmap.Height);
                document.OpenBitmap(openedBitmap);
                document.Show();
            }
            CheckActiveForms();
        }

        public void CheckActiveForms()
        {
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            вФорматеBMPbmpToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            вФорматеJPGToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            рисунокToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void MyOnPropertyChanged()
        {
            if (ActiveMdiChild is DocumentForm form && Scale >= 0.25)
            {
                if (Scale == 0.25)
                {
                    toolStripButton6.Enabled = false;
                }
                else
                    toolStripButton6.Enabled = true;
                form.ChangeScale();
            }
        }

        private void toolStripTextBox_BrushSize_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox_BrushSize.Text == "")
                return;
            Width = int.Parse(toolStripTextBox_BrushSize.Text) * scale;
        }

        private void toolStripTextBox_BrushSize_MouseLeave(object sender, EventArgs e)
        {
            if (toolStripTextBox_BrushSize.Text == "")
                toolStripTextBox_BrushSize.Text = Width.ToString();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            zoom = Zoom.zoomIn;
            Scale += 0.25f;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            zoom = Zoom.zoomOut;
            Scale -= 0.25f;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Tool = Tools.pen;
            DeleteToolChecking();
            toolStripButton1.Checked = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Tool = Tools.line;
            DeleteToolChecking();
            toolStripButton2.Checked = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Tool = Tools.eraser;
            DeleteToolChecking();
            toolStripButton5.Checked = true;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Tool = Tools.star;
            vertexs = 4;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Tool = Tools.star;
            vertexs = 5;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Tool = Tools.star;
            vertexs = 6;
        }

        private void toolStripTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStripTextBox2_MouseLeave(object sender, EventArgs e)
        {
            Tool = Tools.star;
            if (toolStripTextBox2.Text == "" || toolStripTextBox2.Text == "0")
                return;
            vertexs = int.Parse(toolStripTextBox2.Text);
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            Tool = Tools.star;
            if (e.KeyCode == Keys.Enter)
            {
                if (toolStripTextBox2.Text == "" || toolStripTextBox2.Text == "0")
                    return;
                vertexs = int.Parse(toolStripTextBox2.Text);
                e.Handled = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Tool = Tools.ellipse;
            DeleteToolChecking();
            toolStripButton3.Checked = true;
        }

        private void внутреннийРадиусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarRadiiForm form = new StarRadiiForm
            {
                MdiParent = this
            };
            form.Show();
        }

        private void MyPaintMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit())
                e.Cancel = true;
        }

        private void DeleteColorChecking()
        {
            RedToolStripMenuItem.Checked = false;
            BlueToolStripMenuItem.Checked = false;
            GreenToolStripMenuItem.Checked = false;
            BlackToolStripMenuItem.Checked = false;
            WhiteToolStripMenuItem.Checked = false;
            OtherColorToolStripMenuItem.Checked = false;
        }
        private void DeleteToolChecking()
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton1.Checked = false;
        }

        #region PluginsWork

        public static void FindPlugins()
        {
            plugins.Clear();
            var pluginSettings = CheckConfigFile().AppSettings.Settings["PluginNames"].Value.Split(',');

            foreach (var plugin in GetAllPlugins().Values)
            {
                if (pluginSettings.Contains(plugin.GetType().Name))
                {
                    plugins.Add(plugin.Name, plugin);
                }
            }
        }

        public void CreatePluginsMenu()
        {
            FiltersToolStripMenuItem.DropDownItems.Clear();
            foreach (var p in plugins)
            {
                var item = FiltersToolStripMenuItem.DropDownItems.Add(p.Value.Name);
                item.Click += OnPluginClick;
            }
            var about = FiltersToolStripMenuItem.DropDownItems.Add("Все фильтры и подробности о них");
            about.Click += OnFiltersAboutClick;
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            var form = ActiveMdiChild as DocumentForm;
            form.ApplyFilter(plugin);
            form.Invalidate();
        }

        private void OnFiltersAboutClick(object sender, EventArgs args)
        {
            Plugins plugins = new Plugins();
            this.Enabled = false;
            plugins.ShowDialog();
            this.Enabled = true;
        }

        public static Dictionary<string, IPlugin> GetAllPlugins()
        {
            Dictionary<string, IPlugin> allPlugins = new Dictionary<string, IPlugin>();
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
            {
                string pattern = @"\\([^\\]+)\.dll$"; // Регулярное выражение для извлечения названия файла без расширения .dll
                Match match = Regex.Match(file, pattern);

                string pluginName = match.Groups[1].Value;
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            allPlugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
            }
            return allPlugins;
        }

        public static Configuration CheckConfigFile()
        {
            Configuration config;
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins.config");
            //Configuration config;
            if (!File.Exists("Plugins.config"))
            {
                // Create a new app.config file
                if (!File.Exists(configFilePath))
                {
                    File.WriteAllText(configFilePath, $@"<?xml version='1.0' encoding='utf-8'?>
<configuration>
    <appSettings>
        <add key=""PluginNames"" value=""{PluginNames}"" />
    </appSettings>
</configuration>");
                }
            }

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFilePath;
            config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            // Add or update values in the appSettings section
            AppSettingsSection appSettings = config.AppSettings;
            if (!appSettings.Settings.AllKeys.Contains("PluginNames"))
                appSettings.Settings.Add("PluginNames", PluginNames);
            if (appSettings.Settings["PluginNames"].Value.Split(',').Length == 1)
                appSettings.Settings["PluginNames"].Value = PluginNames;

            // Save the changes
            config.Save();
            return config;
        }

        #endregion PluginsWork
    }
}
