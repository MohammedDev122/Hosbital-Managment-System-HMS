using HosbitalDataAccessLayer.MediationsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Medications
{
    /// <summary>
    /// Manages the items within a pharmacy basket.
    /// </summary>
    [Documentation("this Class Is Used To collect the prescriped Medicatios as items in the Basket when buying them through the Pharmecy Record")]
    public class clsItems

    {
        public int ItemID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int PrescripedMedID { get;  set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _PrescripedMedID =-1;
        public double Price { get; private set; }

        

       public int BasketID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _BasketID =-1;



        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        [Documentation("this is used to assign the object from the Code")]

        public clsItems()
        {
            this.ItemID = -1;
            this.PrescripedMedID = -1;
            this.BasketID = -1;
            this.Price = 0;
            Mode = enMode.enAddNew;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsItems(int ItemID, int PrescripedMedID,int BasketID, double Price)
        {
            this.ItemID = ItemID;
            this.BasketID = BasketID;
            this.PrescripedMedID = PrescripedMedID;
            _PrescripedMedID = PrescripedMedID;
            this.BasketID = BasketID;
            this.Price = Price;
            Mode = enMode.enUpdate;

        }
        static public clsItems FindItemByID(int ItemID)
        {

            int PrescripedMedID = -1;
            int BasketID = -1;
            double Price = 0;

            if (clsItemsDAL.GetItemInfoByID(ItemID, ref PrescripedMedID, ref Price,ref BasketID))
            {
                return new clsItems( ItemID,  PrescripedMedID,  BasketID,  Price);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {





            if (this.ItemID == -1)
            {
                clsPrescripedMed PMed=clsPrescripedMed.FindPrescripedMedicationByID(PrescripedMedID);

                if (PMed==null)
                {
                    return false;
                }
                if (!clsBasket.Exist(BasketID))
                {
                    return false;
                }
                if (PMed.State == clsPrescripedMed.enState.enDispensed)
                {
                    return false;
                }
             clsMedications Med=   clsMedications.FindMedicationByID(PMed.MedicationID);
                if ( Med.Quantity==0 )
                {
                    return false;
                }
                //we want here to check if there is already an item with the prescriped Med Is Added
                this.Price = clsMedications.FindMedicationByID(clsPrescripedMed.FindPrescripedMedicationByID(this.PrescripedMedID).MedicationID).Price;
               


            }
            else
            {
                if (clsPrescripedMed.FindPrescripedMedicationByID(_PrescripedMedID).State == clsPrescripedMed.enState.enDispensed)
                {
                    return false;
                }
                this.Price = clsMedications.FindMedicationByID(clsPrescripedMed.FindPrescripedMedicationByID(this._PrescripedMedID).MedicationID).Price;

            }
            return true;

        }
        bool _AddNewItem()
        {
            if (_CheckIfDataIsCorrect())
            {
                clsPrescripedMed PMed = clsPrescripedMed.FindPrescripedMedicationByID(PrescripedMedID);
                clsMedications Med = clsMedications.FindMedicationByID(PMed.MedicationID);

                this.ItemID = clsItemsDAL.AddNewItem(this.PrescripedMedID, this.Price,this.BasketID);

                if (this.ItemID != -1)
                {
                    Med.Quantity--;

                    return Med.Save();
                }
            }
            return false;



        }
        /// <summary>
        ///  Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>

        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewItem())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateItem())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateItem()
        {
            if (_CheckIfDataIsCorrect())
            {
                clsPrescripedMed PMed = clsPrescripedMed.FindPrescripedMedicationByID(_PrescripedMedID);
                PMed.State = clsPrescripedMed.enState.enDispensed;
                if (PMed.Save())
                {
                    return clsItemsDAL.UpdateItemInfo(this.ItemID, this._PrescripedMedID, this.Price, _BasketID);
                }
            }
            return false;
        }

        static public bool Exist(int ItemID)
        {
            return clsItemsDAL.IsExist(ItemID);
        }
        static public DataTable GetItemsForBasket(int BasketID)
        {
            return clsItemsDAL.GetAllItemsForBasket(BasketID);
        }
        static public bool DeleteItem(int ItemID)
        {
            return clsItemsDAL.DeleteItem(ItemID);
        }
        static public bool DeleteItemByPrescripedMedID(int PrescripedMedID)
        {
            if(clsItemsDAL.DeleteItemByPrescripedMedID(PrescripedMedID))
            {
                clsPrescripedMed PMed = clsPrescripedMed.FindPrescripedMedicationByID(PrescripedMedID);
                if (PMed != null)
                {
                    clsMedications Med = clsMedications.FindMedicationByID(PMed.MedicationID);



                    Med.Quantity++;

                    return Med.Save();
                }

            }
            return false ;
        }

    }
}
