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

        List<CountMedia> result;

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
            int amount = (int) SelectionPerMediaNumericUpDown.Value;

            // Parse Coupled Tags.
            string[] cTagsRaw = CoupledTagsTextBox.Lines;
            List<CoupledTag> cTags = new List<CoupledTag>(cTagsRaw.Length);
            foreach (string cTagRaw in cTagsRaw)
            {
                if (cTagRaw == null)
                    continue;

                string[] cTagRawInnerTags = cTagRaw.Split(new char[] { ',' });
                List<string> cTagRawInnerTagsTrimmed = new List<string>(cTagRawInnerTags.Length);
                foreach (string innerTag in cTagRawInnerTags)
                    cTagRawInnerTagsTrimmed.Add(innerTag.Trim());
                cTags.Add(new CoupledTag(cTagRawInnerTagsTrimmed));
            }

            // Parse user.
            User user = await Operation.UserFavoritesStatistics(AnilistUsernameTextBox.Text.Trim());

            // Run Activity Inject.
            ActivityInject activityInject = new ActivityInject(mediaIds, amount, listActivitionStatusSelection,
                user, cTags);
            result = await activityInject.RunActivityInject();

            // Go to next label with interactive UI to show results.

        }
    }
}
