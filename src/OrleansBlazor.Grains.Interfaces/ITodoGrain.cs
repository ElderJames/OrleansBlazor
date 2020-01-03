using Orleans;
using OrleansBlazor.Grains.Models;
using System.Threading.Tasks;

namespace OrleansBlazor.Grains
{
    public interface ITodoGrain : IGrainWithGuidKey
    {
        Task SetAsync(TodoItem item);

        Task ClearAsync();

        Task<TodoItem> GetAsync();
    }
}