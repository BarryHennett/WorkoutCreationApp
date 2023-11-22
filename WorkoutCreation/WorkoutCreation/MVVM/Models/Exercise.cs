using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutCreation.MVVM.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sets { get; set; }
        public decimal Reps { get; set; }

        public Exercise Clone() => MemberwiseClone() as Exercise;
    }
}
