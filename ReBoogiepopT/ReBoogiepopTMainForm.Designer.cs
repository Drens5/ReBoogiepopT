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
            this.CoupledTagsTextBox = new System.Windows.Forms.TextBox();
            this.SelectionFilteringCoupledTagsLabel = new System.Windows.Forms.Label();
            this.SelectionPerMediaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InjectAmountLabel = new System.Windows.Forms.Label();
            this.ActivityStatusSelectionRadioButtonNotPlanning = new System.Windows.Forms.RadioButton();
            this.ActivityStatusSelectionRadioButtonCompleted = new System.Windows.Forms.RadioButton();
            this.ActivityStatusSelectionRadioButtonAll = new System.Windows.Forms.RadioButton();
            this.ActivityStatusLabel = new System.Windows.Forms.Label();
            this.InjectMediaTextBox = new System.Windows.Forms.TextBox();
            this.InjectMediaLabel = new System.Windows.Forms.Label();
            this.AnilistUsernameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ActivityInjectRunButton = new System.Windows.Forms.Button();
            this.ActivityInjectTopText = new System.Windows.Forms.Label();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.LocalPopularitySortedNextButton = new System.Windows.Forms.Button();
            this.LocalPopularitySortedPreviousButton = new System.Windows.Forms.Button();
            this.MeanScoreSortedNextButton = new System.Windows.Forms.Button();
            this.MeanScoreSortedPreviousButton = new System.Windows.Forms.Button();
            this.LocalPopularitySortedLinkLabel = new System.Windows.Forms.LinkLabel();
            this.MeanScoreSortedLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LocalPopularitySortedMediaTitleLabel = new System.Windows.Forms.Label();
            this.MeanScoreSortedMediaTitleLabel = new System.Windows.Forms.Label();
            this.LocalPopularityPictureBox = new System.Windows.Forms.PictureBox();
            this.LocalPopularityLabel = new System.Windows.Forms.Label();
            this.MeanScoreLabel = new System.Windows.Forms.Label();
            this.ResultsPanelTopLabel = new System.Windows.Forms.Label();
            this.MeanScorePictureBox = new System.Windows.Forms.PictureBox();
            this.MeanScoreSortedAmountOutOf = new System.Windows.Forms.Label();
            this.LocalPopularitySortedAmountOutOf = new System.Windows.Forms.Label();
            this.ToMainPanelButton = new System.Windows.Forms.Button();
            this.ActivityInjectPanelBackToMethodSelectionButton = new System.Windows.Forms.Button();
            this.NoResultsLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.ActivityInjectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionPerMediaNumericUpDown)).BeginInit();
            this.ResultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalPopularityPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeanScorePictureBox)).BeginInit();
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
            this.ActivityInjectPanel.Controls.Add(this.ActivityInjectPanelBackToMethodSelectionButton);
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
            // CoupledTagsTextBox
            // 
            this.CoupledTagsTextBox.Location = new System.Drawing.Point(158, 233);
            this.CoupledTagsTextBox.Multiline = true;
            this.CoupledTagsTextBox.Name = "CoupledTagsTextBox";
            this.CoupledTagsTextBox.Size = new System.Drawing.Size(351, 109);
            this.CoupledTagsTextBox.TabIndex = 15;
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
            // InjectAmountLabel
            // 
            this.InjectAmountLabel.AutoSize = true;
            this.InjectAmountLabel.Location = new System.Drawing.Point(23, 181);
            this.InjectAmountLabel.Name = "InjectAmountLabel";
            this.InjectAmountLabel.Size = new System.Drawing.Size(104, 13);
            this.InjectAmountLabel.TabIndex = 11;
            this.InjectAmountLabel.Text = "Selection per Media:";
            // 
            // ActivityStatusSelectionRadioButtonNotPlanning
            // 
            this.ActivityStatusSelectionRadioButtonNotPlanning.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonNotPlanning.Location = new System.Drawing.Point(306, 139);
            this.ActivityStatusSelectionRadioButtonNotPlanning.Name = "ActivityStatusSelectionRadioButtonNotPlanning";
            this.ActivityStatusSelectionRadioButtonNotPlanning.Size = new System.Drawing.Size(86, 17);
            this.ActivityStatusSelectionRadioButtonNotPlanning.TabIndex = 10;
            this.ActivityStatusSelectionRadioButtonNotPlanning.Text = "Not Planning";
            this.ActivityStatusSelectionRadioButtonNotPlanning.UseVisualStyleBackColor = true;
            // 
            // ActivityStatusSelectionRadioButtonCompleted
            // 
            this.ActivityStatusSelectionRadioButtonCompleted.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonCompleted.Location = new System.Drawing.Point(211, 139);
            this.ActivityStatusSelectionRadioButtonCompleted.Name = "ActivityStatusSelectionRadioButtonCompleted";
            this.ActivityStatusSelectionRadioButtonCompleted.Size = new System.Drawing.Size(75, 17);
            this.ActivityStatusSelectionRadioButtonCompleted.TabIndex = 9;
            this.ActivityStatusSelectionRadioButtonCompleted.Text = "Completed";
            this.ActivityStatusSelectionRadioButtonCompleted.UseVisualStyleBackColor = true;
            // 
            // ActivityStatusSelectionRadioButtonAll
            // 
            this.ActivityStatusSelectionRadioButtonAll.AutoSize = true;
            this.ActivityStatusSelectionRadioButtonAll.Checked = true;
            this.ActivityStatusSelectionRadioButtonAll.Location = new System.Drawing.Point(158, 139);
            this.ActivityStatusSelectionRadioButtonAll.Name = "ActivityStatusSelectionRadioButtonAll";
            this.ActivityStatusSelectionRadioButtonAll.Size = new System.Drawing.Size(36, 17);
            this.ActivityStatusSelectionRadioButtonAll.TabIndex = 8;
            this.ActivityStatusSelectionRadioButtonAll.TabStop = true;
            this.ActivityStatusSelectionRadioButtonAll.Text = "All";
            this.ActivityStatusSelectionRadioButtonAll.UseVisualStyleBackColor = true;
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
            // InjectMediaTextBox
            // 
            this.InjectMediaTextBox.Location = new System.Drawing.Point(158, 99);
            this.InjectMediaTextBox.Name = "InjectMediaTextBox";
            this.InjectMediaTextBox.Size = new System.Drawing.Size(351, 20);
            this.InjectMediaTextBox.TabIndex = 6;
            this.InjectMediaTextBox.TextChanged += new System.EventHandler(this.InjectMediaTextBox_TextChanged);
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
            // AnilistUsernameTextBox
            // 
            this.AnilistUsernameTextBox.Location = new System.Drawing.Point(158, 60);
            this.AnilistUsernameTextBox.Name = "AnilistUsernameTextBox";
            this.AnilistUsernameTextBox.Size = new System.Drawing.Size(93, 20);
            this.AnilistUsernameTextBox.TabIndex = 4;
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
            // ActivityInjectRunButton
            // 
            this.ActivityInjectRunButton.Enabled = false;
            this.ActivityInjectRunButton.Location = new System.Drawing.Point(434, 348);
            this.ActivityInjectRunButton.Name = "ActivityInjectRunButton";
            this.ActivityInjectRunButton.Size = new System.Drawing.Size(75, 23);
            this.ActivityInjectRunButton.TabIndex = 1;
            this.ActivityInjectRunButton.Text = "Run";
            this.ActivityInjectRunButton.UseVisualStyleBackColor = true;
            this.ActivityInjectRunButton.Click += new System.EventHandler(this.ActivityInjectRunButton_Click);
            // 
            // ActivityInjectTopText
            // 
            this.ActivityInjectTopText.AutoSize = true;
            this.ActivityInjectTopText.Location = new System.Drawing.Point(3, 24);
            this.ActivityInjectTopText.Name = "ActivityInjectTopText";
            this.ActivityInjectTopText.Size = new System.Drawing.Size(77, 13);
            this.ActivityInjectTopText.TabIndex = 0;
            this.ActivityInjectTopText.Text = "Adjust Settings";
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.Controls.Add(this.NoResultsLabel);
            this.ResultsPanel.Controls.Add(this.ToMainPanelButton);
            this.ResultsPanel.Controls.Add(this.LocalPopularitySortedAmountOutOf);
            this.ResultsPanel.Controls.Add(this.MeanScoreSortedAmountOutOf);
            this.ResultsPanel.Controls.Add(this.LocalPopularitySortedNextButton);
            this.ResultsPanel.Controls.Add(this.LocalPopularitySortedPreviousButton);
            this.ResultsPanel.Controls.Add(this.MeanScoreSortedNextButton);
            this.ResultsPanel.Controls.Add(this.MeanScoreSortedPreviousButton);
            this.ResultsPanel.Controls.Add(this.LocalPopularitySortedLinkLabel);
            this.ResultsPanel.Controls.Add(this.MeanScoreSortedLinkLabel);
            this.ResultsPanel.Controls.Add(this.LocalPopularitySortedMediaTitleLabel);
            this.ResultsPanel.Controls.Add(this.MeanScoreSortedMediaTitleLabel);
            this.ResultsPanel.Controls.Add(this.LocalPopularityPictureBox);
            this.ResultsPanel.Controls.Add(this.LocalPopularityLabel);
            this.ResultsPanel.Controls.Add(this.MeanScoreLabel);
            this.ResultsPanel.Controls.Add(this.ResultsPanelTopLabel);
            this.ResultsPanel.Controls.Add(this.MeanScorePictureBox);
            this.ResultsPanel.Enabled = false;
            this.ResultsPanel.Location = new System.Drawing.Point(12, 12);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(512, 374);
            this.ResultsPanel.TabIndex = 4;
            this.ResultsPanel.Visible = false;
            // 
            // LocalPopularitySortedNextButton
            // 
            this.LocalPopularitySortedNextButton.Enabled = false;
            this.LocalPopularitySortedNextButton.Location = new System.Drawing.Point(390, 334);
            this.LocalPopularitySortedNextButton.Name = "LocalPopularitySortedNextButton";
            this.LocalPopularitySortedNextButton.Size = new System.Drawing.Size(43, 23);
            this.LocalPopularitySortedNextButton.TabIndex = 12;
            this.LocalPopularitySortedNextButton.Text = "Next";
            this.LocalPopularitySortedNextButton.UseVisualStyleBackColor = true;
            this.LocalPopularitySortedNextButton.Click += new System.EventHandler(this.LocalPopularitySortedNextButton_Click);
            // 
            // LocalPopularitySortedPreviousButton
            // 
            this.LocalPopularitySortedPreviousButton.Enabled = false;
            this.LocalPopularitySortedPreviousButton.Location = new System.Drawing.Point(306, 334);
            this.LocalPopularitySortedPreviousButton.Name = "LocalPopularitySortedPreviousButton";
            this.LocalPopularitySortedPreviousButton.Size = new System.Drawing.Size(43, 23);
            this.LocalPopularitySortedPreviousButton.TabIndex = 11;
            this.LocalPopularitySortedPreviousButton.Text = "Back";
            this.LocalPopularitySortedPreviousButton.UseVisualStyleBackColor = true;
            this.LocalPopularitySortedPreviousButton.Click += new System.EventHandler(this.LocalPopularitySortedPreviousButton_Click);
            // 
            // MeanScoreSortedNextButton
            // 
            this.MeanScoreSortedNextButton.Enabled = false;
            this.MeanScoreSortedNextButton.Location = new System.Drawing.Point(151, 334);
            this.MeanScoreSortedNextButton.Name = "MeanScoreSortedNextButton";
            this.MeanScoreSortedNextButton.Size = new System.Drawing.Size(43, 23);
            this.MeanScoreSortedNextButton.TabIndex = 10;
            this.MeanScoreSortedNextButton.Text = "Next";
            this.MeanScoreSortedNextButton.UseVisualStyleBackColor = true;
            this.MeanScoreSortedNextButton.Click += new System.EventHandler(this.MeanScoreSortedNextButton_Click);
            // 
            // MeanScoreSortedPreviousButton
            // 
            this.MeanScoreSortedPreviousButton.Enabled = false;
            this.MeanScoreSortedPreviousButton.Location = new System.Drawing.Point(68, 334);
            this.MeanScoreSortedPreviousButton.Name = "MeanScoreSortedPreviousButton";
            this.MeanScoreSortedPreviousButton.Size = new System.Drawing.Size(43, 23);
            this.MeanScoreSortedPreviousButton.TabIndex = 9;
            this.MeanScoreSortedPreviousButton.Text = "Back";
            this.MeanScoreSortedPreviousButton.UseVisualStyleBackColor = true;
            this.MeanScoreSortedPreviousButton.Click += new System.EventHandler(this.MeanScoreSortedPreviousButton_Click);
            // 
            // LocalPopularitySortedLinkLabel
            // 
            this.LocalPopularitySortedLinkLabel.AutoSize = true;
            this.LocalPopularitySortedLinkLabel.Enabled = false;
            this.LocalPopularitySortedLinkLabel.Location = new System.Drawing.Point(303, 303);
            this.LocalPopularitySortedLinkLabel.Name = "LocalPopularitySortedLinkLabel";
            this.LocalPopularitySortedLinkLabel.Size = new System.Drawing.Size(59, 13);
            this.LocalPopularitySortedLinkLabel.TabIndex = 8;
            this.LocalPopularitySortedLinkLabel.TabStop = true;
            this.LocalPopularitySortedLinkLabel.Text = "Media Link";
            this.LocalPopularitySortedLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LocalPopularitySortedLinkLabel_LinkClicked);
            // 
            // MeanScoreSortedLinkLabel
            // 
            this.MeanScoreSortedLinkLabel.AutoSize = true;
            this.MeanScoreSortedLinkLabel.Enabled = false;
            this.MeanScoreSortedLinkLabel.Location = new System.Drawing.Point(65, 303);
            this.MeanScoreSortedLinkLabel.Name = "MeanScoreSortedLinkLabel";
            this.MeanScoreSortedLinkLabel.Size = new System.Drawing.Size(59, 13);
            this.MeanScoreSortedLinkLabel.TabIndex = 7;
            this.MeanScoreSortedLinkLabel.TabStop = true;
            this.MeanScoreSortedLinkLabel.Text = "Media Link";
            this.MeanScoreSortedLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MeanScoreSortedLinkLabel_LinkClicked);
            // 
            // LocalPopularitySortedMediaTitleLabel
            // 
            this.LocalPopularitySortedMediaTitleLabel.AutoSize = true;
            this.LocalPopularitySortedMediaTitleLabel.Location = new System.Drawing.Point(303, 274);
            this.LocalPopularitySortedMediaTitleLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.LocalPopularitySortedMediaTitleLabel.Name = "LocalPopularitySortedMediaTitleLabel";
            this.LocalPopularitySortedMediaTitleLabel.Size = new System.Drawing.Size(59, 13);
            this.LocalPopularitySortedMediaTitleLabel.TabIndex = 6;
            this.LocalPopularitySortedMediaTitleLabel.Text = "Media Title";
            // 
            // MeanScoreSortedMediaTitleLabel
            // 
            this.MeanScoreSortedMediaTitleLabel.AutoSize = true;
            this.MeanScoreSortedMediaTitleLabel.Location = new System.Drawing.Point(65, 274);
            this.MeanScoreSortedMediaTitleLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.MeanScoreSortedMediaTitleLabel.Name = "MeanScoreSortedMediaTitleLabel";
            this.MeanScoreSortedMediaTitleLabel.Size = new System.Drawing.Size(59, 13);
            this.MeanScoreSortedMediaTitleLabel.TabIndex = 5;
            this.MeanScoreSortedMediaTitleLabel.Text = "Media Title";
            // 
            // LocalPopularityPictureBox
            // 
            this.LocalPopularityPictureBox.Location = new System.Drawing.Point(306, 118);
            this.LocalPopularityPictureBox.Name = "LocalPopularityPictureBox";
            this.LocalPopularityPictureBox.Size = new System.Drawing.Size(127, 138);
            this.LocalPopularityPictureBox.TabIndex = 4;
            this.LocalPopularityPictureBox.TabStop = false;
            // 
            // LocalPopularityLabel
            // 
            this.LocalPopularityLabel.AutoSize = true;
            this.LocalPopularityLabel.Location = new System.Drawing.Point(303, 80);
            this.LocalPopularityLabel.Name = "LocalPopularityLabel";
            this.LocalPopularityLabel.Size = new System.Drawing.Size(130, 13);
            this.LocalPopularityLabel.TabIndex = 3;
            this.LocalPopularityLabel.Text = "Sorted by Local Popularity";
            // 
            // MeanScoreLabel
            // 
            this.MeanScoreLabel.AutoSize = true;
            this.MeanScoreLabel.Location = new System.Drawing.Point(65, 80);
            this.MeanScoreLabel.Name = "MeanScoreLabel";
            this.MeanScoreLabel.Size = new System.Drawing.Size(113, 13);
            this.MeanScoreLabel.TabIndex = 2;
            this.MeanScoreLabel.Text = "Sorted by Mean Score";
            // 
            // ResultsPanelTopLabel
            // 
            this.ResultsPanelTopLabel.AutoSize = true;
            this.ResultsPanelTopLabel.Location = new System.Drawing.Point(36, 24);
            this.ResultsPanelTopLabel.Name = "ResultsPanelTopLabel";
            this.ResultsPanelTopLabel.Size = new System.Drawing.Size(42, 13);
            this.ResultsPanelTopLabel.TabIndex = 1;
            this.ResultsPanelTopLabel.Text = "Results";
            // 
            // MeanScorePictureBox
            // 
            this.MeanScorePictureBox.Location = new System.Drawing.Point(68, 118);
            this.MeanScorePictureBox.Name = "MeanScorePictureBox";
            this.MeanScorePictureBox.Size = new System.Drawing.Size(127, 138);
            this.MeanScorePictureBox.TabIndex = 0;
            this.MeanScorePictureBox.TabStop = false;
            // 
            // MeanScoreSortedAmountOutOf
            // 
            this.MeanScoreSortedAmountOutOf.AutoSize = true;
            this.MeanScoreSortedAmountOutOf.Location = new System.Drawing.Point(66, 102);
            this.MeanScoreSortedAmountOutOf.Name = "MeanScoreSortedAmountOutOf";
            this.MeanScoreSortedAmountOutOf.Size = new System.Drawing.Size(34, 13);
            this.MeanScoreSortedAmountOutOf.TabIndex = 13;
            this.MeanScoreSortedAmountOutOf.Text = "A/AO";
            // 
            // LocalPopularitySortedAmountOutOf
            // 
            this.LocalPopularitySortedAmountOutOf.AutoSize = true;
            this.LocalPopularitySortedAmountOutOf.Location = new System.Drawing.Point(303, 102);
            this.LocalPopularitySortedAmountOutOf.Name = "LocalPopularitySortedAmountOutOf";
            this.LocalPopularitySortedAmountOutOf.Size = new System.Drawing.Size(34, 13);
            this.LocalPopularitySortedAmountOutOf.TabIndex = 14;
            this.LocalPopularitySortedAmountOutOf.Text = "A/AO";
            // 
            // ToMainPanelButton
            // 
            this.ToMainPanelButton.Location = new System.Drawing.Point(375, 19);
            this.ToMainPanelButton.Name = "ToMainPanelButton";
            this.ToMainPanelButton.Size = new System.Drawing.Size(134, 23);
            this.ToMainPanelButton.TabIndex = 15;
            this.ToMainPanelButton.Text = "Quit to Method Selection";
            this.ToMainPanelButton.UseVisualStyleBackColor = true;
            this.ToMainPanelButton.Click += new System.EventHandler(this.ToMainPanelButton_Click);
            // 
            // ActivityInjectPanelBackToMethodSelectionButton
            // 
            this.ActivityInjectPanelBackToMethodSelectionButton.Location = new System.Drawing.Point(3, 348);
            this.ActivityInjectPanelBackToMethodSelectionButton.Name = "ActivityInjectPanelBackToMethodSelectionButton";
            this.ActivityInjectPanelBackToMethodSelectionButton.Size = new System.Drawing.Size(142, 23);
            this.ActivityInjectPanelBackToMethodSelectionButton.TabIndex = 16;
            this.ActivityInjectPanelBackToMethodSelectionButton.Text = "Back to Method Selection";
            this.ActivityInjectPanelBackToMethodSelectionButton.UseVisualStyleBackColor = true;
            this.ActivityInjectPanelBackToMethodSelectionButton.Click += new System.EventHandler(this.ActivityInjectPanelBackToMethodSelectionButton_Click);
            // 
            // NoResultsLabel
            // 
            this.NoResultsLabel.AutoSize = true;
            this.NoResultsLabel.Enabled = false;
            this.NoResultsLabel.Location = new System.Drawing.Point(52, 50);
            this.NoResultsLabel.Name = "NoResultsLabel";
            this.NoResultsLabel.Size = new System.Drawing.Size(269, 13);
            this.NoResultsLabel.TabIndex = 16;
            this.NoResultsLabel.Text = "No results for the settings provided, try a different query.";
            this.NoResultsLabel.Visible = false;
            // 
            // ReBoogiepopTMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 398);
            this.Controls.Add(this.ResultsPanel);
            this.Controls.Add(this.ActivityInjectPanel);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReBoogiepopTMainForm";
            this.Text = "ReBoogiepopT";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ActivityInjectPanel.ResumeLayout(false);
            this.ActivityInjectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionPerMediaNumericUpDown)).EndInit();
            this.ResultsPanel.ResumeLayout(false);
            this.ResultsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalPopularityPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeanScorePictureBox)).EndInit();
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
        private System.Windows.Forms.Label ResultsPanelTopLabel;
        private System.Windows.Forms.PictureBox MeanScorePictureBox;
        private System.Windows.Forms.Label MeanScoreLabel;
        private System.Windows.Forms.PictureBox LocalPopularityPictureBox;
        private System.Windows.Forms.Label LocalPopularityLabel;
        private System.Windows.Forms.Button LocalPopularitySortedNextButton;
        private System.Windows.Forms.Button LocalPopularitySortedPreviousButton;
        private System.Windows.Forms.Button MeanScoreSortedNextButton;
        private System.Windows.Forms.Button MeanScoreSortedPreviousButton;
        private System.Windows.Forms.LinkLabel LocalPopularitySortedLinkLabel;
        private System.Windows.Forms.LinkLabel MeanScoreSortedLinkLabel;
        private System.Windows.Forms.Label LocalPopularitySortedMediaTitleLabel;
        private System.Windows.Forms.Label MeanScoreSortedMediaTitleLabel;
        private System.Windows.Forms.Label LocalPopularitySortedAmountOutOf;
        private System.Windows.Forms.Label MeanScoreSortedAmountOutOf;
        private System.Windows.Forms.Button ToMainPanelButton;
        private System.Windows.Forms.Button ActivityInjectPanelBackToMethodSelectionButton;
        private System.Windows.Forms.Label NoResultsLabel;
    }
}

