using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketPharmacy.Core.Models;

namespace PocketPharmacyTests.Core.Models
{
    [TestClass()]
    public class MedicineTests
    {
        [TestMethod()]
        public void IsExpiredTest_IsExpired_ShouldBeExpired()
        {
            //Arrange
            var dosage = new Dosage
            {
                PerDays = 1,
                Amount = 2,
                Unit = "pills"
            };

            var medicine = new Medicine
            {
                Id = 1,
                Name = "Magic Pills For Everything",
                Description = "...",
                Amount = 30,
                Unit = "pills",
                ExpirationDate = new DateTime(2020, 09, 01),
                NeedPrescription = true,
                Dosage = dosage
            };

            // Act
            var actual = medicine.IsExpired();

            // Assert
            Assert.AreEqual(true, actual, "Test fails when medicine is expired.");
        }

        [TestMethod()]
        public void IsExpiredTest_IsExpired_ShouldNotBeExpired()
        {
            //Arrange
            var dosage = new Dosage
            {
                PerDays = 1,
                Amount = 2,
                Unit = "pills"
            };

            var medicine = new Medicine
            {
                Id = 1,
                Name = "Magic Pills For Everything",
                Description = "...",
                Amount = 30,
                Unit = "pills",
                ExpirationDate = new DateTime(2021, 12, 31),
                NeedPrescription = true,
                Dosage = dosage
            };

            // Act
            var actual = medicine.IsExpired();

            // Assert
            Assert.AreEqual(false, actual, "Test fails when medicine is not expired.");
        }
    }
}
