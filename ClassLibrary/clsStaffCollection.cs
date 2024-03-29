﻿using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStaffCollection
    {
        List<clsStaff> mStaffList = new List<clsStaff>();
        //private data member thisStaff
        clsStaff mThisStaff = new clsStaff();


        //public property of StaffList 
        public List<clsStaff> StaffList
        {
            get
            {
                //return the private data
                return mStaffList;
            }
            set
            {
                //set the private data
                mStaffList = value;
            }
        }

        public int Count
        {
            get
            {
                // return the count of the list
                return mStaffList.Count;
            }
            set
            {

            }
        }
        public clsStaff ThisStaff
        {
            get
            {
                //return the private data
                return mThisStaff;
            }
            set
            {
                //set the private data
                mThisStaff = value;
            }
        }

        public clsStaffCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblStaff_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);


           /* //var for the index
             Int32 Index = 0;
             //var to store the record count
             Int32 RecordCount = 0;
             //object for data connection
             clsDataConnection DB = new clsDataConnection();
             //execute the stored procedure
             DB.Execute("sproc_tblStaff_SelectAll");
             // get count of records
             RecordCount = DB.Count;
             //while there are record to process
             while (Index < RecordCount)
             {
                 //create blank class
                 clsStaff AStaff = new clsStaff();
                 //read in the fields for the current record
                 AStaff.Staff_Id = Convert.ToInt32(DB.DataTable.Rows[Index]["Staff_Id"]);
                 AStaff.Staff_Name = Convert.ToString(DB.DataTable.Rows[Index]["Staff_Name"]);
                 AStaff.Staff_Role = Convert.ToString(DB.DataTable.Rows[Index]["Staff_Role"]);
                 AStaff.Staff_Started = Convert.ToDateTime(DB.DataTable.Rows[Index]["Staff_Started"]);
                 AStaff.Staff_Online = Convert.ToBoolean(DB.DataTable.Rows[Index]["Staff_Online"]);
                 AStaff.Staff_Salary = Convert.ToDouble(DB.DataTable.Rows[Index]["Staff_Salary"]);
                 //add the record to the private data member
                 mStaffList.Add(AStaff);
                 // point at the next record
                 Index++;
             }

             //create items of test data
             clsStaff TestItem = new clsStaff();
             //set its properites
             TestItem.Staff_Id = 1;
             TestItem.Staff_Name = "Stan";
             TestItem.Staff_Role = "Manager";
             TestItem.Staff_Started = DateTime.Now.Date;
             TestItem.Staff_Online = true;
             TestItem.Staff_Salary = 2.21;
             //create items of test data
             //add the item to the test list
             mStaffList.Add(TestItem);*/
        }

        public int Add()
        {
            //adds a new record to the database based on the values of mThisStaff
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //DB.AddParameter("@Staff_Id", mThisStaff.Staff_Id);
            DB.AddParameter("@Staff_Name", mThisStaff.Staff_Name);
            DB.AddParameter("@Staff_Role", mThisStaff.Staff_Role);
            DB.AddParameter("@Staff_Started", mThisStaff.Staff_Started);
            DB.AddParameter("@Staff_Online", mThisStaff.Staff_Online);
            DB.AddParameter("@Staff_Salary", mThisStaff.Staff_Salary);
            //execute the query returning the primary key
            return DB.Execute("sproc_tblStaff_Insert");
        }

        public int Update()
        {
            //updates a exist record based on the values of mThisStaff
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Staff_Id", mThisStaff.Staff_Id);
            DB.AddParameter("@Staff_Name", mThisStaff.Staff_Name);
            DB.AddParameter("@Staff_Role", mThisStaff.Staff_Role);
            DB.AddParameter("@Staff_Started", mThisStaff.Staff_Started);
            DB.AddParameter("@Staff_Online", mThisStaff.Staff_Online);
            DB.AddParameter("@Staff_Salary", mThisStaff.Staff_Salary);
            //execute the stored procedure
            return DB.Execute("sproc_tblStaff_Update");
        }

        public void Delete()
        {
            //deletes the record pointed to by ThisStaff
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@Staff_Id", mThisStaff.Staff_Id);
            //execute the stored procedure
            DB.Execute("sproc_tblStaff_Delete");
        }

        public void ReportByName(string Staff_Name)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the Staff_name parameter to the database
            DB.AddParameter("@Staff_Name", Staff_Name);
            //execute the stored procedure
            DB.Execute("sproc_tblStaff_FilterByName");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based in the data table in parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount;
            //get the cound of records
            RecordCount = DB.Count;
            //clear the private array list
            mStaffList = new List<clsStaff>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank Staff
                clsStaff AStaff = new clsStaff();
                //read in the fields for the current record
                AStaff.Staff_Id = Convert.ToInt32(DB.DataTable.Rows[Index]["Staff_Id"]);
                AStaff.Staff_Name = Convert.ToString(DB.DataTable.Rows[Index]["Staff_Name"]);
                AStaff.Staff_Role = Convert.ToString(DB.DataTable.Rows[Index]["Staff_Role"]);
                AStaff.Staff_Started = Convert.ToDateTime(DB.DataTable.Rows[Index]["Staff_Started"]);
                AStaff.Staff_Online = Convert.ToBoolean(DB.DataTable.Rows[Index]["Staff_Online"]);
                AStaff.Staff_Salary = Convert.ToDouble(DB.DataTable.Rows[Index]["Staff_Salary"]);
                //add tje record to the private data member
                mStaffList.Add(AStaff);
                //point at the next record
                Index++;
            }
        }
    }
}