using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

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
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";

            _pageManager = pageManager;
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        // Click save button
        private async void ClickSaveButton(object sender, EventArgs e)
        {
            Hide();
            List<List<Shape>> fileData = TransformPageManager(_pageManager);
            string currentDirectory = Directory.GetCurrentDirectory();
            string fileText = JsonConvert.SerializeObject(fileData);
            string filePath = Path.Combine(currentDirectory, FILE_NAME);
            File.WriteAllText(filePath, fileText);
            await Upload(filePath);
            if (_uploadEndEvent != null)
            {
                _uploadEndEvent.Invoke(sender, e);
            }
            Close();
        }

        // Upload file
        private async Task Upload(string filePath)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
                if (File.Exists(filePath))
                {
                    List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                    Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => item.Title == FILE_NAME);
                    if (foundFile != null)
                        _service.UpdateFile(FILE_NAME, foundFile.Id, CONTENT_TYPE);
                    else
                        _service.UploadFile(filePath, CONTENT_TYPE);
                    File.Delete(filePath);
                }
            });
        }

        // Transform pageManager
        private List<List<Shape>> TransformPageManager(List<Shapes> pageManager)
        {
            List<List<Shape>> fileData = new List<List<Shape>>();
            for (int i = 0; i < pageManager.Count; i++)
            {
                fileData.Add(new List<Shape>());
                for (int j = 0; j < pageManager[i].ShapeManager.Count; j++)
                {
                    fileData[i].Add(pageManager[i].ShapeManager[j]);
                }
            }
            return fileData;
        }
    }
}
