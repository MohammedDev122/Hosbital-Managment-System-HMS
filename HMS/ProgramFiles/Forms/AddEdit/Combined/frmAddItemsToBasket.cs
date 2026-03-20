using HMS.Lists.Admins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class frmAddItemsToBasket : Form
    {
        public frmAddItemsToBasket(int BasketID,int PrescriptionID)
        {
            InitializeComponent();
            ctrlBasketListForAdmin1.SetID(BasketID);
            ctrlPrescripedMedListForPatientInPharmecy1.SetID(PrescriptionID);
            ctrlPrescripedMedListForPatientInPharmecy1.OnSelectedID += ctrlBasketListForAdmin1.AddNewItem;
            ctrlBasketListForAdmin1.CloseForm = CloseForm;
        }
        public Action UpdatePrice;
        void CloseForm()
        {
            UpdatePrice?.Invoke();
            this.Close();
        }

        private void frmAddItemsToBasket_Load(object sender, EventArgs e)
        {
        }

        private void ctrlBasketListForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
