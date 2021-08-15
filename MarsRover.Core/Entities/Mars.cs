using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Core.Entities
{
    public class Mars
    {
        public Mars()
        {
            this.RRovers = new List<RoboticRover>();
        }

        [Description("Mars Yüzey Alanının X Ekseni")]
        public int X { get; set; }
        [Description("Mars Yüzey Alanının Y Ekseni")]
        public int Y { get; set; }
        [Description("Mars Yüzeyindeki Geziciler")]
        public List<RoboticRover> RRovers { get; set; }
    }
}
