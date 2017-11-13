using NUnit.Framework;
using StopwatchService.Models;
using StopwatchService.Models.Enums;
using System;

namespace StopwatchService.Test
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
            //TODO: Bater no banco para verificar se existe
            //Se Sim,  reseta, senão cria.
            Stopwatch newStopwatch = new Stopwatch("Olympio's Stopwatch", "olympio");

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
            //TODO: Bater no banco para verificar se existe
            //Se Sim,  reseta, senão cria.
            stopwatch.Reset();

            //Assert
            Assert.AreEqual(StopwatchStatus.Reseted, stopwatch.Status,
                "Stopwatch without Status reseted.");
            Assert.IsTrue(stopwatch.InitializeDate > stopwatch.CreationDate,
                "Reseted Stopwatch with wrong Initialize Date.");
        }
    }
}
