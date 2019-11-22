﻿using GraphExplorer.Models;
using GraphExplorer.Utils;

namespace GraphExplorer.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    public class SettingsController : ApiController
    {
        private const string id = "__settings";

        private FileSystemRepository<GraphSettings> settingsRepo = new FileSystemRepository<GraphSettings>("graphsettings.json");

        public async Task<GraphSettings> Get(string collectionId)
        {
            return await settingsRepo.GetItemAsync(collectionId);
        }

        public async Task Post([FromBody]GraphSettings value, [FromUri]string collectionId)
        {
            await settingsRepo.CreateOrUpdateItemAsync(value, collectionId);
        }

        public async Task Delete(string collectionId)
        {
            await settingsRepo.DeleteItemAsync(id, collectionId);
        }
    }
}