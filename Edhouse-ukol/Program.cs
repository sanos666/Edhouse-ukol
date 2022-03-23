using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edhouse_ukol
{
    class Program
    {
        public static void Drive(Truck driver, List<string> navigation, int lowerBound, int upperBound)
        {
            int distanceDriven = 0;
            foreach(string step in navigation)
            {
                string direction = new string(step.Where(char.IsLetter).ToArray());
                int.TryParse(step.Where(char.IsDigit).ToArray(), out int distance);

                switch(direction)
                {
                    case "W":
                        {
                            while(distance > 0)
                            {
                                driver.MoveOneStepWest();
                                distanceDriven++;
                                if (distanceDriven >= lowerBound && distanceDriven <= upperBound)
                                    driver.AddCurrentPostitionToList();
                                distance--;
                            }
                            break;
                        }
                    case "E":
                        {
                            while (distance > 0)
                            {
                                driver.MoveOneStepEast();
                                distanceDriven++;
                                if (distanceDriven >= lowerBound && distanceDriven <= upperBound)
                                    driver.AddCurrentPostitionToList();
                                distance--;
                            }
                            break;
                        }
                    case "N":
                        {
                            while (distance > 0)
                            {
                                driver.MoveOneStepNorth();
                                distanceDriven++;
                                if (distanceDriven >= lowerBound && distanceDriven <= upperBound)
                                    driver.AddCurrentPostitionToList();
                                distance--;
                            }
                            break;
                        }
                    case "S":
                        {
                            while (distance > 0)
                            {
                                driver.MoveOneStepSouth();
                                distanceDriven++;
                                if (distanceDriven >= lowerBound && distanceDriven <= upperBound)
                                    driver.AddCurrentPostitionToList();
                                distance--;
                            }
                            break;
                        }
                    default: break;
                }
            }
        }

        public static Coords ChooseMeetingPoint(Truck driver1, Truck driver2)
        {
            foreach(Coords coords in driver1.possibleMeetingCoords)
            {
                if (driver2.possibleMeetingCoords.Contains(coords))
                    return coords;
            }
            Console.WriteLine("Error, meeting point not found!");
            return new Coords(0, 0);
        }

        static void Main(string[] args)
        {
            Truck driver1 = new Truck();
            Truck driver2 = new Truck();
            List<string> navigation1 = new List<string>();
            List<string> navigation2 = new List<string>();
            int lowerBound, upperbound;
            lowerBound = upperbound = 0;

            try
            {
                //StreamReader sr = new StreamReader(@"..\..\..\..\test.txt");
                StreamReader sr = new StreamReader(@"..\..\..\..\source.txt");
                var line = sr.ReadLine();
                int.TryParse(line.Split('-')[0], out lowerBound);
                int.TryParse(line.Split('-')[1], out upperbound);
                line = sr.ReadLine();
                navigation1 = line.Split(',').ToList();
                line = sr.ReadLine();
                navigation2 = line.Split(',').ToList();
                sr.Close();
            }
            catch
            {
                Console.WriteLine("Error reading file");
            }

            Drive(driver1, navigation1, lowerBound, upperbound);
            Drive(driver2, navigation2, lowerBound, upperbound);

            Coords meetingPoint = ChooseMeetingPoint(driver1, driver2);
            Console.WriteLine("Meeting point: [{0},{1}]", meetingPoint.axisX, meetingPoint.axisY);
        }
    }
}
