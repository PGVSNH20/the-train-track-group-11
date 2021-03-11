using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class TrainScheduler
    {
        private Train train;
        private List<TimeTableEntry> timeTableEntries;
        private bool alreadyAtStation = false;  // Om man kallar på StopTrainAt() två gånger i rad så ska den vara smart nog att kalla på StartTrainAt

        public TrainScheduler(Train newTrain)
        {
            timeTableEntries = new List<TimeTableEntry>();
            train = newTrain;
        }


        // TimeTableEntry har en överladdad konstruktor som skippar den boolean som säger ifall den ska starta eller stanna. Istället för att behöva hålla reda på om "true" betyder "stanna" eller "starta" så kan StartTrainAt() och StopTrainAt() ta emot TimeTableEntry-objekt utan den variabeln satt och hantera detta bakom kulisserna.
        public TrainScheduler StartTrainAt(TimeTableEntry newEntry)         
        {
            if (!alreadyAtStation)
            {
                newEntry.Time.AddMinutes(15);
            }
            newEntry.ArriveOrDepart = true;
            timeTableEntries.Add(newEntry);
            alreadyAtStation = false;
            return this;

        }

        public TrainScheduler StopTrainAt(TimeTableEntry newEntry)
        {
            if (alreadyAtStation)
            {
                alreadyAtStation = false;
                StartTrainAt(timeTableEntries[timeTableEntries.Count - 1]);
            }
            newEntry.ArriveOrDepart = false;
            timeTableEntries.Add(newEntry);
            alreadyAtStation = true;
            return this;

        }

        public ITravelPlan GeneratePlan()
        {
            return new TravelPlan(timeTableEntries, train);
        }


    }
}
