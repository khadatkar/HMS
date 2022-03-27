using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class HospitalRepository : IHospitalRepositiory
    {
        private readonly AppDbContext context;

        public HospitalRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Hospital Add(Hospital hospital)
        {
            context.hospitals.Add(hospital);
            context.SaveChanges();
            return hospital;
        }

        public Hospital Delete(int id)
        {
            Hospital hospital = context.hospitals.Find(id);
            if (hospital != null)
            {
                context.hospitals.Remove(hospital);
                context.SaveChanges();
            }
            return hospital;
        }

        public Hospital getHospital(int hosId)
        {
            Hospital hos = context.hospitals.FirstOrDefault(a => a.HospitalId == hosId);
            return hos;
        }

        public IEnumerable<Hospital> GetHospitals(string name)
        {

            List<Hospital> hoslist = context.hospitals.ToArray()
.Where(x => name == null || name.Length == 0 || x.Name.ToLower().StartsWith(name.ToLower())).ToList();
            return hoslist;
        }

        public Hospital Update(Hospital hospitalChanges)
        {
            var hospital = context.hospitals.Attach(hospitalChanges);
            hospital.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return hospitalChanges;
        }
    }
}
