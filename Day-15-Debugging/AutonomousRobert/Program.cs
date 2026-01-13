using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace AutonomousRobot.AI
{
    public enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    class Program
    {
        public static RobotAction DecideRobotAction(List<SensorReading> recentReading,List<SensorReading> sensorHistory)
        {
            DecisionEngine de = new DecisionEngine();
            if (de.IsBatteryCritical(recentReading))
            {
                return RobotAction.Stop;
            }
            else if(de.IsBatteryDrainingFast(sensorHistory))
            {
                return RobotAction.Stop;
            }
            else if (de.GetNearestObstacleDistance(recentReading) < 1.0)
            {
                return RobotAction.Reroute;
            }
            else if (de.IsTemperatureSafe(recentReading))
            {
                return RobotAction.SlowDown;
            }
            else
            {
                return RobotAction.Continue;
            }
        }
        static void Main()
        {
            List<SensorReading> readings = new List<SensorReading>
            {
                new SensorReading{ SensorId =1, Type="Battery", Value=80, Timestamp=DateTime.Now.AddSeconds(10), Confidence=0.3 },
                new SensorReading{ SensorId =3, Type="Battery", Value=60, Timestamp=DateTime.Now.AddSeconds(30), Confidence=0.3 },
                new SensorReading{ SensorId =9, Type="Battery", Value=40, Timestamp=DateTime.Now.AddSeconds(40), Confidence=0.3},
                new SensorReading{ SensorId =2, Type="Temperature", Value=70, Timestamp=DateTime.Now.AddSeconds(40), Confidence=0.2 },
                new SensorReading{ SensorId =4, Type="Temperature", Value=80, Timestamp=DateTime.Now.AddSeconds(50), Confidence=0.2 },
                new SensorReading{ SensorId =5, Type="Vibration", Value=7.5, Timestamp=DateTime.Now.AddSeconds(25), Confidence=0.3 },
                new SensorReading{ SensorId =6, Type="Vibration", Value=8.0, Timestamp=DateTime.Now.AddSeconds(15), Confidence=0.4 },
                new SensorReading{ SensorId =7, Type="Distance", Value=0.9, Timestamp=DateTime.Now.AddSeconds(15), Confidence=0.9 },
                new SensorReading{ SensorId =8, Type="Distance", Value=0.8, Timestamp=DateTime.Now.AddSeconds(15), Confidence=0.8 },
            };

            DateTime now = DateTime.Now;
            DateTime fromTime = now.AddSeconds(-10);
            Console.WriteLine("Date Time of now: "+now);
            Console.WriteLine("Date Time of 10s from now "+fromTime);

            DecisionEngine de = new DecisionEngine();
            List<SensorReading> reads =  de.GetRecentReadings(readings,fromTime);
            foreach(var it in reads)
            {
                Console.WriteLine("Id : "+it.SensorId+" Type: "+it.Type + "  Value: "+it.Value);
            }

            bool crictical = de.IsBatteryCritical(readings);
            Console.WriteLine(crictical);

            double nearestObsc = de.GetNearestObstacleDistance(readings);
            Console.WriteLine(nearestObsc);

            bool temp = de.IsTemperatureSafe(readings);
            Console.WriteLine(temp);

            double AvgVib = de.GetAverageVibration(readings);
            Console.WriteLine(AvgVib);

            Dictionary<string, double> AvgConf=de.CalculateSensorHealth(readings);
            foreach(var read in AvgConf)
            {
                Console.WriteLine(read.Key + " -> "+read.Value);
            }

            List<string> detFulty = de.DetectFaultySensors(readings);
            foreach(string it in detFulty)
            {
                Console.WriteLine(it);
            }

            bool isDraningBattery = de.IsBatteryDrainingFast(readings);
            Console.WriteLine(isDraningBattery);

            double WeightedDistance = de.GetWeightedDistance(readings);
            Console.WriteLine(WeightedDistance);


            Console.WriteLine(Program.DecideRobotAction(reads, readings));






        }
    }
}