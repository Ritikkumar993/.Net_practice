namespace AutonomousRobot.AI
{
    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            //var result = sensorHistory.Select(r => r.Timestamp >= fromTime).ToList();
            var result = sensorHistory.Where(r => r.Timestamp >= fromTime).ToList();
            return result;
            
        }

        public bool IsBatteryCritical(List<SensorReading> readings)
        {

            return readings.Any(r => r.Type == "Battery" && r.Value < 20);
        } 

        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var distance = readings.Where(r => r.Type=="Distance").Select(r =>  r.Value);
            return distance.Any()? distance.Min() : double.MaxValue;
        }

        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(r => r.Type== "Temperature").All(r => r.Value <=90);
        }

        public double GetAverageVibration(List<SensorReading> readings)
        {
            var vibration =readings.Where(r => r.Type=="Vibration").Select(r => r.Value);
            return vibration.Any()? vibration.Average(): 0;
        }

        public Dictionary<string ,double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            var reslut = sensorHistory.GroupBy(r => r.Type).ToDictionary(g =>g.Key, g => g.Average(r => r.Confidence));
            return reslut;
        }

        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            var reading = sensorHistory.GroupBy(r => r.Type).Where(r => r.Count(res => res.Confidence<0.4)>2).Select(r => r.Key).ToList();
            return reading;           
        }

        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var reads=sensorHistory.Where(r => r.Type=="Battery").OrderBy(r => r.Timestamp).Select(r => r.Value).ToList();
            return reads.Zip(reads.Skip(1), (a ,b) => a>b ).All(x => x);
        }

        public double GetWeightedDistance( List<SensorReading> readings)
        {
            var reads = readings.Where( r => r.Type=="Distance");
            double weightedSum = reads.Sum(r =>r.Value*r.Confidence);
            double totalConfidence = reads.Sum(r => r.Confidence);
            return totalConfidence==0?double.MaxValue:(weightedSum/totalConfidence);
        }


    }
}