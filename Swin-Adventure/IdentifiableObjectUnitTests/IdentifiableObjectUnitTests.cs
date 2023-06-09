using NUnit.Framework;
using Swin_Adventure;
using System.Xml;

namespace IdentifiableObjectUnitTests
{
    [TestFixture]
    public class Tests
    {
        private IdentifiableObject id;
        private IdentifiableObject idEmpty = new IdentifiableObject(new string[] {}); // All Test Will Apply to it.

        [SetUp]
        public void Setup() // This func will run for every test so the object will always be fresh for each test.
        {
            id = new IdentifiableObject(new string[] { "fred", "bob" }); // Only One Test Apply at a time.
        }

        [Test]
        
        public void AreYouTest() 
        {
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }

        [Test]
        public void NotAreYouTest()
        {
            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("boby"));
        }

        [Test]
        public void CaseSensitiveAreYouTest()
        {
            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("bOB"));
        }

            

        

        [Test]
        public void FirstIDTEST()
        {
            Assert.IsTrue(id.FirstId == "fred");
            

        }

        [Test]
        public void NoIDFirstIDTEST()
        {
            
            Assert.IsTrue(idEmpty.FirstId == "");

        }

        [Test]
        public void AddIDTest()
        {
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
            Assert.IsTrue(id.AreYou("wilma"));

        }


    }
}