using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static MarsRover.Core.Enum.Enums;

namespace MarsRover.Core.Entities
{
    public class RoboticRover
    {
        [Description("Gezici X Koordinatı")]
        public int X { get; set; }
        [Description("Gezici Y Koordinatı")]
        public int Y { get; set; }
        [Description("Gezicin Yön Bilgisi")]
        public DirectionEnum Direction { get; set; }
    }
}
