﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CharacterSheet.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterAttributeInput.xaml
    /// </summary>
    public partial class CharacterAttributeTextBox : UserControl
    {
        public static readonly DependencyProperty AttributeNameProperty = DependencyProperty.Register("AttributeName", typeof(string), typeof(CharacterAttributeTextBox));
        public static readonly DependencyProperty AttributeValueProperty = DependencyProperty.Register("AttributeValue", typeof(string), typeof(CharacterAttributeTextBox));
        public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CharacterAttributeTextBox));
        public static readonly DependencyProperty ButtonCommandParameterProperty = DependencyProperty.Register("ButtonCommandParameter", typeof(object), typeof(CharacterAttributeTextBox));
        public static readonly DependencyProperty ButtonVisibilityProperty = DependencyProperty.Register("ButtonVisibility", typeof(Visibility), typeof(CharacterAttributeTextBox));

        public CharacterAttributeTextBox()
        {
            InitializeComponent();
        }

        public string AttributeName
        {
            get => (string)GetValue(AttributeNameProperty);
            set => SetValue(AttributeNameProperty, value);
        }

        public string AttributeValue
        {
            get => (string)GetValue(AttributeValueProperty);
            set => SetValue(AttributeValueProperty, value);
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

        public Visibility ButtonVisibility
        {
            get => (Visibility)GetValue(ButtonVisibilityProperty);
            set => SetValue(ButtonVisibilityProperty, value);
        }
    }
}
