using System;
namespace AutonomousRobot.AI
{

    class SensorReading
    {
        public int SensorId {  get; set; }
        public string Type {  get; set; }
        public double Value {  get; set; }
        public DateTime Timestamp {  get; set; }
        public double Confidence { get; set; }
    }
}
