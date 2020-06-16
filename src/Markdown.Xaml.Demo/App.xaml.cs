using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace Markdown.Demo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoadStyles();
        }

        private void LoadStyles()
        {
            // Load a custom styles file if it exists
            var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var stylesBaseFile = Path.Combine(Path.GetDirectoryName(currentAssembly), Path.GetFileNameWithoutExtension(currentAssembly) + ".Styles");
            var stylesFile = stylesBaseFile + ".xaml";
            if (File.Exists(stylesFile) == false)
            {
                stylesFile = stylesBaseFile + ".Default.xaml";
            }

            try
            {
                using (Stream stream = new FileStream(stylesFile, FileMode.Open, FileAccess.Read))
                {
                    var resources = (ResourceDictionary)XamlReader.Load(stream);
                    Resources.MergedDictionaries.Add(resources);
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show($"Unable to load styles file '{stylesFile}'.\n{ex.Message}");
            }
        }
    }
}
