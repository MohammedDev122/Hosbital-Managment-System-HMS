using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.MediationsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalBussinessLayer.Medications
{
    public class clsPharmecyBasket
    {


       public int BasketID {  get;private set; }
        public int PharmecyRec {  get; set; }
        int _PharmecyRec = -1;
       public double TotalPrice {  get;private set; }
       public enum enMode { enUpdate=0,enAddNew=1}
        enMode Mode;
       public clsPharmecyBasket()
        {
            BasketID = -1;
            PharmecyRec = -1;
            _PharmecyRec= -1;
            TotalPrice = 0;
            Mode = enMode.enAddNew;





        }


         clsPharmecyBasket(int BasketID,int PharmecyRec,double TotalPrice)
        {
            this.BasketID = BasketID;
            this.PharmecyRec = PharmecyRec;
            _PharmecyRec = PharmecyRec;
           this.TotalPrice = TotalPrice;
            Mode = enMode.enUpdate;





        }

        static public clsPharmecyBasket FindBasketByID(int BasketID)
        {

            int PharmecyRec = -1;
            double TotalPrice = 0;
           

            if (clsPharmecyBasketDAL.GetBasketInfoByID(BasketID, ref PharmecyRec, ref TotalPrice))
            {
                return new clsPharmecyBasket(BasketID, PharmecyRec, TotalPrice);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            
            if (this.TotalPrice < 0)
            {
                return false;
            }
           
            if (clsPharmacyRecord.GetPharmecyRecordInfoByID(this.PharmecyRec) == null)
            {
                return false;
            }
            return true;

        }
        bool _AddNewBasket()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.BasketID = clsPharmecyBasketDAL.AddNewBasket(this.PharmecyRec, this.TotalPrice);
                return this.BasketID != -1;
            }
            return false;



        }
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
        bool _UpdateBasket()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsPharmecyBasketDAL.UpdateBasketInfo(this.BasketID, this._PharmecyRec, this.TotalPrice);
            }
            return false;
        }
        static public DataTable GetAllBaskets()
        {

            return clsPharmecyBasketDAL.GetAllBaskets();
        }
        static public bool Exist(int BasketID)
        {
            return clsPharmecyBasketDAL.IsExist(BasketID);
        }

       //static public DataTable GetAllBasketItems(int BasketID)
        //{

           // return clsPharmecyBasketDAL.GetAllBasketItems(BasketID);
      //  }
      





    }
}
