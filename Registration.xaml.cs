using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TSPP
{
    public partial class Registration : Window
    {
        private static Dictionary<string, bool> validity = new Dictionary<string, bool>(3);
        public Registration()
        {
            InitializeComponent();
        }
        private static void validityDictInit()
        {
            
        }
        static private bool IsLatin(string sstring)
        {
            return Regex.IsMatch(sstring, @"\p{IsBasicLatin}");
        }
    }
}
