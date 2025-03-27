using Microsoft.JSInterop;
using System.Text.Json;

namespace DxBlazorApplication1.Components.MDI
{
    public class MDIStateHelper {
        private const string LOCAL_STORAGE_KEY = "MDI-Layout";
        private readonly IJSRuntime js;

        public MDIStateHelper(IJSRuntime js) {
            this.js = js;
        }

        public async Task SaveLayoutToLocalStorageAsync(MDITabCollection tabData) {
            try {
                var json = JsonSerializer.Serialize(tabData);
                await js.InvokeVoidAsync("localStorage.setItem", LOCAL_STORAGE_KEY, json);
            }
            catch { return; }
        }

        public async Task<MDITabCollection?> LoadLayoutFromLocalStorageAsync() {
            try {
                var json = await js.InvokeAsync<string>("localStorage.getItem", LOCAL_STORAGE_KEY);
                return JsonSerializer.Deserialize<MDITabCollection>(json);
            }
            catch { return null; }
        }
    }
}
