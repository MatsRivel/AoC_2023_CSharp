using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_05
{
    public class MapGroup
    {
        public List<Mapping> maps = new List<Mapping>();
        public string name;
        public MapGroup(string name, List<Mapping> maps)
        {
            this.name = name;
            this.maps = maps;
        }
        public MapGroup(string dataString)
        {
            string[] lines = dataString.Split('\n');
            foreach(string line in lines)
            {
                if (line.EndsWith(" map:"))
                {
                    name = line.Substring(0, line.Length - 5);
                    _=false;
                }
                else if (line.Length > 0)
                {
                    maps.Add(new Mapping(line));
                }

            }
        }

        public long ApplyMapping(long seedNumber)
        {
            foreach (Mapping map in maps) {
                long? mappedValue = map.TryMap(seedNumber);
                if (mappedValue != null)
                {
                    return (long)mappedValue;
                }
            }
            return seedNumber;
        }
    }
}
