using HMS.Lists.Bases.DerivedTables;
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
    public partial class ctrlOperationRoomForOthers : ctrlOperationRoomsListBase
    {
        public ctrlOperationRoomForOthers()
        {
            InitializeComponent();
        }
        public event EventHandler<int> onIDSelected;
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

        private void ctrlOperationRoomForOthers_Load(object sender, EventArgs e)
        {

        }
    }
}
