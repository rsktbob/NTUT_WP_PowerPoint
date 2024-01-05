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
        public event EventHandler _uploadEndEvent;
        private GoogleDriveService _service;
        List<Shapes> _pageManager;
        const string CONTENT_TYPE = "application/json";
        const string FILE_NAME = "data.json";

        public SaveForm(List<Shapes> pageManager)
        {
            InitializeComponent();
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIEBT_SECRET_FILE_NAME = "clientSecret.json";

            _pageManager = pageManager;
            _service = new GoogleDriveService(APPLICATION_NAME, CLIEBT_SECRET_FILE_NAME);
        }

        // Click save button
        private async void ClickSaveButton(object sender, EventArgs e)
        {
            Hide();
            List<List<List<object>>> fileData = CovertPageManager(_pageManager);
            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonText = JsonConvert.SerializeObject(fileData);
            string filePath = Path.Combine(currentDirectory, FILE_NAME);
            File.WriteAllText(filePath, jsonText);
            await Task.Delay(10000);
            await Upload(filePath);
            if (_uploadEndEvent != null)
            {
                _uploadEndEvent.Invoke(sender, e);
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
                    data[i].Add(new List<object> { shape.ShapeName, shape.IsSelected, shape.PointX1, shape.PointY1, shape.PointX2, shape.PointY2 });
                }
            }
            return data;
        }

        // Upload file
        private async Task Upload(string filePath)
        {
            await Task.Run(() =>
            {
                if (File.Exists(filePath))
                {
                    List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                    Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == FILE_NAME; });
                    if (foundFile != null)
                    {
                        _service.UpdateFile(FILE_NAME, foundFile.Id, CONTENT_TYPE);
                    }
                    else
                    {
                        _service.UploadFile(filePath, CONTENT_TYPE);
                    }
                    File.Delete(filePath);
                }
            });
        }
    }
}
