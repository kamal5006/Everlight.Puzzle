using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Puzzle.Models
{
    public class BallContainer
    {
        public int ContainerIndex { get; set; }
        public int Lenght { get; set; }

        public void AddBall()
        {
            Lenght++;
        }
    }
}
