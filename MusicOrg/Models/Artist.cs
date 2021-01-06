using System;
using System.Collections.Generic;

namespace MusicOrg.Models
{
  public class Artist
  {
    public string Name {get; set;}
    public int Id {get; set;}
    public static List<Artist> _instances = new List<Artist>{};
    public List<Vinyl> Records = new List<Vinyl>{};

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static Artist Find(int id)
    {
      return _instances[id - 1];
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void DeleteArtist(int id)
    {
      _instances.RemoveAt(id - 1);
      for(int index = 0; index < _instances.Count; index++)
      {
        _instances[index].Id = index + 1;
      }
    }

    public static void ClearAll()
    {
        _instances.Clear();
    }

  }
}