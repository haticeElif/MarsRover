using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Core.Enum
{
    public class Enums
    {
        [Description("Yön Enumları")]
        public enum DirectionEnum
        {
            [System.ComponentModel.Description("North")]
            N = 0,
            [System.ComponentModel.Description("East")]
            E = 1,
            [System.ComponentModel.Description("South")]
            S = 2,
            [System.ComponentModel.Description("West")]
            W = 3,
        }

        [Description("Hareket Enumları")]
        public enum MovementUnitEnum
        {
            [System.ComponentModel.Description("Right")]
            Right = 'R',
            [System.ComponentModel.Description("Left")]
            Left = 'L',
        }
    }
}
