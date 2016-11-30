using System;
using System.Windows.Forms;
using System.Device.Location;
using System.Drawing;
using System.Collections.Generic;
using System.Net.Http;
using WindowsFormsApplication1.Models;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class GoLocalWindowsClient : Form
    {
        List<Control> controllist = new List<Control>(); //control list for news feed page
        List<Control> postlist = new List<Control>();//control list for post news page
        List<Panel> panelList = new List<Panel>(); //create a list for panels
        List<Control> completeFeedList = new List<Control>(); //list of controls on the complete feed page
        int index;//used for panel index....for previous and next buton
        int maxlength = 1000; // to limit the maximum length of textbox
        string apikey = "";
        string latLng = string.Empty;
        List<FeedModel> result = new List<FeedModel>();

        public GoLocalWindowsClient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // GetLocation();
            label2.Hide();
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            latLng = e.Position.Location.Latitude + "," + e.Position.Location.Longitude;
        }

        private async void login_Click(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
            userlabel.Hide();
            userinput.Hide();
            desclbl.Hide();
            homepagelogo.Hide();
            login.Hide();
            applogo.Show();
            post.Show();
            //int feedcount = 5;
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost:61731/api/FeedsService" + (latLng == string.Empty ? "" : "?latLng=" + latLng));
            request.Method = HttpMethod.Get;
            apikey = 123 + "-" + userinput.Text;
            request.Headers.Add("apiKey", apikey);
            HttpResponseMessage message = await client.SendAsync(request);
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<FeedModel>>(response);
            }
            createPanel(result); //calls method to create panels based on number of feeds received
            label1.Hide();
        }

        void createPanel(List<FeedModel> feed)
        {
            int feedcount = feed.Count;
            int noOfPanels = (int)Math.Ceiling(((double)feedcount) / 2); // calculate number of panels required
            //panel coordinates
            int panelx = 150;
            int panely = 70;
            //panel size
            int width = 400;
            int height = 400;
            int dispcount = 0; //number of feeds to be displayed on a panel
            for (int i = 0; i < noOfPanels; i++)
            {
                Panel pane = new Panel();
                pane.Name = "pane" + i;
                pane.AutoScroll = true;
                pane.Location = new Point(panelx, panely);
               // int paneheight = 0;
                if (feedcount <= 2)
                {
                    dispcount = feedcount;
                 //   paneheight = 195 * dispcount;
                }
                else
                {
                    dispcount = 2;
                    feedcount -= 2;
                   // paneheight = 195 * 5;
                }
                pane.Size = new Size(width, height);
                this.Controls.Add(pane);
                panelList.Add(pane);
                showNewsFeed(dispcount,i,result);
            }
            createNavButtons();
        }

        private void createNavButtons()
        {
            int btnx = 390;
            int btny = 485;
            int btnwidth = 70;
            int btnheight = 30;
            Button next = new Button();
            Button previous = new Button();
            next.Name = "btnnext";
            next.Text = "Next";
            previous.Name = "btnprevious";
            previous.Text = "Previous";

            //set location and size for buttons
            previous.Location = new Point(btnx, btny);
            previous.Size = new Size(btnwidth, btnheight);
            next.Location = new Point(btnx + btnwidth + 10, btny);
            next.Size = new Size(btnwidth, btnheight);
            this.Controls.Add(previous);
            this.Controls.Add(next);
            //on click previous and next buttons
            previous.Click += previous_click;
            next.Click += next_click;
        }

        private void next_click(object sender, EventArgs e)
        {
            if (index < panelList.Count - 1)
                panelList[++index].BringToFront();
        }

        private void previous_click(object sender, EventArgs e)
        {
            if (index > 0)
                panelList[--index].BringToFront();
        }

        void showNewsFeed(int feedcount, int panelindex, List<FeedModel> feeds)
        {

            //textbox coordinates relative to pane 
            int startx = 5;
            int starty = 10;
            int width = 369;
            int height = 153;
            //button coordinates relative to pane 
            int btnstartx = 214;
            int btnwidth = 70;
            int btnheight = 27;
            for (int i = 1; i <= feedcount; i++)
            {
                //create a textbox
                TextBox txtNumber = new TextBox();
                txtNumber.Name = "txtNumber_"+i;
                txtNumber.Text = feeds[(i+2*panelindex-1)].Content;

                //set properties of the textbox
                txtNumber.Multiline = true;
                txtNumber.ReadOnly = true;
                txtNumber.WordWrap = true;
                txtNumber.DoubleClick += txtNumber_click;
                txtNumber.ScrollBars = ScrollBars.Vertical;
                
                //set the location of the textbox
                txtNumber.Location = new Point(startx, starty);

                //set the size of the textbox               
                txtNumber.Size = new Size(width, height);

                // This adds a new TextBox
                this.Controls.Add(txtNumber);
                // add the textbox to the list
                controllist.Add(txtNumber);
                //add textbox to panel
                panelList[panelindex].Controls.Add(txtNumber);
                //adjust the height for the buttons
                starty += 5 + height;

                //create labels for upvote and downvote
                Button upvote = new Button();
                Button downvote = new Button();
                upvote.Name = "btnup" + 20 + i;
                upvote.Text = "Upvote";
                downvote.Name = "btndown" + 20 + i;
                downvote.Text = "Downvote";

                //set location and size for buttons
                upvote.Location = new Point(btnstartx, starty);
                upvote.Size = new Size(btnwidth, btnheight);
                downvote.Location = new Point(btnstartx + btnwidth + 10, starty);
                downvote.Size = new Size(btnwidth, btnheight);
                this.Controls.Add(upvote);
                this.Controls.Add(downvote);
                controllist.Add(upvote);
                controllist.Add(downvote);
                //add controls to the panel
                panelList[panelindex].Controls.Add(upvote);
                panelList[panelindex].Controls.Add(downvote);
                starty += btnheight + 10;
            }
            //label2.Location = new Point(startx, starty + 15);
            //label2.Show();
        }

        private void txtNumber_click(object sender, EventArgs e)
        {
            string name  = (sender as TextBox).Name;
            //int index1 = name.IndexOf("_");
            //int id = int.Parse((name.Substring(index1 + 1)));
            //MessageBox.Show("Hello");
            /* for (int i = 0; i < panelList.Count; i++)
             {
                 panelList[i].Hide();
             }*/
            int feedindex = panelList[index].Controls.GetChildIndex(sender as TextBox);
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Hide();
            }
            post.Hide();
            this.Controls.Find("btnnext", true)[0].Hide();
            this.Controls.Find("btnprevious", true)[0].Hide();
            TextBox completefeed = new TextBox();
            //create a textbox
            completefeed.Name = "completefeed";
            completefeed.Text = panelList[index].Controls[feedindex].Text;

            //set properties of the textbox
            completefeed.Multiline = true;
            completefeed.WordWrap = true;
            completefeed.MaxLength = maxlength+1000;
            completefeed.ScrollBars = ScrollBars.Vertical;

            //set the location of the textbox
            completefeed.Location = new Point(155, 80);

            //set the size of the textbox               
            completefeed.Size = new Size(369, 153);
            this.Controls.Add(completefeed);
            completeFeedList.Add(completefeed);
            completefeed.Show();

            Button backtocomplete = new Button();
            backtocomplete.Name = "btncomplete";
            backtocomplete.Text = "Back";
            backtocomplete.Location = new Point(454, 248);
            backtocomplete.Size = new Size(70, 30);
            this.Controls.Add(backtocomplete);
            completeFeedList.Add(backtocomplete);
            backtocomplete.Click += backtocomplete_click; 
            /*int panelx = 150;
            int panely = 70;
            //panel size
            int width = 400;
            int height = 400;
            Panel pane = new Panel();
            pane.Name = "panefull";
            pane.AutoScroll = true;
            pane.Location = new Point(panelx, panely);
            Button backtocomplete = new Button();
            backtocomplete.Name = "btncomplete";
            backtocomplete.Text = "Back";                                                                                                       
            upvote.Location = new Point(panelList[index], starty);
            upvote.Size = new Size(btnwidth, btnheight);
            */



            //this.Controls.Find(name, true)[0].Show();


        }

        private void backtocomplete_click(object sender, EventArgs e)
        {
            for (int i = 0; i < completeFeedList.Count; i++)
            {
                completeFeedList[i].Hide();
            }
            post.Show();
            this.Controls.Find("btnnext", true)[0].Show();
            this.Controls.Find("btnprevious", true)[0].Show();
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Show();
            }
        }

        //label for footer
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }*/

        //label for api key
        private void userlabel_Click(object sender, EventArgs e)
        {
        }
        //function for post news button click
        private void post_Click(object sender, EventArgs e)
        {
            // need to implement code to post a story to the app here
            // hide all elements and show only a textbox (+ image, if possible)
            // add a button to post the new story
            //hide the post news button
            post.Hide();
            //hide previous and next button
            this.Controls.Find("btnnext",true)[0].Hide();
            this.Controls.Find("btnprevious", true)[0].Hide();
            //for (int i = 0; i < controllist.Count; i++)
            for (int i = 0; i < panelList.Count; i++)
            {
                //controllist[i].Hide();
                panelList[i].Hide();
            }
            //create a textbox
            TextBox txtNumber = new TextBox();
            txtNumber.Name = "txtNumber" + 10;
            txtNumber.Text = "Post your news here";

            //set properties of the textbox
            txtNumber.Multiline = true;
            txtNumber.WordWrap = true;
            txtNumber.MaxLength = maxlength;
            txtNumber.ScrollBars = ScrollBars.Vertical;

            //set the location of the textbox
            txtNumber.Location = new Point(153, 82);

            //set the size of the textbox               
            txtNumber.Size = new Size(369, 153);

            // This adds a new TextBox
            this.Controls.Add(txtNumber);
            postlist.Add(txtNumber);

            //add post and back button
            Button postnews = new Button();
            Button back = new Button();
            postnews.Name = "btnpost" + 20;
            postnews.Text = "Post";
            back.Name = "btnback" + 20;
            back.Text = "Back";
            postnews.Location = new Point(362, 245);
            postnews.Size = new Size(70, 27);
            back.Location = new Point(442, 245);
            back.Size = new Size(70, 27);
            this.Controls.Add(postnews);
            this.Controls.Add(back);
            postlist.Add(postnews);
            postlist.Add(back);
            back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < postlist.Count; i++)
            {
                postlist[i].Hide();
            }
            post.Show();
            this.Controls.Find("btnnext", true)[0].Show();
            this.Controls.Find("btnprevious", true)[0].Show();
            /*for (int i = 0; i < controllist.Count; i++)
            {
                controllist[i].Show();
            }*/
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Show();
            }
        }
    }
}
