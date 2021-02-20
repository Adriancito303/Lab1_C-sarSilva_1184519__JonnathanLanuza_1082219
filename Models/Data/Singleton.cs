using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models.Data
{
    public class Singleton
    {
        private readonly static Singleton Plays = new Singleton();
        public List<MLSplayers> ListPlayers;

        private Singleton()
        {
            ListPlayers = new List<MLSplayers>();
        }

        public static Singleton Playrs
        {
            get
            {
                return Plays;
            }
        }
    }
}
