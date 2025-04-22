Namespace DxBlazorApplication1.Components.MDI

    Public Class MDITab

        Public Property Text As String

        Public Property VisibleIndex As Integer

        Public Property Visible As Boolean

        Public Sub New(ByVal text As String, ByVal visibleIndex As Integer, ByVal visible As Boolean)
            Me.Text = text
            Me.VisibleIndex = visibleIndex
            Me.Visible = visible
        End Sub
    End Class
End Namespace
