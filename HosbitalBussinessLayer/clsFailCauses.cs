using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    [Documentation("this Class Is Responsiple for providing the reason behind process fail in the system")]
    public static class clsFailCauses
    {


        public enum enPersonsFailCauses
        {
            enUnkownError = 0, enAccountNumIsTooShortOrTooLong = 1, enAmmountOfMoneyIsBellowZero = 2, enPasswordIsTooShortOrTooLong = 3,
            enPasswordCantHoldAnyChar = 4, enFirstNameIsTooShort = 5, enLastNameIsTooShort = 6, enPhoneNumCantHoldAnyChar = 7,
            enDateOfBirthIsWrong = 8, enNoSuchGender = 9, enFailedToAddNewAccount = 10, enWorkingDaysBellowZero = 11,
            enSaleryBellowZero = 12, enWrongDepartmentID = 13, enWrongEmploymentDate = 14, enWrongPersonID = 15,enWrongSpecID=16
        };




        public enum enServicesFailCause
        {
            enUnkownError = 0, enPaymentFailed = 1, enUnPayed = 2, enCancelledOrFinished = 3,
            enWrongPatientID = 5, enPatientIsDead = 6, enWrongServiceTypeID = 7, enOverLappedTime = 8, enWrongTime = 9
            , enFailedToGetServiceInfo = 10, enFailedToAddService = 11,
            enFailedToAddLog = 12, enWrongDoctorID = 13, enPassedDoctorDueDate = 14, enWrongSpecilization = 15, enIncompatiblespec = 16, enFailedToAddReservation = 17
              , enFailedtoAddDiagnosisDB = 18,   enPayedAmmountBellowZero=19, enWrongDate=20, enFailedToSavePatient=21, enFailedToSaveService=22, enWrongMedicalRecordID=23, enWrongRoomID=24, enOneOfStaffHasOverLappedTime=25
        }
        public enum enPaymentFailCause
        {
            enUnkownError = 0, enWrongTime = 1 ,enWrongAccountantID = 2, enWrongAccountID = 3, enInSufficentMoney = 4, enPayedAmmountBellowZero = 5, enWrongDate = 6, enAccountantIsFired = 7
        }


        public enum enLogsAndRecFailCause { enUnkownError = 0, enWrongDoctorID = 1, enDoctorIsFired=2, enWrongServiceID = 3,
            enWrongDate = 4, enWrongTime = 5, enWrongPatientID = 6,
            enThereIsNoDiagnsticNotes = 7, enPatientIsDead = 8, enWrongNurseID = 9, enNurseIsFired = 10,enWrongRoomID=11,enWrongEmployeeID=12,
 enWrongOperationID    =13, enOverLapTime
        =14, enAlreadyAssignedStaff
        =15}
        public enum enPharmecyRecFailCause
        {
            enUnkownError = 0, enWrongPrescriptionID = 1, enPatientIsDead = 2, enWrongPharmacistID = 3,enPharmacistisFired
          
          = 8, enPrescriptionCancelled = 9, enPrescripedMedDispenced = 10, enMedIsnotAvaliable = 11, enPaymentFailed=12, enCancelledOrFinished=13
        }


        public enum enBankAccountsFailCause { enUnkownError = 0, enAccountNumIsTooShortOrTooLong = 1, enAmmountOfMoneyIsBellowZero = 2, enPasswordIsTooShortOrTooLong = 3, enPasswordCantHoldAnyChar = 4 }

        public enum enDepartmentsFailCause { enUnkownError = 0, enVeryShortDepatmentName = 1, enNumOfEmployeesBelowZero = 2, enWrongDepartmentManagerID = 3, enDepartmentMangerIsntEmployeeAtTheDepatment = 4 }
        public enum enPaymentMethodsFailCause { enUnknownError = 0, enPaymentMethodNameIsTooShort = 1 }
        public enum enServicesTypesFailCause { enUnKnownError = 0, enVeryShortServiceName = 1, enServiceCostBellowZero = 2 }


        public enum enSpecFailCause { enUnkownError = 0, enVeryShortSpecName = 1 }

        public enum enCatorgiesFailCause {enUknownError=0, enVeryShortCatorgyName=1,enMedicationNumBellowZero=2 }

        public enum enMedicationsFailCause { enUknownError = 0, enVeryShortMedName = 1, enVeryShortNotes = 2, enMedQuantityBellowZero = 3, enMedPriceBellowZero = 4, enWrongMedCatorgy = 5 }




        public enum enPrescriptionFailCause {  enUnKnownError = 0,enWrongMedRecID=1,enDeadPatient=2}

        public enum enPrescripedMedFailCause {  enUnKnownError = 0,enWrongStartDate=1,enWrongPrescriptionID=2
                ,enPrescriptionIsCancelled=3,enPrescripedMedIsDispensedOrCancelled=4,enDosageIsBellowZero=5,enWrongMedicationID=6,enThereIsNoInstructions=7,
        enWrongEndDate=8
        }

        public enum enOperationRoomsFailCause {  enUnKnownError = 0,enVeryShortOrLongOperationRoomNum=1}
        public enum enLoginFailCause { enUnKnownError = 0,enLoginNameIsTooShortorLong = 1,enLoginPasswordCantHoldAnyChar=2, enLoginPasswordtooShortorLong = 3 ,enEmployeeIsntInSystem=4}
        public enum enBasketFailCause { enUnKnownError = 0, enPrescripedMedIsNotFound = 1, enPrescripedMedDosentBelongToThisPrescription = 2, enPrescripedMedAlreadyAddedToBasket = 3, enMedication_Isnt_avaliable = 4 }



    }
}
