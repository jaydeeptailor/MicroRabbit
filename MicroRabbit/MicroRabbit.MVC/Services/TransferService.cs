using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient client)
        {
            _apiClient = client;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), System.Text.Encoding.UTF8, "application/json");

            var resoponse = await _apiClient.PostAsync(uri, transferContent);

            resoponse.EnsureSuccessStatusCode();
        }
    }
}
