using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_05
{
    public class Mapping
    {
        public long destination;
        public long source;
        public long length;
        public Mapping(long destination, long source, long length){
            this.destination = destination;
            this.source = source;
            this.length = length;
        }
        public Mapping(string row)
        {
            long[] nums = row
                .Split(' ')
                .Select(num => long.Parse(num))
                .ToArray();
            destination = nums[0];
            source = nums[1];
            length = nums[2];
        }
        public bool Contains(long sourceValue)
        {
            return source <= sourceValue && sourceValue < source + length;
        }

        public long? TryMap(long sourceValue)
        {
            if (Contains(sourceValue))
            {
                long destinationValue = sourceValue - source + destination;
                return destinationValue;
            }
            else
            {
                return null;
            }
        }
    }
}
