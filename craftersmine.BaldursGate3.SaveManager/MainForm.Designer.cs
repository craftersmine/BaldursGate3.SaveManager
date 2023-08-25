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
            label1 = new Label();
            deleteCurrentSave = new Button();
            deleteSelectedSaves = new Button();
            ((System.ComponentModel.ISupportInitialize)saveImage).BeginInit();
            SuspendLayout();
            // 
            // saveImage
            // 
            saveImage.BackgroundImageLayout = ImageLayout.Stretch;
            saveImage.ImageLocation = "";
            saveImage.Location = new Point(424, 12);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(400, 225);
            saveImage.TabIndex = 0;
            saveImage.TabStop = false;
            // 
            // savesList
            // 
            savesList.FormattingEnabled = true;
            savesList.Location = new Point(12, 12);
            savesList.Name = "savesList";
            savesList.Size = new Size(406, 436);
            savesList.TabIndex = 1;
            savesList.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(424, 240);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // deleteCurrentSave
            // 
            deleteCurrentSave.Location = new Point(626, 426);
            deleteCurrentSave.Name = "deleteCurrentSave";
            deleteCurrentSave.Size = new Size(197, 23);
            deleteCurrentSave.TabIndex = 3;
            deleteCurrentSave.Text = "Delete Current";
            deleteCurrentSave.UseVisualStyleBackColor = true;
            deleteCurrentSave.Click += deleteCurrentSaveClick;
            // 
            // deleteSelectedSaves
            // 
            deleteSelectedSaves.Location = new Point(424, 426);
            deleteSelectedSaves.Name = "deleteSelectedSaves";
            deleteSelectedSaves.Size = new Size(196, 23);
            deleteSelectedSaves.TabIndex = 4;
            deleteSelectedSaves.Text = "Delete Selected";
            deleteSelectedSaves.UseVisualStyleBackColor = true;
            deleteSelectedSaves.Click += deleteSelectedSaves_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 461);
            Controls.Add(deleteSelectedSaves);
            Controls.Add(deleteCurrentSave);
            Controls.Add(label1);
            Controls.Add(savesList);
            Controls.Add(saveImage);
            Name = "MainForm";
            Text = "Baldur's Gate Save Manager";
            ((System.ComponentModel.ISupportInitialize)saveImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox saveImage;
        private CheckedListBox savesList;
        private Label label1;
        private Button deleteCurrentSave;
        private Button deleteSelectedSaves;
    }
}