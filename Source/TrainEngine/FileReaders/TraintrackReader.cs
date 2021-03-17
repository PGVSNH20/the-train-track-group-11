using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Class_Objects;
using TrainEngine.Interfaces;

namespace TrainEngine.FileReaders
{
    public class TraintrackReader : IFileReader
    {
        List<TrackSegment> TrackSegments { get; set; }
        public List<object> ListOfLists { get; set; }
        public bool[,] positionChecked;
        public List<object> Load(string url)
        {
            ListOfLists = new List<object>();
            string inputData = new StreamReader(
                            File.Open(url, FileMode.Open)
                                            ).ReadToEnd();
            string[] dataArray = inputData.Split("\n");

            int longestRow = 0;
            // Finds which row is the longest
            longestRow = LongestRowFinder(dataArray, longestRow);

            // Adds whitespace at the end of all rows that are shorter than the longest row to create a proper grid
            GridWhitespaceAdder(dataArray, longestRow);

            int numberOfRows = dataArray.Length;

            // Denna array kommer användas senare för att se till att spår inte dupliceras
            positionChecked = new bool[numberOfRows, longestRow];
            SetAllPositionsInPositionCheckerArrayToFalse(longestRow, numberOfRows);

            bool startingPointExists = false;
            int[] startingPointCoordinates = new int[2];
            startingPointExists = StartPointFinder(dataArray, longestRow, numberOfRows, startingPointExists, startingPointCoordinates);
            /*
             * Förklaring: Förväntan är att varje karta har en * som indikerar var man ska börja läsa.
             * Dessa nästlade loopar är till för att hitta koordinaterna för denna stjärna.
             * Då kartorna är designade så att varje tecken har exakt samma bredd och höjd så kan man lätt mappa dem på ett tvådimensionellt rutnät.
             * Efter det börjar man alltid läsa höger om stjärnan.
             */

            if (startingPointExists)
            {
                TrackSegments = new List<TrackSegment>();
                TrackInterpreter(dataArray, startingPointCoordinates);
            }

            /* Dags att börja att gå igenom kartan systematiskt och skapa spår.
             * Ett spår ska bestå av flera segment.
             * Läser man [ (station start), ] (station slut), en siffra (faktiska stationen), - (spår), = (bilvägskorsning) så är det bara att gå ett steg åt höger efter.
             * Läser man < så blir det en splittring, vilket betyder att man behöver kalla på två nya läsningar med olika riktningar, upp och höger samt ner och höger.
             * "/" och \ är diagonaler. Den första leder upp-och-höger, den andra ner-och-höger.
             * I rutnätet så är noll, noll top vänster, medan max, max är nere till höger.
             * Det smidigaste är att skriva en rekursiv funktion som, beroende på vad den hittar, 
             *      antingen anropar sig själv noll (whitespace), två (förgrening) eller en gång (andra fall).
            */


            return ListOfLists;
        }

        private void SetAllPositionsInPositionCheckerArrayToFalse(int longestRow, int numberOfRows)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < longestRow; j++)
                {
                    positionChecked[i, j] = false;
                }
            }
        }

        private static int LongestRowFinder(string[] dataArray, int longestRow)
        {
            foreach (string s in dataArray)
            {
                if (s.Length > longestRow)
                {
                    longestRow = s.Length;
                }
            }

            return longestRow;
        }

        private static void GridWhitespaceAdder(string[] dataArray, int longestRow)
        {
            for (int i = 0; i < dataArray.Length; i++)
            {
                int numberOfSpacesToAdd = longestRow - dataArray[i].Length;
                for (int j = 0; j < numberOfSpacesToAdd; j++)
                {
                    dataArray[i] += " ";
                }
            }
        }

        private static bool StartPointFinder(string[] dataArray, int longestRow, int numberOfRows, bool startingPointExists, int[] startingPointCoordinates)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < longestRow; j++)
                {
                    if (dataArray[i][j] == '*' && startingPointExists == false)
                    {
                        startingPointExists = true;
                        startingPointCoordinates[0] = i;
                        startingPointCoordinates[1] = j;
                    }
                }
            }

            return startingPointExists;
        }

        public void TrackInterpreter(string[] dataArray, int[] currentPosition)
        {
            if (!positionChecked[currentPosition[0],currentPosition[1]]) // Note the NOT (!)
            {
                positionChecked[currentPosition[0], currentPosition[1]] = true;
                int howToMove = CheckTrackPiece(dataArray[currentPosition[0]][currentPosition[1]]);
                if (howToMove == 0)
                {
                    NextStepChecker(dataArray, howToMove, currentPosition);
                }
                else
                {
                    TrackSegment currentSegment = new TrackSegment(SegmentInterpreter(dataArray[currentPosition[0]][currentPosition[1]]));
                    TrackSegments.Add(currentSegment);
                    NextStepChecker(dataArray, howToMove, currentPosition);
                }
            }
        }

        private void NextStepChecker(string[] dataArray, int howToMove, int[] currentPosition)
        {
            switch (howToMove)
            {
                case 0: // Need to check if symbol above or below whitespace is a backslash or frontslash
                    HowToMoveCaseZeroChecker(dataArray, currentPosition);
                    break;
                case 1:     // Move one to the right
                    int[] nextStep = { currentPosition[0], currentPosition[1] + 1 };
                    TrackInterpreter(dataArray, nextStep);
                    break;
                case 2:     // Split to up and right, down and right
                    int[] nextStep1 = { currentPosition[0] - 1, currentPosition[1] + 1 };
                    int[] nextStep2 = { currentPosition[0] + 1, currentPosition[1] + 1 };
                    ListOfLists.Add(TrackSegments);
                    TrackSegments = new List<TrackSegment>();
                    TrackInterpreter(dataArray, nextStep1);
                    TrackInterpreter(dataArray, nextStep2);
                    break;
                case 3:     // Move one up to the right
                    int[] nextStep3 = { currentPosition[0] - 1, currentPosition[1] + 1 };
                    TrackInterpreter(dataArray, nextStep3);
                    break;
                case 4:     // Move one down to the right
                    int[] nextStep4 = { currentPosition[0] + 1, currentPosition[1] + 1 };
                    TrackInterpreter(dataArray, nextStep4);
                    break;
                //case 5:
                //    TrackInterpreter(); ????
                default: throw new Exception("Invalid value in NextStepChecker()");
            }
        }

        private void HowToMoveCaseZeroChecker(string[] dataArray, int[] currentPosition)
        {
            int[] nextStep = new int[2];
            bool isThisTheEndOfTheCurrentTrack = false;
            switch (currentPosition[0])
            {
                case 0:
                    if (dataArray[currentPosition[0]+1].ToCharArray()[currentPosition[1]] == '\\')
                    {
                        nextStep[0] = currentPosition[0] + 1;
                        nextStep[1] = currentPosition[1];
                        TrackInterpreter(dataArray, nextStep);
                        break;
                    }
                    isThisTheEndOfTheCurrentTrack = true;
                    break;
                default:
                    if (dataArray[currentPosition[0] + 1].ToCharArray()[currentPosition[1]] == '\\')
                    {
                        nextStep[0] = currentPosition[0] + 1;
                        nextStep[1] = currentPosition[1];
                        TrackInterpreter(dataArray, nextStep);
                        break;
                    }
                    if (dataArray[currentPosition[0] - 1].ToCharArray()[currentPosition[1]] == '/')
                    {
                        nextStep[0] = currentPosition[0] - 1;
                        nextStep[1] = currentPosition[1];
                        TrackInterpreter(dataArray, nextStep);
                        break;
                    }
                    isThisTheEndOfTheCurrentTrack = true;
                    break;
            }
            if (isThisTheEndOfTheCurrentTrack)
            {
                ListOfLists.Add(TrackSegments);
                TrackSegments = new List<TrackSegment>();
            }
        }

        private string SegmentInterpreter(char c)
        {
            switch (c)
            {
                case '*': return "StartingPosition";
                case '[': return "StationStart";
                case ']': return "StationEnd";
                case '-': return "HorizontalTrack";
                case '/': return "DiagonalUpRightTrack";
                case '\\': return "DiagonalDownRightTrack";
                case '=': return "LevelCrossingTrack";
                case '<': return "BranchSplit";
                case '>': return "BrachJoin";
                case '1': return "Station 1";
                case '2': return "Station 2";
                case '3': return "Station 3";
                case '4': return "Station 4";
                default: return $"Invalid Symbol";
            }
        }

        public static int CheckTrackPiece(char c)
        {
            switch (c)
            {
                case '<': return 2;
                case ' ': return 0;
                case '/': return 3;
                case '\\': return 4;
                case '>': return 5;
                default:
                    return 1;
            }
        }
    }
}
