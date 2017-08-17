<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadAlertsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAlertsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeaturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChatLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MathGamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TypeToWinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AntiAFKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoRelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnableDisableAlertsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.box_output = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerAntiAFK = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.LemonChiffon
        Me.TextBox1.Location = New System.Drawing.Point(12, 465)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(875, 25)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.Location = New System.Drawing.Point(893, 465)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 25)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.BackColor = System.Drawing.Color.Black
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(82, 27)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(785, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server ip:"
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConnect.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.ButtonConnect.Location = New System.Drawing.Point(870, 25)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(91, 23)
        Me.ButtonConnect.TabIndex = 10
        Me.ButtonConnect.Text = "Connect!"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.FeaturesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(966, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReloadAlertsToolStripMenuItem, Me.EditAlertsToolStripMenuItem, Me.StopChatToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'ReloadAlertsToolStripMenuItem
        '
        Me.ReloadAlertsToolStripMenuItem.Name = "ReloadAlertsToolStripMenuItem"
        Me.ReloadAlertsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ReloadAlertsToolStripMenuItem.Text = "Reload Alerts"
        '
        'EditAlertsToolStripMenuItem
        '
        Me.EditAlertsToolStripMenuItem.Name = "EditAlertsToolStripMenuItem"
        Me.EditAlertsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.EditAlertsToolStripMenuItem.Text = "Edit Alerts"
        '
        'StopChatToolStripMenuItem
        '
        Me.StopChatToolStripMenuItem.Name = "StopChatToolStripMenuItem"
        Me.StopChatToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.StopChatToolStripMenuItem.Text = "Stop chat connection"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FeaturesToolStripMenuItem
        '
        Me.FeaturesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChatLogToolStripMenuItem, Me.ClearChatToolStripMenuItem, Me.MathGamesToolStripMenuItem, Me.TypeToWinToolStripMenuItem, Me.AntiAFKToolStripMenuItem, Me.AutoRelogToolStripMenuItem, Me.EnableDisableAlertsToolStripMenuItem})
        Me.FeaturesToolStripMenuItem.Name = "FeaturesToolStripMenuItem"
        Me.FeaturesToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.FeaturesToolStripMenuItem.Text = "Features"
        '
        'SaveChatLogToolStripMenuItem
        '
        Me.SaveChatLogToolStripMenuItem.Name = "SaveChatLogToolStripMenuItem"
        Me.SaveChatLogToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SaveChatLogToolStripMenuItem.Text = "Save Chat log"
        '
        'ClearChatToolStripMenuItem
        '
        Me.ClearChatToolStripMenuItem.Name = "ClearChatToolStripMenuItem"
        Me.ClearChatToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ClearChatToolStripMenuItem.Text = "Clear chat"
        '
        'MathGamesToolStripMenuItem
        '
        Me.MathGamesToolStripMenuItem.CheckOnClick = True
        Me.MathGamesToolStripMenuItem.Name = "MathGamesToolStripMenuItem"
        Me.MathGamesToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.MathGamesToolStripMenuItem.Text = "Math games"
        '
        'TypeToWinToolStripMenuItem
        '
        Me.TypeToWinToolStripMenuItem.CheckOnClick = True
        Me.TypeToWinToolStripMenuItem.Name = "TypeToWinToolStripMenuItem"
        Me.TypeToWinToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.TypeToWinToolStripMenuItem.Text = "Type to win"
        '
        'AntiAFKToolStripMenuItem
        '
        Me.AntiAFKToolStripMenuItem.CheckOnClick = True
        Me.AntiAFKToolStripMenuItem.Name = "AntiAFKToolStripMenuItem"
        Me.AntiAFKToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AntiAFKToolStripMenuItem.Text = "AntiAFK"
        '
        'AutoRelogToolStripMenuItem
        '
        Me.AutoRelogToolStripMenuItem.CheckOnClick = True
        Me.AutoRelogToolStripMenuItem.Enabled = False
        Me.AutoRelogToolStripMenuItem.Name = "AutoRelogToolStripMenuItem"
        Me.AutoRelogToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AutoRelogToolStripMenuItem.Text = "Auto Relog"
        '
        'EnableDisableAlertsToolStripMenuItem
        '
        Me.EnableDisableAlertsToolStripMenuItem.CheckOnClick = True
        Me.EnableDisableAlertsToolStripMenuItem.Name = "EnableDisableAlertsToolStripMenuItem"
        Me.EnableDisableAlertsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.EnableDisableAlertsToolStripMenuItem.Text = "Enable/Disable Alerts"
        '
        'box_output
        '
        Me.box_output.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.box_output.BackColor = System.Drawing.Color.Black
        Me.box_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.box_output.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.box_output.ForeColor = System.Drawing.SystemColors.Highlight
        Me.box_output.HideSelection = False
        Me.box_output.Location = New System.Drawing.Point(12, 63)
        Me.box_output.Name = "box_output"
        Me.box_output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.box_output.Size = New System.Drawing.Size(949, 386)
        Me.box_output.TabIndex = 12
        Me.box_output.Text = ""
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox2.BackColor = System.Drawing.Color.Black
        Me.RichTextBox2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RichTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.RichTextBox2.HideSelection = False
        Me.RichTextBox2.Location = New System.Drawing.Point(727, 67)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(234, 382)
        Me.RichTextBox2.TabIndex = 13
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 26)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText
        Me.CloseToolStripMenuItem.ForeColor = System.Drawing.Color.Coral
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'TimerAntiAFK
        '
        Me.TimerAntiAFK.Interval = 150000
        '
        'Form1
        '
        Me.AcceptButton = Me.ButtonConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(966, 502)
        Me.Controls.Add(Me.box_output)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.RichTextBox2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minecraft Chat"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReloadAlertsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditAlertsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopChatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents box_output As RichTextBox
    Friend WithEvents FeaturesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MathGamesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TypeToWinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents SaveChatLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearChatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimerAntiAFK As Timer
    Friend WithEvents AntiAFKToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoRelogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnableDisableAlertsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
End Class
