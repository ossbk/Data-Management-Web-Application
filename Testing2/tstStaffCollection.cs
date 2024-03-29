﻿using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class tstStaffCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create a instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //test to see if it exists
            Assert.IsNotNull(AllStaff);
        }

        [TestMethod]
        public void StaffListOK()
        {
            //create instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create test data to assign to property
            // in this case data needs to be a list of objects
            List<clsStaff> TestList = new List<clsStaff>();
            // add a item to the list
            //create item of test data
            clsStaff TestItem = new clsStaff();
            //set its properties
            TestItem.Staff_Id = 1;
            TestItem.Staff_Name = "Lewis";
            TestItem.Staff_Role = "Manager";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = true;
            TestItem.Staff_Salary = 2.21;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign data to the property
            AllStaff.StaffList = TestList;
            //Test to see that the two values are the same
            Assert.AreEqual(AllStaff.StaffList, TestList);
        }


        [TestMethod]
        public void ThisStaffPropertyOK()
        {
            //Create an instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create test data
            clsStaff TestStaff = new clsStaff();
            //set properties of test object
            TestStaff.Staff_Id = 1;
            TestStaff.Staff_Name = "Lewis";
            TestStaff.Staff_Role = "Manager";
            TestStaff.Staff_Started = DateTime.Now.Date;
            TestStaff.Staff_Online = true;
            TestStaff.Staff_Salary = 2.21;
            //assign the data to the property
            AllStaff.ThisStaff = TestStaff;
            //test
            Assert.AreEqual(AllStaff.ThisStaff, TestStaff);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create test data to assign to property
            // in this case data needs to be a list of objects
            List<clsStaff> TestList = new List<clsStaff>();
            // add a item to the list
            //create item of test data
            clsStaff TestItem = new clsStaff();
            //set its properties
            TestItem.Staff_Id = 1;
            TestItem.Staff_Name = "Lewis";
            TestItem.Staff_Role = "Manager";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = true;
            TestItem.Staff_Salary = 2.21;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign data to the property
            AllStaff.StaffList = TestList;
            //Test to see that the two values are the same
            Assert.AreEqual(AllStaff.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create instance of class you want to create
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Staff_Name = "James";
            TestItem.Staff_Role = "Manager";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = true;
            TestItem.Staff_Salary = 2.21;
            //set ThisStaff to the test data
            AllStaff.ThisStaff = TestItem;
            //add the record
            PrimaryKey = AllStaff.Add();
            //set the primary key of the test data
            TestItem.Staff_Id = PrimaryKey;
            //find the record
            AllStaff.ThisStaff.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllStaff.ThisStaff, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOk()
        {
            //create an instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Staff_Name = "Alex";
            TestItem.Staff_Role = "Front";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = true;
            TestItem.Staff_Salary = 200.1;
            //set ThisStaff to the test data
            AllStaff.ThisStaff = TestItem;
            //add to the record
            PrimaryKey = AllStaff.Add();
            //set the primary key of the test data
            TestItem.Staff_Id = PrimaryKey;
            //modify test data
            TestItem.Staff_Name = "Alex";
            TestItem.Staff_Role = "Manager";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = false;
            TestItem.Staff_Salary = 200.25;
            //set the record based on the new test data
            AllStaff.ThisStaff = TestItem;
            //update the record
            AllStaff.Update();
            //find the record
            AllStaff.ThisStaff.Find(PrimaryKey);
            //test to see ThisStaff matches the test data
            Assert.AreEqual(AllStaff.ThisStaff, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create instance of the class
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create the item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Staff_Name = "Jed";
            TestItem.Staff_Role = "Cleaner";
            TestItem.Staff_Started = DateTime.Now.Date;
            TestItem.Staff_Online = false;
            TestItem.Staff_Salary = 2000.23;
            //set ThisStaff to the test data
            AllStaff.ThisStaff = TestItem;
            //add the record
            PrimaryKey = AllStaff.Add();
            //set the primary key of the test data
            TestItem.Staff_Id = PrimaryKey;
            //find the record
            AllStaff.ThisStaff.Find(PrimaryKey);
            //delete the record
            AllStaff.Delete();
            //now find the record
            Boolean Found = AllStaff.ThisStaff.Find(PrimaryKey);
            //test to see that the record was not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByNameMetodOK()
        {
            //create an instance of the class containing unfiltered results
            clsStaffCollection AllStaff = new clsStaffCollection();
            //create an instance of the filtered data
            clsStaffCollection FilteredNames = new clsStaffCollection();
            //apply a blank string (should return all records)
            FilteredNames.ReportByName(" ");
            //test to see that the two values are the same
            Assert.AreEqual(AllStaff.Count, FilteredNames.Count);
        }

        [TestMethod]
        public void ReportByNameNoneFound()
        {
            //create an instance of the filtered data
            clsStaffCollection FilteredNames = new clsStaffCollection();
            //apply a name that doesn't exist
            FilteredNames.ReportByName("xxx xxx");
            //test to see that there are no records
            Assert.AreEqual(0, FilteredNames.Count);
        }

        [TestMethod]
        public void ReportByNameTestDataFound()
        {
            //create an instance of the filtered data
            clsStaffCollection FilteredNames = new clsStaffCollection();
            //var to store outcome
            Boolean OK = true;
            //apply a name that doesn't exist
            FilteredNames.ReportByName("VVV");
            //check that the correct number of records are found
            if (FilteredNames.Count == 2)
            {
                //check that the first record is ID 45
                if (FilteredNames.StaffList[0].Staff_Id != 45)
                {
                    OK = false;
                }
                //check that the first record is ID 46
                if (FilteredNames.StaffList[1].Staff_Id != 46)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            //test to see that there are no records
            Assert.IsTrue(OK);
        }



    }
}
