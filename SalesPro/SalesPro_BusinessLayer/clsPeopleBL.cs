using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsPeopleBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Phone4 { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }


        public clsPeopleBL()
        {
            this.PersonID = -1;
            this.PersonName = string.Empty;
            this.Address = string.Empty;
            this.Phone1 = string.Empty;
            this.Phone2 = string.Empty;
            this.Phone3 = string.Empty;
            this.Phone4 = string.Empty;
            this.Email = string.Empty;
            this.Notes = string.Empty;
            this.Mode = enMode.AddNew;
        }

        private clsPeopleBL(int personID, string personName, string address,
            string phone1, string phone2, string phone3, string phone4, string email,
            string notes)
        {
            this.PersonID = personID;
            this.PersonName = personName;
            this.Address = address;
            this.Phone1 = phone1;
            this.Phone2 = phone2;
            this.Phone3 = phone3;
            this.Phone4 = phone4;
            this.Email = email;
            this.Notes = notes;
            this.Mode = enMode.Update;
        }

        // Find a person by PersonID
        public static clsPeopleBL FindPersonByID(int PersonID)
        {
            string personName = string.Empty;
            string address = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string phone3 = string.Empty;
            string phone4 = string.Empty;
            string email = string.Empty;
            string notes = string.Empty;

            if (clsPeopleDAL.GetPersonByID(PersonID, ref personName, ref address,
                ref phone1, ref phone2, ref phone3, ref phone4, ref email,
                ref notes))
            {
                return new clsPeopleBL(PersonID, personName, address,
                    phone1, phone2, phone3, phone4, email, notes);
            }
            else
            {
                return null;
            }
        }

        public static clsPeopleBL FindPersonByName(string personName)
        {
            int PersonID = -1;
            string address = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string phone3 = string.Empty;
            string phone4 = string.Empty;
            string email = string.Empty;
            string notes = string.Empty;

            if (clsPeopleDAL.GetPersonByName(ref PersonID, personName, ref address,
                ref phone1, ref phone2, ref phone3, ref phone4, ref email,
                ref notes))
            {
                return new clsPeopleBL(PersonID, personName, address,
                    phone1, phone2, phone3, phone4, email, notes);
            }
            else
            {
                return null;
            }
        }


        // Check if a person with the given name exists
        public static bool CheckPersonName(string PersonName)
        {
            return clsPeopleDAL.CheckPersonName(PersonName);
        }

        // Add a new person
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDAL.AddNewPerson(this.PersonName, this.Address,
                this.Phone1, this.Phone2, this.Phone3, this.Phone4, this.Email,
                this.Notes);
            return this.PersonID != -1;
        }

        // Update an existing person
        private bool _UpdatePerson()
        {
            return clsPeopleDAL.UpdatePerson(this.PersonID, this.PersonName, this.Address,
                this.Phone1, this.Phone2, this.Phone3, this.Phone4, this.Email,
                this.Notes);
        }

        // Save (add or update) the person
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPerson())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdatePerson();
                default:
                    return false;
            }
        }

        // Get all people
        public static DataTable GetAllPeople()
        {
            return clsPeopleDAL.GetAllPeople();
        }

        // Delete a person
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDAL.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeopleNames()
        {
            return clsPeopleDAL.GetAllPeopleNames();
        }
    }
}