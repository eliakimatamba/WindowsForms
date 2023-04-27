using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeasantSimulation
{
    public class Peasant
    {
        private string name;
        private Stopwatch lifeTime = new Stopwatch();
        private double eventOccurrence;
        private ListBox journalBox;
        private static Random randomGenerator = new Random();

        public ListBox JournalBox
        {
            set { journalBox = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public double ElapsedTime
        {
            get { return lifeTime.ElapsedMilliseconds; }
        }

        public Peasant(string name)
        {
            this.name = name;
            lifeTime.Start();
            eventOccurrence = randomGenerator.NextDouble() * (2.0 - 0.5) + 0.5;
        }

        public void WriteToJournal(string message)
        {
            if (journalBox.InvokeRequired)
            {
                journalBox.Invoke(new MethodInvoker(() => journalBox.Items.Add(message)));
            }
            else
            {
                journalBox.Items.Add(message);
            }
        }

        public async Task LiveLifeAsync()
        {
            WriteToJournal($"Peasant {name} has been born into the world");

            while (lifeTime.ElapsedMilliseconds <= 15000)
            {
                await Task.Delay((int)(eventOccurrence * 1000));

                int eventNumber = randomGenerator.Next(1, 6);
                string eventName = GetEventName(eventNumber);

                WriteToJournal($"{name} is {lifeTime.ElapsedMilliseconds}ms old and {eventName}");
            }
        }

        private string GetEventName(int eventNumber)
        {
            switch (eventNumber)
            {
                case 1:
                    return "is working in the fields";
                case 2:
                    return "is protecting the farm from predators";
                case 3:
                    return "is running scared";
                case 4:
                    return "is resting in the shade";
                case 5:
                    return "is socializing with other peasants";
                default:
                    return "is doing something mysterious";
            }
        }
    }
}
