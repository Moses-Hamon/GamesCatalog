using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesCatalog
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            // use txtSelectID to get the id of a record
            // use Game.SelectOne to load that record
            // copy the data from that record onto the form
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // create a new Game record
            // fill it with data from the form
            // invoke the Save method of the Game record
            // test UPDATE (modifying existing) as well as INSERT code
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtCost.Text = "";
            txtName.Text = "";
            txtPlatform.Text = "";
            txtReleased.Text = "";
        }
    }
}