using System.Collections.Generic;

namespace MusicOrg.Models
{
    public class Vinyl
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Id { get; }
        private static List<Vinyl> _instances = new List<Vinyl> {};
        public static List<Vinyl> testList = new List<Vinyl> {};

        public Vinyl(string title)
        {
            Title = title;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Vinyl> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Vinyl Find(int id)
        {
            return _instances[id - 1];
        }
    }
}