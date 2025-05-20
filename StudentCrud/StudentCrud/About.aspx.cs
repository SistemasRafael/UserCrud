using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCrud
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCombo();
            }
            //ControlParameter country = new ControlParameter();
            //country.Name = "country";
            //country.Type = TypeCode.String;
            //country.ControlID = "DropDownList1";
            //country.PropertyName = "SelectedValue";
            //country.DefaultValue = "UK";

        }
        void LoadCombo()
        {
            DateTime Today = DateTime.Now;
            DateTime dtStart = new DateTime(Today.Year, Today.Month, 1);

            for (int i = 1; i <= 12; i++)
            {
                ListItem OneMonth = new ListItem();
                OneMonth.Text = dtStart.ToString("MMM - yyyy");
                OneMonth.Value = i.ToString();
                cboMonth.Items.Add(OneMonth);
                cboMonth.SelectedValue = "4";
                dtStart = dtStart.AddMonths(-1);
            }

            var resutl = cboMonth.SelectedValue;
        }
    }
}