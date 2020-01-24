namespace ReBoogiepopT
{
    partial class ReBoogiepopTMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReBoogiepopTMainForm));
            this.ChooseText = new System.Windows.Forms.Label();
            this.ActivityInjectRadioSelection = new System.Windows.Forms.RadioButton();
            this.MethodChoiceNextButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ActivityInjectPanel = new System.Windows.Forms.Panel();
            this.ActivityInjectTopText = new System.Windows.Forms.Label();
            this.ActivityInjectRunButton = new System.Windows.Forms.Button();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.AnilistUsernameTextBox = new System.Windows.Forms.TextBox();
            this.InjectMediaLabel = new System.Windows.Forms.Label();
            this.InjectMediaTextBox = new System.Windows.Forms.TextBox();
            this.ActivityStatusLabel = new System.Windows.Forms.Label();
            this.ActivityStatusSelectionRadioButtonAll = new System.Windows.Forms.RadioButton();
            this.ActivityStatusSelectionRadioButtonCompleted = new System.Windows.Forms.RadioButton();
            this.ActivityStatusSelectionRadioButtonNotPlanning = new System.Windows.Forms.RadioButton();
            this.InjectAmountLabel = new System.Windows.Forms.Label();
            this.SelectionPerMediaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SelectionFilteringCoupledTagsLabel = new System.Windows.Forms.Label();
            this.CoupledTagsTextBox = new System.Windows.Forms.TextBox();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.ActivityInjectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionPerMediaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseText
            // 
            this.ChooseText.AutoSize = true;
            this.ChooseText.Location = new System.Drawing.Point(23, 11);
            this.ChooseText.Name = "ChooseText";
            this.ChooseText.Size = new System.Drawing.Size(188, 13);
            this.ChooseText.TabIndex = 0;
            this.ChooseText.Text = "Choose your recommendation method:";
            // 
            // ActivityInjectRadioSelection
            // 
            this.ActivityInjectRadioSelection.AutoSize = true;
            this.ActivityInjectRadioSelection.Checked = true;
            this.ActivityInjectRadioSelection.Location = new System.Drawing.Point(39, 60);
            this.ActivityInjectRadioSelection.Name = "ActivityInjectRadioSelection";
            this.ActivityInjectRadioSelection.Size = new System.Drawing.Size(88, 17);
            this.ActivityInjectRadioSelection.TabIndex = 1;
            this.ActivityInjectRadioSelection.TabStop = true;
            this.ActivityInjectRadioSelection.Text = "Activity Inject";
            this.ActivityInjectRadioSelection.UseVisualStyleBackColor = true;
            // 
            // MethodChoiceNextButton
            // 
            this.MethodChoiceNextButton.Location = new System.Drawing.Point(434, 348);
            this.MethodChoiceNextButton.Name = "MethodChoiceNextButton";
            this.MethodChoiceNextButton.Size = new System.Drawing.Size(75, 23);
            this.MethodChoiceNextButton.TabIndex = 2;
            this.MethodChoiceNextButton.Text = "Next";
            this.MethodChoiceNextButton.UseVisualStyleBackColor = true;
            this.MethodChoiceNextButton.Click += new System.EventHandler(this.MethodChoiceNextButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MethodChoiceNextButton);
            this.MainPanel.Controls.Add(this.ChooseText);
            this.MainPanel.Controls.Add(this.ActivityInjectRadioSelection);
            this.MainPanel.Location = new System.Drawing.Point(12, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(512, 374);
            this.MainPanel.TabIndex = 3;
            // 
            // ActivityInjectPanel
            // 
            this.ActivityInjectPanel.Controls.Add(this.CoupledTagsTextBox);
            this.ActivityInjectPanel.Controls.Add(this.SelectionFilteringCoupledTagsLabel);
            this.ActivityInjectPanel.Controls.Add(this.SelectionPerMediaNumericUpDown);
            this.ActivityInjectPanel.Controls.Add(this.InjectAmountLabel);
            this.ActivityInjectPanel.Controls.Add(this.ActivityStatusSelectionRadioButtonNotPlanning);
            this.ActivityInjectPanel.Controls.Add(this.ActivityStatusSelectionRadioButtonCompleted);
            this.ActivityInjectPanel.Controls.Add(this.ActivityStatusSelectionRadioButtonAll);
            this.ActivityInjectPanel.Controls.Add(this.ActivityStatusLabel);
            this.ActivityInjectPanel.Controls.Add(this.InjectMediaTextBox);
            this.ActivityInjectPanel.Controls.Add(this.InjectMediaLabel);
            this.ActivityInjectPanel.Controls.Add(this.AnilistUsernameTextBox);
            this.ActivityInjectPanel.Controls.Add(this.UserNameLabel);
            this.ActivityInjectPanel.Controls.Add(this.ActivityInjectRunButton);
            this.ActivityInjectPanel.Controls.Add(this.ActivityInjectTopText);
            this.ActivityInjectPanel.Enabled = false;
            this.ActivityInjectPanel.Location = new System.Drawing.Point(12, 12);
            this.ActivityInjectPanel.Name = "ActivityInjectPanel";
            this.ActivityInjectPanel.Size = new System.Drawing.Size(512, 374);
            this.ActivityInjectPanel.TabIndex = 3;
            this.ActivityInjectPanel.Visible = false;
            // 
            // ActivityInjectTopText
            // 
            this.ActivityInjectTopText.AutoSize = true;
            this.ActivityInjectTopText.Location = new System.Drawing.Point(23, 24);
            this.ActivityInjectTopText.Name = "ActivityInjectTopText";
            this.ActivityInjectTopText.Size = new System.Drawing.Size(77, 13);
            this.ActivityInjectTopText.TabIndex = 0;
            this.ActivityInjectTopText.Text = "Adjust Settings";
            // 
            // ActivityInjectRunButton
            // 
            this.ActivityInjectRunButton.Location = new System.Drawing.Point(434, 348);
            this.ActivityInjectRunButton.Name = "ActivityInjectRunButton";
            this.ActivityInjectRunButton.Size = new System.Drawing.Size(75, 23);
            this.ActivityInjectRunButton.TabIndex = 1;
            this.ActivityInjectRunButton.Text = "Run";
            this.ActivityInjectRunButton.UseVisualStyleBackColor = true;
            this.ActivityInjectRunButton.Click += new System.EventHandler(this.ActivityInjectRunButton_Click);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(23, 63);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(88, 13);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "Anilist Username:";
            // 
            // AnilistUsernameTextBox
            // 
            this.AnilistUsernameTextBox.Location = new System.Drawing.Point(158, 60);
            this.AnilistUsernameTextBox.Name = "AnilistUsernameTextBox";
            this.AnilistUsernameTextBox.Size = new System.Drawing.Size(93, 20);
            this.AnilistUsernameTextBox.TabIndex = 4;
            // 
            // InjectMediaLabel
            // 
            this.InjectMediaLabel.AutoSize = true;
            this.InjectMediaLabel.Location = new System.Drawing.Point(23, 102);
            this.InjectMediaLabel.Name = "InjectMediaLabel";
            this.InjectMediaLabel.Size = new System.Drawing.Size(124, 13);
            this.InjectMediaLabel.TabIndex = 5;
            this.InjectMediaLabel.Text = "Media Requirement (ids):";
            // 
            // InjectMediaTextBox
            // 
            this.InjectMediaTextBox.Location = new System.Drawing.Point(158, 99);
            this.InjectMediaTextBox.Name = "InjectMediaTextBox";
            this.InjectMediaTextBox.Size = new System.Drawing.Size(351, 20);
            this.InjectMediaTextBox.TabIndex = 6;
            // 
            // ActivityStatusLabel
            // 
            this.ActivityStatusLabel.AutoSize = true;
            this.ActivityStatusLabel.Location = new System.Drawing.Point(23, 141);
            this.ActivityStatusLabel.Name = "ActivityStatusLabel";
            this.ActivityStatusLabel.Size = new System.Drawing.Size(77, 13);
            this.ActivityStatusLabel.TabIndex = 7;
            this.ActivityStatusLabel.Text = "Activity Status:";
            // 
            // ActivityStatusSelectionRadioButtonAll
            // 
            this.ActivityStatusSelectionRadioButtonAll.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonAll.Location = new System.Drawing.Point(158, 139);
            this.ActivityStatusSelectionRadioButtonAll.Name = "ActivityStatusSelectionRadioButtonAll";
            this.ActivityStatusSelectionRadioButtonAll.Size = new System.Drawing.Size(36, 17);
            this.ActivityStatusSelectionRadioButtonAll.TabIndex = 8;
            this.ActivityStatusSelectionRadioButtonAll.TabStop = true;
            this.ActivityStatusSelectionRadioButtonAll.Text = "All";
            this.ActivityStatusSelectionRadioButtonAll.UseVisualStyleBackColor = true;
            // 
            // ActivityStatusSelectionRadioButtonCompleted
            // 
            this.ActivityStatusSelectionRadioButtonCompleted.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonCompleted.Location = new System.Drawing.Point(211, 139);
            this.ActivityStatusSelectionRadioButtonCompleted.Name = "ActivityStatusSelectionRadioButtonCompleted";
            this.ActivityStatusSelectionRadioButtonCompleted.Size = new System.Drawing.Size(75, 17);
            this.ActivityStatusSelectionRadioButtonCompleted.TabIndex = 9;
            this.ActivityStatusSelectionRadioButtonCompleted.TabStop = true;
            this.ActivityStatusSelectionRadioButtonCompleted.Text = "Completed";
            this.ActivityStatusSelectionRadioButtonCompleted.UseVisualStyleBackColor = true;
            // 
            // ActivityStatusSelectionRadioButtonNotPlanning
            // 
            this.ActivityStatusSelectionRadioButtonNotPlanning.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonNotPlanning.Location = new System.Drawing.Point(306, 139);
            this.ActivityStatusSelectionRadioButtonNotPlanning.Name = "ActivityStatusSelectionRadioButtonNotPlanning";
            this.ActivityStatusSelectionRadioButtonNotPlanning.Size = new System.Drawing.Size(86, 17);
            this.ActivityStatusSelectionRadioButtonNotPlanning.TabIndex = 10;
            this.ActivityStatusSelectionRadioButtonNotPlanning.TabStop = true;
            this.ActivityStatusSelectionRadioButtonNotPlanning.Text = "Not Planning";
            this.ActivityStatusSelectionRadioButtonNotPlanning.UseVisualStyleBackColor = true;
            // 
            // InjectAmountLabel
            // 
            this.InjectAmountLabel.AutoSize = true;
            this.InjectAmountLabel.Location = new System.Drawing.Point(23, 181);
            this.InjectAmountLabel.Name = "InjectAmountLabel";
            this.InjectAmountLabel.Size = new System.Drawing.Size(104, 13);
            this.InjectAmountLabel.TabIndex = 11;
            this.InjectAmountLabel.Text = "Selection per Media:";
            // 
            // SelectionPerMediaNumericUpDown
            // 
            this.SelectionPerMediaNumericUpDown.Location = new System.Drawing.Point(158, 179);
            this.SelectionPerMediaNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SelectionPerMediaNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SelectionPerMediaNumericUpDown.Name = "SelectionPerMediaNumericUpDown";
            this.SelectionPerMediaNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.SelectionPerMediaNumericUpDown.TabIndex = 12;
            this.SelectionPerMediaNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // SelectionFilteringCoupledTagsLabel
            // 
            this.SelectionFilteringCoupledTagsLabel.AutoSize = true;
            this.SelectionFilteringCoupledTagsLabel.Location = new System.Drawing.Point(23, 217);
            this.SelectionFilteringCoupledTagsLabel.Name = "SelectionFilteringCoupledTagsLabel";
            this.SelectionFilteringCoupledTagsLabel.Size = new System.Drawing.Size(177, 39);
            this.SelectionFilteringCoupledTagsLabel.TabIndex = 13;
            this.SelectionFilteringCoupledTagsLabel.Text = "Coupled Tags for Selection Filtering:\r\n    Each Line Defines a\r\n    Coupled Tag\r\n" +
    "";
            // 
            // CoupledTagsTextBox
            // 
            this.CoupledTagsTextBox.Location = new System.Drawing.Point(158, 233);
            this.CoupledTagsTextBox.Multiline = true;
            this.CoupledTagsTextBox.Name = "CoupledTagsTextBox";
            this.CoupledTagsTextBox.Size = new System.Drawing.Size(351, 71);
            this.CoupledTagsTextBox.TabIndex = 15;
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.Location = new System.Drawing.Point(12, 12);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(512, 374);
            this.ResultsPanel.TabIndex = 4;
            // 
            // ReBoogiepopTMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 398);
            this.Controls.Add(this.ActivityInjectPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ResultsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReBoogiepopTMainForm";
            this.Text = "ReBoogiepopT";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ActivityInjectPanel.ResumeLayout(false);
            this.ActivityInjectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionPerMediaNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ChooseText;
        private System.Windows.Forms.RadioButton ActivityInjectRadioSelection;
        private System.Windows.Forms.Button MethodChoiceNextButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ActivityInjectPanel;
        private System.Windows.Forms.Label ActivityInjectTopText;
        private System.Windows.Forms.Button ActivityInjectRunButton;
        private System.Windows.Forms.TextBox AnilistUsernameTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label InjectMediaLabel;
        private System.Windows.Forms.TextBox InjectMediaTextBox;
        private System.Windows.Forms.RadioButton ActivityStatusSelectionRadioButtonNotPlanning;
        private System.Windows.Forms.RadioButton ActivityStatusSelectionRadioButtonCompleted;
        private System.Windows.Forms.RadioButton ActivityStatusSelectionRadioButtonAll;
        private System.Windows.Forms.Label ActivityStatusLabel;
        private System.Windows.Forms.Label InjectAmountLabel;
        private System.Windows.Forms.NumericUpDown SelectionPerMediaNumericUpDown;
        private System.Windows.Forms.TextBox CoupledTagsTextBox;
        private System.Windows.Forms.Label SelectionFilteringCoupledTagsLabel;
        private System.Windows.Forms.Panel ResultsPanel;
    }
}

