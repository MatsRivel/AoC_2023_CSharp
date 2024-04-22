using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_2023_03
{
    public class PuzzleSolver
    {
        public List<Component> uniqueNumberComponentsFound;
        public ComponentManager components;
        public PuzzleSolver(string filePath)
        {
            components = ComponentManager.ReadFileToDictionary(filePath);
            uniqueNumberComponentsFound = [];
        }

        public Component? GetDictValue(Tuple<int,int> key)
        {
            return components.Get(key);
        }
        public Component GetDictValueUnchecked(Tuple<int, int> key)
        {
            return components.GetDictValuesUnchecked(key);
        }
        public Tuple<int, int>[] GetDictKeys()
        {
            return components.GetDictKeys();
        }
        public Component[] GetDictValues()
        {
            return components.GetDictValues();
        }

        
        public bool isValidUnseenComponent(Tuple<int,int> tupleCoord, List<int> seen)
        {
            // Only check valid indices.
            if (GetDictValue(tupleCoord) is null)
            {
                return false;
            }
            // Ignore symbols and previously seen numbers.
            Component currentComponent = GetDictValueUnchecked(tupleCoord);
            if (currentComponent.CheckIsSymbol() || seen.Contains(currentComponent.identifier))
            {
                return false;
            }
            return true;
        }
        public int SumOfComponentsAdjacentToSymbols()
        {
            int output = 0;
            List<int> seen = [];
            foreach (Tuple<int, int> tupleCoord in GetDictKeys())
            {
                if (isValidUnseenComponent(tupleCoord, seen))
                {   
                    Component currentComponent = GetDictValueUnchecked(tupleCoord);
                    
                    uniqueNumberComponentsFound.Add(currentComponent);
                    if (IsNeighbourOfSymbol(currentComponent, tupleCoord))
                    {
                        seen.Add(currentComponent.identifier);
                        output += GetValueIfNeighbourOfSymbol(currentComponent, tupleCoord);

                    }

                }
            }
            return output;

        }
        public bool IsNeighbourOfSymbol(Component currentComponent, Tuple<int, int> currentCoord)
        {
            if (currentComponent.CheckIsSymbol())
            {
                return false;
            }
            Tuple<int, int>[] neighbours = getNeighbours(currentCoord);
            foreach (Tuple<int, int> neighbour in neighbours)
            {
                if (GetDictValue(neighbour) is null)
                {
                    continue;
                }
                Component validNeighbour = GetDictValueUnchecked(neighbour);
                if (validNeighbour.CheckIsSymbol()) // Add a number if it has a neighbour that is a symbol.
                {
                    // Only add each number once.
                    return true;
                }
            }
            return false;
        }
        public int GetValueIfNeighbourOfSymbol(Component currentComponent, Tuple<int,int> currentCoord)
        {   
            if (currentComponent.CheckIsSymbol())
            {
                return 0;
            }
            Tuple<int, int>[] neighbours = getNeighbours(currentCoord);
            foreach (Tuple<int, int> neighbour in neighbours)
            {
                if (GetDictValue(neighbour) is null)
                {
                    continue;
                }
                Component validNeighbour = GetDictValueUnchecked(neighbour);
                if (validNeighbour.CheckIsSymbol()) // Add a number if it has a neighbour that is a symbol.
                {
                    // Only add each number once.
                    return currentComponent.GetNumericValueUnchecked();
                }
            }
            return 0;
        }

        public static Tuple<int, int>[] getNeighbours(Tuple<int, int> startCoord)
        {
            List<Tuple<int, int>> neighbours = new();
            for (int i = startCoord.Item1 -1; i <= startCoord.Item1+1; i++)
            {
                for (int j = startCoord.Item2-1;j <= startCoord.Item2+1; j++)
                {
                    if ( (i != startCoord.Item1 || j != startCoord.Item2) &&  (i >= 0) && (j >= 0))
                    {
                        Tuple<int, int> neighbour = new(i, j);
                        neighbours.Add(neighbour);
                    }
                }
            }
            return [.. neighbours];
        }
    }
}
