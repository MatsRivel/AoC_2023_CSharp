using System.Collections.Generic;

namespace AoC_2023_03.Test
{
    public class PuzzleSolverShould
    {   
        public static string AddFileNameToDirPath(string fileName)
        {
            return $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_03.Test\\{fileName}";
        }
        [Fact]
        public void ReadInputFileToHashMap()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            Dictionary<Tuple<int,int>,Component> output = puzzleSolver.components.dict;
            Assert.NotEmpty(output);

        }
        [Fact] 
        public void AssignMultipleIndicesToMultiDigitNumbers()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            // First 3 characters in the test data is "467", so each index should refer to the number 467.
            Tuple<int, int> tupleA = new(0, 0);
            Tuple<int, int> tupleB = new(0, 1);
            Tuple<int, int> tupleC = new(0, 2);
            
            Assert.Equal(puzzleSolver.GetDictValueUnchecked(tupleA), puzzleSolver.GetDictValueUnchecked(tupleB));
            Assert.Equal(puzzleSolver.GetDictValueUnchecked(tupleB), puzzleSolver.GetDictValueUnchecked(tupleC));

            Tuple<int, int> tupleD = new(2, 6);
            Tuple<int, int> tupleE = new(2, 7);
            Tuple<int, int> tupleF = new(2, 8);
            Assert.Equal(puzzleSolver.GetDictValueUnchecked(tupleD), puzzleSolver.GetDictValueUnchecked(tupleE));
            Assert.Equal(puzzleSolver.GetDictValueUnchecked(tupleE), puzzleSolver.GetDictValueUnchecked(tupleF));

            Assert.NotEqual(puzzleSolver.GetDictValueUnchecked(tupleA), puzzleSolver.GetDictValueUnchecked(tupleE));
            Assert.NotEqual(puzzleSolver.GetDictValueUnchecked(tupleC), puzzleSolver.GetDictValueUnchecked(tupleF));
        }
        [Fact]
        public void HaveKnownNumbersInCorrectPositions()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            Dictionary<Tuple<int, int>, Component> output = puzzleSolver.components.dict;
            // First 3 characters in the test data is "467", so each index should refer to the number 467.
            Tuple<int, int> tupleA = new(0, 0);
            Tuple<int, int> tupleB = new(0, 1);
            Tuple<int, int> tupleC = new(0, 2);

            // These 3 characters in the test data is "633", so each index should refer to the number 467.
            Tuple<int, int> tupleD = new(2, 6);
            Tuple<int, int> tupleE = new(2, 7);
            Tuple<int, int> tupleF = new(2, 8);

            Tuple<int, int>[] tuples = [tupleA, tupleB, tupleC, tupleD, tupleE, tupleF];
            foreach (Tuple<int,int> tupleIdx in tuples)
            {
                Assert.NotNull(output[tupleIdx]);
            }
        }

        [Fact]
        public void OnlyAddTogetherNumbersAdjacentToComponents()
        {
            int expected = 4361;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void OnlyAddEachNumberOnce()
        {
            int expected = 111;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput2.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void OnlyUseEachNumberOncePerSymbol()
        {
            int expected = 2;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput3.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void UseOneSymbolMultipleTimesForDifferentNumbers()
        {
            int expected = 4;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput4.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void OnlyAddNumbersAdjacentToSymbols()
        {
            int expected = 0;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput5.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DealsWithOneCriteriaAtOnce()
        {
            int expected = 200;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput8.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DealsWithTwoCriteriaAtOnce()
        {
            int expected = 300;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput7.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DealsWithMultipleCriteriaAtOnce()
        {
            int expected = 630;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput6.txt"));
            int actual = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindsTheCorrectNumberOfUniqueNumbers()
        {
            int expected = 10;
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            _ = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            int actual = puzzleSolver.uniqueNumberComponentsFound.Count();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FindsAllTheCorrectUniqueNumbers()
        {
            List<int> expected = new() { 467, 114, 35, 633, 617, 58, 592, 755, 664, 598 };
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            _ = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            List<Component> componentsFound = puzzleSolver.uniqueNumberComponentsFound;
            List<int> actual = [];
            foreach (Component component in componentsFound)
            {
                actual.Add(component.GetNumericValueUnchecked());
            }
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void FindsAllTheCorrectUniqueNumberIndices()
        {
            List<int> expected = new() { 0,5,2,6,0,7,2,6,1,5 };
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            _ = puzzleSolver.SumOfComponentsAdjacentToSymbols();
            List<Component> componentsFound = puzzleSolver.uniqueNumberComponentsFound;
            for (int i = 0; i < componentsFound.Count; i++)
            {
                Assert.Equal(expected[i], componentsFound[i].idx);
            }
        }

        [Fact]
        public void FindCorrectNeighboursAtEdge()
        {
            Tuple<int, int> startCoord = new(0, 0);
            Tuple<int, int>[] expected = [new(0, 1), new(1, 0), new(1, 1)];
            Tuple<int, int>[] neighbours = PuzzleSolver.getNeighbours(startCoord);
            Assert.Equivalent(expected, neighbours);
        }

        [Fact]
        public void FindCorrectNeighbours()
        {
            Tuple<int, int> startCoord = new(3, 3);
            Tuple<int, int>[] expected = [
                new(2, 2), new(2, 3), new(2, 4),
                new(3, 2)           , new(3, 4),
                new(4, 2), new(4, 3), new(4, 4)
                ];
            Tuple<int, int>[] neighbours = PuzzleSolver.getNeighbours(startCoord);
            Assert.Equivalent(expected, neighbours);
        }
        [Fact]
        public void RecognizeSymbolsVSNumbers()
        {
            Component aSymbol = new("*",0,0);
            Component aNumber = new("123",1,1);
            Assert.True(aSymbol.CheckIsSymbol());
            Assert.False(aNumber.CheckIsSymbol());
        }
        [Fact]
        public void RecognizeSameIdentifier()
        {
            Component aSymbol = new("*", 0,0);
            Component aNumber = new("123", 1,1);
            Assert.Equal(0, aSymbol.identifier);
            Assert.Equal(1, aNumber.identifier);
            Assert.NotEqual(aSymbol.identifier, aNumber.identifier);
        }
        [Fact]
        public void FindTheCorrectNumberOfComponents()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput1.txt"));
            Component[] values = puzzleSolver.GetDictValues();
            int symbolCounter = 0;
            int numberCounter = 0;
            int uniqueNumberCounter = 0;
            List<int> seenIds = [];
            foreach (Component value in values)
            {
                if (value.CheckIsSymbol())
                {
                    symbolCounter += 1;
                }
                else
                {
                    numberCounter += 1;
                    if (!seenIds.Contains(value.identifier))
                    {
                        seenIds.Add(value.identifier);
                        uniqueNumberCounter += 1;
                    }
                }
            }
            Assert.Equal(6,  symbolCounter);
            Assert.Equal(28, numberCounter);
            Assert.Equal(10, uniqueNumberCounter);
        }
        [Fact]
        public void CorrectlyIdentifySymbolNeighbour()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput6.txt"));
            Tuple<int, int> centerNumberCoord = new(1, 2);
            Component centerNumber = puzzleSolver.components.dict[centerNumberCoord];
            int expected = 200;
            Assert.Equal(expected, centerNumber.GetNumericValueUnchecked());
            Assert.Equal(expected, puzzleSolver.GetValueIfNeighbourOfSymbol(centerNumber, centerNumberCoord));
        }
        [Fact]
        public void CorrectlyIdentifySymbol()
        {
            PuzzleSolver puzzleSolver = new(AddFileNameToDirPath("TestInput6.txt"));
            Tuple<int, int> knownNumberCoord = new(1, 2);
            Component knownNumber = puzzleSolver.components.dict[knownNumberCoord];

            Tuple<int, int> knownSymbolCoord= new(1, 5);
            Component knownSymbol = puzzleSolver.components.dict[knownSymbolCoord];
            // This part is here to verify that we are looking at the components we think we are.
            Assert.Equal("#", knownSymbol.GetContent());
            Assert.Equal("200", knownNumber.GetContent());

            Assert.True(knownSymbol.CheckIsSymbol());

            Assert.False(knownNumber.CheckIsSymbol());

        }
    }
}