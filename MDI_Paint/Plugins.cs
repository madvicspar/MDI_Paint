using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class Plugins : Form
    {
        public Plugins()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IsSelected", typeof(bool));
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Автор", typeof(string));
            dataTable.Columns.Add("Версия", typeof(string));

            foreach (var plugin in MyPaintMainForm.plugins)
            {
                Assembly assembly = plugin.Value.GetType().Assembly;
                AssemblyFileVersionAttribute fileVersionAttribute = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute));
                string fileVersion = fileVersionAttribute != null ? fileVersionAttribute.Version : "";

                dataTable.Rows.Add(true, plugin.Value.Name, plugin.Value.Author, fileVersion);
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Check",
                DataPropertyName = "IsSelected",
                HeaderText = "",
                Width = 25,
                Resizable = DataGridViewTriState.False
            };

            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns.Add("Name", "Название");
            dataGridView1.Columns.Add("Author", "Автор");
            dataGridView1.Columns.Add("Version", "Версия");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dataTable.Rows[i].ItemArray[0], dataTable.Rows[i].ItemArray[1], dataTable.Rows[i].ItemArray[2], dataTable.Rows[i].ItemArray[3]);
            }
        }
    }
}
