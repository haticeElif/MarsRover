using MarsRover.Core.Entities;
using MarsRover.Core.Tools;
using System;
using Xunit;

namespace MarsRover.TestProject
{
    public class MarsRoverUnitTest
    {
        //[Fact]
        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void MarsRoverTest(string marsParameter, string roboticRoverParameter, string movementUnitsParameter, string expected)
        {
            MarsRoverTool marsRoverTool = new MarsRoverTool(); //Mars ��lemleri Class�n�n �retilmesi.

            #region MarsRoverTravel
            Mars mars = marsRoverTool.NewMars(marsParameter); //Mars Olu�turma ��lemi.
            RoboticRover newRoboticRover = marsRoverTool.NewRoboticRover(roboticRoverParameter); //Mars Y�zeyindeki Gezicinin �lk Olu�um ��lemi.
            
            newRoboticRover = marsRoverTool.TravelRoboticRover(newRoboticRover, movementUnitsParameter); //Gelen Harekete Parametrelerine G�re Gezicinin Son Halinin ��lemi.
            mars.RRovers.Add(newRoboticRover); //Mars�n ��inde �oklu Gezici Olmas� Durumu ��in Mars Gezicilerine Ekleme ��lemi.
            #endregion

            //Mars Y�zeyindeki Gezicilerin Son Konum Bilgileri.
            foreach (var item in mars.RRovers)
            {
                Assert.Equal(expected, string.Format("{0} {1} {2}", item.X, item.Y, item.Direction));
            }
        }
    }
}
