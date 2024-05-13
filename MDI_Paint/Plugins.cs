using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class Plugins : Form
    {
        public Plugins()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            LoadData();
        }

        public void LoadData()
        {
            var dataTable = GetData();

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

        public DataTable GetData()
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IsSelected", typeof(bool));
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Автор", typeof(string));
            dataTable.Columns.Add("Версия", typeof(string));

            foreach (var plugin in MyPaintMainForm.GetAllPlugins())
            {
                Assembly assembly = plugin.Value.GetType().Assembly;
                AssemblyFileVersionAttribute fileVersionAttribute = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute));
                string fileVersion = fileVersionAttribute != null ? fileVersionAttribute.Version : "";

                bool isDownload = MyPaintMainForm.plugins.ContainsKey(plugin.Value.Name);

                dataTable.Rows.Add(isDownload, plugin.Value.Name, plugin.Value.Author, fileVersion);
            }
            return dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();

            MyPaintMainForm.FindPlugins();
            MyPaintMainForm mainForm = (MyPaintMainForm)Application.OpenForms["MyPaintMainForm"]; // Получаем экземпляр формы
            mainForm.CreatePluginsMenu(); // Вызываем метод CreatePluginsMenu() для этого экземпляра

            this.Close();
        }

        private string GetPluginNames()
        {
            string pluginNames = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    pluginNames += MyPaintMainForm.GetAllPlugins().Values.First(p => p.Name == row.Cells[1].Value.ToString()).GetType().Name + ",";
                }
            }
            return pluginNames.Trim(',');
        }

        private void SaveChanges()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins.config");

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFilePath;
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            // Add or update values in the appSettings section
            AppSettingsSection appSettings = config.AppSettings;
            appSettings.Settings["PluginNames"].Value = GetPluginNames();

            // Save the changes
            config.Save();
        }
    }
}
