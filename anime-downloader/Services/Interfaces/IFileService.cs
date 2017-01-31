﻿using System.Collections.Generic;
using System.Threading.Tasks;
using anime_downloader.Enums;
using anime_downloader.Models;

namespace anime_downloader.Services.Interfaces
{
    /// <summary>
    ///     The logic behind handling file retrieval for anime episodes and
    ///     some file operations.
    /// </summary>
    public interface IFileService
    {
        IEnumerable<AnimeFile> GetEpisodes(Anime anime);
        IEnumerable<AnimeFile> GetEpisodes(EpisodeStatus episodeStatus);
        IEnumerable<AnimeFile> GetEpisodes(Anime anime, EpisodeStatus episodeStatus);
        Task<IEnumerable<AnimeFile>> GetEpisodesAsync(EpisodeStatus episodeStatus);
        Task<IEnumerable<AnimeFile>> GetEpisodesFromAsync(Anime anime, EpisodeStatus episodeStatus);

        AnimeFile FirstEpisode(Anime anime);
        AnimeFile LastEpisode(Anime anime);

        // First/last of everything in sequence
        IEnumerable<AnimeFile> FirstEpisodes(IEnumerable<AnimeFile> files);
        IEnumerable<AnimeFile> LastEpisodes(IEnumerable<AnimeFile> files);

        // Closest
        AnimeFile ClosestFile(IEnumerable<AnimeFile> files, string name);
        Anime ClosestAnime(IEnumerable<Anime> animes, string name);
        Anime ClosestAnime(IEnumerable<Anime> animes, AnimeFile file);

        // 
        Task<int> MoveDuplicatesAsync();
    }
}