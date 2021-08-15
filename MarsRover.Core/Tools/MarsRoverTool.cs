using MarsRover.Core.Entities;
using MarsRover.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Core.Tools
{
    public class MarsRoverTool
    {
        [Description("Gelen Mars Parametresine Göre Mars Nesnesini Oluşturan Metot.")]
        public Mars NewMars(string marsParameter)
        {
            var mars = new Mars(); //Mars Nesnesinin Oluşturulması.
            string[] marsDimension = marsParameter.Split(' '); //Gelen Parametrenin Boşluğa Göre Split Edilmesi.
            mars.X = Convert.ToInt32(marsDimension[0]); //İlk Değerin integer'a Cast Edilerek X Eksenine Atanması.
            mars.Y = Convert.ToInt32(marsDimension[1]); //İkinci Değerin integer'a Cast Edilerek Y Eksenine Atanması.
            return mars; //Mars Nesnesinin Döndürülmesi.
        }

        [Description("Gelen Gezici Parametresine Göre Gezici Nesnesini Oluşturan Metot.")]
        public RoboticRover NewRoboticRover(string roboticRoverParameter)
        {
            var roboticRover = new RoboticRover(); //Gezicinin Oluşturulması.
            var roboticRoverParameters = roboticRoverParameter.Split(' '); //Gelen Parametrenin Boşluğa Göre Split Edilmesi.
            roboticRover.X = Convert.ToInt32(roboticRoverParameters[0]); //İlk Değerin integer'a Cast Edilerek X Koordinatına Atanması.
            roboticRover.Y = Convert.ToInt32(roboticRoverParameters[1]); //İkinci Değerin integer'a Cast Edilerek Y Koordinatına Atanması.
            roboticRover.Direction = (Enums.DirectionEnum)System.Enum.Parse(typeof(Enums.DirectionEnum), roboticRoverParameters[2]); //Üçüncü Değerin Yön Enumına Cast Edilerek Gezicinin Yönünün Belirlenmesi.
            return roboticRover; //Gezici Nesnesinin Döndürülmesi.
        }

        [Description("Gelen Gezici ve Gezme Parametresine Göre Gezici Nesnesinin Hareketini Sağlayan Metot.")]
        public RoboticRover TravelRoboticRover(RoboticRover roboticRover, string movementUnitsParameter)
        {
            var movementUnitsParameters = movementUnitsParameter.ToCharArray(); //Gezme Parametresinin Karakterlere Ayrım İşlemi.
            foreach (var movementUnit in movementUnitsParameters) //Gezme Parametrelerinin Kontrolü.
            {
                if (movementUnit == 'M') //Gezme Parametresi Move İse
                {
                    switch (roboticRover.Direction) //Yön Bilgisine Göre Gezicinin İlerletilmesi.
                    {
                        case Enums.DirectionEnum.N:
                            roboticRover.Y += 1;
                            break;
                        case Enums.DirectionEnum.E:
                            roboticRover.X += 1;
                            break;
                        case Enums.DirectionEnum.S:
                            roboticRover.Y -= 1;
                            break;
                        case Enums.DirectionEnum.W:
                            roboticRover.X -= 1;
                            break;
                    }
                }
                else
                {
                    if ((Enums.MovementUnitEnum)movementUnit == Enums.MovementUnitEnum.Right) //Gezme Parametresi Sağa Dönme İşlemi İse
                        roboticRover.Direction = EnumProvider.Next<Enums.DirectionEnum>(roboticRover.Direction); //Gezicinin Yön Enumının Sonraki Enumı.
                    else //Gezme Parametresi Sola Dönme İşlemi İse
                        roboticRover.Direction = EnumProvider.Previous<Enums.DirectionEnum>(roboticRover.Direction); //Gezicinin Yön Enumının Önceki Enumı.
                }
            }
            return roboticRover; //Yeni Bilgiler İle Gezicinin Geri Döndürülmesi.
        }

    }
}
