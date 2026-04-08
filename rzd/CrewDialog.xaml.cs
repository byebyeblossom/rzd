using System.Windows;

namespace TrainRzdApp
{
    public partial class CrewDialog : Window
    {
        public Crew Crew { get; set; }

        public CrewDialog(Crew crew, string title)
        {
            InitializeComponent();
            Title = title;
            Crew = crew;

            txtName.Text = crew.CrewName;
            txtDriver.Text = crew.DriverName;
            txtAssistant.Text = crew.AssistantName;
            txtExperience.Text = crew.Experience.ToString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Crew.CrewName = txtName.Text;
            Crew.DriverName = txtDriver.Text;
            Crew.AssistantName = txtAssistant.Text;
            Crew.Experience = int.Parse(txtExperience.Text);

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}