using HMS.Lists.Bases.Medications;
using HosbitalBussinessLayer.Medications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Others
{
    public partial class ctrlPrescriptionsListForOthers : ctrlPrescribtionBaseList
    {
        public ctrlPrescriptionsListForOthers()
        {
            InitializeComponent();
        }
        public event EventHandler<int> OnSelectedID;
        void SelectID(int ID)
        {



            OnSelectedID?.Invoke(this, ID);



        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int id))
            {
                int ID = id;
                clsPrescription prescription = clsPrescription.FindPrescriptionByID(ID);
                if (prescription.State == clsPrescription.enPrescriptionState.enCancelled || prescription.State == clsPrescription.enPrescriptionState.enFullydispensed)
                {
                    MessageBox.Show($"Prescription with ID: {ID}, is already cancelled/dispensed", "Selected ID", MessageBoxButtons.OKCancel);


            }
                else
                {
                    if (MessageBox.Show($"You Selected {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SelectID(ID);
                    }
                }
            }
        }
        //overload for the double click and event to transfer the info to the form and to transfer it to the pharmecy record ctrl
        private void ctrlPrescriptionsListForOthers_Load(object sender, EventArgs e)
        {

        }

      
    }
}
