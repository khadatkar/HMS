using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public interface IHospitalRepositiory
    {
        public Hospital getHospital(int hosId);
        public IEnumerable<Hospital> GetHospitals(string name);
        Hospital Add(Hospital hospital);
        Hospital Update(Hospital hospitalChanges);
        Hospital Delete(int id);
    }
}
