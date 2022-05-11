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
	/// Логика взаимодействия для Authorization.xaml
	/// </summary>
	public partial class Authorization : Window
	{
		public Authorization()
		{
			InitializeComponent();
		}
		UsersEntities db = new UsersEntities();
		private void user_GotMouseCapture(object sender, MouseEventArgs e)
		{
			log.Clear();
		}

		private void password_GotMouseCapture(object sender, MouseEventArgs e)
		{
			pas.Clear();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed) DragMove();
		}
		
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
			DateUser.Login = "false";
		}

		private void SignIn_Click(object sender, RoutedEventArgs e)
		{
			var UserID = from p in db.users
					   where p.Login == log.Text && p.Password == pas.Password
					   select p;
			if (UserID.Count() == 1)
			{
				DateUser.ID = UserID.First().ID;
				DateUser.Right = UserID.First().Rights;
				DateUser.FirstName = UserID.First().FirstName;
				DateUser.SecondName = UserID.First().SecondName;
				DateUser.Login = "true";
				this.Close();
			}
			else MessageBox.Show("Неверный логин и/или пароль", "Ошибка");
		}

		private void SignUp_Click(object sender, RoutedEventArgs e)
		{
			DateUser.Login = "reg";
			SignUp next = new SignUp();
			next.Show();
			next.Owner = this;
		}

		private void log_GotFocus(object sender, RoutedEventArgs e)
		{
			if (log.Text == "Username")
				log.Clear();
		}

		private void log_LostFocus(object sender, RoutedEventArgs e)
		{
			if (log.Text == "") 
				log.Text = "Username";
		}

		private void pas_GotFocus(object sender, RoutedEventArgs e)
		{
			if (pas.Password == "Passw0rd")
				pas.Clear();
		}

		private void pas_LostFocus(object sender, RoutedEventArgs e)
		{
			if (pas.Password == "") 
				pas.Password = "Passw0rd";
		}
	}
}
