using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repository.IRepository
{
    public interface IPlatesRepository
    {
        ICollection<Plate> GetPlates();
        Plate GetPlate(int plateId);
        bool PlateExists(string name);
        bool PlateExists(int id);
        bool CreatePlate(Plate plate);
        bool UpdatePlate(Plate plate);
        bool DeletePlate(Plate plate);
        bool Save();

    }
}
