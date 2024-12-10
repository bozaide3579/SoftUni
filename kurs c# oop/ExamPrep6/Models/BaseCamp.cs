using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private readonly List<string> _residents = new List<string>();
        public IReadOnlyCollection<string> Residents => _residents;

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}
