using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice19
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		AccountingEntities db = new AccountingEntities();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Authorization logpas = new Authorization();
			logpas.ShowDialog();
			if (DateUser.Login == "false") Close();
			string right = DateUser.Right;
			if (DateUser.Right == "admin") right = "Администратор";
			else
			{
				right = "Пользователь";
				Addnote.IsEnabled = false;
				Changenote.IsEnabled = false;
				Delnote.IsEnabled = false;
				Viborka.IsEnabled = false;
				obnovlenie.IsEnabled = false;
				udalenie.IsEnabled = false;
			}
			this.Title = this.Title + " " + right + " " + DateUser.FirstName + " " + DateUser.SecondName;
			db.Accountings.Load();
			tabl.ItemsSource = db.Accountings.Local.ToList();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void AddNote_Click(object sender, RoutedEventArgs e)
		{
			AddNote add = new AddNote();
			add.ShowDialog();
			tabl.Focus();
		}

		private void ChangeNote_Click(object sender, RoutedEventArgs e)
		{
			int IndexRow = tabl.SelectedIndex;
			if (IndexRow != -1)
			{
				Accounting row = (Accounting)tabl.Items[IndexRow];
				Date.НомерПункта = row.НомерПункта;
				ChangeNote change = new ChangeNote();
				change.ShowDialog();
				tabl.Items.Refresh();
				tabl.Focus();
			}
		}

		private void DelNote_Click(object sender, RoutedEventArgs e)
		{
			int IndexRow = tabl.SelectedIndex;
			MessageBoxResult result;
			result = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				try
				{
					Accounting row = (Accounting)tabl.Items[IndexRow];
					db.Accountings.Remove(row);
					db.SaveChanges();
				}
				catch (ArgumentOutOfRangeException)
				{
					MessageBox.Show("Сначала выберите запись", "Ошибка");
				}
			}
		}

		private void Info_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Выполнил студент группы ИСП-31 Константинов Кирилл");
		}

		private void Directory_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Обновление содержимого базы данных - CTRL+H", "Справочник");
		}

		public void Update_Click(object sender, RoutedEventArgs e)
		{
			db.Accountings.Load();
			tabl.ItemsSource = db.Accountings.Local.ToList();
		}

		private void CostType_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string type = CostType.Text;
				IQueryable<Accounting> cost = from x in db.Accountings where x.ВидЗатратПеречисления.Contains(type) select x;
				DateQuery.SQL = cost;
				tabl.ItemsSource = DateQuery.SQL.ToList();
			}
			catch { MessageBox.Show("Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
		}

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
			Application.Current.Shutdown();
		}

		private void itogsum_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var ItogSum = db.Accountings.Sum(x => x.СуммаПеречисления);
				itogsum.Text = Convert.ToString(ItogSum);
			}
			catch
			{
				MessageBox.Show("Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void CommerceON_Checked(object sender, RoutedEventArgs e)
		{
			try
			{
				IQueryable<Accounting> commerce = from x in db.Accountings
												  where x.Коммерческая.Contains("Да")
												  select x;
				DateQuery.SQL = commerce;
				tabl.ItemsSource = DateQuery.SQL.ToList();
			}
			catch
			{
				MessageBox.Show("Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void orgtype_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string org = orgtype.Text;
				IQueryable<Accounting> type = from x in db.Accountings
											  where x.ОрганизацияПолучатель.StartsWith(org)
											  select x;
				DateQuery.SQL = type;
				tabl.ItemsSource = DateQuery.SQL.ToList();
			}
			catch
			{
				MessageBox.Show("Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void CommerceOFF_Checked(object sender, RoutedEventArgs e)
		{
			db.Accountings.Load();
			tabl.ItemsSource = db.Accountings.Local.ToList();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			db.Accountings.Load();
			tabl.ItemsSource = db.Accountings.Local.ToList();
		}

		private void DeletID_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@НомерПункта";
				param1.Value = Convert.ToInt32(ID.Text);

				db.Database.ExecuteSqlCommand($"DELETE FROM Accounting WHERE НомерПункта=@НомерПункта", param1);
				DateQuery.SQL = db.Accountings;
				MessageBox.Show("Успешно удалено", "Успех", MessageBoxButton.OK);
			}
			catch
			{
				MessageBox.Show("Не удалось удалить данный номер\nВозможно, его просто не существует или он введен некорректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Query1_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@НомерПункта";
				param1.Value = Convert.ToInt32(ID1.Text);

				SqlParameter param2 = new SqlParameter();
				param2.ParameterName = "@Адрес";
				param2.Value = address.Text;

				db.Database.ExecuteSqlCommand($"UPDATE Accounting SET Адрес=@Адрес WHERE НомерПункта=@НомерПункта", param1, param2);
				DateQuery.SQL = db.Accountings;
				db.Accountings.Load();
				tabl.ItemsSource = db.Accountings.Local.ToList();
			}
			catch
			{
				MessageBox.Show("Не удалось выполнить обновление", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
}

		private void Query2_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@НомерПункта";
				param1.Value = Convert.ToInt32(ID1.Text);

				SqlParameter param2 = new SqlParameter();
				param2.ParameterName = "@СуммаПеречисления";
				param2.Value = sum.Text;

				db.Database.ExecuteSqlCommand($"UPDATE Accounting SET СуммаПеречисления=@СуммаПеречисления WHERE НомерПункта=@НомерПункта", param1, param2);
				DateQuery.SQL = db.Accountings;
				db.Accountings.Load();
				tabl.ItemsSource = db.Accountings.Local.ToList();
			}
			catch
			{
				MessageBox.Show("Не удалось выполнить обновление", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void View_Click(object sender, RoutedEventArgs e)
		{
			Date.IndexRow = tabl.SelectedIndex;
			ViewWindow view = new ViewWindow();
			view.ShowDialog();
			this.Owner = Owner;
		}
	}
}
