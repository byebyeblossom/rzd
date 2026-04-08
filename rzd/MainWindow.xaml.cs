using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace TrainRzdApp
{
    public partial class MainWindow : Window
    {
        // Коллекции для хранения данных
        private ObservableCollection<Train> trainsList = new ObservableCollection<Train>();
        private ObservableCollection<Crew> crewsList = new ObservableCollection<Crew>();
        private ObservableCollection<Assignment> assignmentsList = new ObservableCollection<Assignment>();

        public MainWindow()
        {
            InitializeComponent();

            // Привязка данных к DataGrid
            dgTrains.ItemsSource = trainsList;
            dgCrews.ItemsSource = crewsList;
            dgAssignments.ItemsSource = assignmentsList;

            // Загружаем тестовые данные (замените на вашу БД)
            LoadTestData();
        }

        // ========== ЗДЕСЬ ВЫ ПОДКЛЮЧИТЕ ВАШУ БД ==========
        private void LoadTestData()
        {
            // ⚠️ ВМЕСТО ЭТОГО - ПОДКЛЮЧАЙТЕ ВАШУ БД ⚠️

         
            trainsList.Add(new Train { Id = 1, TrainNumber = "001А", TrainType = "Пассажирский", MaxSpeed = 120, Weight = 850, Status = "Активен" });
            trainsList.Add(new Train { Id = 2, TrainNumber = "1502", TrainType = "Грузовой", MaxSpeed = 90, Weight = 2500, Status = "Активен" });
            trainsList.Add(new Train { Id = 3, TrainNumber = "701У", TrainType = "Скорый", MaxSpeed = 160, Weight = 720, Status = "Активен" });

           
            crewsList.Add(new Crew { Id = 1, CrewName = "Бригада №1", DriverName = "Петров И.И.", AssistantName = "Сидоров А.А.", Experience = 15 });
            crewsList.Add(new Crew { Id = 2, CrewName = "Бригада №2", DriverName = "Смирнов В.П.", AssistantName = "Козлов Д.С.", Experience = 8 });
            crewsList.Add(new Crew { Id = 3, CrewName = "Бригада №3", DriverName = "Васильев А.Н.", AssistantName = "Морозов Е.В.", Experience = 22 });

            
            assignmentsList.Add(new Assignment { Id = 1, TrainId = 1, CrewId = 1, TrainNumber = "001А", CrewName = "Бригада №1", AssignmentDate = DateTime.Now, Route = "Уфа - Москва" });
            assignmentsList.Add(new Assignment { Id = 2, TrainId = 2, CrewId = 2, TrainNumber = "1502", CrewName = "Бригада №2", AssignmentDate = DateTime.Now, Route = "Уфа - Челябинск" });
        }

        

        private void LoadTrainsFromDB()
        {
           
        }

        private void LoadCrewsFromDB()
        {
            
        }

        private void LoadAssignmentsFromDB()
        {
           
        }

       

        private void BtnRefreshTrains_Click(object sender, RoutedEventArgs e)
        {
            LoadTrainsFromDB(); 
        }

        private void BtnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TrainDialog(new Train(), "Добавление поезда");
            if (dialog.ShowDialog() == true)
            {
              
              
                trainsList.Add(dialog.Train); 
                MessageBox.Show("Поезд добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnEditTrain_Click(object sender, RoutedEventArgs e)
        {
            Train selected = dgTrains.SelectedItem as Train;
            if (selected == null)
            {
                MessageBox.Show("Выберите поезд для редактирования", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dialog = new TrainDialog(selected, "Редактирование поезда");
            if (dialog.ShowDialog() == true)
            {
               
                int index = trainsList.IndexOf(selected);
                trainsList[index] = dialog.Train;

                MessageBox.Show("Поезд обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            Train selected = dgTrains.SelectedItem as Train;
            if (selected == null)
            {
                MessageBox.Show("Выберите поезд для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить поезд {selected.TrainNumber}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
               

                trainsList.Remove(selected); 
                MessageBox.Show("Поезд удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

       

        private void BtnRefreshCrews_Click(object sender, RoutedEventArgs e)
        {
            LoadCrewsFromDB(); 
        }

        private void BtnAddCrew_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CrewDialog(new Crew(), "Добавление бригады");
            if (dialog.ShowDialog() == true)
            {
                
                crewsList.Add(dialog.Crew); 
                MessageBox.Show("Бригада добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnEditCrew_Click(object sender, RoutedEventArgs e)
        {
            Crew selected = dgCrews.SelectedItem as Crew;
            if (selected == null)
            {
                MessageBox.Show("Выберите бригаду для редактирования", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dialog = new CrewDialog(selected, "Редактирование бригады");
            if (dialog.ShowDialog() == true)
            {
               
                int index = crewsList.IndexOf(selected);
                crewsList[index] = dialog.Crew;

                MessageBox.Show("Бригада обновлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDeleteCrew_Click(object sender, RoutedEventArgs e)
        {
            Crew selected = dgCrews.SelectedItem as Crew;
            if (selected == null)
            {
                MessageBox.Show("Выберите бригаду для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить бригаду {selected.CrewName}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
             

                crewsList.Remove(selected); 
                MessageBox.Show("Бригада удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

 

        private void BtnRefreshAssignments_Click(object sender, RoutedEventArgs e)
        {
            LoadAssignmentsFromDB(); 
        }

        private void BtnAddAssignment_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AssignmentDialog(new Assignment(), trainsList.ToList(), crewsList.ToList());
            if (dialog.ShowDialog() == true)
            {
                

                assignmentsList.Add(dialog.Assignment); 
                MessageBox.Show("Назначение добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDeleteAssignment_Click(object sender, RoutedEventArgs e)
        {
            Assignment selected = dgAssignments.SelectedItem as Assignment;
            if (selected == null)
            {
                MessageBox.Show("Выберите назначение для отмены", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Отменить назначение для поезда {selected.TrainNumber}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                
                assignmentsList.Remove(selected); 
                MessageBox.Show("Назначение отменено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}