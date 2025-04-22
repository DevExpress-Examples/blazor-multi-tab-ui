Imports System.Web

Namespace DxBlazorApplication1

    Public Module UrlGenerator

        Public Const ToggleSidebarName As String = "toggledSidebar"

        Public Function GetUrl(ByVal baseUrl As String, ByVal toggledSidebar As Boolean) As String
            Return $"{baseUrl}?{ToggleSidebarName}={toggledSidebar}"
        End Function

        Public Function GetUrl(ByVal toggledSidebar As Boolean, ByVal returnUrl As String) As String
            Dim baseUriBuilder = New UriBuilder(returnUrl)
            Dim query = HttpUtility.ParseQueryString(baseUriBuilder.Query)
            Dim baseUrl = baseUriBuilder.Fragment + baseUriBuilder.Host + baseUriBuilder.Path
            Return $"{baseUrl}?{ToggleSidebarName}={toggledSidebar}&{query}"
        End Function
    End Module
End Namespace
