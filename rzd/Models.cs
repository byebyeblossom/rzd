using System;

namespace TrainRzdApp
{
    // Модель Поезда
    public class Train
    {
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public string TrainType { get; set; }
        public int MaxSpeed { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
    }

    // Модель Бригады
    public class Crew
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public string DriverName { get; set; }
        public string AssistantName { get; set; }
        public int Experience { get; set; }
    }

    // Модель Назначения
    public class Assignment
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public int CrewId { get; set; }
        public string TrainNumber { get; set; }
        public string CrewName { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Route { get; set; }
    }
}