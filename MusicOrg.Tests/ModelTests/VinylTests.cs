using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrg.Models;
using System;

namespace MusicOrg.Tests
{
    [TestClass]
    public class VinylTests : IDisposable
    {
        public void Dispose()
        {
            Vinyl.ClearAll();
        }
        [TestMethod]
        public void VinylConstructor_CreatesInstanceOfVinyl_Vinyl()
        {
            Vinyl newVinyl = new Vinyl("Abbey Road");
            Assert.AreEqual(typeof(Vinyl), newVinyl.GetType());
        }
        [TestMethod]
        public void GetTitle_ReturnsTitleOfVinyl_String()
        {
            string title = "Abbey Road";
            Vinyl newVinyl = new Vinyl(title);
            string result = newVinyl.Title;
            Assert.AreEqual(title, result);
        }
        [TestMethod]
        public void GetAll_ReturnsListOfVinyls_List()
        {
            Vinyl newVinyl = new Vinyl("title");
            Vinyl newVinyl2 = new Vinyl("title");
            List<Vinyl> newList = new List<Vinyl> { newVinyl, newVinyl2};
            List<Vinyl> result = Vinyl.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }
        [TestMethod]
        public void Find_ReturnsInstanceOfVinylWithThatId_Vinyl()
        {
            Vinyl newVinyl = new Vinyl("title");
            Vinyl newVinyl2 = new Vinyl("title");
            Vinyl result = Vinyl.Find(1);
            Assert.AreEqual(newVinyl, result);

        }
    }
}