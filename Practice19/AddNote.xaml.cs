using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Practice19
{
	/// <summary>
	/// Логика взаимодействия для AddNote.xaml
	/// </summary>
	public partial class AddNote : Window
	{
		public AddNote()
		{
			InitializeComponent();
		}
		AccountingEntities db = new AccountingEntities();
		Accounting org = new Accounting();
		private void Add_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();
			if (ID.Text.Length == 0 && date.SelectedDate == null && organization.Text.Length == 0 && address.Text.Length == 0 && type.Text.Length == 0 && Sum.Text.Length == 0) 
				errors.AppendLine("Не все поля заполнены или заполнены некорректно");
			if (errors.Length > 0)
			{
				MessageBox.Show(errors.ToString());
				return;
			}
			try
			{
				org.НомерПункта = Convert.ToInt32(ID.Text);
				org.ДатаПеречисления = Convert.ToDateTime(date.SelectedDate);
				org.ОрганизацияПолучатель = organization.Text;
				org.Адрес = address.Text;
				if (yes.IsChecked == true) org.Коммерческая = "Да";
				if (not.IsChecked == true) org.Коммерческая = "Нет";
				org.ВидЗатратПеречисления = type.Text;
				org.СуммаПеречисления = Convert.ToInt32(Sum.Text);
				try
				{
					db.Accountings.Add(org);
					db.SaveChanges();
					MessageBox.Show("Информация сохранена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
				}
			}
			catch
			{
				MessageBox.Show("Не все поля заполнены или заполнены некорректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void yes_Checked(object sender, RoutedEventArgs e)
		{
			if (yes.IsChecked == true)
			{
				not.IsEnabled = false;
			}
			if (yes.IsChecked == false)
			{
				not.IsEnabled = true;
			}
		}

		private void not_Checked(object sender, RoutedEventArgs e)
		{
			if (not.IsChecked == true)
			{
				yes.IsEnabled = false;
			}
			if(not.IsChecked==false)
			{
				yes.IsEnabled = true;
			}
		}
	}
}
