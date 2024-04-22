using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Listtt.ItemsSource = people;
        }
        
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            string? name,surname,genderr=null,city=null;
            bool step;
            name = Name_TextBox.Text;
            surname = Surname_TextBox.Text;
            foreach (var item in GenderSTC.Children)
            {
                var RDB = item as RadioButton;
                if(RDB != null) 
                {
                   if(RDB.IsChecked == true)
                    {
                        genderr = RDB.Content.ToString();
                    }
                }
            }
            foreach (var item in CityCMB.Items)
            {
                var cityty = item as string;
                city = CityCMB.SelectedValue.ToString().Split(":")[1];
            }
            step = Stepp.IsChecked ?? false;
            people.Add(new Person(name, surname,genderr,step, city));
            Listtt.Items.Refresh();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Listtt.SelectedItem != null)
            {
                people.Remove((Person)Listtt.SelectedItem);
                Listtt.Items.Refresh();
            }    
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

                var p = Listtt.Items[0] as Person;
                var filename = p.Name;
                var options = new JsonSerializerOptions()
                { WriteIndented = true };
                string json = JsonSerializer.Serialize(Listtt.Items, options);

                File.WriteAllText(filename, json);
                people.Clear();
            Listtt.Items.Refresh();
            
        }
    }
}