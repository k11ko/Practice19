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
	/// Логика взаимодействия для ChangeNote.xaml
	/// </summary>
	public partial class ChangeNote : Window
	{
		public ChangeNote()
		{
			InitializeComponent();
		}
		AccountingEntities db = new AccountingEntities();
		Accounting org = new Accounting();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			org = db.Accountings.Find(Date.НомерПункта);
			ID.Text = Convert.ToString(org.НомерПункта);
			organization.Text = org.ОрганизацияПолучатель;
			address.Text = org.Адрес;
			type.Text = org.ВидЗатратПеречисления;
			Sum.Text = Convert.ToString(org.СуммаПеречисления);
			if (org.Коммерческая == "Да") yesornot.IsChecked = true;
			else yesornot.IsChecked = false;
		}
		private void Change_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();
			if (ID.Text.Length == 0 && Data.SelectedDate == null && organization.Text.Length == 0 && address.Text.Length == 0 && type.Text.Length == 0 && Sum.Text.Length == 0)
				errors.AppendLine("Не все поля заполнены или заполнены некорректно");
			if (errors.Length > 0)
			{
				MessageBox.Show(errors.ToString());
				return;
			}
			try
			{
				org.НомерПункта = Convert.ToInt32(ID.Text);
				org.ДатаПеречисления = Convert.ToDateTime(Data.SelectedDate);
				org.ОрганизацияПолучатель = organization.Text;
				org.Адрес = address.Text;
				if (yesornot.IsChecked == true) org.Коммерческая = "Да";
				else org.Коммерческая = "Нет";
				org.ВидЗатратПеречисления = type.Text;
				org.СуммаПеречисления = Convert.ToInt32(Sum.Text);
				try
				{
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
				MessageBox.Show("Не все обязательные поля заполнены или заполнены некорректно");
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
