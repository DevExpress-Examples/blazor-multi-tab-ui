Imports Microsoft.JSInterop
Imports System.Text.Json

Namespace DxBlazorApplication1.Components.MDI

    Public Class MDIStateHelper

        Private Const LOCAL_STORAGE_KEY As String = "MDI-Layout"

        Private ReadOnly js As IJSRuntime

        Public Sub New(ByVal js As IJSRuntime)
            Me.js = js
        End Sub

        Public Async Function SaveLayoutToLocalStorageAsync(ByVal tabData As MDITabCollection) As Task
            Try
                Dim json = JsonSerializer.Serialize(tabData)
                Await js.InvokeVoidAsync("localStorage.setItem", LOCAL_STORAGE_KEY, json)
            Catch
                Return
            End Try
        End Function

        Public Async Function LoadLayoutFromLocalStorageAsync() As Task(Of MDITabCollection?)
            Try
                Dim json = Await js.InvokeAsync(Of String)("localStorage.getItem", LOCAL_STORAGE_KEY)
                Return JsonSerializer.Deserialize(Of MDITabCollection)(json)
            Catch
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
