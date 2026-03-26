using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TodoList.Models;

namespace TodoList.Services;

public class ClassiService
{
    private readonly HttpClient _http;

    // Create a HttpClient with the correct BaseAddress from NavigationManager.
    public ClassiService(NavigationManager nav)
    {
        _http = new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
    }

    public async Task<List<Classe>> GetAllAsync()
    {
        var res = await _http.GetFromJsonAsync<List<Classe>>("api/classi");
        return res ?? new List<Classe>();
    }

    public async Task<Classe?> GetAsync(int id)
    {
        return await _http.GetFromJsonAsync<Classe>($"api/classi/{id}");
    }

    public async Task<Classe?> AddAsync(Classe classe)
    {
        var resp = await _http.PostAsJsonAsync("api/classi", classe);
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<Classe>();
    }

    public async Task<bool> UpdateAsync(int id, Classe classe)
    {
        var resp = await _http.PutAsJsonAsync($"api/classi/{id}", classe);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var resp = await _http.DeleteAsync($"api/classi/{id}");
        return resp.IsSuccessStatusCode;
    }
}
