﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SecretWord.ChildDialogs
{
    class ChildDialog : DependencyObject
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ChildDialog), new PropertyMetadata(""));

        public UserControl View
        {
            get { return (UserControl)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("View", typeof(UserControl), typeof(ChildDialog), new PropertyMetadata(null));

        private bool dialogResult = false;
        public bool DialogResult => dialogResult;


        public ChildDialog(string title, object viewModel)
        {
            #region Колхоз на тему: по быстрому найти подходящий View
            string viewTypeName = viewModel.GetType().FullName.Replace("ViewModels","Views");
            viewTypeName = viewTypeName.Remove(viewTypeName.Length - "Model".Length);
            Type viewType = Type.GetType(viewTypeName);
            View = Activator.CreateInstance(viewType) as UserControl;
            #endregion
            Title = title;
            View.DataContext = viewModel;
            ChildDialogWindow cdw = new ChildDialogWindow();
            cdw.DataContext = this;
            cdw.oKay.Click += (s, e) => {
                dialogResult = true;
                cdw.Close();
            };
            cdw.ShowDialog();
        }








    }
}
