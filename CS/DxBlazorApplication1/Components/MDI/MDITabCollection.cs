using DevExpress.Blazor;
using System.Collections;
using System.Text.Json.Serialization;

namespace DxBlazorApplication1.Components.MDI
{
    public class MDITabCollection {
        [JsonInclude]
        private List<MDITab> tabs;

        public int Count => tabs.Count;

        public MDITabCollection() {
            tabs = new List<MDITab>();
        }

        public MDITabCollection(IEnumerable<ITabInfo> tabs) {
            this.tabs = tabs.Select(t => new MDITab(t.Text,  
                t.VisibleIndex == -1 ? tabs.ToList().IndexOf(t) : t.VisibleIndex,
                t.Visible)).ToList();
        }

        public void SetVisibleAllTabs(bool visible) {
            tabs.ForEach((t) => t.Visible = visible);
        }

        public string? GetTabTextByTabInfo(ITabInfo tabInfo) {
            return tabs.FirstOrDefault(t => t.Text == tabInfo.Text)?.Text;
        }

        public int GetVisibleIndexByTabText(string? text) {
            return tabs.Find(t => t.Text == text)?.VisibleIndex ?? -1;
        }

        public bool GetVisibleByTabText(string? text) {
            return tabs.Find(t => t.Text == text)?.Visible ?? true;
        }

        public void SetVisibleByTabText(string? text, bool visible) {
            var tab = tabs.Find(t => t.Text == text);
            if(tab != null)
            {
                tab.Visible = visible;
            }
        }

        public void SetVisibleIndexByTabText(string? text, int visibleIndex) {
            var tab = tabs.Find(t => t.Text == text);
            if(tab != null)
            {
                tab.VisibleIndex = visibleIndex;
            }
        }
    }
}
