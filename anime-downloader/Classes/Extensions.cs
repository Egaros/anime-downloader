﻿using System;
using System.Collections;
using anime_downloader.Classes.Xml;
using anime_downloader.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace anime_downloader.Classes
{
    public static class Extensions
    {
        public static IEnumerable<Anime> AiringAndWatching(this IEnumerable<Anime> animes)
        {
            return animes.Where(a => a.Airing && a.Status.Equals("Watching"));
        }

        // TODO: Hey turn this into a real data binding instead of a fake one
        /// <summary>
        ///     "Refresh" the datacontext on the UI.
        /// </summary>
        /// <param name="animeList"></param>
        /// <param name="controller"></param>
        public static void Refresh(this AnimeList animeList, XmlController controller)
        {
            var anime = controller.Animes.ToList();
            animeList.DataGrid.ItemsSource = controller.FilteredSortedAnimes();
            animeList.StatsLabel.Content = $"{anime.Count} total animes. " +
                                           $"{anime.Count(a => a.Airing)} airing or watching, " +
                                           $"{anime.Count(a => a.Status.Equals("Finished"))} finished, " +
                                           $"{anime.Count(a => a.Status.Equals("Dropped"))} dropped.";
        }

        /// <summary>
        ///     Check if the container is empty.
        /// </summary>
        /// <param name="textbox"></param>
        /// <returns></returns>
        public static bool Empty(this TextBox textbox) => textbox.Text.Equals("");

        public static void WriteLine(this TextBox textbox, string text)
        {
            textbox.AppendText(text + "\n");
            textbox.Focus();
            textbox.CaretIndex = textbox.Text.Length;
            textbox.ScrollToEnd();
        }

        /// <summary>
        ///     Simulate a button press on a control.
        /// </summary>
        /// <param name="button"></param>
        public static void Press(this Control button)
        {
            if (button.IsHitTestVisible)
                button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        /// <summary>
        ///     Toggle opacity and visibility of a Control between two states.
        /// </summary>
        /// <param name="button"></param>
        public static void Toggle(this Control button)
        {
            button.Opacity = button.IsHitTestVisible ? 0.4 : 1.0;
            button.IsHitTestVisible ^= true;
        }

        /// <summary>
        ///     Toggle opacity and visibility of all buttons inside the MainWindow.
        /// </summary>
        /// <param name="mainWindow"></param>
        public static void ToggleButtons(this MainWindow mainWindow)
        {
            foreach (var button in GetAll<ToggleButton>(mainWindow))
                button.Toggle();
        }
        
        /* --WIP
        public static void AssignTo<T1, T2, T3>(this UserControl parent, Action function)
            where T1 : Control
            where T2 : Control
            where T3 : Control
        {
            var collections = new object[] { parent.GetAll<T1>(), parent.GetAll<T2>(), parent.GetAll<T3>() };

            foreach (var collection in collections)
                foreach (var item in (IEnumerable) collection)
                    ((Control) item).KeyDown += delegate { function(); };
        }
        */

        public static List<T> GetAll<T>(this object parent) where T : DependencyObject
        {
            var logicalCollection = new List<T>();
            GetAll(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private static void GetAll<T>(DependencyObject parent, ICollection<T> collection)
            where T : DependencyObject
        {
            var children = LogicalTreeHelper.GetChildren(parent);
            foreach (var child in children)
            {
                if (!(child is DependencyObject))
                    continue;
                var dependencyObject = child as DependencyObject;
                if (child is T)
                    collection.Add(child as T);
                GetAll(dependencyObject, collection);
            }
        }
    }
}