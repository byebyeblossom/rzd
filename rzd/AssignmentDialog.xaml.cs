using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TrainRzdApp
{
    public partial class AssignmentDialog : Window
    {
        public Assignment Assignment { get; set; }

        public AssignmentDialog(Assignment assignment, List<Train> trains, List<Crew> crews)
        {
            InitializeComponent();
            Assignment = assignment;

            cmbTrains.ItemsSource = trains;
            cmbCrews.ItemsSource = crews;

            dpDate.SelectedDate = assignment.AssignmentDate == DateTime.MinValue ? DateTime.Now : assignment.AssignmentDate;
            txtRoute.Text = assignment.Route;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTrains.SelectedItem == null || cmbCrews.SelectedItem == null)
            {
                MessageBox.Show("Выберите поезд и бригаду!");
                return;
            }

            Train selectedTrain = cmbTrains.SelectedItem as Train;
            Crew selectedCrew = cmbCrews.SelectedItem as Crew;

            Assignment.TrainId = selectedTrain.Id;
            Assignment.CrewId = selectedCrew.Id;
            Assignment.TrainNumber = selectedTrain.TrainNumber;
            Assignment.CrewName = selectedCrew.CrewName;
            Assignment.AssignmentDate = dpDate.SelectedDate ?? DateTime.Now;
            Assignment.Route = txtRoute.Text;

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