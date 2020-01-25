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

        }

        private async void ActivityInjectRunButton_Click(object sender, EventArgs e)
        {
            // Make form unresponsive to user input.
            ActivityInjectPanel.Enabled = false;

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

            // Run Activity Inject.
            ActivityInject activityInject = new ActivityInject(mediaIds, amount, listActivitionStatusSelection,
                user, cTags);
            List<CountMedia> result = await activityInject.RunActivityInject();

            // Go to next label with interactive UI to show results.
            ActivityInjectPanel.Visible = false;
            ResultsPanel.Enabled = true;
            ResultsPanel.Visible = true;

            try
            {
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
            DisplayMeanScoreSortedMedia();
        }
        private void MeanScoreSortedPreviousButton_Click(object sender, EventArgs e)
        {
            if (indexMeanScoreSorted <= 0)
                indexMeanScoreSorted = highestIndex;
            else
                indexMeanScoreSorted--;
            DisplayMeanScoreSortedMedia();
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
            ResultsPanel.Enabled = false;
            ResultsPanel.Visible = false;

            // No need to worry about GC, it happens on the next activity run.

            MainPanel.Visible = true;
            MainPanel.Enabled = true;

            // Make sure that if the previous attempt did not yield any results, the no results label is hidden.
            NoResultsLabel.Enabled = false;
            NoResultsLabel.Visible = false;
        }

        private void ActivityInjectPanelBackToMethodSelectionButton_Click(object sender, EventArgs e)
        {
            ActivityInjectPanel.Enabled = false;
            ActivityInjectPanel.Visible = false;

            MainPanel.Visible = true;
            MainPanel.Enabled = true;
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
    }
}
