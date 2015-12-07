using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_C2CStore.AuctionService;

namespace WinForm_C2CStore
{
    public partial class DetailAution : Form
    {
        private AuctionServiceClient client = new AuctionServiceClient("WSHttpBinding_IAuctionService");
        int id;
        public DetailAution(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void DetailAution_Load(object sender, EventArgs e)
        {
            var auction = client.GetAuction(id);
            txtId.Text = auction.Id.ToString();
            txtName.Text = auction.Name;
            txtBest.Text = auction.BestBid.ToString();
            txtCategory.Text = auction.Category.Name;
            txtOwner.Text = auction.Owner.UserName;
            txtEndTime.Text = auction.EndTime.ToString();
            txtStartTime.Text = auction.StartTime.ToString();
            txtStatus.Text = auction.AutionStatus.ToString();
            txtDescription.Text = auction.Description;
            txtPrice.Text = auction.Price.ToString();

            foreach(var bid in auction.Bids)
            {
                bidsGV.Rows.Add(bid.Id, bid.User.UserName, bid.Price, bid.Time);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
