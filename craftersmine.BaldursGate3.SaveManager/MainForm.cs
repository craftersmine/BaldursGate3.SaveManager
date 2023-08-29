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
    }
}