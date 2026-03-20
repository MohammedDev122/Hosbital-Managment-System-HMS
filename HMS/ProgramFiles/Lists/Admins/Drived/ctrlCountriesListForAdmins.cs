using HMS.Lists.Bases.DerivedTables;
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

namespace HMS.Lists.Admins
{
    public partial class ctrlCountriesListForAdmins : ctrlCountriesBaseList
    {
        public ctrlCountriesListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefilThisDGV()
        {
                    RefillDGV(clsCountries.GetAllCountries());



        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Country with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditCountry frmCountries = new frmAddEditCountry(ID);
                    frmCountries.MdiParent = clsMDIParent.MDIPARENT;
                    frmCountries.Dock = DockStyle.Fill;
                    frmCountries.ReloadCallingDGV = RefilThisDGV;
                    frmCountries.Show();
                   


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Country with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditCountry frmCountries = new frmAddEditCountry(ID);
                    frmCountries.MdiParent = clsMDIParent.MDIPARENT;
                    frmCountries.Dock = DockStyle.Fill;
                    frmCountries.Show();

                    RefillDGV(clsCountries.GetAllCountries());

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCountry frmCountries = new frmAddEditCountry(-1);
            frmCountries.MdiParent = clsMDIParent.MDIPARENT;
            frmCountries.Dock = DockStyle.Fill;
            frmCountries.Show();
            RefillDGV(clsCountries.GetAllCountries());
        }
        private void ctrlCountriesListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
