﻿using System.Threading.Tasks;
using anime_downloader.Models;

namespace anime_downloader.Services.Interfaces
{
    /// <summary>
    ///     Identification 
    /// </summary>
    public interface IRequireIdentification
    {
        /// <summary>
        ///     Takes the id needed to fill in service from the anime
        /// </summary>
        int GetId(Anime anime);

        /// <summary>
        ///     Sets the property where the id is with the id value
        /// </summary>
        void SetId(Anime anime, int id);

        /// <summary>
        ///     Find the anime needed for the service (if possible)
        /// </summary>
        Task<(bool successful, int id)> FindId(Anime anime);
    }
}