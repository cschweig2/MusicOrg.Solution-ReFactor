using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrg.Models;
using System;

namespace MusicOrg.Tests
{
    [TestClass]
    public class ArtistTests : IDisposable
    {
      public void Dispose()
      {
        Artist.ClearAll();
      }
        [TestMethod]
        public void Find_ReturnInstanceOfArtistWithThatId_Artist()
        {
            Artist artist = new Artist("name");
            Artist artist2 = new Artist("name");
            Artist result = Artist.Find(1);
            Assert.AreEqual(artist, result);
        }
        [TestMethod]
        public void DeleteArtist_RemoveArtistInstance_Void()
        {
          Artist artist = new Artist("name");
          Artist artist2 = new Artist("name");
          Artist.DeleteArtist(1);
          Assert.AreEqual(1, Artist._instances.Count);
        }
        [TestMethod]
        public void DeleteArtist_RemoveArtistInstanceAndResetId_Void()
        {
          Artist artist = new Artist("name");
          Artist artist2 = new Artist("name");
          Artist artist3 = new Artist("name");
          Artist.DeleteArtist(1);
          Artist result = Artist.Find(1);
          Assert.AreEqual(artist2, result);
        }
    }
}