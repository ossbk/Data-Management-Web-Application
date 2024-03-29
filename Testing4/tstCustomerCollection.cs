﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;
using System.Collections.Generic;

namespace Testing4
{
    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            Assert.IsNotNull(AllCustomers);
        }

        [TestMethod]
        public void CustomerListOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            clsCustomer TestItem = new clsCustomer();

            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.Address = "some street LE1 1WE";
            TestItem.ContactNumber = "123456789";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "example@gmail.com";
            TestItem.Password = "123abc";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            Assert.AreEqual(AllCustomers.CustomerList, TestList);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestCustomer = new clsCustomer();

            TestCustomer.Active = true;
            TestCustomer.CustomerID = 1;
            TestCustomer.Address = "some street LE1 1WE";
            TestCustomer.ContactNumber = "123456789";
            TestCustomer.DateAdded = DateTime.Now.Date;
            TestCustomer.Email = "example@gmail.com";
            TestCustomer.Password = "123abc";

            AllCustomers.ThisCustomer = TestCustomer;
            Assert.AreEqual(AllCustomers.ThisCustomer, TestCustomer);

        }
        [TestMethod]
        public void ListAndCountOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            List<clsCustomer> TestList = new List<clsCustomer>();
            clsCustomer TestItem = new clsCustomer();

            TestItem.Active = true;
            TestItem.Address = "some street LE1 1WE";
            TestItem.CustomerID = 1;
            TestItem.ContactNumber = "123456789";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "example@gmail.com";
            TestItem.Password = "123abc";

            TestList.Add(TestItem);
            AllCustomers.CustomerList = TestList;
            Assert.AreEqual(AllCustomers.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;

            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.Address = "some street LE1 1WE";
            TestItem.ContactNumber = "123456789";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "example@gmail.com";
            TestItem.Password = "123abc";

            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerID = PrimaryKey;
            AllCustomers.ThisCustomer.Find(PrimaryKey);

            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }
        [TestMethod]
        public void UpdateMethodOK()
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();

            Int32 PrimaryKey = 0;

            TestItem.Active = true;
            TestItem.Address = "some street LE1 1WE";
            TestItem.ContactNumber = "123456789";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "example@gmail.com";
            TestItem.Password = "123abc";

            AllCustomers.ThisCustomer = TestItem;
            PrimaryKey = AllCustomers.Add();
            TestItem.CustomerID = PrimaryKey;

            TestItem.Active = false;
            TestItem.Address = "update street LE1 1WE";
            TestItem.ContactNumber = "121111111";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "update@gmail.com";
            TestItem.Password = "123444444";

            AllCustomers.ThisCustomer = TestItem;
            AllCustomers.Update();
            AllCustomers.ThisCustomer.Find(PrimaryKey);

            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }
        [TestMethod]
        public void DeleteMethodOK()
        {

            clsCustomerCollection allCustomers = new clsCustomerCollection();
            clsCustomer TestItem = new clsCustomer();
            Int32 PrimaryKey = 0;

            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.Address = "wilberforce LE1 1WE";
            TestItem.DateAdded = DateTime.Now.Date;
            TestItem.Email = "email@gmail.com";
            TestItem.ContactNumber = "333333";
            TestItem.Password = "123444444";

            allCustomers.ThisCustomer = TestItem;
            PrimaryKey = allCustomers.Add();
            TestItem.CustomerID = PrimaryKey;

            allCustomers.ThisCustomer.Find(PrimaryKey);
            allCustomers.Delete();

            Boolean Found = allCustomers.ThisCustomer.Find(PrimaryKey);
            Assert.IsFalse(Found);

        }
        [TestMethod]
        public void ReportByAddressMethodOK()
        {
            clsCustomerCollection allCustomer = new clsCustomerCollection();
            clsCustomerCollection filteredCustomer = new clsCustomerCollection();

            filteredCustomer.ReportByAddress("");
            Assert.AreEqual(allCustomer.Count, filteredCustomer.Count);
        }

        [TestMethod]
        public void ReportByAddressNoneFound()
        {
            clsCustomerCollection filteredCustomer = new clsCustomerCollection();
            filteredCustomer.ReportByAddress("xxx xxx");
            Assert.AreEqual(0, filteredCustomer.Count);
        }

        [TestMethod]
        public void ReportByNameTestDataFound()
        {
            //create an instance of the filtered data
            clsCustomerCollection filteredAddresses = new clsCustomerCollection();
            //var to store outcome
            Boolean OK = true;
            //apply a name that doesn't exist
            filteredAddresses.ReportByAddress("London");
            //check that the correct number of records are found
            if (filteredAddresses.Count == 1)
            {
               
                if (filteredAddresses.CustomerList[0].CustomerID != 1)
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
