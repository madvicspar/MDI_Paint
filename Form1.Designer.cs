using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using System;

namespace MDI_Paint
{
    partial class MyPaintMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPaintMainForm));
            this.menuStrip_MainForm = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вФорматеBMPbmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вФорматеJPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерХолстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваНаправоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуВнизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядочитьЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.RedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_BrushSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.количествоЛучейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.внутреннийРадиусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.введитеЗначениеНижеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_MainForm.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_MainForm
            // 
            this.menuStrip_MainForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_MainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.окноToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip_MainForm.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_MainForm.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip_MainForm.Name = "menuStrip_MainForm";
            this.menuStrip_MainForm.Size = new System.Drawing.Size(1082, 28);
            this.menuStrip_MainForm.TabIndex = 1;
            this.menuStrip_MainForm.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += новыйToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.открытьToolStripMenuItem.Text = "Открыть..";
            this.открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.DropDownOpening += сохранитьToolStripMenuItem_DropDownOpening;
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вФорматеBMPbmpToolStripMenuItem,
            this.вФорматеJPGToolStripMenuItem});
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.DropDownOpening += сохранитьКакToolStripMenuItem_DropDownOpening;
            // 
            // вФорматеBMPbmpToolStripMenuItem
            // 
            this.вФорматеBMPbmpToolStripMenuItem.Name = "вФорматеBMPbmpToolStripMenuItem";
            this.вФорматеBMPbmpToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.вФорматеBMPbmpToolStripMenuItem.Text = "в формате BMP.bmp";
            this.вФорматеBMPbmpToolStripMenuItem.Click += вФорматеBMPbmpToolStripMenuItem_Click;
            // 
            // вФорматеJPGToolStripMenuItem
            // 
            this.вФорматеJPGToolStripMenuItem.Name = "вФорматеJPGToolStripMenuItem";
            this.вФорматеJPGToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.вФорматеJPGToolStripMenuItem.Text = "в формате JPG.jpg";
            this.вФорматеJPGToolStripMenuItem.Click += вФорматеJPGToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерХолстаToolStripMenuItem});
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            this.рисунокToolStripMenuItem.DropDownOpening += рисунокToolStripMenuItem_DropDownOpening;
            // 
            // размерХолстаToolStripMenuItem
            // 
            this.размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            this.размерХолстаToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.размерХолстаToolStripMenuItem.Text = "Размер холста...";
            this.размерХолстаToolStripMenuItem.Click += размерХолстаToolStripMenuItem_Click;
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.слеваНаправоToolStripMenuItem,
            this.сверхуВнизToolStripMenuItem,
            this.упорядочитьЗначкиToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.каскадомToolStripMenuItem.Text = "Каскадом";
            this.каскадомToolStripMenuItem.Click += каскадомToolStripMenuItem_Click;
            // 
            // слеваНаправоToolStripMenuItem
            // 
            this.слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            this.слеваНаправоToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.слеваНаправоToolStripMenuItem.Text = "Слева направо";
            this.слеваНаправоToolStripMenuItem.Click += слеваНаправоToolStripMenuItem_Click;
            // 
            // сверхуВнизToolStripMenuItem
            // 
            this.сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            this.сверхуВнизToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.сверхуВнизToolStripMenuItem.Text = "Сверху вниз";
            this.сверхуВнизToolStripMenuItem.Click += сверхуВнизToolStripMenuItem_Click;
            // 
            // упорядочитьЗначкиToolStripMenuItem
            // 
            this.упорядочитьЗначкиToolStripMenuItem.Name = "упорядочитьЗначкиToolStripMenuItem";
            this.упорядочитьЗначкиToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.упорядочитьЗначкиToolStripMenuItem.Text = "Упорядочить значки";
            this.упорядочитьЗначкиToolStripMenuItem.Click += упорядочитьЗначкиToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // AboutProgramToolStripMenuItem
            // 
            this.AboutProgramToolStripMenuItem.Name = "AboutProgramToolStripMenuItem";
            this.AboutProgramToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.AboutProgramToolStripMenuItem.Text = "О программе...";
            this.AboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.toolStripTextBox_BrushSize,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripDropDownButton3,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1082, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedToolStripMenuItem,
            this.BlueToolStripMenuItem,
            this.GreenToolStripMenuItem,
            this.BlackToolStripMenuItem,
            this.WhiteToolStripMenuItem,
            this.OtherColorToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // RedToolStripMenuItem
            // 
            this.RedToolStripMenuItem.AutoSize = false;
            this.RedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RedToolStripMenuItem.Image")));
            this.RedToolStripMenuItem.Name = "RedToolStripMenuItem";
            this.RedToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.RedToolStripMenuItem.Text = "Красный";
            this.RedToolStripMenuItem.Click += RedToolStripMenuItem_Click;
            // 
            // BlueToolStripMenuItem
            // 
            this.BlueToolStripMenuItem.AutoSize = false;
            this.BlueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BlueToolStripMenuItem.Image")));
            this.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            this.BlueToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.BlueToolStripMenuItem.Text = "Синий";
            this.BlueToolStripMenuItem.Click += BlueToolStripMenuItem_Click;
            // 
            // GreenToolStripMenuItem
            // 
            this.GreenToolStripMenuItem.AutoSize = false;
            this.GreenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GreenToolStripMenuItem.Image")));
            this.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem";
            this.GreenToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.GreenToolStripMenuItem.Text = "Зеленый";
            this.GreenToolStripMenuItem.Click += GreenToolStripMenuItem_Click;
            // 
            // BlackToolStripMenuItem
            // 
            this.BlackToolStripMenuItem.AutoSize = false;
            this.BlackToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BlackToolStripMenuItem.Image")));
            this.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem";
            this.BlackToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.BlackToolStripMenuItem.Text = "Черный";
            this.BlackToolStripMenuItem.Click += BlackToolStripMenuItem_Click;
            // 
            // WhiteToolStripMenuItem
            // 
            this.WhiteToolStripMenuItem.AutoSize = false;
            this.WhiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WhiteToolStripMenuItem.Image")));
            this.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            this.WhiteToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.WhiteToolStripMenuItem.Text = "Белый";
            this.WhiteToolStripMenuItem.Click += WhiteToolStripMenuItem_Click;
            // 
            // OtherColorToolStripMenuItem
            // 
            this.OtherColorToolStripMenuItem.AutoSize = false;
            this.OtherColorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OtherColorToolStripMenuItem.Image")));
            this.OtherColorToolStripMenuItem.Name = "OtherColorToolStripMenuItem";
            this.OtherColorToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.OtherColorToolStripMenuItem.Text = "Другой..";
            this.OtherColorToolStripMenuItem.Click += OtherColorToolStripMenuItem_Click;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 24);
            this.toolStripLabel1.Text = "Кисть:";
            // 
            // toolStripTextBox_BrushSize
            // 
            this.toolStripTextBox_BrushSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_BrushSize.Name = "toolStripTextBox_BrushSize";
            this.toolStripTextBox_BrushSize.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox_BrushSize.KeyDown += toolStripTextBox_BrushSize_KeyDown;
            this.toolStripTextBox_BrushSize.KeyPress += toolStripTextBox_BrushSize_KeyPress;
            this.toolStripTextBox_BrushSize.MouseLeave += toolStripTextBox_BrushSize_MouseLeave;
            this.toolStripTextBox_BrushSize.TextChanged += toolStripTextBox_BrushSize_TextChanged;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton5.Text = "toolStripButton5"; 
            this.toolStripButton5.Click += toolStripButton5_Click;

            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоЛучейToolStripMenuItem,
            this.внутреннийРадиусToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton3.Text = "toolStripDropDownButton3";
            // 
            // количествоЛучейToolStripMenuItem
            // 
            this.количествоЛучейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripTextBox2});
            this.количествоЛучейToolStripMenuItem.Name = "количествоЛучейToolStripMenuItem";
            this.количествоЛучейToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.количествоЛучейToolStripMenuItem.Text = "Количество лучей..";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem6.Text = "4";
            this.toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem7.Text = "5";
            this.toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem8.Text = "6";
            this.toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripTextBox2.KeyDown += toolStripTextBox2_KeyDown;
            this.toolStripTextBox2.KeyPress += toolStripTextBox2_KeyPress;
            this.toolStripTextBox2.MouseLeave += toolStripTextBox2_MouseLeave;
            // 
            // внутреннийРадиусToolStripMenuItem
            // 
            this.внутреннийРадиусToolStripMenuItem.Name = "внутреннийРадиусToolStripMenuItem";
            this.внутреннийРадиусToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.внутреннийРадиусToolStripMenuItem.Text = "Внутренний радиус..";
            this.внутреннийРадиусToolStripMenuItem.Click += внутреннийРадиусToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // введитеЗначениеНижеToolStripMenuItem
            // 
            this.введитеЗначениеНижеToolStripMenuItem.Enabled = false;
            this.введитеЗначениеНижеToolStripMenuItem.Name = "введитеЗначениеНижеToolStripMenuItem";
            this.введитеЗначениеНижеToolStripMenuItem.ShowShortcutKeys = false;
            this.введитеЗначениеНижеToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.введитеЗначениеНижеToolStripMenuItem.Text = "Введите значение ниже:";
            // 
            // MyPaintMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip_MainForm);
            this.DoubleBuffered = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyPaintMainForm_FormClosing);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_MainForm;
            this.Name = "MyPaintMainForm";
            this.Text = "MyPaint";
            this.menuStrip_MainForm.ResumeLayout(false);
            this.menuStrip_MainForm.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_MainForm;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерХолстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядочитьЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem RedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OtherColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_BrushSize;
        private System.Windows.Forms.ToolStripMenuItem вФорматеBMPbmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вФорматеJPGToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem количествоЛучейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem внутреннийРадиусToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem введитеЗначениеНижеToolStripMenuItem;
    }
}

