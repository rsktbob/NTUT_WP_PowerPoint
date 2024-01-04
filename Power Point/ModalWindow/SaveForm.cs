using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDriveUploader.GoogleDrive;
using System.IO;
using Newtonsoft.Json;

namespace Power_Point
{
    public partial class SaveForm : System.Windows.Forms.Form
    {
        private GoogleDriveService _service;
        string _currentDirectory;

        public SaveForm()
        {
            InitializeComponent();
            _currentDirectory = Directory.GetCurrentDirectory();
        }

        // Load save form
        private void LoadSaveForm(object sender, EventArgs e)
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIEBT_SECRET_FILE_NAME = "clientSecret.json";

            _service = new GoogleDriveService(APPLICATION_NAME, CLIEBT_SECRET_FILE_NAME);
        }

        // Click save button
        private void ClickSaveButton(object sender, EventArgs e)
        {
            List<List<List<object>>> lst1 = new List<List<List<object>>> { new List<List<object>>
            {   new List<object> { "client", 3, 6, 14, 8},
                new List<object> {"dessert", 21, 8, 6, 14 } },
             new List<List<object>> {
                 new List<object> { "circle", 3, 6, 14, 8},
                 new List<object> {"square", 21, 8, 6, 14 }}
             };

            // 將List轉換為JSON格式字串
            string json = JsonConvert.SerializeObject(lst1);

            // 輸出JSON格式字串
            Console.WriteLine(json);

            // 指定檔案路徑和檔名
            string filePath = "data.json";

            // 寫入JSON資料到檔案
            File.WriteAllText(filePath, json);

            if (File.Exists(filePath))
            {
                string jsonFile = File.ReadAllText(filePath);

                List<List<List<object>>> lst2 = JsonConvert.DeserializeObject<List<List<List<object>>>>(jsonFile);
            }
        }
    }
}
