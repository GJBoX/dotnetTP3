using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp1.Interface;
using Shared.Models;

namespace BlazorApp1.Services
{
    public class WSServiceUtilisateur : IService<Utilisateur>
    {
        private readonly HttpClient httpClient;

        public WSServiceUtilisateur(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:5219/api/");
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Utilisateur>?> GetAllAsync(string? nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Utilisateur?> GetByStringAsync(string nomControleur, string email)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Utilisateur>($"{nomControleur}/{email}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task AddAsync(string nomControleur, Utilisateur utilisateur)
        {
            try
            {
                await httpClient.PostAsJsonAsync(nomControleur, utilisateur);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding utilisateur: {ex.Message}");
            }
        }

        public async Task UpdateAsync(string nomControleur, Utilisateur utilisateur)
        {
            try
            {
                await httpClient.PutAsJsonAsync($"{nomControleur}/{utilisateur.UtilisateurId}", utilisateur);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating utilisateur: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(string nomControleur, int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{nomControleur}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<Utilisateur>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> GetByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
