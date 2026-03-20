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
    public partial class ctrlReservationBaseList : ctrlBaseDGV
    {
        protected string StateFilter="";
        public ctrlReservationBaseList()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbState();
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Reserver ID");
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.Items.Insert(0, "Reservation ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbState()
        {
            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Bending");
            cmbState.Items.Insert(0, "Finished");
            cmbState.Items.Insert(0, "All");

            cmbState.SelectedIndex = 0;



        }

      
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        { }
      override  protected void GetAllFileterResult()
        {

            FilterString = "";

            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
          if(StateFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += StateFilter;


            }



        }
      protected  void GetStateFilter(string State)
        {

            if (State != "'All'")
            {

                StateFilter = $"State = {State}";


            }
            else
            {
                StateFilter = "";
            }


        }
        private void ctrlReservationBaseList_Load(object sender, EventArgs e)
        {

        }

        virtual protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetStateFilter(FixedString);
            refreshDataGrid();


        }
    }
}
