﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWSIM.UI.Shared;
using Eto.Forms;
using Settings = DWSIM.GlobalSettings.Settings;

namespace DWSIM.UI.Forms.Forms
{
    class GeneralSettings
    {

        public Form GetForm()
        {

            string prefix = this.GetLocalizationPrefix();

            var tab1 = Common.GetDefaultContainer();
            tab1.Tag = "User Interface";

            tab1.CreateAndAddLabelRow("Renderer");

            int currentrenderer = 0;
            var renderers = new List<String>();

            switch (GlobalSettings.Settings.RunningPlatform())
            {
                case Settings.Platform.Windows:
                    renderers.AddRange(Enum.GetNames(typeof(Settings.WindowsPlatformRenderer)));
                    currentrenderer = (int)Settings.WindowsRenderer;
                    break;
                case Settings.Platform.Linux:
                    renderers.AddRange(Enum.GetNames(typeof(Settings.LinuxPlatformRenderer)));
                    currentrenderer = (int)Settings.LinuxRenderer;
                    break;
                case Settings.Platform.Mac:
                    renderers.AddRange(Enum.GetNames(typeof(Settings.MacOSPlatformRenderer)));
                    currentrenderer = (int)Settings.MacOSRenderer;
                    break;
            }

            tab1.CreateAndAddDropDownRow("Platform Renderer", renderers, currentrenderer, (sender, e) =>
            {
                switch (GlobalSettings.Settings.RunningPlatform())
                {
                    case Settings.Platform.Windows:
                        Settings.WindowsRenderer = (Settings.WindowsPlatformRenderer)sender.SelectedIndex;
                        break;
                    case Settings.Platform.Linux:
                        Settings.LinuxRenderer = (Settings.LinuxPlatformRenderer)sender.SelectedIndex;
                        break;
                    case Settings.Platform.Mac:
                        Settings.MacOSRenderer = (Settings.MacOSPlatformRenderer)sender.SelectedIndex;
                        break;
                }
            });

            tab1.CreateAndAddDescriptionRow("This sets the GUI Renderer for the current platform. Recommended renderers for each platform are:\nWindows: WPF (Windows Presentation Foundation)\nLinux: GTK 2\nmacOS: MonoMac");
            tab1.CreateAndAddDescriptionRow("Changes to this setting will have effect upon application restart.");

            tab1.CreateAndAddLabelRow("Flowsheet Designer");

            tab1.CreateAndAddDropDownRow("Flowsheet Renderer", new List<string>() {"Software (CPU)", "Hardware (OpenGL)" }, (int)Settings.FlowsheetRenderer, (sender, e) =>
            {
                Settings.FlowsheetRenderer = (Settings.SkiaCanvasRenderer)sender.SelectedIndex;
            });

            tab1.CreateAndAddCheckBoxRow("EnableAntiAliasing".Localize(prefix), Settings.DrawingAntiAlias, (CheckBox sender, EventArgs obj) => { Settings.DrawingAntiAlias = sender.Checked.Value; });
            tab1.CreateAndAddDescriptionRow("Sets anti-aliasing (edge smoothing) for the Flowsheet Designer.");

            tab1.CreateAndAddLabelRow("Editors");

            var sizes = new[] { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };

            if (Settings.EditorFontSize == -1) Settings.EditorFontSize = (int)(new Eto.Drawing.Font(Eto.Drawing.SystemFont.Label).Size);

            tab1.CreateAndAddDropDownRow("Font Size (Editor Labels/Descriptions)", sizes.ToList(), sizes.ToList().IndexOf(Settings.EditorFontSize.ToString()), (DropDown sender, EventArgs obj) => { Settings.EditorFontSize = int.Parse(sender.SelectedValue.ToString()); });
            tab1.CreateAndAddDescriptionRow("Sets the Font Size for Editor labels and descriptions.");

            tab1.CreateAndAddDropDownRow("Font Size (Text Reports)", sizes.ToList(), sizes.ToList().IndexOf(Settings.ResultsReportFontSize.ToString()), (DropDown sender, EventArgs obj) => { Settings.ResultsReportFontSize = int.Parse(sender.SelectedValue.ToString()); });
            tab1.CreateAndAddDescriptionRow("Sets the Font Size for text reports.");

            tab1.CreateAndAddCheckBoxRow("Fix Size of Input Controls", Settings.EditorTextBoxFixedSize, (CheckBox sender, EventArgs obj) => { Settings.EditorTextBoxFixedSize = sender.Checked.Value; });
            tab1.CreateAndAddDescriptionRow("Fix the size of input textboxes and checkboxes on editors.");

            tab1.CreateAndAddCheckBoxRow("View/Open Object Editor After Selection", Settings.EditOnSelect, (CheckBox sender, EventArgs obj) => { Settings.EditOnSelect = sender.Checked.Value; });
            tab1.CreateAndAddDescriptionRow("Opens the object editor after selection on the flowsheet.");

            tab1.CreateAndAddCheckBoxRow("Call Solver on Editor Property Update", Settings.CallSolverOnEditorPropertyChanged, (CheckBox sender, EventArgs obj) => { Settings.CallSolverOnEditorPropertyChanged = sender.Checked.Value; });
            tab1.CreateAndAddDescriptionRow("Requests a flowsheet calculation after an object property is changed/updated on the editor.");

            var tab2 = Common.GetDefaultContainer();
            tab2.Tag = "Solver".Localize(prefix);

            tab2.CreateAndAddLabelRow("ControlOptions".Localize(prefix));
            tab2.CreateAndAddCheckBoxRow("EnableCPUParallelProcessing".Localize(prefix), Settings.EnableParallelProcessing, (CheckBox sender, EventArgs obj) => { Settings.EnableParallelProcessing = sender.Checked.GetValueOrDefault(); });
            tab2.CreateAndAddDescriptionRow("Enables utilization of all CPU cores during flowsheet calculations.");
            tab2.CreateAndAddCheckBoxRow("EnableCPUSIMDAccel".Localize(prefix), Settings.UseSIMDExtensions, (CheckBox sender, EventArgs obj) => { Settings.UseSIMDExtensions = sender.Checked.GetValueOrDefault(); });
            tab2.CreateAndAddDescriptionRow("Enables utilization of special CPU instructions for accelerated math calculations.");
            //tab2.CreateAndAddCheckBoxRow("EnableGPUAccel".Localize(prefix), Settings.EnableGPUProcessing, (CheckBox sender, EventArgs obj) => { Settings.EnableGPUProcessing = sender.Checked.Value; });
            tab2.CreateAndAddCheckBoxRow("BreakOnException".Localize(prefix), Settings.SolverBreakOnException, (CheckBox sender, EventArgs obj) => { Settings.SolverBreakOnException = sender.Checked.GetValueOrDefault(); });
            tab2.CreateAndAddDescriptionRow("If activated, the solver won't calculate the rest of the flowsheet if an error occurs during the calculation of an intermediate block/object.");

            tab2.CreateAndAddLabelRow("Solution Inspector");
            tab2.CreateAndAddCheckBoxRow("Enable Inspector Reports", Settings.InspectorEnabled, (CheckBox sender, EventArgs obj) => { Settings.InspectorEnabled = sender.Checked.GetValueOrDefault(); });
            tab2.CreateAndAddDescriptionRow("Enabling Inspector Reports will create model description and performance reports on-the-fly as the calculations are requested by the Flowsheet Solver. Use the Solution Inspector tool to view these reports.");
            tab2.CreateAndAddDescriptionRow("When the Inspector Reports feature is enabled and the Flowsheet Solver is called, the Parallel CPU Processing is automatically disabled. You must re-enable it manually and disable the Inspector to increase the calculation speed again.");
            tab2.CreateAndAddCheckBoxRow("Clear Previous Reports on new Flowsheet Calculation Request", Settings.ClearInspectorHistoryOnNewCalculationRequest, (CheckBox sender, EventArgs obj) => { Settings.ClearInspectorHistoryOnNewCalculationRequest = sender.Checked.GetValueOrDefault(); });
            tab2.CreateAndAddDescriptionRow("This will erase all previously stored reports when a new flowsheet calculation request is made by the user.");

            var tab3 = Common.GetDefaultContainer();
            tab3.Tag = "UserComps".Localize(prefix);

            tab3.CreateAndAddLabelRow("User-Defined Compound Datasets");
            var list1 = tab3.CreateAndAddListBoxRow(200, GlobalSettings.Settings.UserDatabases.ToArray(), null);
            tab3.CreateAndAddButtonRow("Add Dataset", null, (sender, e) =>
            {
                var dialog = new OpenFileDialog();
                dialog.Title = "Select File".Localize();
                dialog.Filters.Add(new FileFilter("Compound dataset files", new[] { ".xml", ".json" }));
                dialog.MultiSelect = false;
                dialog.CurrentFilterIndex = 0;
                if (dialog.ShowDialog(null) == DialogResult.Ok)
                {
                    if (!GlobalSettings.Settings.UserDatabases.Contains(dialog.FileName))
                    {
                        GlobalSettings.Settings.UserDatabases.Add(dialog.FileName);
                        list1.Items.Add(dialog.FileName);
                    }
                }
            });
            tab3.CreateAndAddButtonRow("Remove selected", null, (sender, e) => {
                GlobalSettings.Settings.UserDatabases.Remove(list1.SelectedValue.ToString());
                list1.Items.RemoveAt(list1.SelectedIndex);
            });

            tab3.CreateAndAddLabelRow("User-Defined Interaction Parameter Datasets");
            var list2 = tab3.CreateAndAddListBoxRow(200, GlobalSettings.Settings.UserInteractionsDatabases.ToArray(), null);
            tab3.CreateAndAddButtonRow("Add Dataset", null, (sender, e) =>
            {
                var dialog = new OpenFileDialog();
                dialog.Title = "Select File".Localize();
                dialog.Filters.Add(new FileFilter("Interaction Parameter dataset files", new[] { ".xml"}));
                dialog.MultiSelect = false;
                dialog.CurrentFilterIndex = 0;
                if (dialog.ShowDialog(null) == DialogResult.Ok)
                {
                    if (!GlobalSettings.Settings.UserInteractionsDatabases.Contains(dialog.FileName))
                    {
                        GlobalSettings.Settings.UserInteractionsDatabases.Add(dialog.FileName);
                        list2.Items.Add(dialog.FileName);
                    }
                }
            });
            tab3.CreateAndAddButtonRow("Remove selected", null, (sender, e) =>
            {
                GlobalSettings.Settings.UserInteractionsDatabases.Remove(list2.SelectedValue.ToString());
                list2.Items.RemoveAt(list2.SelectedIndex);
            });

            var tab4 = Common.GetDefaultContainer();
            tab4.Tag = "Backup".Localize(prefix);

            tab4.CreateAndAddLabelRow("BackupCopies".Localize(prefix));
            tab4.CreateAndAddCheckBoxRow("EnableBackupCopies".Localize(prefix), Settings.EnableBackupCopies, (CheckBox sender, EventArgs obj) => { Settings.EnableBackupCopies = sender.Checked.Value; });
            tab4.CreateAndAddEmptySpace();
            tab4.CreateAndAddTextBoxRow("N0", "BackupInterval".Localize(prefix), Settings.BackupInterval, (TextBox sender, EventArgs obj) => { Settings.BackupInterval = sender.Text.IsValidDouble() ? (int)sender.Text.ToDouble() : Settings.BackupInterval; });
            tab4.CreateAndAddEmptySpace();
            tab4.CreateAndAddButtonRow("PurgeBackupFolder".Localize(prefix), null, (sender, e) => {
                string backupdir = "";
                if (GlobalSettings.Settings.RunningPlatform() == GlobalSettings.Settings.Platform.Mac)
                {
                    backupdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents", "DWSIM Application Data", "Backup") + Path.DirectorySeparatorChar;
                }
                else
                {
                    backupdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DWSIM Application Data", "Backup") + Path.DirectorySeparatorChar;
                }
                var files = Directory.GetFiles(backupdir);
                foreach (var file in files)
                {
                    try {
                        File.Delete(file);
                    }
                    catch { }
                }
            });
            tab4.CreateAndAddEmptySpace();

            var tab5 = Common.GetDefaultContainer();
            tab5.Tag = "Misc".Localize(prefix);
            
            tab5.CreateAndAddLabelRow("Octave Settings");
            tab5.CreateAndAddDescriptionRow("Setup the path for Octave binaries to enable integration with DWSIM.");
            TextBox tbox = null;
            tbox = tab5.CreateAndAddLabelAndTextBoxAndButtonRow("Binaries Path", GlobalSettings.Settings.OctavePath, "Search", null,
                (sender, e) => GlobalSettings.Settings.OctavePath = sender.Text,
                (sender, e) =>
                {
                    var searchdialog = new SelectFolderDialog() { Title = "Search", Directory = GlobalSettings.Settings.OctavePath };
                    if (searchdialog.ShowDialog(tab5) == DialogResult.Ok)
                    {
                        tbox.Text = searchdialog.Directory;
                    }
                });
            tab5.CreateAndAddTextBoxRow("N0", "Calling Timeout (minutes)", GlobalSettings.Settings.OctaveTimeoutInMinutes, (sender, e) =>
            {
                if (sender.Text.IsValidDouble()) GlobalSettings.Settings.OctaveTimeoutInMinutes = sender.Text.ToDouble();
            });

            tab5.CreateAndAddLabelRow("Python Settings");
            tab5.CreateAndAddDescriptionRow("Setup the path for Python binaries to enable integration with DWSIM.");
            TextBox tbox2 = null;
            tbox2 = tab5.CreateAndAddLabelAndTextBoxAndButtonRow("Binaries Path", GlobalSettings.Settings.PythonPath, "Search", null,
                (sender, e) => GlobalSettings.Settings.PythonPath = sender.Text,
                (sender, e) =>
                {
                    var searchdialog = new SelectFolderDialog() { Title = "Search", Directory = GlobalSettings.Settings.PythonPath };
                    if (searchdialog.ShowDialog(tab5) == DialogResult.Ok)
                    {
                        tbox2.Text = searchdialog.Directory;
                    }
                });
            tab5.CreateAndAddTextBoxRow("N0", "Calling Timeout (minutes)", GlobalSettings.Settings.PythonTimeoutInMinutes, (sender, e) =>
            {
                if (sender.Text.IsValidDouble()) GlobalSettings.Settings.PythonTimeoutInMinutes = sender.Text.ToDouble();
            });

            return Common.GetDefaultTabbedForm("Title".Localize(prefix), 700, 550, new[] { tab1, tab2, tab3, tab4, tab5 });

        }


    }
}
