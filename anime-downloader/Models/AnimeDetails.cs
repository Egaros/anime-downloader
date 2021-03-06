﻿using System;
using System.Collections.Generic;
using anime_downloader.Enums;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace anime_downloader.Models
{
    [Serializable]
    public sealed class AnimeDetails : ObservableObject
    {
        private static int CurrentYear() => DateTime.Now.Year;

        private static Season CurrentSeason() => (Season) Math.Ceiling(Convert.ToDouble(DateTime.Now.Month) / 3);

        private string _english = "";

        private string _id = "";

        private int _aniId;

        private bool _needsUpdating;

        private int _overallTotal;

        private string _synonyms = "";

        private string _synopsis = "";

        private string _title = "";

        private int _totalEpisodes;

        // 

        /// <summary>
        ///     The MyAnimeList id number.
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get => _id;
            set
            {
                Set(() => Id, ref _id, value);
                RaisePropertyChanged(nameof(HasId));
            }
        }

        /// <summary>
        ///     The AniList id number.
        /// </summary>
        [JsonProperty("ani_id")]
        public int AniId
        {
            get => _aniId;
            set => Set(() => AniId, ref _aniId, value);
        }

        /// <summary>
        ///     The provided synopsis of the plot.
        /// </summary>
        [JsonProperty("synopsis")]
        public string Synopsis
        {
            get => _synopsis;
            set => Set(() => Synopsis, ref _synopsis, value);
        }

        /// <summary>
        ///     The path to the thumbnail image.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        ///     The official title (usually the japanese version).
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
            set
            {
                Set(() => Title, ref _title, value);
                RaisePropertyChanged(nameof(TitleAndEnglish));
            }
        }

        /// <summary>
        ///     The specifically english version of the title.
        /// </summary>
        [JsonProperty("english")]
        public string English
        {
            get => _english;
            set
            {
                Set(() => English, ref _english, value);
                RaisePropertyChanged(nameof(TitleAndEnglish));
            }
        }

        /// <summary>
        ///     All various nicknames and abbreviations used to represent the show.
        /// </summary>
        [JsonProperty("synonyms")]
        public string Synonyms
        {
            get => _synonyms;
            set
            {
                Set(() => Synonyms, ref _synonyms, value);
                RaisePropertyChanged(nameof(SynonymsSplit));
            }
        }

        /// <summary>
        ///     True if any change was made that would be pushed to a synchronization service.
        /// </summary>
        [JsonProperty("needs_updates")]
        public bool NeedsUpdating
        {
            get => _needsUpdating;
            set => Set(() => NeedsUpdating, ref _needsUpdating, value);
        }

        /// <summary>
        ///     The total episode count for the series.
        /// </summary>
        [JsonProperty("total_episodes")]
        public int TotalEpisodes
        {
            get => _totalEpisodes;
            set
            {
                Set(() => TotalEpisodes, ref _totalEpisodes, value);
                RaisePropertyChanged(nameof(Total));
            }
        }

        /// <summary>
        ///     The total episodes for the entire series (a sum of prequel series totals to get current episode).
        /// </summary>
        [JsonProperty("overall_total")]
        public int OverallTotal
        {
            get => _overallTotal;
            set
            {
                Set(() => OverallTotal, ref _overallTotal, value);
                RaisePropertyChanged(nameof(Total));
            }
        }
        
        /// <summary>
        ///     The season that the anime aired on.
        /// </summary>
        [JsonProperty("aired")]
        public AnimeSeason Aired { get; set; }

        /// <summary>
        ///     The season that the anime ended on.
        /// </summary>
        [JsonProperty("ended")]
        public AnimeSeason Ended { get; set; }

        /// <summary>
        ///     The common, publicly used title for the series.
        /// </summary>
        [JsonProperty("preferred_search_title")]
        public string PreferredSearchTitle { get; set; }

        // 

        /// <summary>
        ///     True if the series is still considered airing relative to the current season.
        /// </summary>
        [JsonIgnore]
        public bool AiringNow
        {
            /*
             * Given that the airing is not null and that either the year is less than the current year
             * or that the year is the same as the current year and the season is less than or equal to the current season,
             * combined with the fact that there is either no end date or the end date is this season, then the show
             * has to be airing
             * 
             * Starting airing in 2007,
             *    No End Date
             *    Current is 2016
             *    = Still airing e.g. Naruto Shippuden
             * Started airing in Summer 2016, 
             *     Ended Airing in Fall 2017
             *     Current is Fall 2017
             *     = Still airing e.g. Twin Star Exorcists
             * */
            get
            {
                return Aired != null
                       && (Aired.Year < CurrentYear() || (Aired.Year == CurrentYear() && (int) Aired.Season <= (int) CurrentSeason()))
                       && (Ended == null || (Ended.Year == CurrentYear() && (int) Ended.Season == (int) CurrentSeason()));
            }
        }

        /// <summary>
        ///     The calculated total from choosing either the overalltotal or totalepisodes.
        /// </summary>
        [JsonIgnore]
        public int Total => OverallTotal > 0 ? OverallTotal : TotalEpisodes;

        /// <summary>
        ///     True if the series has a myanimelist id.
        /// </summary>
        [JsonIgnore]
        public bool HasId => !string.IsNullOrEmpty(Id);

        [JsonIgnore]
        public IEnumerable<string> TitleAndEnglish => new[] {Title, English};

        [JsonIgnore]
        public IEnumerable<string> SynonymsSplit => Synonyms.Split(';');
    }
}