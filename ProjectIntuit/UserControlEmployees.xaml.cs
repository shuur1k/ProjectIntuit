using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace ProjectIntuit
{
    /// <summary>
    /// Логика взаимодействия для UserControlClients.xaml
    /// </summary>
    public partial class UserControlClients : UserControl
    {
        DavidovEntities dataEntities = new DavidovEntities();
        ObservableCollection<Workers> ListEmployee = new ObservableCollection<Workers>();
        public UserControlClients()
        {
            DavidovEntities dataEntities = new DavidovEntities();

            InitializeComponent();


            save.IsEnabled = false;
            edit.IsEnabled = true;
            Undo.IsEnabled = false;
            serch.IsEnabled = true;
            add.IsEnabled = true;
            remove.IsEnabled = true;
        }

        private bool isDirty = true;
        private void UndoCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Отмена");
            isDirty = true;
        }
        private void EditCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridCliesnt.IsReadOnly = false;
            DataGridCliesnt.BeginEdit();
            MessageBox.Show("Редактирование");
            isDirty = true;
        }
        private void SearchCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Поиск");
            isDirty = true;
        }
        private void AddCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = true;
            Workers employee = new Workers();
            try
            {
                employee.ID = dataEntities.Workers.Count() + 1;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronumic = "не задано";
                employee.Telephone = "0";
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 0;
                dataEntities.Workers.Add(employee);
                dataEntities.SaveChanges();
                DataGridCliesnt.BeginEdit();
                var worker = dataEntities.Workers;
                var query =
                    from Workers in worker
                    select Workers;
                DataGridCliesnt.ItemsSource = query.ToList();
            }
            catch
            {
                employee.ID = dataEntities.Workers.Count() + 2;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronumic = "не задано";
                employee.Telephone = "0";
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 1;
                dataEntities.Workers.Add(employee);
                dataEntities.SaveChanges();
                DataGridCliesnt.BeginEdit();
                var worker = dataEntities.Workers;
                var query =
                    from Workers in worker
                    select Workers;
                DataGridCliesnt.ItemsSource = query.ToList();
            }

        }
        private void DeleteCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Удаление");
            isDirty = true;
            Workers emp = DataGridCliesnt.SelectedItem as Workers;
            if (emp != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника?", "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    dataEntities.Workers.Remove(emp);
                    DataGridCliesnt.SelectedIndex = DataGridCliesnt.SelectedIndex == 0 ? 1 : DataGridCliesnt.SelectedIndex - 1;
                    ListEmployee.Remove(emp);
                    dataEntities.SaveChanges();
                    var worker = dataEntities.Workers;
                    var query =
                        from Workers in worker
                        select Workers;
                    DataGridCliesnt.ItemsSource = query.ToList();
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления");
                }
            }
        }
        private void SaveCommandBinding_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            dataEntities.SaveChanges();
            MessageBox.Show("Сохранение");
            isDirty = true;
            DataGridCliesnt.IsReadOnly = true;
            var worker = dataEntities.Workers;
            var query =
                from Workers in worker
                select Workers;
            DataGridCliesnt.ItemsSource = query.ToList();
        }
        private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void AddCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void UndoCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SearchCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            save.IsEnabled = true;
            edit.IsEnabled = false;
            Undo.IsEnabled = true;
            serch.IsEnabled = false;
            add.IsEnabled = false;
            remove.IsEnabled = false;
            Workers employee = new Workers();
            try
            {
                employee.ID = dataEntities.Workers.Count() + 1;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronumic = "не задано";
                employee.Telephone = "0";
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 0;
                dataEntities.Workers.Add(employee);
                dataEntities.SaveChanges();
                DataGridCliesnt.BeginEdit();
                var worker = dataEntities.Workers;
                var query =
                    from Workers in worker
                    select Workers;
                DataGridCliesnt.ItemsSource = query.ToList();
            }
            catch
            {
                employee.ID = dataEntities.Workers.Count() + 2;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronumic = "не задано";
                employee.Telephone = "0";
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 1;
                dataEntities.Workers.Add(employee);
                dataEntities.SaveChanges();
                DataGridCliesnt.BeginEdit();
                var worker = dataEntities.Workers;
                var query =
                    from Workers in worker
                    select Workers;
                DataGridCliesnt.ItemsSource = query.ToList();
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            save.IsEnabled = true;
            edit.IsEnabled = false;
            Undo.IsEnabled = true;
            serch.IsEnabled = false;
            add.IsEnabled = false;
            remove.IsEnabled = false;

            DataGridCliesnt.IsReadOnly = false;
            DataGridCliesnt.BeginEdit();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            save.IsEnabled = false;
            edit.IsEnabled = true;
            Undo.IsEnabled = false;
            serch.IsEnabled = true;
            add.IsEnabled = true;
            remove.IsEnabled = true;

            dataEntities.SaveChanges();
            DataGridCliesnt.IsReadOnly = true;
            var worker = dataEntities.Workers;
            var query =
                from Workers in worker
                select Workers;
            DataGridCliesnt.ItemsSource = query.ToList();
        }


        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            Workers emp = DataGridCliesnt.SelectedItem as Workers;
            if (emp != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника?", "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    dataEntities.Workers.Remove(emp);
                    DataGridCliesnt.SelectedIndex = DataGridCliesnt.SelectedIndex == 0 ? 1 : DataGridCliesnt.SelectedIndex - 1;
                    ListEmployee.Remove(emp);
                    dataEntities.SaveChanges();
                    var worker = dataEntities.Workers;
                    var query =
                        from Workers in worker
                        select Workers;
                    DataGridCliesnt.ItemsSource = query.ToList();
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления");
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var worker = dataEntities.Workers;
            var query =
                from Workers in worker
                select Workers;
            DataGridCliesnt.ItemsSource = query.ToList();
        }

        private void ButtonFindSurname_Click(object sender,  RoutedEventArgs e)

        {
            string surname = TextBoxSurname.Text;
            dataEntities = new DavidovEntities();
            ListEmployee.Clear();
            List<Workers> employee = new List<Workers>();
            var queryEmployee = from emp in dataEntities.Workers
                                where emp.Surname == surname
                                select emp;
            foreach (var emp in queryEmployee)
            {
                ListEmployee.Add(emp);
            }
            if (ListEmployee.Count > 0)
            {
                DataGridCliesnt.ItemsSource = ListEmployee;
                ButtonFindSurname.IsEnabled = true;
                ButtonFindTitle.IsEnabled = false;
            }
            else
                MessageBox.Show("Сотрудник с фамилией \n" + surname + "\n не найдан",
                     "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Serch_Click(object sender, RoutedEventArgs e)
        {
            BorderFind.Visibility = System.Windows.Visibility.Visible;
        }
   
        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonFindSurname.IsEnabled = true;
            ButtonFindTitle.IsEnabled = false;
            ComboBoxTitle.SelectedIndex = -1;
        }

        private void ComboBoxTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonFindTitle.IsEnabled = true;
            ButtonFindSurname.IsEnabled = false;
            TextBoxSurname.Text = "";
        }

        private void ButtonFindTitle_Click(object sender, RoutedEventArgs e)
        {
            dataEntities = new DavidovEntities();
            ListEmployee.Clear();
            List<Title> titles = new List<Title>();
            Title title = ComboBoxTitle.SelectedItem as Title;
            var queryEmployee = from emp in dataEntities.Workers
                                where emp.TitleID == title.ID
                                select emp;
            foreach (var emp in queryEmployee)
            {
                ListEmployee.Add(emp);
            }

            DataGridCliesnt.ItemsSource = ListEmployee;
        }
    }
}
