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
        List<TrackSegment> trackSegments = new List<TrackSegment>();
        public List<object> listOfLists { get; set; }
        public bool[,] positionChecked;
        public List<object> Load(string url)
        {
            listOfLists = new List<object>();
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
            positionChecked = new bool[longestRow, numberOfRows];
            for (int i = 0; i < positionChecked.Length; i++)
            {
                for(int j = 0; j < positionChecked.)
            }

            bool startingPointExists = false;
            int[] startingPointCoordinates = new int[2];
            startingPointExists = StartPointFinder(dataArray, longestRow, numberOfRows, startingPointExists, startingPointCoordinates);
            /*
             * Förklaring: Förväntan är att varje karta har en * som indikerar var man ska börja läsa.
             * Dessa nästlade loopar är till för att hitta koordinaterna för denna stjärna.
             * Då kartorna är designade så att varje tecken har exakt samma bredd och höjd så kan man lätt mappa dem på ett tvådimensionellt rutnät.
             * Efter det börjar man alltid läsa höger om stjärnan.
             */

            trackSegments = new List<TrackSegment>();


            /* Dags att börja att gå igenom kartan systematiskt och skapa spår.
             * Ett spår ska bestå av flera segment.
             * Läser man [ (station start), ] (station slut), en siffra (faktiska stationen), - (spår), = (bilvägskorsning) så är det bara att gå ett steg åt höger efter.
             * Läser man < så blir det en splittring, vilket betyder att man behöver kalla på två nya läsningar med olika riktningar, upp och höger samt ner och höger.
             * "/" och \ är diagonaler. Den första leder upp-och-höger, den andra ner-och-höger.
             * I rutnätet så är noll, noll top vänster, medan max, max är nere till höger.
             * Det smidigaste är att skriva en rekursiv funktion som, beroende på vad den hittar, 
             *      antingen anropar sig själv noll (whitespace), två (förgrening) eller en gång (andra fall).
            */


            return listOfLists;
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
            for (int i = 0; i < longestRow; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
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
            List<TrackSegment> currentTrack = new List<TrackSegment>();
            TrackSegment currentSegment = new TrackSegment(SegmentInterpreter(dataArray[currentPosition[0]][currentPosition[1]]));
            int howToMove = CheckTrackPiece(dataArray[currentPosition[0]][currentPosition[1]]);
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
                default: return $"Station {c}";
            }
        }

        public static int CheckTrackPiece(char c)
        {
            switch (c)
            {
                case '<':
                    return 2;
                case ' ':
                    return 0;
                default:
                    return 1;
            }
        }
    }
}
