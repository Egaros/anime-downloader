﻿using System.Collections.Generic;
using anime_downloader.Models;

namespace anime_downloader.Services.Interfaces
{
    /// <summary>
    ///     The logic behind handling adding, removing and retrieving anime
    ///     from the user's stored settings.
    /// </summary>
    public interface IAnimeService
    {
        /// <summary>
        ///     The entire collection of anime.
        /// </summary>
        IEnumerable<Anime> Animes { get; }

        // The most accessed group types

        /// <summary>
        ///     The collection that is most likely to be used for displaying, 
        ///     a list that is filtered and sorted by the users preferences
        /// </summary>
        IEnumerable<Anime> FilteredAndSorted();

        /// <summary>
        ///     All shows that are currently airing and are being watched.
        /// </summary>
        IEnumerable<Anime> AiringAndWatching { get; }

        /// <summary>
        ///    All shows that are flagged for needing an update.
        /// </summary>
        IEnumerable<Anime> NeedsUpdates { get; }
        
        /// <summary>
        ///     All shows that have been fully watched but are not marked as finished.
        /// </summary>
        IEnumerable<Anime> FullyWatched();

        /// <summary>
        ///     All shows that are airing, watched, and (if they have a total episode count) not completed.
        /// </summary>
        IEnumerable<Anime> AiringAndWatchingAndNotCompleted();

        // Collection operations

        /// <summary>
        ///     Add to the collection.
        /// </summary>
        void Add(Anime anime);

        /// <summary>
        ///     Remove from the collection.
        /// </summary>
        void Remove(Anime anime);

        /// <summary>
        ///     Remove from the collection (matching by name).
        /// </summary>
        void Remove(string name);
    }
}