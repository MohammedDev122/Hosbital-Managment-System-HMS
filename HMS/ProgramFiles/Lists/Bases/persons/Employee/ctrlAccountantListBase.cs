using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Admins
{
    public partial class ctrlAccountantListBase : ctrlEmployeeList
    {
        public ctrlAccountantListBase()
        {
            InitializeComponent();
            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Last Name");
            cmbSearch.Items.Insert(0, "First Name");
            cmbSearch.Items.Insert(0, "Accountant ID");
            cmbSearch.SelectedIndex = 0;
            FullData = clsAccountant.GetAll(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int EmployeeID))
                    {
                        GetSearchFileter(($"CONVERT(AccountantID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($"FirstName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;

                case (2):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($"LastName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;






            }

        }

        private void ctrlAccountantListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
