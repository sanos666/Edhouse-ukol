using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edhouse_ukol
{
    public struct Coords
    {
        public int axisX;
        public int axisY;

        public Coords(int x, int y)
        {
            this.axisX = x;
            this.axisY = y;
        }
    }

    public class Truck
    {
        public Coords actualPosition;
        public List<Coords> possibleMeetingCoords { get; set; }

        public Truck()
        {
            this.actualPosition = new Coords(0, 0);
            this.possibleMeetingCoords = new List<Coords>();
        }

        public void MoveOneStepWest()
        {
            this.actualPosition.axisX--;
        }

        public void MoveOneStepEast()
        {
            this.actualPosition.axisX++;
        }

        public void MoveOneStepNorth()
        {
            this.actualPosition.axisY++;
        }

        public void MoveOneStepSouth()
        {
            this.actualPosition.axisY--;
        }

        public void AddCurrentPostitionToList()
        {
            Coords currentPostition = this.actualPosition;
            this.possibleMeetingCoords.Add(currentPostition);
        }
    }
}
