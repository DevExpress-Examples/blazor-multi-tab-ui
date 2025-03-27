namespace DxBlazorApplication1.Components.MDI
{
    public class MDITab {
        public string Text { get; set; }
        public int VisibleIndex { get; set; }
        public bool Visible { get; set; }
        public MDITab(string text, int visibleIndex, bool visible) {
            Text = text;
            VisibleIndex = visibleIndex;
            Visible = visible;
        }
    }
}
