using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        BindingList<Book> Books;

        [TestMethod]
        public void TestMethodSort()
        {
            List<string> actual = college.GetStudentsByGroup(group); //правильный

            List<string> expected = new List<string>(); //наш


            CollectionAssert.AreEqual(expected, actual);           
        }
    }
}