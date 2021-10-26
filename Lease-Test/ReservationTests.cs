using EcoLease_Admin.Models;
using EcoLease_Admin.Validators;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Xunit.EcoLease_Admin.test
{
    public class ReservationTests
    {
        private readonly ReservationValidator _validator;

        public ReservationTests()
        {
            _validator = new ReservationValidator();
        }

        //runs each test
        [Theory]
        [ClassData(typeof(ReservationData))]
        public void CreateReservation_ShouldAReservation(bool expected, Reservation r)
        {
            //Arrange => expected;

            //Act => validates the objects
            var actual = _validator.Validate(r).IsValid;

            //Assert must be equal with the expected what is passed by the VehicleData object array
            Assert.Equal(expected, actual);
        }

        //creates the test objects
        public class ReservationData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                //false => should NOT valid (wrong dates)
                yield return new object[] { false, new Reservation(123, new DateTime(2010,1,10), new DateTime(2020, 1, 10), "Pending", new Customer("firstName", "lastName", new DateTime(1999, 5, 21), "email@ok.hu", "12332112"), new Vehicle(111, "Bmw", "850i", 2021, "J-352-SP", 100, "Beast!", "Available", "img1.jpg", 750))  };
                //false => should NOT valid (status)
                yield return new object[] { false, new Reservation(123, DateTime.Now.AddDays(1), DateTime.Now.AddDays(600), "Not valid", new Customer("firstName", "lastName", new DateTime(1999, 5, 21), "emailok.hu", "12332112"), new Vehicle(111, "Bmw", "850i", 2021, "J-352-SP", 100, "Beast!", "Available", "img1.jpg", 750)) };
                //true => should valids
                yield return new object[] { true, new Reservation(123, DateTime.Now.AddDays(5), DateTime.Now.AddDays(600), "Pending", new Customer("firstName", "lastName", new DateTime(1999, 5, 21), "email@ok.hu", "12332112"), new Vehicle(111, "Bmw", "850i", 2021, "J-352-SP", 100, "Beast!", "Available", "img1.jpg", 750)) };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
