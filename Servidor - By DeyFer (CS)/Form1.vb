Imports MaterialSkin
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.ComponentModel

Public Class Form1
#Region "Variables"
    Private server As TcpListener
    Private isServerRunning As Boolean = False
    Dim Dinero As Integer
#End Region
#Region "Inicio de la aplicacion"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        SkinManager.ColorScheme = New ColorScheme(Primary.LightBlue900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
        'Dimenciones Form
        '592, 460
        Me.Width = 592
        Me.Height = 460
        BufferServer.ForeColor = Color.Lime
        BufferServer.BackColor = Color.Black
    End Sub
#End Region
    'Cuando la app se cierra
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Close()
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Close()
    End Sub
    Private Sub StartServer_()
        Try
            server = New TcpListener(IPAddress.Any, 3497)
            server.Start()
            isServerRunning = True
            Dim serverThread As Thread = New Thread(AddressOf ListenForClients_)
            serverThread.Start()
            Log_("Servidor iniciado en " & IPAddress.Any.ToString() & " puerto 3497.")
        Catch ex As Exception
            Log_("Error al iniciar el servidor: " & ex.Message)
        End Try
    End Sub
    Private Sub StopServer_()
        If isServerRunning Then
            server.Stop()
            isServerRunning = False
            Log_("Servidor detenido.")
        End If
    End Sub
    Private Sub ClearLog_()
        BufferServer.Clear()
    End Sub
    Private Sub Log_(message As String, Optional direction As String = "<-")
        If BufferServer.InvokeRequired Then
            BufferServer.Invoke(Sub() BufferServer.AppendText(direction & " " & message & Environment.NewLine))
        Else
            BufferServer.AppendText(direction & " " & message & Environment.NewLine)
        End If
    End Sub
    Private Sub ListenForClients_()
        Try
            While isServerRunning
                Dim client As TcpClient = server.AcceptTcpClient()
                Dim clientEndPoint As Net.IPEndPoint = CType(client.Client.RemoteEndPoint, Net.IPEndPoint)
                Log_("Cliente conectado desde " & clientEndPoint.Address.ToString() & ":" & clientEndPoint.Port.ToString())

                Dim clientThread As Thread = New Thread(Sub() HandleClientRequests(client))
                clientThread.Start()
            End While
        Catch ex As Exception
            Log_("Error al aceptar cliente: " & ex.Message)
        End Try
    End Sub
    Private Function WaitForResponse(stream As NetworkStream) As String
        Log_("WaitForResponse")
        Dim responseData As New StringBuilder()
        Dim buffer(1024) As Byte
        Dim bytesRead As Integer

        While stream.DataAvailable
            bytesRead = stream.Read(buffer, 0, buffer.Length)
            responseData.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead))
        End While

        Log_(responseData.ToString())
        Return responseData.ToString()
    End Function
    Private Sub HandleClientRequests(client As TcpClient)
        Try
            Dim Dinero As Integer = 500

            Log_("Nueva conexion", "<-")
            Log_("HandleClientRequests:" & client.ToString(), "<-")
            Dim stream As NetworkStream = client.GetStream()
            Dim bufferSize As Integer = 1024
            Dim data(bufferSize) As Byte

            While True
                Dim bytesRead As Integer = stream.Read(data, 0, bufferSize)

                If bytesRead <= 0 Then
                    Exit While
                End If

                Dim requestData As String = Encoding.ASCII.GetString(data, 0, bytesRead).Trim()
                Log_("Mensaje recibido del cliente: " & requestData, "<-")
                Select Case requestData
                    Case "GET_INITIAL_MONEY"
                        Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(Dinero.ToString())
                        stream.Write(responseBytes, 0, responseBytes.Length)
                        stream.Flush()
                        Log_("Enviando cantidad inicial de dinero al cliente: " & Dinero.ToString(), "->")
                    Case "OPEN_CHEST"
                        Dim random As New Random()
                        Dim coins As Integer = random.Next(1, 101)
                        Dinero += coins
                        Dim response As String = "COINS_RECEIVED:" & coins.ToString()
                        Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(response)
                        stream.Write(responseBytes, 0, responseBytes.Length)
                        stream.Flush()
                        Log_("Enviando monedas recibidas al cliente: " & coins.ToString(), "->")
                    Case "BUY_CHEST"
                        If Dinero >= 250 Then
                            Dinero -= 250
                            Dim response As String = "COINS_RECEIVED:-250"
                            Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(response)
                            stream.Write(responseBytes, 0, responseBytes.Length)
                            stream.Flush()
                            Log_("Enviando monedas restantes al cliente: " & Dinero.ToString(), "->")
                        Else
                            Dim response As String = "INSUFFICIENT_FUNDS"
                            Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(response)
                            stream.Write(responseBytes, 0, responseBytes.Length)
                            stream.Flush()
                            Log_("Enviando mensaje de fondos insuficientes al cliente.", "->")
                        End If
                    Case "CHECK_COINS"
                        Dim response As String = "CURRENT_COINS:" & Dinero.ToString()
                        Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(response)
                        stream.Write(responseBytes, 0, responseBytes.Length)
                        stream.Flush()
                        Log_("Enviando cantidad actual de monedas al cliente: " & Dinero.ToString(), "->")
                End Select
            End While
        Catch ex As Exception
            Log_("Error al manejar solicitudes del cliente: " & ex.Message)
        Finally
            Log_("La conexión con el cliente se mantendrá abierta.", "->")
        End Try
    End Sub
    'Botones
    Private Sub StartServer_Click(sender As Object, e As EventArgs) Handles StartServer.Click
        StartServer_()
    End Sub

    Private Sub StopServer_Click(sender As Object, e As EventArgs) Handles StopServer.Click
        StopServer_()
    End Sub

    Private Sub ClearLog_Click(sender As Object, e As EventArgs) Handles ClearLog.Click
        ClearLog_()
    End Sub
End Class