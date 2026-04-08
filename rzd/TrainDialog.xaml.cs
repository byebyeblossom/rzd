using System.Windows;
using System.Windows.Controls;

namespace TrainRzdApp
{
    public partial class TrainDialog : Window
    {
        public Train Train { get; set; }

        public TrainDialog(Train train, string title)
        {
            InitializeComponent();
            Title = title;
            Train = train;

            txtNumber.Text = train.TrainNumber;
            txtSpeed.Text = train.MaxSpeed.ToString();
            txtWeight.Text = train.Weight.ToString();

            // Выбор типа
            foreach (ComboBoxItem item in cmbType.Items)
            {
                if (item.Content.ToString() == train.TrainType)
                {
                    cmbType.SelectedItem = item;
                    break;
                }
            }

            // Выбор статуса
            foreach (ComboBoxItem item in cmbStatus.Items)
            {
                if (item.Content.ToString() == train.Status)
                {
                    cmbStatus.SelectedItem = item;
                    break;
                }
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Train.TrainNumber = txtNumber.Text;
            Train.TrainType = (cmbType.SelectedItem as ComboBoxItem)?.Content.ToString();
            Train.MaxSpeed = int.Parse(txtSpeed.Text);
            Train.Weight = int.Parse(txtWeight.Text);
            Train.Status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString();

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