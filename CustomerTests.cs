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
    public class CustomerTests
    {
        private readonly CustomerValidator _validator;

        public CustomerTests()
        {
            _validator = new CustomerValidator();
        }

        //runs each test
        [Theory]
        [ClassData(typeof(CustomerData))]
        public void CreateVehicle_ShouldAValidVehicle(bool expected, Customer c)
        {
            //Arrange => expected;

            //Act => validates the objects
            var actual = _validator.Validate(c).IsValid;

            //Assert must be equal with the expected what is passed by the VehicleData object array
            Assert.Equal(expected, actual);
        }

        //creates the test objects
        public class CustomerData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                //false => should NOT valid (date of birth)
                yield return new object[] { false, new Customer("firstName", "lastName", new DateTime(2022, 1, 12), "email@ok.hu", "12332112") };
                //false => should NOT valid (firstName, email)
                yield return new object[] { false, new Customer("fs", "lastName", new DateTime(1999, 5, 21), "emailbadhu", "12332112") };
                //true => should valids
                yield return new object[] { true, new Customer("firstName", "lastName", new DateTime(1999, 5, 21), "email@ok.hu", "12332112") };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
