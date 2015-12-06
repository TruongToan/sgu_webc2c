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
    public partial class AutionForm : Form
    {

        private AuctionServiceClient client = new AuctionServiceClient();

        public AutionForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var listAuction = client.GetAllAutions();
            foreach(var auction in listAuction)
            {
                allAutionGridView.Rows.Add(auction.Id, auction.Item.Name,auction.Item.Category.ToString(),auction.BestBid,auction.EndTime,auction.AutionStatus);
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
    }
}
