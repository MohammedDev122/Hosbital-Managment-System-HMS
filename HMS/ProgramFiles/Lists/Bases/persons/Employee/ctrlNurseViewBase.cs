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

namespace HMS.Lists.Bases
{
    public partial class ctrlNurseViewBase : ctrlEmployeeList
    {
        public ctrlNurseViewBase()
        {
            InitializeComponent();
            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "LastName");
            cmbSearch.Items.Insert(0, "FirstName");
            cmbSearch.Items.Insert(0, "NurseID");
            cmbSearch.SelectedIndex = 0;
            FullData= clsNurses.GetAll(Showing);
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
                        GetSearchFileter(($"CONVERT(NurseID, 'System.String') like '{txtSearch.Text}%'"));
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

                    ;
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

        private void ctrlNurseViewBase_Load(object sender, EventArgs e)
        {

        }
    }
}
