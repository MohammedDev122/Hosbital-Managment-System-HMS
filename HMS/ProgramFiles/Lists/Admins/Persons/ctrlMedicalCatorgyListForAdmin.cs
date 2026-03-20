using HMS.Lists.Bases.Medications;
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

namespace HMS.Lists.Admins.Persons
{
    public partial class ctrlMedicalCatorgyListForAdmin : ctrlMedicalCatorgiesListBase
    {
        public ctrlMedicalCatorgyListForAdmin()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        private void ctrlMedicalCatorgyListForAdmin_Load(object sender, EventArgs e)
        {

        }
        void RefillThisDGV()
        {


            FullData = clsMedicalCatorgies.GetAllCatorgies();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;


        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value),out int ID))
            {

                frmAddEditMedicalCatorgies frmMedCat = new frmAddEditMedicalCatorgies(ID);
                frmMedCat.MdiParent = clsMDIParent.MDIPARENT;
                frmMedCat.Dock = DockStyle.Fill;
                frmMedCat.ReloadCallingDGV = RefillThisDGV;

                frmMedCat.Show(); 
               

            }
           
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalCatorgies frmMedCat = new frmAddEditMedicalCatorgies(-1);
            frmMedCat.MdiParent = clsMDIParent.MDIPARENT;
            frmMedCat.Dock = DockStyle.Fill;
            frmMedCat.ReloadCallingDGV = RefillThisDGV;

            frmMedCat.Show(); 
           

        }
    }
}
