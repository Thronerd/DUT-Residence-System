using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Logic
{
    public class Business
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Residence> getAllResidences()
        {
            return db.Residences.ToList();
        }
        public List<Residence>LetterSearch(string Letter)
        {
            return db.Residences.Where(x => x.ResName.StartsWith(Letter)).ToList();
        }
        public List<Residence>ResSearch(string search)
        {
            return db.Residences.Where(x => x.ResName.Contains(search) || x.ResName.StartsWith(search)).ToList();
        }
        public Residence ResDetails(string id)
        {
            return db.Residences.Find(id);
        }
        public List<Rooms> RoomsByRes(string ResId)
        {
            var result2 = db.Rooms.Where(x => x.residenceCode == ResId).ToList();
            return result2;
        }
    }
}
