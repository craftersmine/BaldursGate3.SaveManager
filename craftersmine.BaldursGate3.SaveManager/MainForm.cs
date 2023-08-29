using craftersmine.BaldursGate3.SaveManager.Core;

using Imazen.WebP;

namespace craftersmine.BaldursGate3.SaveManager
{
    public partial class MainForm : Form
    {
        private SimpleDecoder webpDecoder = new SimpleDecoder();
        List<BaldursGateSave> saves = new List<BaldursGateSave>();

        public MainForm()
        {
            InitializeComponent();

            //DirectoryInfo savesDir = new DirectoryInfo("D:\\_TEMP\\Test");
            DirectoryInfo savesDir = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Larian Studios", "Baldur's Gate 3", "PlayerProfiles", "Public", "Savegames", "Story"));

            Text = "Baldur's Gate 3 Saves Manager - " + savesDir.FullName;

            foreach (DirectoryInfo saveDir in savesDir.EnumerateDirectories())
            {
                string saveFile = saveDir.EnumerateFiles("*.lsv", SearchOption.TopDirectoryOnly).First().FullName;
                BaldursGateSave save = new BaldursGateSave(saveFile);
                saves.Add(save);
            }

            saves.Sort((x, y) => y.LastModified.CompareTo(x.LastModified));

            savesList.Items.AddRange(saves.ToArray());
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (savesList.SelectedItem is not null)
            {
                byte[] data = File.ReadAllBytes(((BaldursGateSave)savesList.SelectedItem).ScreenshotPath);
                saveImage.BackgroundImage = webpDecoder.DecodeFromBytes(data, data.Length);
                FillSaveInfo(((BaldursGateSave)savesList.SelectedItem));
            }
        }

        private void FillSaveInfo(BaldursGateSave save)
        {
            saveName.Text = string.Format("Save Name: {0}", save.SaveInformation.Name);
            leaderName.Text = string.Format("Leader Name: {0}", save.LeaderName);
            gameVersion.Text = string.Format("Game Version: {0}", save.SaveInformation.GameVersion);
            difficulty.Text = string.Format("Difficulty: {0}", string.Join(", ", save.SaveInformation.Difficulty));
            currentWorldLevel.Text = string.Format("Current World Level: {0}", save.SaveInformation.CurrentLevel);
            activePartyCount.Text = string.Format("Party Members Count: {0} entities (players/characters/companions)",
                save.SaveInformation.ActiveParty.Characters.Length);
        }

        private void deleteCurrentSaveClick(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you really want to delete this save? This action is irreversable!", "Deleting Save!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                case DialogResult.Yes:
                    if (savesList.SelectedItem is not null)
                    {
                        BaldursGateSave save = (BaldursGateSave)savesList.SelectedItem;
                        if (DeleteSave(save))
                        {
                            savesList.Items.Remove(save);
                            saves.Remove(save);
                        }
                    }
                    break;
            }
        }

        private bool DeleteSave(BaldursGateSave save)
        {
            try
            {
                save.Delete();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to remove save \"" + save.ToString() + "\"! " + exception.Message);
            }

            return false;
        }

        private void deleteSelectedSaves_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you really want to delete selected saves? This action is irreversable!", "Deleting Saves!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                case DialogResult.Yes:
                    if (savesList.CheckedItems.Count > 0)
                    {
                        for (int i = 0; i < savesList.CheckedItems.Count; i++)
                        {
                            BaldursGateSave save = (BaldursGateSave)savesList.CheckedItems[i];
                            if (!DeleteSave(save))
                                break;
                        }

                        while (savesList.CheckedItems.Count > 0)
                        {
                            BaldursGateSave save = (BaldursGateSave)savesList.CheckedItems[0];
                            saves.Remove(save);
                            savesList.Items.Remove(save);
                        }
                    }
                    break;
            }
        }

        private SaveArchiver? currentArchiver;

        private async void archiveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (RequestOutputFile(out string filename))
                {
                    using (currentArchiver = new SaveArchiver(saves.ToArray(), filename))
                    {
                        currentArchiver.OnArchivingStatusChanged += Archiver_OnArchivingStatusChanged;
                        currentArchiver.OnArchiveCreated += Archiver_OnArchiveCreated;
                        await currentArchiver.CreateArchiveAsync();
                        if (currentArchiver is not null)
                            currentArchiver.Dispose();
                        currentArchiver = null;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred! " + exception.Message, "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Archiver_OnArchiveCreated(object? sender, ArchivingCompletedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(SetStatusCompleted, e.IsCancelled, ((SaveArchiver)sender).OutputFile);
            else
                SetStatusCompleted(e.IsCancelled, ((SaveArchiver)sender).OutputFile);
        }

        private void SetStatusCompleted(bool cancelled, string outputFile)
        {
            if (!cancelled)
            {
                status.Text = "Archiving completed! Archive: " + outputFile;
                statusProgress.Visible = false;
                cancelButton.Visible = false;
            }
            else
            {
                status.Text = "Archiving cancelled by user!";
                statusProgress.Visible = false;
                cancelButton.Visible = false;
            }
        }

        private void Archiver_OnArchivingStatusChanged(object? sender, ArchivingStatusEventArgs e)
        {
            if (InvokeRequired)
                Invoke(SetStatusChanged, e.Save, e.Total, e.Processed);
            else
                SetStatusChanged(e.Save, e.Total, e.Processed);
        }

        private void SetStatusChanged(BaldursGateSave currentSave, int total, int processed)
        {
            float progress = ((float)processed / (float)total) * 100f;
            status.Text = string.Format("Archiving save: {0}... {1}/{2} - {3:F2}%", currentSave.ToString(), processed,
                total, progress);
            statusProgress.Value = (int)progress;
            statusProgress.Visible = true;
            cancelButton.Visible = true;
        }

        private bool RequestOutputFile(out string filename)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.AddExtension = true;
                saveFileDialog.Filter = "Zip Archives (*.zip)|*.zip|All Files (*.*)|*.*";
                saveFileDialog.SupportMultiDottedExtensions = true;
                saveFileDialog.AutoUpgradeEnabled = true;
                saveFileDialog.ShowHelp = false;
                saveFileDialog.Title = "Select the output saves backup archive file";
                switch (saveFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        filename = saveFileDialog.FileName;
                        return true;
                    case DialogResult.Cancel:
                        filename = string.Empty;
                        return false;
                }
            }

            filename = string.Empty;
            return false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you really want to cancel creating archive?", "Cancel archive creation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    currentArchiver?.Cancel();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private async void archiveSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (savesList.CheckedItems.Count <= 0)
                {
                    MessageBox.Show("No saves selected to archive!", "No saves selected!", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (RequestOutputFile(out string filename))
                {
                    using (currentArchiver = new SaveArchiver(savesList.CheckedItems.Cast<BaldursGateSave>().ToArray(), filename))
                    {
                        currentArchiver.OnArchivingStatusChanged += Archiver_OnArchivingStatusChanged;
                        currentArchiver.OnArchiveCreated += Archiver_OnArchiveCreated;
                        await currentArchiver.CreateArchiveAsync();
                        if (currentArchiver is not null)
                            currentArchiver.Dispose();
                        currentArchiver = null;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred! " + exception.Message, "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}