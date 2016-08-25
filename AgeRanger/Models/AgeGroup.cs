using System;

namespace AgeRanger.Models
{
    public class AgeGroup
    {
        public Int64 Id { get; set; }

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string Description { get; set; }
    }
}