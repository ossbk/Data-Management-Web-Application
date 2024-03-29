﻿using System;

namespace ClassLibrary
{
    public class clsCustomer
    {
        private Int32 mCustomerID;
        private DateTime mDateAdded;
        private string mEmailAdded;
        private string mPassword;
        private string mAddress;
        private string mContactNumber;
        private Boolean mActive;

        public bool Active {
            get
            {
                //sends data out of the property
                return mActive;
            }
            set
            {
                //allows data into the property
                mActive = value;
            }
        }
        public DateTime DateAdded {
            get
            {
                //sends data out of the property
                return mDateAdded;
            }
            set
            {
                //allows data into the property
                mDateAdded = value;
            }

        }
        public string ContactNumber {
            get
            {
                //sends data out of the property
                return mContactNumber;
            }
            set
            {
                //allows data into the property
                mContactNumber = value;
            }

        }
        public int CustomerID {
            get
            {
                //sends data out of the property
                return mCustomerID;
            } 
            set
            {
                //allows data into the property
                mCustomerID = value;
            }
            
         }
        public string Password {
            get
            {
                //sends data out of the property
                return mPassword;
            }
            set
            {
                //allows data into the property
                mPassword = value;
            }

        }
        public string Email {
            get
            {
                //sends data out of the property
                return mEmailAdded; 
            }
            set
            {
                //allows data into the property
                mEmailAdded = value;
            }

        }
        public string Address {
            get
            {
                //sends data out of the property
                return mAddress;
            }
            set
            {
                //allows data into the property
                mAddress = value;
            }
        }

        public bool Find(int customerID)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //Adding parameter for the address no to search for
            DB.AddParameter("@CustomerID", customerID);
            //execute the stored procedure
            DB.Execute("sproc_tblCustomer_FilterByCustomerID");
            //if one record is found
            if(DB.Count == 1)
            {
                //copy the data from the database to the private data members
                mCustomerID = Convert.ToInt32(DB.DataTable.Rows[0]["CustomerID"]);
                mEmailAdded = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mPassword = Convert.ToString(DB.DataTable.Rows[0]["Password"]);
                mDateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateOfBirth"]);
                mAddress = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                mContactNumber = Convert.ToString(DB.DataTable.Rows[0]["ContactNumber"]);
                mActive = Convert.ToBoolean(DB.DataTable.Rows[0]["OnlineStatus"]);
                return true;
            }
            else
            {
                return false;
            }           
        }

        public string Valid(string emailCustomer, string passwordCustomer,string dateOfBirthCustomer, string addressCustomer, string contactNumberCustomer)
        {
            String Error = "";
            DateTime DateTemp;

            if (emailCustomer.Length == 0)
            {
                Error = Error + " Email  may not be blank: ";
            }

            if (emailCustomer.Length > 50)
            {
                Error = Error + "Email must be less than 50 characters: ";
            }

            try
            {
                DateTemp = Convert.ToDateTime(dateOfBirthCustomer);

                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the future: ";
                }
                if (DateTemp < (DateTemp.AddYears(-200))) ;
                {
                    Error = Error + "Too old to be still alive: ";
                }
            }
            catch
            {

                Error = Error + "the date was not a valid date: ";
            }

            if (addressCustomer.Length == 0)
            {
                Error = Error + "The address may not be blank: ";
            }

            if (addressCustomer.Length > 50)
            {
                Error = Error + "The address must be less than 50 characters: ";
            }

            if (contactNumberCustomer.Length == 0)
            {
                Error = Error + "The Contact Number may not be blank: ";
            }

            if (contactNumberCustomer.Length > 50)
            {
                Error = Error + "The Contact Number must be less than 50 characters: ";
            }

            if (passwordCustomer.Length == 0)
            {
                Error = Error + "The Password may not be blank: ";
            }

            if (passwordCustomer.Length > 50)
            {
                Error = Error + "The Password must be less than 50 characters: ";
            }

            return Error;
        }
    }
}