using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketPharmacy.Core.Models;

namespace PocketPharmacyTests.Core.Models
{
    [TestClass]
    public class MedicineTests
    {
        [TestMethod]
        public void IsExpiredTest_IsExpired_ShouldBeExpired()
        {
            // Arrange
            var dosage = new Dosage
            {
                PerDay = 1,
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
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsExpiredTest_IsExpired_ShouldNotBeExpired()
        {
            // Arrange
            var dosage = new Dosage
            {
                PerDay = 1,
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
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetWeeklyDosageTest()
        {
            // Arrange
            var dosage = new Dosage
            {
                PerDay = 2,
                Amount = 4,
                Unit = "mg"
            };

            var medicine = new Medicine
            {
                Id = 1,
                Name = "Magic Pills For Everything 300mg",
                Description = "...",
                Amount = 300,
                Unit = "mg",
                ExpirationDate = new DateTime(2021, 12, 31),
                NeedPrescription = true,
                Dosage = dosage
            };

            // Act
            var actual = medicine.GetWeeklyDosage();

            // Assert
            Assert.AreEqual(56, actual);
        }

        [TestMethod]
        public void HasWeeklyDosageTest_ShouldHave()
        {
            // Arrange
            var dosage = new Dosage
            {
                PerDay = 2,
                Amount = 4,
                Unit = "mg"
            };

            var medicine = new Medicine
            {
                Id = 1,
                Name = "Magic Pills For Everything 300mg",
                Description = "...",
                Amount = 300,
                Unit = "mg",
                ExpirationDate = new DateTime(2021, 12, 31),
                NeedPrescription = true,
                Quantity = 10,
                Dosage = dosage
            };

            // Act
            var actual = medicine.HasWeeklyDosage();

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void HasWeeklyDosageTest_ShouldNotHave()
        {
            // Arrange
            var dosage = new Dosage
            {
                PerDay = 2,
                Amount = 300,
                Unit = "mg"
            };

            var medicine = new Medicine
            {
                Id = 1,
                Name = "Magic Pills For Everything 300mg",
                Description = "...",
                Amount = 300,
                Unit = "mg",
                ExpirationDate = new DateTime(2021, 12, 31),
                NeedPrescription = true,
                Quantity = 13,
                Dosage = dosage
            };

            // Act
            var actual = medicine.HasWeeklyDosage();

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
