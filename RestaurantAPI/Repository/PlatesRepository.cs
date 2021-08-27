using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using RestaurantAPI.Repository.IRepository;

namespace RestaurantAPI.Repository
{
    public class PlatesRepository : IPlatesRepository
    {
        private readonly ApplicationDBContext _db;

        public PlatesRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public ICollection<Plate> GetPlates()
        {
            return _db.Plates.OrderBy(a => a.Price).ToList();
        }

        public Plate GetPlate(int plateId)
        {
            return _db.Plates.FirstOrDefault(a => a.id == plateId);
        }

        public bool PlateExists(string name)
        {
            bool value = _db.Plates.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool PlateExists(int id)
        {
            return _db.Plates.Any(a => a.id == id);
        }

        public bool CreatePlate(Plate plate)
        {
            _db.Plates.Add(plate);
            return Save();
        }

        public bool UpdatePlate(Plate plate)
        {
            _db.Plates.Update(plate);
            return Save();
        }

        public bool DeletePlate(Plate plate)
        {
            _db.Plates.Remove(plate);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
