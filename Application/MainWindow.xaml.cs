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
using GamingService;
using GamingService.DataType;

namespace Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameService _service;

        public MainWindow()
        {
            InitializeComponent();

            _service = new GameService();

        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var task = _service.GetRandomGame();
            var game = await task;

            label.Content = game.Name;
        }
    }
}
