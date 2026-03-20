using HMS.Lists.Bases.Medications;
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
    public partial class ctrlPrescripedMedListForPatientInPharmecy : ctrlPrescripedMedListBase
    {
        public ctrlPrescripedMedListForPatientInPharmecy()
        {
            InitializeComponent();
        }
        public event EventHandler<int> OnSelectedID;
        public void SelectedID(int id)
        {
            OnSelectedID?.Invoke(this, id);
        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You want to Add This med with ID: {ID} to the Basket", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                SelectedID(ID);
            }
        }
        private void ctrlPrescripedMedForPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
