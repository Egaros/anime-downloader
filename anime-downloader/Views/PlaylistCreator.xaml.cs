﻿using System.Windows.Input;
using anime_downloader.Classes;

namespace anime_downloader.Views
{
    /// <summary>
    ///     Interaction logic for PlaylistCreator.xaml
    /// </summary>
    public partial class PlaylistCreator
    {
        public PlaylistCreator()
        {
            InitializeComponent();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CreateButton.Press();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateButton.Focus();
        }
    }
}