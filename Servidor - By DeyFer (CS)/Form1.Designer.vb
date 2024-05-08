<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    'Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StartServer = New MaterialSkin.Controls.MaterialButton()
        Me.BufferServer = New System.Windows.Forms.TextBox()
        Me.StopServer = New MaterialSkin.Controls.MaterialButton()
        Me.ClearLog = New MaterialSkin.Controls.MaterialButton()
        Me.SuspendLayout()
        '
        'StartServer
        '
        Me.StartServer.AutoSize = False
        Me.StartServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.StartServer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.StartServer.Depth = 0
        Me.StartServer.HighEmphasis = True
        Me.StartServer.Icon = Nothing
        Me.StartServer.Location = New System.Drawing.Point(4, 415)
        Me.StartServer.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.StartServer.MouseState = MaterialSkin.MouseState.HOVER
        Me.StartServer.Name = "StartServer"
        Me.StartServer.NoAccentTextColor = System.Drawing.Color.Empty
        Me.StartServer.Size = New System.Drawing.Size(181, 36)
        Me.StartServer.TabIndex = 1
        Me.StartServer.Text = "Start Server"
        Me.StartServer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.StartServer.UseAccentColor = False
        Me.StartServer.UseVisualStyleBackColor = True
        '
        'BufferServer
        '
        Me.BufferServer.BackColor = System.Drawing.Color.Black
        Me.BufferServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.BufferServer.ForeColor = System.Drawing.Color.Lime
        Me.BufferServer.Location = New System.Drawing.Point(4, 69)
        Me.BufferServer.Multiline = True
        Me.BufferServer.Name = "BufferServer"
        Me.BufferServer.Size = New System.Drawing.Size(582, 337)
        Me.BufferServer.TabIndex = 2
        '
        'StopServer
        '
        Me.StopServer.AutoSize = False
        Me.StopServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.StopServer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.StopServer.Depth = 0
        Me.StopServer.HighEmphasis = True
        Me.StopServer.Icon = Nothing
        Me.StopServer.Location = New System.Drawing.Point(206, 415)
        Me.StopServer.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.StopServer.MouseState = MaterialSkin.MouseState.HOVER
        Me.StopServer.Name = "StopServer"
        Me.StopServer.NoAccentTextColor = System.Drawing.Color.Empty
        Me.StopServer.Size = New System.Drawing.Size(181, 36)
        Me.StopServer.TabIndex = 3
        Me.StopServer.Text = "Stop Server"
        Me.StopServer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.StopServer.UseAccentColor = False
        Me.StopServer.UseVisualStyleBackColor = True
        '
        'ClearLog
        '
        Me.ClearLog.AutoSize = False
        Me.ClearLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClearLog.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.ClearLog.Depth = 0
        Me.ClearLog.HighEmphasis = True
        Me.ClearLog.Icon = Nothing
        Me.ClearLog.Location = New System.Drawing.Point(405, 415)
        Me.ClearLog.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.ClearLog.MouseState = MaterialSkin.MouseState.HOVER
        Me.ClearLog.Name = "ClearLog"
        Me.ClearLog.NoAccentTextColor = System.Drawing.Color.Empty
        Me.ClearLog.Size = New System.Drawing.Size(181, 36)
        Me.ClearLog.TabIndex = 4
        Me.ClearLog.Text = "Limpiar log"
        Me.ClearLog.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.ClearLog.UseAccentColor = False
        Me.ClearLog.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 460)
        Me.Controls.Add(Me.ClearLog)
        Me.Controls.Add(Me.StopServer)
        Me.Controls.Add(Me.BufferServer)
        Me.Controls.Add(Me.StartServer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "Servidor - By DeyFer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartServer As MaterialSkin.Controls.MaterialButton
    Friend WithEvents BufferServer As TextBox
    Friend WithEvents StopServer As MaterialSkin.Controls.MaterialButton
    Friend WithEvents ClearLog As MaterialSkin.Controls.MaterialButton
End Class
