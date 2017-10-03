using NUnit.Framework;
using Stopwatch_Service.Models;
using Stopwatch_Service.Models.Enums;
using System;

namespace Stopwatch_Service.UnitTest
{
    [TestFixture]
    public class StopwatchTest
    {
        Stopwatch stopwatch;

        [OneTimeSetUp]
        public void Init()
        {
            stopwatch = new Stopwatch("Cronometro1", "olympio");
        }

        [Test]
        public void Create_New_Stopwatch_With_Status_Started()
        {
            //Assert
            Assert.AreEqual(StopwatchStatus.Started, stopwatch.Status, 
                "Stopwatch without Status Started.");
            Assert.AreNotEqual(DateTime.MinValue, stopwatch.CreationDate,
                "Stopwatch not created.");
            Assert.AreNotEqual(DateTime.MinValue, stopwatch.InitializeDate,
                "Stopwatch not initialized.");
        }

        [Test]
        public void Reset_Existent_Stopwatch()
        {
            //Act
            stopwatch.Reset();

            //Assert
            Assert.AreEqual(StopwatchStatus.Reseted, stopwatch.Status,
                "Stopwatch without Status reseted.");
            Assert.IsTrue(stopwatch.InitializeDate > stopwatch.CreationDate,
                "Reseted Stopwatch with wrong Initialize Date.");
        }
    }
}
