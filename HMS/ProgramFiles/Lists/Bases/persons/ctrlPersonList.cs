using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HMS
{
    public partial class ctrlPersonList : ctrlBaseDGV
    {
       protected string GenderFilter = "";
      protected  string CountryFilter = "";

        public ctrlPersonList()
        {
            InitializeComponent();
            FullData = clsPerson.GetAll(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = FullData;

            cmbSearch.SelectedIndex = 0;
            _FillCountryComboBox();


        }
        void _FillCountryComboBox()
        {

            cmbCountry.Items.Clear();
            DataTable dt = clsCountries.GetAllCountries();
            cmbCountry.Items.Add("All");
            foreach (DataRow dr in dt.Rows) {

                cmbCountry.Items.Add(dr["CountryName"]);
            
            }
            cmbCountry.SelectedIndex = 0;
        }
        private void ctrlPersonList_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler<int> OnSelectedID;
        void SelectID(int ID)
        {
            OnSelectedID?.Invoke(this, ID);

        }
        override  protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You Selected {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectID(ID);
            }
        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PersonID))

                    {
                        GetSearchFileter(($"CONVERT(PersonID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
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
                 ;
                    break;






            }
        }
        protected void GetGenderFileter(string Gender)
        {
            if (!string.IsNullOrWhiteSpace(Gender))
            {
                GenderFilter = $"Gender ={Gender}";
            }
            else
            {
                GenderFilter = "";
            }
        }
        protected void GetCountryFileter(string Country)
        {
            if (Country!="'All'")
            {
                CountryFilter = $"CountryName ={Country}";
            }
            else
            {
                CountryFilter = "";
            }
        }
     
        override protected void GetAllFileterResult()
        {
            FilterString = "";
            if (GenderFilter.Length > 0)
            {
                FilterString += GenderFilter;

            }
            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
            if(CountryFilter.Length > 0)
            {
                FilterString=AddAnd(FilterString);
                FilterString += CountryFilter;

            }



        }
     //override   protected void refreshDataGrid()
     //   {
     //       GetAllFileterResult();
     //       BindingSource1.Filter = FilterString;

     //       dataGridView1.DataSource = FullData;
     //   }
        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
           RadioButton rdbtn = (RadioButton)sender;
            GetGenderFileter(rdbtn.Tag.ToString());
            refreshDataGrid();

        }

        private void cmbCountry_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string AfterFixation="'"+cmb.Text.ToString()+"'";
            GetCountryFileter(AfterFixation);
            refreshDataGrid();
        }
    }
}