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

namespace HMS.Lists.Bases.DerivedTables
{
    public partial class ctrlDepartmentsListBase : ctrlBaseDGV
    {
        public ctrlDepartmentsListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FullData =clsDeparmtments.GetAllDepartments();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Manager ID");
            cmbSearch.Items.Insert(0, "Department Name");
            cmbSearch.Items.Insert(0, "Department ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int DepartmentID))
                    {
                        GetSearchFileter(($"CONVERT(DepartmentID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;

                case (1):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"DepartmentName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;
                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int DepartmentManagerID))
                    {
                        GetSearchFileter(($"CONVERT(DepartmentManagerID, 'System.String') like '{txtSearch.Text}%'"));
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

        private void ctrlDepartmentsListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
