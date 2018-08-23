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

namespace CharacterSheet.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterAttributeInput.xaml
    /// </summary>
    public partial class CharacterAttributeInput : UserControl
    {
        public static readonly DependencyProperty AttributeNameProperty = DependencyProperty.Register("AttributeName", typeof(string), typeof(CharacterAttributeInput));
        public static readonly DependencyProperty AttributeValueProperty = DependencyProperty.Register("AttributeValue", typeof(int), typeof(CharacterAttributeInput));

        public CharacterAttributeInput()
        {
            InitializeComponent();
        }

        public string AttributeName
        {
            get => (string)GetValue(AttributeNameProperty);
            set => SetValue(AttributeNameProperty, value);
        }

        public int AttributeValue
        {
            get => (int)GetValue(AttributeValueProperty);
            set => SetValue(AttributeValueProperty, value);
        }
    }
}
