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

namespace CharacterCreationPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterAttributeComboBox.xaml
    /// </summary>
    public partial class CharacterAttributeComboBox : UserControl
    {
        public static readonly DependencyProperty AttributeNameProperty = DependencyProperty.Register("AttributeName", typeof(string), typeof(CharacterAttributeComboBox));
        public static readonly DependencyProperty AttributeItemsProperty = DependencyProperty.Register("AttributeItems", typeof(List<string>), typeof(CharacterAttributeComboBox));
        public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CharacterAttributeComboBox));
        public static readonly DependencyProperty ButtonCommandParameterProperty = DependencyProperty.Register("ButtonCommandParameter", typeof(object), typeof(CharacterAttributeComboBox));
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(CharacterAttributeComboBox));
        public static readonly DependencyProperty ButtonVisibilityProperty = DependencyProperty.Register("ButtonVisibility", typeof(Visibility), typeof(CharacterAttributeComboBox));

        public CharacterAttributeComboBox()
        {
            InitializeComponent();
        }

        public string AttributeName
        {
            get => (string)GetValue(AttributeNameProperty);
            set => SetValue(AttributeNameProperty, value);
        }

        public List<string> AttributeItems
        {
            get => (List<string>)GetValue(AttributeItemsProperty);
            set => SetValue(AttributeItemsProperty, value);
        }

        public ICommand ButtonCommand
        {
            get => (ICommand)GetValue(ButtonCommandProperty);
            set => SetValue(ButtonCommandProperty, value);
        }

        public object ButtonCommandParameter
        {
            get => GetValue(ButtonCommandParameterProperty);
            set => SetValue(ButtonCommandParameterProperty, value);
        }

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public Visibility ButtonVisibility
        {
            get => (Visibility)GetValue(ButtonVisibilityProperty);
            set => SetValue(ButtonVisibilityProperty, value);
        }
    }
}
