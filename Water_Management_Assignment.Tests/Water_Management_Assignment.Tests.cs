using FluentAssertions;
using Xunit;
using Program = Water_Management_Assignment.Program;



namespace WaterManagementTests
{
    public class Tests
    {
        [Fact]
        public void Task_AllotWater()
        {
            var apartmentType = 2;
            var corporationWater = 1;
            var borewellWater = 2;



            var expectedResult = 300;



            Program program = new Program();



            var actualResult = program.allotWater(apartmentType, corporationWater, borewellWater);



            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Task_AddGuest()
        {
            var addGuest = 4;



            var expectedResult = 1200;



            Program program = new Program();



            var actualResult = program.addGuest(addGuest);



            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Task_GetBill()
        {
            Program program = new Program();
            var actualResult = program.getBill();



            actualResult.GetType().Should().Be(typeof(String));
        }
    }
}

has context menu
