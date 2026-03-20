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

namespace HMS.Add_Edit
{
    public partial class ctrlEditServicesTypes : ctrlAddEditBase
    {
        public ctrlEditServicesTypes()
        {
            InitializeComponent();
        }

        private void ctrlEditServicesTypes_Load(object sender, EventArgs e)
        {

        }
        protected void FillTypeInfo(int TypeID)
        {
            clsServiceTypes Type = clsServiceTypes.FindServiceTypeByID(TypeID);
            lblID.Text = Convert.ToString(ID);

            txtPrice.Text = Type.ServiceCost.ToString();
            lblServiceName.Text = Type.ServiceName;

        }

        override protected void FillInfo(int ID)
        {

            if (ID != -1)
            {
                clsServiceTypes Type = clsServiceTypes.FindServiceTypeByID(ID);

                if (Type != null)
                {

                    setAddEdit("Edit Type");
                    FillTypeInfo(Type.TypeID);
                    _Mode = enMode.enUpdate;


                }
                else
                {
                    setAddEdit("Add New Type");
                    _Mode = enMode.enAddNew;
                    btnSave.Enabled = false;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Type");
                _Mode = enMode.enAddNew;
                btnSave.Enabled = false;

                //new Record


            }






        }


        protected void UpdateType(clsServiceTypes Type)
        {
if(float.TryParse(Convert.ToString(txtPrice.Text),out float price))
            {

                Type.ServiceCost = price;

            }
            if (Type.Save())
            {
                ID = Type.TypeID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Type.Cause.ToString(), "Error");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
            

                clsServiceTypes serviceTypes = clsServiceTypes.FindServiceTypeByID(ID);
                UpdateType(serviceTypes);
                FillInfo(serviceTypes.TypeID);




            
        }














    }
}
