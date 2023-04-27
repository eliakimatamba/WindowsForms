using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeasantSimulation
{
    public partial class MainForm : Form
    {
        private Peasant peasant1;
        private Peasant peasant2;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void StartSimulationButton_Click(object sender, EventArgs e)
        {
            InitiateSimulationLabel.Text = "Simulation initiating";
            peasant1 = new Peasant("Bob");
            peasant2 = new Peasant("Alice");

            peasant1.JournalBox = Peasant1JournalBox;
            peasant2.JournalBox = Peasant2JournalBox;

            Task t1 = peasant1.LiveLifeAsync();
            Task t2 = peasant2.LiveLifeAsync();

            await Task.WhenAll(t1, t2);

            InitiateSimulationLabel.Text = "Simulation finished";
        }
    }
}
