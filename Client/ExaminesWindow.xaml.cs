﻿using System;
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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for ExaminesWindow.xaml
    /// </summary>
    public partial class ExaminesWindow : Window
    {
        public ExaminesWindow()
        {
            InitializeComponent();
        }

        private void newMeasureBtn_Click(object sender, RoutedEventArgs e)
        {
            ExamineWindow window = new ExamineWindow();
            window.ShowDialog();
        }
    }
}
