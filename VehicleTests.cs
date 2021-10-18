using EcoLease_Admin.Models;
using EcoLease_Admin.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunit.EcoLease_Admin.test
{
    public class VehicleTests
    {
        private readonly VehicleValidator _validator;

        public VehicleTests()
        {
            _validator = new VehicleValidator();
        }

        //runs each test
        [Theory]
        [ClassData(typeof(VehicleData))]
        public void CreateVehicle_ShouldAValidVehicle(bool expected, Vehicle v)
        {
            //Arrange => expected;

            //Act => validates the objects
            var actual = _validator.Validate(v).IsValid;

            //Assert must be equal with the expected what is passed by the VehicleData object array
            Assert.Equal(expected, actual);
        }

        //creates the test objects
        public class VehicleData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                //true => should valid
                yield return new object[] { true, new Vehicle(111, "Bmw", "850i", 2021, "J-352-SP", 100, "Beast!", "Available", "img1.jpg", 750) };
                //true => should valid
                yield return new object[] { true, new Vehicle("Audi", "A8", 2020, "K-234-DP", 120, null, "Out of Service", "img2.jpg", 850) };
                //true should NOT valid (wrong registered year)
                yield return new object[] { false, new Vehicle(123, "asd", "Civic", 1015, "S-222-SS", 25000, null, "Out of Service", "img3.jpg", 250) };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
