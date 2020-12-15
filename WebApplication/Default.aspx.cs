using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertUser u = new InsertUser();

            u.Name = TextBox1.Text;
            u.Email = TextBox2.Text;

            string r = client.Insert(u);

            lblmsg.Text = r.ToString();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            gettstdata g = new gettstdata();
            g = client.GetInfo();
            DataTable dt = new DataTable();
            dt = g.usertab;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateUser u = new UpdateUser();
            u.UID = Convert.ToInt32(TextBoxID.Text);
            u.Name = TextBox1.Text;
            u.Email = TextBox2.Text;

            string result = client.Update(u);
            lblmsg.Text = result.ToString();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteUser u = new DeleteUser();
            u.UID = Convert.ToInt32(TextBoxID.Text);


            string result = client.Delete(u);
            lblmsg.Text = result.ToString();
        }
    }
}
