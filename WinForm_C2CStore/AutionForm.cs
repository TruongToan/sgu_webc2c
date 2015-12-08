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
using WinForm_C2CStore.UserService;

namespace WinForm_C2CStore
{
    public partial class AutionForm : Form
    {
        Timer timer = new Timer();
        private AuctionServiceClient client = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
        private UserServiceClient userClient = new UserServiceClient("BasicHttpBinding_IUserService");

        public AutionForm()
        {
            InitializeComponent();
        }


        private void AutionForm_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(updateAutions);

            userGridView.AllowUserToAddRows = false;
            allAutionGV.AllowUserToAddRows = false;
            auctionNewGV.AllowUserToAddRows = false;
            auctionCancelGV.AllowUserToAddRows = false;
            auctionPendingGV.AllowUserToAddRows = false;
            auctionOpenningGV.AllowUserToAddRows = false;
            auctionSoldGV.AllowUserToAddRows = false;

            showAutions();
        }

        private void showAutions()
        {
            userGridView.Rows.Clear();
            allAutionGV.Rows.Clear();
            auctionNewGV.Rows.Clear();
            auctionCancelGV.Rows.Clear();
            auctionPendingGV.Rows.Clear();
            auctionOpenningGV.Rows.Clear();
            auctionSoldGV.Rows.Clear();


            // Tab user
            var users = userClient.GetAllUser();

            foreach (var user in users)
            {
                userGridView.Rows.Add(user.Id, user.UserName, user.Email, user.PhoneNumber);
            }

            //Tab All Auction
            var allAuction = client.GetAllAutions();
            foreach (var auction in allAuction)
            {
                allAutionGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Owner.UserName, auction.BestBid, auction.EndTime, auction.AutionStatus);
            }

            //Tab Auction New
            var auctionNew = client.GetAutionsByStatus(AuctionStatus.New);
            foreach (var auction in auctionNew)
            {
                auctionNewGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Price, auction.StartTime, auction.EndTime);
            }

            //Tab Auction Openning
            var auctionPending = client.GetAutionsByStatus(AuctionStatus.Pending);
            foreach (var auction in auctionPending)
            {
                auctionPendingGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Price, auction.StartTime, auction.EndTime);
            }

            //Tab Auction Pending
            var auctionOpen = client.GetAutionsByStatus(AuctionStatus.Opened);
            foreach (var auction in auctionOpen)
            {
                auctionOpenningGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Owner.UserName, auction.BestBid, auction.EndTime);
            }

            //Tab Auction Sold
            var auctionSold = client.GetAutionsByStatus(AuctionStatus.Closed);
            foreach (var auction in auctionSold)
            {
                auctionSoldGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Owner.UserName, auction.BestBid, auction.EndTime);
            }

            //Tab Auction Cancelled
            var auctionCancel = client.GetAutionsByStatus(AuctionStatus.Cancelled);
            foreach (var auction in auctionCancel)
            {
                auctionCancelGV.Rows.Add(auction.Id, auction.Name, auction.Category.Name, auction.Owner.UserName, auction.Price, auction.EndTime, auction.EndTime);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void allAutionGridView_CellContentClick(object sender, DataGridViewCellEventArgs  e)
        {

            //var listAuction = client.GetAllAutions();
            //foreach (var auction in listAuction)
            //{
            //    sender = auction;
            //   var auction.Item.Name;
            //}
        }

        private void auctionNewGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void auctionCancelGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void auctionSoldGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void allAutionGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          var auctionId =  allAutionGV.CurrentRow.Cells[0].Value;             
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void auctionNewGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var auctionId = auctionNewGV.CurrentRow.Cells[0].Value;
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void auctionPendingGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var auctionId = auctionPendingGV.CurrentRow.Cells[0].Value;
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void auctionOpenningGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var auctionId = auctionOpenningGV.CurrentRow.Cells[0].Value;
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void auctionSoldGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var auctionId = auctionSoldGV.CurrentRow.Cells[0].Value;
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void auctionCancelGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var auctionId = auctionCancelGV.CurrentRow.Cells[0].Value;
            int id = Int32.Parse(auctionId.ToString());
            var auction = client.GetAuction(id);
            DetailAution detail = new DetailAution(id);
            detail.Show();
        }

        private void buttonUpdateManual_Click(object sender, EventArgs e)
        {
            client.UpdateAutions();
            showAutions();
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetTimeout.Enabled = checkBoxAutoUpdate.Checked;
            if (checkBoxAutoUpdate.Checked)
            {
                startTimer();
            }
            else
            {
                timer.Stop();
            }
        }

        private void startTimer()
        {
            timer.Stop();
            timer.Interval = (int)txtUpdateTime.Value * 1000;
            timer.Start();
        }

        private void updateAutions(object sender, EventArgs e)
        {
            Console.WriteLine("Update starting!");
            client.UpdateAutions();
            showAutions();
            Console.WriteLine("Update completed!");
        }

        private void buttonSetTimeout_Click(object sender, EventArgs e)
        {
            startTimer();
        }
    }
}
