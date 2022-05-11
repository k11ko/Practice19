using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Data.SqlClient;
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
	/// Логика взаимодействия для ViewWindow.xaml
	/// </summary>
	public partial class ViewWindow : Window
	{
		public ViewWindow()
		{
			InitializeComponent();
		}
		AccountingEntities db = new AccountingEntities();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			IQueryable<Accounting> view = from x in db.Accountings
										  where x.НомерПункта == Date.IndexRow+1
										  select x;
			DateQuery.SQL = view;
			tabl.ItemsSource = DateQuery.SQL.ToList();
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
