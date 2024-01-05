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
        List<List<List<object>>> _data;
        const string CONTENT_TYPE = "application/json";
        const string FILE_NAME = "data.json";

        public SaveForm(List<Shapes> pageManager)
        {
            InitializeComponent();
            _currentDirectory = Directory.GetCurrentDirectory();
            _data = CovertPageManager(pageManager);
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
            string jsonText = JsonConvert.SerializeObject(_data);
            string fileName = Path.Combine(_currentDirectory, FILE_NAME);

            // 寫入JSON資料到檔案
            File.WriteAllText(fileName, jsonText);
            if (File.Exists(fileName))
            {
                List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == "data.json"; });
                if (foundFile != null)
                {
                    _service.UpdateFile("data.json", foundFile.Id, CONTENT_TYPE);
                }
                else
                {
                    _service.UploadFile(fileName, CONTENT_TYPE);
                }
                File.Delete(fileName);
            }
            Close();
        }

        // pageManager corvert to list<list<list<object>>>
        private List<List<List<object>>> CovertPageManager(List<Shapes> pageManager)
        {
            List<List<List<object>>> data = new List<List<List<object>>>();
            for (int i = 0; i < pageManager.Count; i++)
            {
                data.Add(new List<List<object>>());
                for (int j = 0; j < pageManager[i].ShapeManager.Count; j++)
                {
                    Shape shape = pageManager[i].ShapeManager[j];
                    data[i].Add(new List<object> { shape.ShapeName, shape.PointX1, shape.PointY1, shape.PointX2, shape.PointY2 });
                }
            }
            return data;
        }
    }
}
