using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Markdown.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(NavigationCommands.GoToPage, (sender, e) => Console.WriteLine((string)e.Parameter)));

            DataContext = new DemoViewModel();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DemoSource.Text = LoadSample();
        }

        private string LoadSample()
        {
            var subjectType = GetType();
            var subjectAssembly = subjectType.Assembly;
            using (var stream = subjectAssembly.GetManifestResourceStream(subjectType.FullName + ".md"))
            {
                if (stream is null)
                {
                    return string.Format(
                        CultureInfo.InvariantCulture,
                        "Could not find sample text *{0}*.md", 
                        subjectType.FullName);
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Manual preview markdown.
        /// </summary>
        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            ((DemoViewModel)DataContext).TextPreview = ((DemoViewModel)DataContext).TextMarkdown;
        }
    }
}
