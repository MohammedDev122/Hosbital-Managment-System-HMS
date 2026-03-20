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

namespace HMS.Lists.Bases.Patient
{
    public partial class ctrlPatientListViewBase : ctrlPersonList
    {
        string StateFilter = "";
        public ctrlPatientListViewBase()
        {
            
            InitializeComponent();
            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Last Name");
            cmbSearch.Items.Insert(0, "First Name");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.SelectedIndex = 0;
            FullData = clsPatients.GetAll(clsViews.enShowing.enAdmin);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
      override   protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
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
            if (CountryFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += CountryFilter;

            }
            if(StateFilter.Length > 0)
            {
                FilterString= AddAnd(FilterString);
                FilterString+= StateFilter;
            }



        }

        protected void GetStateFileter(string State)
        {
            if (State != "'ALL'")
            {
               
                    StateFilter = $"State ={State}";
                
            }
            else
            {
                StateFilter = "";
            }
        }
        private void ctrlPatientListViewBase_Load(object sender, EventArgs e)
        {

        }
     

        private void rbtnState_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdbtn = (RadioButton)sender;
            string AfterFixation = "'" + rdbtn.Text + "'";

            GetStateFileter(AfterFixation);
            refreshDataGrid();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
