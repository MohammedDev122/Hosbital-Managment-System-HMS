using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Others.Employee
{
    public partial class ctrlEmployeeListViewForOthers : ctrlEmployeeList
    {
        public string Department = "";
        public ctrlEmployeeListViewForOthers()
        {
            InitializeComponent();
            
        }
        public  EventHandler<int> onIDSelected;
        void SelectID(int id)
        {

            onIDSelected?.Invoke(this, id);

        }
          override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You Selected {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectID(ID);
            }




        }
        



        private void ctrlEmployeeListViewForOthers_Load(object sender, EventArgs e)
        {


            GetStateFilter("'Working'");
            GetDepartmentFilter("'" + Department + "')");
            refreshDataGrid();



        }
        protected void GetDepartmentFilter(string Department)
        {

            if (Department != "'All'")
            {
                DepartmentFilter = $"(DepartmentName ={Department}";

            }
            else
            {
                DepartmentFilter = "";
            }


        }
        protected override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PersonID))
                    {
                        GetSearchFileter(($"CONVERT(EmployeeID, 'System.String') like '{txtSearch.Text}%'"));
                        GetStateFilter("'Working'");
                        GetDepartmentFilter("'" + Department + "')");
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        GetStateFilter("'Working'");
                        GetDepartmentFilter("'" + Department + "')");
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($"FirstName like '{txtSearch.Text}%'"));
                        GetStateFilter("'Working'");
                        GetDepartmentFilter("'" + Department + "') ");
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
                        GetStateFilter("'Working'");
                        GetDepartmentFilter("'" + Department + "')");
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
    }
}
