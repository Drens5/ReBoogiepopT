using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReBoogiepopT
{
    public partial class ReBoogiepopTMainForm : Form
    {
        public ReBoogiepopTMainForm()
        {
            InitializeComponent();
        }

        List<CountMedia> resultMeanScoreSorted;
        List<CountMedia> resultLocalPopularitySorted;
        int indexMeanScoreSorted;
        int indexLocalPopularitySorted;
        int amountOfResults;
        int highestIndex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>An event listener, I suppose whatever class invokes the delegate has this method addeed as a 
        /// listener already, + indeed check the references.</remarks>
        private void MethodChoiceNextButton_Click(object sender, EventArgs e)
        {
            if (ActivityInjectRadioSelection.Checked)
            {
                MainPanel.Visible = false;
                MainPanel.Enabled = false;

                ActivityInjectPanel.Visible = true;
                ActivityInjectPanel.Enabled = true;
            }

            if (MetricLiftPlusActivityInjectRadioSelection.Checked)
            {
                MainPanel.Visible = false;
                MainPanel.Enabled = false;

                MetricLiftPanel.Visible = true;
                MetricLiftPanel.Enabled = true;
            }
        }

        private async void ActivityInjectRunButton_Click(object sender, EventArgs e)
        {
            // Make form unresponsive to user input.
            ActivityInjectPanel.Enabled = false;

            // User Update
            ActivityInjectStatusLabel.Text = "Parsing User Input.";
            ActivityInjectStatusLabel.Visible = true;

            // Parse inject media ids.
            String[] textMediaIds = InjectMediaTextBox.Text.Split(new char[] { ',' });
            List<int> mediaIds = new List<int>(textMediaIds.Length);
            foreach (string textMediaId in textMediaIds)
            {
                if (int.TryParse(textMediaId, out int mediaId))
                    mediaIds.Add(mediaId);
            }

            // Parse activity status.
            ActivityInject.ListActivityStatusSelection listActivitionStatusSelection;
            if (ActivityStatusSelectionRadioButtonAll.Checked)
                listActivitionStatusSelection = ActivityInject.ListActivityStatusSelection.All;
            else if (ActivityStatusSelectionRadioButtonCompleted.Checked)
                listActivitionStatusSelection = ActivityInject.ListActivityStatusSelection.CompletedOnly;
            else if (ActivityStatusSelectionRadioButtonNotPlanning.Checked)
                listActivitionStatusSelection = ActivityInject.ListActivityStatusSelection.NotPlanning;
            else
                throw new ArgumentException("Invalid ListActivityStatusSelection in MainForm.");

            // Parse Inject Amount.
            int amount = (int)SelectionPerMediaNumericUpDown.Value;

            // Parse Coupled Tags.
            List<CoupledTag> cTags;
            string[] cTagsRaw = CoupledTagsTextBox.Lines;
            if (cTagsRaw == null || cTagsRaw.Length == 0)
                cTags = null;
            else
            {
                cTags = new List<CoupledTag>(cTagsRaw.Length);
                foreach (string cTagRaw in cTagsRaw)
                {
                    // Skip lines with no text.
                    if (cTagRaw == null || cTagRaw.Length == 0)
                        continue;

                    string[] cTagRawInnerTags = cTagRaw.Split(new char[] { ',' });
                    List<string> cTagRawInnerTagsTrimmed = new List<string>(cTagRawInnerTags.Length);
                    foreach (string innerTag in cTagRawInnerTags)
                        cTagRawInnerTagsTrimmed.Add(innerTag.Trim());
                    cTags.Add(new CoupledTag(cTagRawInnerTagsTrimmed));
                }
            }

            // Parse user.
            User user = await Operation.UserFavoritesStatistics(AnilistUsernameTextBox.Text.Trim());

            // MetricLift Declerations, in case of addition.
            StatInfoMode statInfoMode;
            MetricMode metricMode;
            MetricLiftMode metricLiftMode;
            
            GenreAndTagStatInfo statInfo;
            Metric metric;
            MetricLift metricLift = null;

            // Set up metriclift.
            if (metriclift)
            {
                // User Update
                ActivityInjectStatusLabel.Text = "Setting up MetricLift.";

                // Parse StatInfoMode
                if (MetricLiftStatInfoRadioButtonQuick.Checked)
                    statInfoMode = StatInfoMode.Quick;
                else if (MetricLiftStatInfoRadioButtonSophisticated.Checked)
                    statInfoMode = StatInfoMode.Sophisticated;
                else if (MetricLiftStatInfoRadioButtonFavourites.Checked)
                    statInfoMode = StatInfoMode.Favourites;
                else
                    throw new ArgumentOutOfRangeException("Invalid StatInfoMode in MainForm MetricLiftPanel!");

                // Parse MetricMode
                if (MetricLiftMetricModeCountRadioButton.Checked)
                    metricMode = MetricMode.Count;
                else if (MetricLiftMetricModeMinutesWatchedRadioButton.Checked)
                    metricMode = MetricMode.MinutesWatched;
                else
                    throw new ArgumentOutOfRangeException("Invalid MetricMode in MainForm MetricLiftPanel!");

                // Parse MetricLiftMode
                if (MetricLiftModeArrowRadioButton.Checked)
                    metricLiftMode = MetricLiftMode.Arrow;
                else if (MetricLiftModeConnectionRadioButton.Checked)
                    metricLiftMode = MetricLiftMode.Connection;
                else
                    throw new ArgumentOutOfRangeException("Invalid MetricLiftMode in MainForm MetricLiftPanel!");

                statInfo = new GenreAndTagStatInfo(user, statInfoMode);
                await statInfo.Initialize();

                metric = new Metric(statInfo, metricMode);
                metricLift = new MetricLift(baseMediaId1, baseMediaId2, aptMediaId, metricLiftMode, metric);
            }

            // User Update
            ActivityInjectStatusLabel.Text = "Running Activity Inject.";

            // Run Activity Inject.
            ActivityInject activityInject = new ActivityInject(mediaIds, amount, listActivitionStatusSelection,
                user, cTags);

            List<CountMedia> result = null;
            List<Media> mediaToConsider = null;
            List<MetricLiftAggregation> metricLiftResults = null;

            // MetricLift + Activity Inject
            if (metriclift)
            {
                // Activity Inject part.
                mediaToConsider = await activityInject.ActivityInjectMediaSelection();

                // User Update
                ActivityInjectStatusLabel.Text = "Applying MetricLift.";

                // Apply MetricLift
                try
                {
                    // In this case, this is where the ArgumentNullException may appear, the one below is for solo activity inject.
                    metricLiftResults = await metricLift.ApplyMetricLift(mediaToConsider);
                }
                catch (ArgumentNullException)
                {
                    NoResultsLabel.Enabled = true;
                    NoResultsLabel.Visible = true;

                    // Disable the buttons
                    LocalPopularitySortedNextButton.Enabled = false;
                    LocalPopularitySortedPreviousButton.Enabled = false;
                    MeanScoreSortedNextButton.Enabled = false;
                    MeanScoreSortedPreviousButton.Enabled = false;

                    // Disable links
                    MeanScoreSortedLinkLabel.Enabled = false;
                    LocalPopularitySortedLinkLabel.Enabled = false;
                }
            }
            else
                // Running Activity Inject solo.
                result = await activityInject.RunActivityInject();

            // Go to next label with interactive UI to show results.
            ActivityInjectStatusLabel.Visible = false;
            ActivityInjectPanel.Visible = false;
            ResultsPanel.Enabled = true;
            ResultsPanel.Visible = true;

            try
            {
                if (metriclift)
                    InteractiveMetricLiftResultsPanel(metricLiftResults);
                else
                    InteractiveMeanScoreAndLocalPopularityResultsPanel(result);
            }
            catch (ArgumentNullException)
            {
                NoResultsLabel.Enabled = true;
                NoResultsLabel.Visible = true;

                // Disable the buttons
                LocalPopularitySortedNextButton.Enabled = false;
                LocalPopularitySortedPreviousButton.Enabled = false;
                MeanScoreSortedNextButton.Enabled = false;
                MeanScoreSortedPreviousButton.Enabled = false;

                // Disable links
                MeanScoreSortedLinkLabel.Enabled = false;
                LocalPopularitySortedLinkLabel.Enabled = false;
            }
            
        }

        List<MetricLiftAggregation> metricLiftResults;

        /// <summary>
        /// Displays the result of metriclift on the left section of the results panel.
        /// </summary>
        /// <param name="results">result of metriclift application.</param>
        /// <remarks>
        /// The left side of the original resultspanel of activity inject was named after mean score therefore those identifiers are
        /// in place.
        /// </remarks>
        private void InteractiveMetricLiftResultsPanel(List<MetricLiftAggregation> results)
        {
            if (results == null || results.Count == 0)
                throw new ArgumentNullException(nameof(results));

            amountOfResults = results.Count;
            highestIndex = amountOfResults - 1;

            metricLiftResults = results;

            // Show first one metriclift sorted.
            indexMeanScoreSorted = 0;
            DisplayMetricLiftSortedMedia();

            // Enable the buttons
            MeanScoreSortedNextButton.Enabled = true;
            MeanScoreSortedPreviousButton.Enabled = true;

            // Enable links
            MeanScoreSortedLinkLabel.Enabled = true;

            // Correct names of UI elements.
            MeanScoreLabel.Text = "Sorted by MetricLift's Delta.";

            // Hide all local popularity (which means right here) elements.
            LocalPopularityLabel.Visible = false;
            LocalPopularityPictureBox.Visible = false;
            LocalPopularitySortedAmountOutOf.Visible = false;
            LocalPopularitySortedLinkLabel.Visible = false;
            LocalPopularitySortedMediaTitleLabel.Visible = false;
            LocalPopularitySortedNextButton.Visible = false;
            LocalPopularitySortedPreviousButton.Visible = false;
        }

        private void InteractiveMeanScoreAndLocalPopularityResultsPanel(List<CountMedia> result)
        {
            if (result == null || result.Count == 0)
                throw new ArgumentNullException(nameof(result));

            amountOfResults = result.Count;
            highestIndex = amountOfResults - 1;

            // New list that is sorted by mean score.
            resultMeanScoreSorted = new List<CountMedia>(result);
            resultMeanScoreSorted.Sort(Aggregation.MeanScore);

            // New identifier for results which is sorted on local popularity.
            resultLocalPopularitySorted = result;
            resultLocalPopularitySorted.Sort(Aggregation.LocalPopularity);

            // Show first one mean score sorted.
            indexMeanScoreSorted = 0;
            DisplayMeanScoreSortedMedia();

            // Show first one local popularity sorted.
            indexLocalPopularitySorted = 0;
            DisplayLocalPopularitySortedMedia();

            // Enable the buttons
            LocalPopularitySortedNextButton.Enabled = true;
            LocalPopularitySortedPreviousButton.Enabled = true;
            MeanScoreSortedNextButton.Enabled = true;
            MeanScoreSortedPreviousButton.Enabled = true;

            // Enable links
            MeanScoreSortedLinkLabel.Enabled = true;
            LocalPopularitySortedLinkLabel.Enabled = true;
        }

        private void MeanScoreSortedLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MeanScoreSortedLinkLabel.Text);
        }

        private void LocalPopularitySortedLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LocalPopularitySortedLinkLabel.Text);
        }

        private void MeanScoreSortedNextButton_Click(object sender, EventArgs e)
        {
            if (indexMeanScoreSorted >= highestIndex)
                indexMeanScoreSorted = 0;
            else
                indexMeanScoreSorted++;

            if (metriclift)
                DisplayMetricLiftSortedMedia();
            else
                DisplayMeanScoreSortedMedia();
        }
        private void MeanScoreSortedPreviousButton_Click(object sender, EventArgs e)
        {
            if (indexMeanScoreSorted <= 0)
                indexMeanScoreSorted = highestIndex;
            else
                indexMeanScoreSorted--;

            if (metriclift)
                DisplayMetricLiftSortedMedia();
            else
                DisplayMeanScoreSortedMedia();
        }

        // Poor naming, but does what needs to be done.
        private void DisplayMetricLiftSortedMedia()
        {
            MetricLiftAggregation meanScoreSorted = metricLiftResults[indexMeanScoreSorted];
            MeanScorePictureBox.Load(meanScoreSorted.Media.CoverImage.Medium);
            MeanScoreSortedMediaTitleLabel.Text = meanScoreSorted.Media.Title.English != null ?
                meanScoreSorted.Media.Title.English : meanScoreSorted.Media.Title.Romaji != null ?
                meanScoreSorted.Media.Title.Romaji : meanScoreSorted.Media.Title.Native;
            MeanScoreSortedLinkLabel.Text = meanScoreSorted.Media.SiteUrl;
            MeanScoreSortedAmountOutOf.Text = (indexMeanScoreSorted + 1).ToString() + " / " + amountOfResults.ToString() + ", Delta: " +
                meanScoreSorted.BaseMinusInnerProductWithBase.ToString();
        }

        private void DisplayMeanScoreSortedMedia()
        {
            CountMedia meanScoreSorted = resultMeanScoreSorted[indexMeanScoreSorted];
            MeanScorePictureBox.Load(meanScoreSorted.Media.CoverImage.Medium);
            MeanScoreSortedMediaTitleLabel.Text = meanScoreSorted.Media.Title.English != null ?
                meanScoreSorted.Media.Title.English : meanScoreSorted.Media.Title.Romaji != null ?
                meanScoreSorted.Media.Title.Romaji : meanScoreSorted.Media.Title.Native;
            MeanScoreSortedLinkLabel.Text = meanScoreSorted.Media.SiteUrl;
            MeanScoreSortedAmountOutOf.Text = (indexMeanScoreSorted + 1).ToString() + " / " + amountOfResults.ToString() + ", Mean Score: " +
                meanScoreSorted.Media.MeanScore.ToString();
        }

        private void DisplayLocalPopularitySortedMedia()
        {
            CountMedia localPopularitySorted = resultLocalPopularitySorted[indexLocalPopularitySorted];
            LocalPopularityPictureBox.Load(localPopularitySorted.Media.CoverImage.Medium);
            LocalPopularitySortedMediaTitleLabel.Text = localPopularitySorted.Media.Title.English != null ?
                localPopularitySorted.Media.Title.English : localPopularitySorted.Media.Title.Romaji != null ?
                localPopularitySorted.Media.Title.Romaji : localPopularitySorted.Media.Title.Native;
            LocalPopularitySortedLinkLabel.Text = localPopularitySorted.Media.SiteUrl;
            LocalPopularitySortedAmountOutOf.Text = (indexLocalPopularitySorted + 1).ToString() + " / " + amountOfResults.ToString() +
                ", Local Popularity: " + localPopularitySorted.Count.ToString();
        }

        private void LocalPopularitySortedNextButton_Click(object sender, EventArgs e)
        {
            // Cyclic behaviour of buttons.
            if (indexLocalPopularitySorted >= highestIndex)
                indexLocalPopularitySorted = 0;
            else
                indexLocalPopularitySorted++;
            DisplayLocalPopularitySortedMedia();
        }

        private void LocalPopularitySortedPreviousButton_Click(object sender, EventArgs e)
        {
            if (indexLocalPopularitySorted <= 0)
                indexLocalPopularitySorted = highestIndex;
            else
                indexLocalPopularitySorted--;
            DisplayLocalPopularitySortedMedia();
        }

        private void ToMainPanelButton_Click(object sender, EventArgs e)
        {
            // Put UI properties back to default settings
            LocalPopularityLabel.Visible = true;
            LocalPopularityPictureBox.Visible = true;
            LocalPopularitySortedAmountOutOf.Visible = true;
            LocalPopularitySortedLinkLabel.Visible = true;
            LocalPopularitySortedMediaTitleLabel.Visible = true;
            LocalPopularitySortedNextButton.Visible = true;
            LocalPopularitySortedPreviousButton.Visible = true;

            MeanScoreLabel.Text = "Sorted by Mean Score";

            ActivityInjectPanelBackToMethodSelectionButton.Text = "Back to Method Selection";
            // This one isn't so bad, maybe even preferable.
            // InjectMediaTextBox.Text = "";

            ResultsPanel.Enabled = false;
            ResultsPanel.Visible = false;

            // No need to worry about GC, it happens on the next activity run.

            MainPanel.Visible = true;
            MainPanel.Enabled = true;

            // Make sure that if the previous attempt did not yield any results, the no results label is hidden.
            NoResultsLabel.Enabled = false;
            NoResultsLabel.Visible = false;

            // Reset field flags
            metriclift = false;
        }

        private void ActivityInjectPanelBackToMethodSelectionButton_Click(object sender, EventArgs e)
        {
            ActivityInjectPanel.Enabled = false;
            ActivityInjectPanel.Visible = false;

            MainPanel.Visible = true;
            MainPanel.Enabled = true;

            // Go back to previous form if metriclift was added.
            if (metriclift)
            {
                ActivityInjectPanel.Enabled = false;
                ActivityInjectPanel.Visible = false;

                MetricLiftPanel.Visible = true;
                MetricLiftPanel.Enabled = true;

                metriclift = false;

                ActivityInjectPanelBackToMethodSelectionButton.Text = "Back to Method Selection";
                InjectMediaTextBox.Text = "";
            }
        }

        /// <summary>
        /// It is required to have inject media filled in (properly).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InjectMediaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (InjectMediaTextBox.Text.Length != 0)
                ActivityInjectRunButton.Enabled = true;
            else
                ActivityInjectRunButton.Enabled = false;
        }

        /// <summary>
        /// Boolean flag for addition of metriclift to other methods.
        /// </summary>
        private bool metriclift;

        private void NextButtonMetricLift_Click(object sender, EventArgs e)
        {
            metriclift = true;

            MetricLiftPanel.Visible = false;
            MetricLiftPanel.Enabled = false;

            ActivityInjectPanel.Visible = true;
            ActivityInjectPanel.Enabled = true;

            InjectMediaTextBox.Text = BaseMediaId1TextBox.Text.Trim() + ", " + BaseMediaId2TextBox.Text.Trim()
                + ", " + AptMediaIdTextBox.Text.Trim();

            ActivityInjectPanelBackToMethodSelectionButton.Text = "Back to MetricLift";
        }

        // Helper booleans for verifying these text boxes on their input.
        private bool validBaseMedia1IdTextBox;
        private bool validBaseMedia2IdTextBox;
        private bool validAptMediaIdTextBox;

        /// <summary>
        /// Method to call on each change of the text boxes to be verified of their input.
        /// </summary>
        private void ToEnableNextButtonMetricLift()
        {
            if (validBaseMedia1IdTextBox && validBaseMedia2IdTextBox && validAptMediaIdTextBox)
                NextButtonMetricLift.Enabled = true;
            else
                NextButtonMetricLift.Enabled = false;
        }

        private int baseMediaId1;
        private int baseMediaId2;
        private int aptMediaId;

        private void BaseMediaId2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(BaseMediaId2TextBox.Text.Trim(), out int baseMediaId2))
            {
                validBaseMedia2IdTextBox = true;
                this.baseMediaId2 = baseMediaId2;
            }
            else
                validBaseMedia2IdTextBox = false;

            ToEnableNextButtonMetricLift();
        }

        private void BaseMediaId1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(BaseMediaId1TextBox.Text.Trim(), out int baseMediaId1))
            {
                validBaseMedia1IdTextBox = true;
                this.baseMediaId1 = baseMediaId1;
            }    
            else
                validBaseMedia1IdTextBox = false;

            ToEnableNextButtonMetricLift();
        }

        private void AptMediaIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(AptMediaIdTextBox.Text.Trim(), out int aptMediaId))
            {
                validAptMediaIdTextBox = true;
                this.aptMediaId = aptMediaId;
            }            else
                validAptMediaIdTextBox = false;

            ToEnableNextButtonMetricLift();
        }

        private void MetricLiftBackToMethodSelectionButton_Click(object sender, EventArgs e)
        {
            MetricLiftPanel.Visible = false;
            MetricLiftPanel.Enabled = false;

            MainPanel.Visible = true;
            MainPanel.Enabled = true;
        }
    }
}
