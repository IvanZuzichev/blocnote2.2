using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace blocnote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            dchoose.SelectedDate = dateTime;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<peremenii> mas = file.MyDeserialize<List<peremenii>>("zapiski.json");

            peremenii newzapiska = new peremenii();
            newzapiska.made = dchoose.SelectedDate.Value;
            newzapiska.content = zapcontent.Text;
            newzapiska.name = zapname.Text;
            mas.Add(newzapiska);

            file.MySerialize(mas, "zapiski.json");
            zapcontent.Text = " ";
            zapname.Text = " ";

            Color black = Color.FromRgb(60, 60, 60);
            Color white = Color.FromRgb(180, 180, 180);

            Button button1 = new Button();
            button1.Content = newzapiska.name;
            button1.Background = new SolidColorBrush(black);
            button1.Foreground = new SolidColorBrush(white);
            button1.Click += Button_Click1;

            stack.Children.Add(button1);

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            zapname.Text = (string)(sender as Button).Content;
            List<peremenii> mas = file.MyDeserialize<List<peremenii>>("zapiski.json");
            foreach (peremenii zap1 in mas)
            {
                if (zapname.Text == zap1.name)
                {
                    zapcontent.Text = zap1.content;
                }
                else
                {

                }
            }
        }


        private void delete_Click(object sender, RoutedEventArgs e)
        {
            List<peremenii> mas = file.MyDeserialize<List<peremenii>>("zapiski.json");
            int x2;
            x2 = 0;
            bool res = false;

            foreach (peremenii x in mas)
            {
                if (x.name == zapname.Text)
                { 
                    zapname.Text = " ";
                    zapcontent.Text = " ";
                    res = true;
                    break;
                }
                x2++;
            }

            if (res == true)
            {
                mas.RemoveAt(y);
                stack.Children.Clear();
                foreach (peremenii x in mas)
                {
                    if (x.made == dchoose.SelectedDate)
                    {
                        Color black = Color.FromRgb(60, 60, 60);
                        Color white = Color.FromRgb(180, 180, 180);

                        Button button = new Button();
                        button.Content = x.name;
                        button.Background = new SolidColorBrush(black);
                        button.Foreground = new SolidColorBrush(white);
                        button.Click += Button_Click1;
                        stack.Children.Add(button);
                    }
                    else
                    {

                    }
                }
                file.MySerialize(mas, "zapiski.json");
            }
        }
        private void dchoose_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            stack.Children.Clear();
            List<peremenii> mas = file.MyDeserialize<List<peremenii>>("zapiski.json");

            foreach (peremenii x in mas)
            {
                if (x.made == dchoose.SelectedDate)
                {
                    Color black = Color.FromRgb(60, 60, 60);
                    Color white = Color.FromRgb(180, 180, 180);
                    Button button = new Button();
                    button.Content = x.name;
                    button.Background = new SolidColorBrush(black);
                    button.Foreground = new SolidColorBrush(white);
                    button.Click += Button_Click1;
                    stack.Children.Add(button);
                }
                else
                {

                }
            }
        }
    }
}
