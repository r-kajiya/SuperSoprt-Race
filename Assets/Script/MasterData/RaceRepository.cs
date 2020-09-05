using Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SuperSport
{
    public class RaceRepository : BaseRepository<RaceModel, RaceDataStore>
    {
        public static RaceRepository I { get; }

        static RaceRepository()
        {
            I = new RaceRepository();
        }

        RaceRepository() : base(new RaceDataStore()) { }
    }
}