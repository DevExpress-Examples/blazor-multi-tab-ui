Imports DevExpress.Blazor
Imports System.Collections
Imports System.Text.Json.Serialization

Namespace DxBlazorApplication1.Components.MDI

    Public Class MDITabCollection

        <JsonInclude>
        Private tabs As List(Of MDITab)

        Public ReadOnly Property Count As Integer
            Get
                Return tabs.Count
            End Get
        End Property

        Public Sub New()
            tabs = New List(Of MDITab)()
        End Sub

        Public Sub New(ByVal tabs As IEnumerable(Of ITabInfo))
            Me.tabs = tabs.[Select](Function(t) New MDITab(t.Text, If(t.VisibleIndex Is -1, tabs.ToList().IndexOf(t), t.VisibleIndex), t.Visible)).ToList()
        End Sub

        Public Sub SetVisibleAllTabs(ByVal visible As Boolean)
            tabs.ForEach(Function(t) CSharpImpl.__Assign(t.Visible, visible))
        End Sub

        Public Function GetTabTextByTabInfo(ByVal tabInfo As ITabInfo) As String?
            Return tabs.FirstOrDefault(Function(t) t.Text Is tabInfo.Text)?.Text
        End Function

        Public Function GetVisibleIndexByTabText(ByVal text As String?) As Integer
            Return If(tabs.Find(Function(t) t.Text Is text)?.VisibleIndex, -1)
        End Function

        Public Function GetVisibleByTabText(ByVal text As String?) As Boolean
            Return If(tabs.Find(Function(t) t.Text Is text)?.Visible, True)
        End Function

        Public Sub SetVisibleByTabText(ByVal text As String?, ByVal visible As Boolean)
            Dim tab = tabs.Find(Function(t) t.Text Is text)
            If tab IsNot Nothing Then
                tab.Visible = visible
            End If
        End Sub

        Public Sub SetVisibleIndexByTabText(ByVal text As String?, ByVal visibleIndex As Integer)
            Dim tab = tabs.Find(Function(t) t.Text Is text)
            If tab IsNot Nothing Then
                tab.VisibleIndex = visibleIndex
            End If
        End Sub

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
