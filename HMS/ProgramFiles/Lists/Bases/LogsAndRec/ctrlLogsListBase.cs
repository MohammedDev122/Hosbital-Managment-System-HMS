using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.LogsAndRec
{
    public partial class ctrlLogsListBase : ctrlBaseDGV
    {
        public ctrlLogsListBase()
        {
            InitializeComponent();
            DGV1.DataSource = clsLogs.GetAllLogs();
            FillCmbSearch();
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
          
            cmbSearch.Items.Insert(0, "Department Name");
            cmbSearch.Items.Insert(0, "Login Name");
            cmbSearch.Items.Insert(0, "Logged ID");
            cmbSearch.SelectedIndex = 0;

        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int LoggedID))
                    {
                        GetSearchFileter(($"CONVERT(LoggedID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"LoginName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;

                case (2):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"DepartmentName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;
              




            }
        }
        private void ctrlLogsListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
