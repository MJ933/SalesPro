using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsGuarantorsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int GuarantorID { get; set; }
        public int PersonID { get; set; }
        public clsPeopleBL PersonInfo { get; set; }

        public clsGuarantorsBL()
        {
            this.GuarantorID = -1;
            this.PersonID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsGuarantorsBL(int guarantorID, int personID)
        {
            this.GuarantorID = guarantorID;
            this.PersonID = personID;
            this.PersonInfo = clsPeopleBL.FindPersonByID(personID);
            this.Mode = enMode.Update;
        }

        // Find a guarantor by GuarantorID
        public static clsGuarantorsBL FindGuarantorByID(int GuarantorID)
        {
            int personID = -1;
            if (clsGuarantorsDAL.GetGuarantorByID(GuarantorID, ref personID))
            {
                return new clsGuarantorsBL(GuarantorID, personID);
            }
            else
            {
                return null;
            }
        }

        // Find a guarantor by Name
        public static clsGuarantorsBL FindGuarantorByName(string PersonName)
        {
            int guarantorID = -1;
            if (clsGuarantorsDAL.GetGuarantorByName(PersonName, ref guarantorID))
            {
                return FindGuarantorByID(guarantorID);
            }
            else
            {
                return null;
            }
        }

        // Add a new guarantor
        private bool _AddNewGuarantor()
        {
            this.GuarantorID = clsGuarantorsDAL.AddNewGuarantor(this.PersonID);
            return this.GuarantorID != -1;
        }

        // Update an existing guarantor
        private bool _UpdateGuarantor()
        {
            return clsGuarantorsDAL.UpdateGuarantor(this.GuarantorID, this.PersonID);
        }

        // Save (add or update) the guarantor
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewGuarantor())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateGuarantor();
                default:
                    return false;
            }
        }

        // Get all guarantors
        public static DataTable GetAllGuarantors()
        {
            return clsGuarantorsDAL.GetAllGuarantors();
        }

        // Get Guarantors Names
        public static DataTable GetGuarantorsNames()
        {
            return clsGuarantorsDAL.GetGuarantorsNames();
        }

        // Delete a guarantor
        public static bool DeleteGuarantor(int GuarantorID)
        {
            return clsGuarantorsDAL.DeleteGuarantor(GuarantorID);
        }

        // Check if a guarantor exists
        public static bool GuarantorExists(int GuarantorID)
        {
            return clsGuarantorsDAL.GuarantorExists(GuarantorID);
        }
    }
}