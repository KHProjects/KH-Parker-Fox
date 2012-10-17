using System;
using LearnEntityFramework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnEntityFramework.Data;
using System.Data.SqlServerCe;
using System.Configuration;

namespace LearnEntityFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataContext context = new DataContext();

            context.Customers.Add(new Customer {FirstName = "seb"});

            context.SaveChanges();
        }

        [TestMethod]
        public void TestConnection()
        {
            SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString);

            cn.Open();
            
        }
       
    }
}
