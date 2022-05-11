using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Practice19
{
	/// <summary>
	/// Логика взаимодействия для SignUp.xaml
	/// </summary>
	public partial class SignUp : Window
	{
		public SignUp()
		{
			InitializeComponent();
		}
		UsersEntities db = new UsersEntities();
		private void user_GotMouseCapture(object sender, MouseEventArgs e)
		{
			user.Clear();
		}

		private void password_GotMouseCapture(object sender, MouseEventArgs e)
		{
			password.Clear();
		}

		private void email_GotMouseCapture(object sender, MouseEventArgs e)
		{
			email.Clear();
		}

		private void firstname_GotMouseCapture(object sender, MouseEventArgs e)
		{
			firstname.Clear();
		}

		private void secondname_GotMouseCapture(object sender, MouseEventArgs e)
		{
			secondname.Clear();
		}
		user us = new user();
		private void SignUp_Click(object sender, RoutedEventArgs e)
		{
			if (user.Text.Length == 0 || user.Text == "Username"
				|| password.Password.Length == 0 || password.Password == "Passw0rd"
				|| firstname.Text.Length == 0 || firstname.Text == "Имя"
				|| secondname.Text.Length == 0 || secondname.Text == "Фамилия"
				|| email.Text.Length == 0 || email.Text == "Email adress") { MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
			//int p1, p2, p3, p4;
			//p1 = p2 = p3 = p4  = 0;
			//for (int i = 0; i < password.Password.Length; i++)
			//{
			//	if (Char.IsLetter(password.Password[i]) && Char.IsLower(password.Password[i])) p1 = 1;
			//	if (Char.IsLetter(password.Password[i]) && Char.IsLower(password.Password[i])) p2 = 1;
			//	if (Char.IsDigit(password.Password[i])) p3 = 1;
			//	if (Char.IsPunctuation(password.Password[i])) p4 = 1;
			//}
			//if (p1 != 1 || p2 != 1 || p3 != 1 || p4 != 1)
			//{
			//	MessageBox.Show("Сложность пароля неудовлетворительна", "Ошибка");
			//	return;
			//}
			var id = db.users.Max(x => x.ID);
			int max = id+1;
			ID.Text = Convert.ToString(max);
			us.ID = Convert.ToInt32(ID.Text);
			us.Login = Convert.ToString(user.Text);
			us.Password = Convert.ToString(password.Password);
			us.FirstName = Convert.ToString(firstname.Text);
			us.SecondName = Convert.ToString(secondname.Text);
			us.Email = Convert.ToString(email.Text);
			us.Rights = Convert.ToString("user");

			db.users.Add(us);
			db.SaveChanges();
			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed) DragMove();
		}

		private void user_GotFocus(object sender, RoutedEventArgs e)
		{
			if (user.Text == "Username")
				user.Clear();
		}

		private void user_LostFocus(object sender, RoutedEventArgs e)
		{
			if (user.Text == "")
				user.Text = "Username";
		}

		private void password_GotFocus(object sender, RoutedEventArgs e)
		{
			if (password.Password == "Passw0rd")
				password.Clear();
		}

		private void password_LostFocus(object sender, RoutedEventArgs e)
		{
			if (password.Password == "")
				password.Password = "Passw0rd";
		}

		private void email_GotFocus(object sender, RoutedEventArgs e)
		{
			if (email.Text == "Email adress")
				email.Clear();
		}

		private void email_LostFocus(object sender, RoutedEventArgs e)
		{
			if (email.Text == "")
				email.Text = "Email adress";
		}

		private void firstname_GotFocus(object sender, RoutedEventArgs e)
		{
			if (firstname.Text == "Имя")
				firstname.Clear();
		}

		private void firstname_LostFocus(object sender, RoutedEventArgs e)
		{
			if (firstname.Text == "")
				firstname.Text = "Имя";
		}

		private void secondname_GotFocus(object sender, RoutedEventArgs e)
		{
			if (secondname.Text == "Фамилия")
				secondname.Clear();
		}

		private void secondname_LostFocus(object sender, RoutedEventArgs e)
		{
			if (secondname.Text == "")
				secondname.Text = "Фамилия";
		}
	}
}
