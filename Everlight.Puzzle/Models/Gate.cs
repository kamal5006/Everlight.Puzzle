using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Puzzle.Models
{
    public class Gate
    {
        

        public void ToggleGates()
        {
            if (OpenGateSide == OpenGateSide.Left)
            {
               OpenGateSide = OpenGateSide.Right;
            }
            else
            {
                OpenGateSide = OpenGateSide.Left;
            }
        }


        public Gate LeftGate { get; set; }
        public Gate RightGate { get; set; }
        public OpenGateSide OpenGateSide { get; set; }
        public BallContainer BallContainer { get; set; }
        

    }

    public  enum OpenGateSide
    {
        Left,
        Right
        
    }
}
