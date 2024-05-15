using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_05
{
    public class GroupManager
    {
        public long[] seeds;
        public MapGroup[] groups;
        private MapGroup condencedGroup;

        private long[] ExtractSeedsFromString(string seedString)
        {
            string cleanedSeedString = seedString.Substring(6, seedString.Length - 6);
            long[] cleanedSeeds = cleanedSeedString.Split(' ')
                .Where(s => s != "")
                .Select(s => long.Parse(s))
                .ToArray();
            return cleanedSeeds;
        }
        public GroupManager(string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            string seedString = lines.First();
            seeds  = ExtractSeedsFromString(seedString);
            groups = ExtractGroupsFromLines(lines);
            

        }

        private MapGroup[] ExtractGroupsFromLines(IEnumerable<string> lines)
        {
            List<List<string>> stringGroups = new List<List<string>>();
            List<string> innerStringGroup = new List<string>();
            foreach (string line in lines.Skip(2))
            {
                if (line.Length <= 4)
                {
                    stringGroups.Add(innerStringGroup);
                    innerStringGroup = new List<string>();
                }
                else
                {
                    innerStringGroup.Add(line);
                }
            }
            stringGroups.Add(innerStringGroup);
            MapGroup[] output = stringGroups
                            .Select(group => new MapGroup(string.Join("\n", group)))
                            .ToArray();
            return output;
        }

        public long ProcessSeed(long seedNumber)
        {
            return groups.Aggregate(seedNumber, (agg, group )=> group.ApplyMapping(agg));
        }
        public long GetSmallestOutputSeed()
        {
            long[] processedSeeds = seeds.Select(seed => ProcessSeed(seed)).ToArray();
            return processedSeeds.Min();
        }
        public MapGroup CondenceMap(List<(long,long)> ranges)
        {   
            List<Mapping> mapList = new List<Mapping>();
            for (int i = 0; i < ranges.Count; i++)
            {
                long rangeStart = ranges[i].Item1;
                long rangeLength = ranges[i].Item2;
                long? prevVal = null;
                long? currentVal = null;
                long? nextVal = null;
                long newRangeStart = rangeStart;
                long mapStep = ProcessSeed(newRangeStart) - newRangeStart;

                for (long j = rangeStart; j < rangeStart+rangeLength; j++)
                {
                    long processedSeed = ProcessSeed(j);
                    prevVal = currentVal;
                    currentVal = nextVal;
                    nextVal = processedSeed;
                    bool endIsReached = j == newRangeStart + rangeLength;
                    bool newMappingRequired = currentVal - prevVal != nextVal - currentVal;
                    if (newMappingRequired|| endIsReached)
                    {
                        long source = newRangeStart;
                        long destination = source + mapStep;
                        long length = j-newRangeStart+1;
                        Mapping newMap = new Mapping( destination, source, length );
                        mapList.Add(newMap);
                        newRangeStart = j;
                        mapStep = processedSeed - j;
                    }
                }
            }
            return new MapGroup("seed-to-location", mapList);
        }

        public long ProcessSeedCondenced(long seed)
        {   
            if (condencedGroup is null)
            {
                List<(long, long)> condencedSeedRanges = new List<(long, long)>();
                for (int i = 0; i < seeds.Length; i += 2)
                {
                    condencedSeedRanges.Add((seeds[i]-1, seeds[i + 1]+2));
                }
                condencedGroup= CondenceMap(condencedSeedRanges);
            }

            return condencedGroup.ApplyMapping(seed);
        }
    }
}
