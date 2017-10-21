using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everlight.Puzzle.Models;


namespace Everlight.Puzzle
{
    public  static class PuzzleSystem
    {
        
        private static int _systemDepth;
        private static int _ballsNumber;
        private static Random _random;
        public static List<BallContainer> SystemContainers { get; set; }
        private static List<Gate> Gates { get; set; }
        private static Gate RoorGate { get; set; }
        public static void Initialize()
        {
            string systemDepthString = ConfigurationManager.AppSettings["SystemDepth"];
            bool parseResult = int.TryParse(systemDepthString, out _systemDepth);
            if (!parseResult || _systemDepth<1)
            {
                throw new ApplicationException("Wrong system depth value! Please make sure that the configured value for system depth is a positve integer");
            }
            _random = new Random();
            _ballsNumber = (int)(Math.Pow(2, _systemDepth) - 1);
            SystemContainers = new List<BallContainer>();
            RoorGate = BuildGate(1);
        }

        public static void Run()
        {
            InitializeGates(RoorGate);
            SystemContainers.ForEach(sc=>sc.Lenght=0);
            for(int i= 1;i<=_ballsNumber;i++)
            {
                PassBall(RoorGate);
            }
        }

        private static void PassBall(Gate gate)
        {
            if (gate.LeftGate !=null && gate.OpenGateSide == OpenGateSide.Left)
            {
                PassBall(gate.LeftGate);
                gate.ToggleGates();
            }
            else if (gate.RightGate != null && gate.OpenGateSide == OpenGateSide.Right)
            {
                PassBall(gate.RightGate);
                gate.ToggleGates();
            }
            // Add the ball the container of the leaf node
            else
            {
                gate.BallContainer?.AddBall();
            }
        }

        private static void InitializeGates(Gate gate)
        {
            if (gate != null && gate.RightGate != null && gate.LeftGate != null)
            {
                
                int randomValue = _random.Next(0, 2);
                gate.OpenGateSide = (OpenGateSide)randomValue;
                InitializeGates(gate.LeftGate);
                InitializeGates(gate.RightGate);

            }

        }
        private static Gate BuildGate(int level)
        {
            var gate = new Gate();
            if (level > _systemDepth)
            {
                gate.BallContainer = new BallContainer {ContainerIndex = SystemContainers.Count + 1};
                SystemContainers.Add(gate.BallContainer);
                return gate;
            }
            
            gate.RightGate = BuildGate(level + 1);
            gate.LeftGate = BuildGate(level + 1);
            return gate;
        }

       

    }
}
