namespace craftersmine.BaldursGate3.SaveManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveImage = new PictureBox();
            savesList = new CheckedListBox();
            deleteCurrentSave = new Button();
            deleteSelectedSaves = new Button();
            statusStrip1 = new StatusStrip();
            status = new ToolStripStatusLabel();
            statusProgress = new ToolStripProgressBar();
            cancelButton = new ToolStripDropDownButton();
            archiveSelected = new Button();
            archiveAll = new Button();
            groupBox1 = new GroupBox();
            activePartyCount = new Label();
            currentWorldLevel = new Label();
            difficulty = new Label();
            gameVersion = new Label();
            leaderName = new Label();
            saveName = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)saveImage).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // saveImage
            // 
            saveImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveImage.BackgroundImageLayout = ImageLayout.Stretch;
            saveImage.ImageLocation = "";
            saveImage.Location = new Point(374, 12);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(400, 225);
            saveImage.TabIndex = 0;
            saveImage.TabStop = false;
            // 
            // savesList
            // 
            savesList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            savesList.FormattingEnabled = true;
            savesList.Location = new Point(12, 12);
            savesList.Name = "savesList";
            savesList.Size = new Size(356, 544);
            savesList.TabIndex = 1;
            savesList.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // deleteCurrentSave
            // 
            deleteCurrentSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteCurrentSave.FlatStyle = FlatStyle.System;
            deleteCurrentSave.Location = new Point(6, 51);
            deleteCurrentSave.Name = "deleteCurrentSave";
            deleteCurrentSave.Size = new Size(160, 23);
            deleteCurrentSave.TabIndex = 3;
            deleteCurrentSave.Text = "Delete Current";
            deleteCurrentSave.UseVisualStyleBackColor = true;
            deleteCurrentSave.Click += deleteCurrentSaveClick;
            // 
            // deleteSelectedSaves
            // 
            deleteSelectedSaves.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteSelectedSaves.FlatStyle = FlatStyle.System;
            deleteSelectedSaves.Location = new Point(6, 22);
            deleteSelectedSaves.Name = "deleteSelectedSaves";
            deleteSelectedSaves.Size = new Size(160, 23);
            deleteSelectedSaves.TabIndex = 4;
            deleteSelectedSaves.Text = "Delete Selected";
            deleteSelectedSaves.UseVisualStyleBackColor = true;
            deleteSelectedSaves.Click += deleteSelectedSaves_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { status, statusProgress, cancelButton });
            statusStrip1.Location = new Point(0, 579);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            status.Name = "status";
            status.Size = new Size(769, 17);
            status.Spring = true;
            status.Text = "Ready";
            status.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusProgress
            // 
            statusProgress.Name = "statusProgress";
            statusProgress.Size = new Size(150, 16);
            statusProgress.Visible = false;
            // 
            // cancelButton
            // 
            cancelButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cancelButton.Image = Properties.Resources.cancel;
            cancelButton.ImageTransparentColor = Color.Magenta;
            cancelButton.Name = "cancelButton";
            cancelButton.ShowDropDownArrow = false;
            cancelButton.Size = new Size(20, 20);
            cancelButton.Text = "toolStripDropDownButton1";
            cancelButton.Visible = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // archiveSelected
            // 
            archiveSelected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            archiveSelected.FlatStyle = FlatStyle.System;
            archiveSelected.Location = new Point(6, 51);
            archiveSelected.Name = "archiveSelected";
            archiveSelected.Size = new Size(196, 23);
            archiveSelected.TabIndex = 6;
            archiveSelected.Text = "Archive Selected";
            archiveSelected.UseVisualStyleBackColor = true;
            archiveSelected.Click += archiveSelected_Click;
            // 
            // archiveAll
            // 
            archiveAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            archiveAll.FlatStyle = FlatStyle.System;
            archiveAll.Location = new Point(6, 22);
            archiveAll.Name = "archiveAll";
            archiveAll.Size = new Size(196, 23);
            archiveAll.TabIndex = 7;
            archiveAll.Text = "Archive All";
            archiveAll.UseVisualStyleBackColor = true;
            archiveAll.Click += archiveAll_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(activePartyCount);
            groupBox1.Controls.Add(currentWorldLevel);
            groupBox1.Controls.Add(difficulty);
            groupBox1.Controls.Add(gameVersion);
            groupBox1.Controls.Add(leaderName);
            groupBox1.Controls.Add(saveName);
            groupBox1.Location = new Point(374, 243);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(398, 180);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Save Info";
            // 
            // activePartyCount
            // 
            activePartyCount.Location = new Point(6, 110);
            activePartyCount.Name = "activePartyCount";
            activePartyCount.Size = new Size(386, 18);
            activePartyCount.TabIndex = 5;
            activePartyCount.Text = "Party Members Count: n/a";
            // 
            // currentWorldLevel
            // 
            currentWorldLevel.Location = new Point(6, 92);
            currentWorldLevel.Name = "currentWorldLevel";
            currentWorldLevel.Size = new Size(386, 18);
            currentWorldLevel.TabIndex = 4;
            currentWorldLevel.Text = "Current World Level: n/a";
            // 
            // difficulty
            // 
            difficulty.Location = new Point(6, 74);
            difficulty.Name = "difficulty";
            difficulty.Size = new Size(386, 18);
            difficulty.TabIndex = 3;
            difficulty.Text = "Difficulty: n/a";
            // 
            // gameVersion
            // 
            gameVersion.Location = new Point(6, 56);
            gameVersion.Name = "gameVersion";
            gameVersion.Size = new Size(386, 18);
            gameVersion.TabIndex = 2;
            gameVersion.Text = "Game Version: n/a";
            // 
            // leaderName
            // 
            leaderName.Location = new Point(6, 38);
            leaderName.Name = "leaderName";
            leaderName.Size = new Size(386, 18);
            leaderName.TabIndex = 1;
            leaderName.Text = "Leader Name: n/a";
            // 
            // saveName
            // 
            saveName.Location = new Point(6, 19);
            saveName.Name = "saveName";
            saveName.Size = new Size(386, 19);
            saveName.TabIndex = 0;
            saveName.Text = "Save Name: n/a";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(374, 429);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(398, 127);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tasks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkGray;
            label1.Location = new Point(660, 559);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 10;
            label1.Text = "© craftersmine 2023";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(archiveAll);
            groupBox3.Controls.Add(archiveSelected);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(208, 84);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Archive to ZIP";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(deleteSelectedSaves);
            groupBox4.Controls.Add(deleteCurrentSave);
            groupBox4.Location = new Point(220, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(172, 84);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Delete Saves";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 601);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(savesList);
            Controls.Add(saveImage);
            MinimumSize = new Size(800, 640);
            Name = "MainForm";
            Text = "Baldur's Gate Save Manager - {savesPath}";
            ((System.ComponentModel.ISupportInitialize)saveImage).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox saveImage;
        private CheckedListBox savesList;
        private Button deleteCurrentSave;
        private Button deleteSelectedSaves;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel status;
        private ToolStripProgressBar statusProgress;
        private ToolStripDropDownButton cancelButton;
        private Button archiveSelected;
        private Button archiveAll;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label activePartyCount;
        private Label currentWorldLevel;
        private Label difficulty;
        private Label gameVersion;
        private Label leaderName;
        private Label saveName;
        private Label label1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}