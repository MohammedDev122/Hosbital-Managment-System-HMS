using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.MediationsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Medications
{
    /// <summary>
    ///  Represents a basket of items to be purchased in a pharmacy record,
    /// managing the items, total price.
    /// </summary>
    [Documentation("Used To Be Container of the items-prescriped Medications- which the Patient Select them from his Prescription")]
    public class clsBasket
    {
public int BasketID {  get; [Documentation("This Var Is Private To Make It only readable.")] private set; } 
        public Int16 NumOfItems {  get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public double TotalPrice {  get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        internal int PrescriptionID = -1;



     public   clsFailCauses.enBasketFailCause FailCause = clsFailCauses.enBasketFailCause.enUnKnownError;


        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        [Documentation("this is used to assign the object from the Code")]

        public clsBasket()
        {
            this.TotalPrice = 0;
            this.NumOfItems = 0;
            this.BasketID = -1;
            FailCause = clsFailCauses.enBasketFailCause.enUnKnownError;

            Mode = enMode.enAddNew;
           
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsBasket(int BasketID, Int16 NumOfItems, double TotalPrice)
        {
            this.BasketID = BasketID;
            this.NumOfItems = NumOfItems;
            this.TotalPrice = TotalPrice;
           this.PrescriptionID=clsBasketDAL.GetPrescriptionIDByBasketID(BasketID);
            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enBasketFailCause.enUnKnownError;


        }
        static public clsBasket FindBasketByID(int BasketID)
        {

            Int16 NumOfItems = 0;
            double TotalPrice = 0;
            
            if (clsBasketDAL.GetBasketInfoByID(BasketID, ref TotalPrice, ref NumOfItems))
            {
                return new clsBasket(BasketID, NumOfItems, TotalPrice);
            }

            return null;



        }
      
        bool _AddNewBasket()
        {
            this.BasketID = clsBasketDAL.AddNewBasket(this.TotalPrice,this.NumOfItems);
                if (this.BasketID != -1)
                {
                    return true;
                }
            
            return false;



        }
        /// <summary>
        /// Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>

        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewBasket())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateBasket())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        //bool _UpdateAllItemsInBasket()
        //{
        //    DataTable dt=clsItems.GetItemsForBasket(this.BasketID);
        //    clsItems items = new clsItems();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        items = clsItems.FindItemByID(Convert.ToInt32(dr["ItemID"]));
        //       if(! items.Save())
        //            return false;

        //    }
        //    return true;
        //}
        bool _UpdateBasket()
        {
            
               
                if( clsBasketDAL.UpdateBasketInfo(this.BasketID, this.TotalPrice, this.NumOfItems))
                {


                    //return _UpdateAllItemsInBasket();
                    return true;


                }
           
            return false;
        }
       
        static public bool Exist(int BasketID)
        {
            return clsBasketDAL.IsExist(BasketID);
        }
        [Documentation("It is Used To Check if the item already exist in the basket list to prevent assigning it two times")]
        bool _checkIfItemAlreadyExist(int PrescripedMedID)
        {

         DataTable Items=   clsItems.GetItemsForBasket(this.BasketID);
            clsItems Item1;
            foreach (DataRow Item in Items.Rows)
            {


                Item1 = clsItems.FindItemByID(Convert.ToInt32(Item["ItemID"]));
                if (Item1.PrescripedMedID == PrescripedMedID)
                {
                    return true;
                }

            }
            return false ;

        }
      public bool AddItemToBasket(int PrescripedMedID)
        {
            clsPrescripedMed prescripedMed = clsPrescripedMed.FindPrescripedMedicationByID(PrescripedMedID);
            if (prescripedMed==null)
            {
                FailCause = clsFailCauses.enBasketFailCause.enPrescripedMedIsNotFound;

                return false;
            }
            if (prescripedMed.PrescriptionID != PrescriptionID)
            {
                FailCause = clsFailCauses.enBasketFailCause.enPrescripedMedDosentBelongToThisPrescription;

                return false;
            }
            if (_checkIfItemAlreadyExist(PrescripedMedID))
            {
                FailCause = clsFailCauses.enBasketFailCause.enPrescripedMedAlreadyAddedToBasket;

                return false;
            }
            clsMedications Med = clsMedications.FindMedicationByID(prescripedMed.MedicationID);
            if (Med.Quantity == 0)
            {
                FailCause = clsFailCauses.enBasketFailCause.enMedication_Isnt_avaliable;

                return false;
            }
            
            clsItems Item = new clsItems();
            Item.PrescripedMedID = PrescripedMedID; ;
            Item.BasketID = this.BasketID;

            if (Item.Save())
            {
                TotalPrice += Item.Price;
                NumOfItems++;
                clsPharmacyRecord record = clsPharmacyRecord.GetPharmecyRecordInfoByID(clsBasketDAL.getPharmecyRecordIDbyBasketID(BasketID));
                clsPayments payments = clsPayments.GetPaymentInfoByID(record.PaymentID);


                payments.PayedAmmount = TotalPrice;

                if (payments.Save())
                {
                    if (Save())
                    {
                        return true;
                    }
                    else
                    {
                        payments.PayedAmmount -= Item.Price;
                        payments.Save();

                        RemoveItemFromBasketItem(Item.ItemID);

                    }

                }
                else
                {
                    RemoveItemFromBasketItem(Item.ItemID);
                }
                return false;



            }
            return false;

        }
        public bool RemoveItemFromBasketItem(int ItemID)
        {
            clsItems item = clsItems.FindItemByID(ItemID);
            if (item != null)
            {
                double price = item.Price;
                if (clsItems.DeleteItemByPrescripedMedID(item.PrescripedMedID))
                {
                    TotalPrice -= price;
                    NumOfItems--;

                    clsPharmacyRecord record = clsPharmacyRecord.GetPharmecyRecordInfoByID(clsBasketDAL.getPharmecyRecordIDbyBasketID(BasketID));
                    clsPayments payments = clsPayments.GetPaymentInfoByID(record.PaymentID);


                    payments.PayedAmmount = TotalPrice;
                    payments.Save();
                    return Save();




                }
            }
            return false;
        }
    }




}
