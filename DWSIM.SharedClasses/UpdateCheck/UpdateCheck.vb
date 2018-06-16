﻿Imports System.Net

Public Class UpdateCheck

    Public Shared Function CheckForUpdates() As Boolean
        Dim webClient = New WebClient()
        Dim proxyObj As New WebProxy(Net.WebRequest.GetSystemWebProxy.GetProxy(New Uri("http://dwsim.inforside.com.br")))
        proxyObj.Credentials = CredentialCache.DefaultCredentials
        webClient.Proxy = proxyObj
        Dim url = New Uri("http://dwsim.inforside.com.br/update/desktop.txt")
        Dim latestversion As String = ""
        Try
            latestversion = webClient.DownloadString(url)
            If latestversion = "" Then Return False
            If latestversion <> GlobalSettings.Settings.CurrentRunningVersion Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
