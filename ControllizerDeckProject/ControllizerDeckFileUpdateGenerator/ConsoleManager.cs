using ControllizerDeck.FileUpdateGenerator.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terminal.Gui;

namespace ControllizerDeck.FileUpdateGenerator
{
    public class ConsoleManager
    {
        private Window mainWindow;
        private UpdateFileList DataList = null;

        private readonly List<CheckBox> filesCheckboxes = new();
        private readonly Dictionary<int, string> files = new();

        private string SelectedFilePath;
        public void Init(Toplevel container)
        {
            mainWindow = new Window("ControllizerDeck File Update Generator")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            container.Add(mainWindow);
            var menuBar = new MenuBar(new MenuBarItem[] {
                new MenuBarItem("_File", new MenuItem[]
                {
                    new MenuItem("_New","Creates new file", () => NewFile()),
                    new MenuItem("_Save", "Export generated file", () => SaveFile(), () => { return DataList != null; }),
                    new MenuItem("_Load", "Load an existing file", () => { }, () => { return false; }),
                    new MenuItem("_Quit", "Quit from this utilities app", () => { container.Running = false; })
                }),
                new MenuBarItem("_About", "Show the about view", () => AboutView())
            });
            container.Add(menuBar);
        }
        private void NewFile()
        {
            DataList = new UpdateFileList();
            // Add controls:
            var btnSelectBuildPath = new Button("Select directory") { X = 1, Y = 2 };
            btnSelectBuildPath.Clicked += () => SelectPath();
            var lblSelectBuildPathDescription = new Label("Select the directory to scan for files and folders.") { X = Pos.Right(btnSelectBuildPath) + 1, Y = 2 };
            mainWindow.Add(btnSelectBuildPath, lblSelectBuildPathDescription);
        }

        private void SaveFile()
        {
            var saveDialog = new SaveDialog()
            {
                AllowedFileTypes = new[] { "*.json" }
            };
            Application.Run(saveDialog);
            if (!saveDialog.Canceled)
            {
                string filename = saveDialog.FileName.ToString();
                using (StreamWriter writer = File.CreateText(filename))
                {
                    JsonSerializer s = new() { Formatting = Formatting.Indented };
                    s.Serialize(writer, DataList.ConvertToJObject());
                }
                MessageBox.Query(50, 10, "Save", "Save succeeded", "OK");
            }
        }

        private void SelectPath()
        {
            var openDialog = new OpenDialog()
            {
                CanChooseDirectories = true,
                CanChooseFiles = false,
                CanCreateDirectories = false,
                AllowsMultipleSelection = false
            };
            Application.Run(openDialog);
            if (!openDialog.Canceled)
            {
                string path = openDialog.FilePaths[0];
                SelectedFilePath = path;
                var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                var filesWindow = new Window("Select files...") { X = 0, Y = 0, Width = 80, Height = 20 };
                var filesView = new ScrollView(new Rect(0, 0, 80, 20));
                int yPos = 0;
                int index = 0;
                foreach (string s in files)
                {
                    var ckSelectItem = new CheckBox(s.Split("\\").Reverse().First(), true) { X = 1, Y = 1 + yPos++ };
                    filesView.Add(ckSelectItem);
                    filesCheckboxes.Add(ckSelectItem);
                    this.files.Add(index++, s);
                }
                filesWindow.Add(filesView);
                mainWindow.Add(filesWindow);
                var btnSave = new Button("OK") { X = 38, Y = 17 };
                btnSave.Clicked += () =>
                {
                    for (int i = 0; i < filesCheckboxes.Count; i++)
                    {
                        if (!filesCheckboxes[i].Checked)
                            this.files.Remove(i);
                    }
                    mainWindow.Remove(filesWindow);
                    ProgressFileChecksum();
                };
                var btnCancel = new Button("CANCEL") { X = Pos.Right(btnSave), Y = 17 };
                btnCancel.Clicked += () =>
                {
                    mainWindow.Remove(filesWindow);
                };
                filesWindow.Add(btnSave, btnCancel);
            }
        }

        private void ProgressFileChecksum()
        {
            foreach (var file in files.Values)
            {
                DataList.Add(new UpdateFile(file, SelectedFilePath));
            }
        }

        private static void AboutView()
        {
            MessageBox.Query(50, 10, "About", "A simple util that generates a file list to update Controllizer Deck and all of it's components.\n\nMade by GhostyJade", "Ok");
        }
    }
}
