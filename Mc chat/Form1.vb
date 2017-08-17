Imports AMCSAPI
Imports AMCSAPI.InfoStructures
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Linq

Public Class Form1

#Region "Variables"

    Dim WithEvents mc As Server
    Dim CmdBuffer As LinkedList(Of String) = New LinkedList(Of String)()
    Dim AlertList As List(Of String) = New List(Of String)
    Private InternalCommandList As New List(Of String)
    Dim buf As String

    Private Property AlertState As Boolean
    Private Property MathGame As Boolean
    Private Property MathResult As String
    Private Property TypeResult As String
    Private Property TypeToWin As Boolean
    Private Property AntiAFk As Boolean
    Private Property AutoRelog As Boolean

    Private Const SB_VERT As Integer = &H1
    Private Const SIF_RANGE As Integer = &H1
    Private Const SIF_PAGE As Integer = &H2
    Private Const SIF_POS As Integer = &H4

    <DllImport("user32.dll", EntryPoint:="GetScrollInfo")>
    Private Shared Function GetScrollInfo(ByVal hwnd As IntPtr, ByVal nBar As Integer, ByRef lpsi As SCROLLINFO) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure SCROLLINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As Integer
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure

#End Region

    Private Sub mc_chatMessageReceived(e As ChatReceivedEventArgs) Handles mc.chatMessageReceived
        If AlertState = True Then
            MsgAlert(e.message)
        End If


        If MathGame = True Then
            If e.message.Contains("GAMES Solve") Then
                Dim t As String = e.message.Substring(11, 7)
                MathResult = New DataTable().Compute(t, Nothing)
            End If
        End If

        If TypeToWin = True Then
            If e.message.Contains("GAMES Type") Then
                Dim st As String() = e.message.Split("""")
                TypeResult = st(1)
            End If
        End If

        '//Display the message formated
        printstring(e.messageRaw)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text.Length > 0 Then
                If TextBox1.Text.Length > 0 Then
                    If TextBox1.Text.Chars(0) = "/" Then
                        box_output.AppendText("> " + TextBox1.Text + vbNewLine)
                        mc.sendChatMessage(TextBox1.Text)
                    ElseIf TextBox1.Text.Chars(0) = "!" Then
                        InternalCommand(TextBox1.Text)
                    Else
                        mc.sendChatMessage(TextBox1.Text)
                    End If
                    CmdBuffer.AddLast(TextBox1.Text)
                    TextBox1.Text = ""
                End If
            End If
        Catch ex As Exception
            If ex.Message.Contains("Object reference") Then
                box_output.AppendText("Not connected to the server" + vbNewLine)
            ElseIf ex.Message.Contains("not currently connected") Then
                box_output.AppendText("Connection to the server lost." + vbNewLine + "Type !reconect to connect again.")
            Else
                box_output.AppendText(ex.Message)
            End If
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If TextBox1.Text.Length > 0 Then
                    If TextBox1.Text.Chars(0) = "/" Then
                        box_output.AppendText("> " + TextBox1.Text + vbNewLine)
                        mc.sendChatMessage(TextBox1.Text)
                    ElseIf TextBox1.Text.Chars(0) = "!" Then
                        InternalCommand(TextBox1.Text)
                    Else
                        mc.sendChatMessage(TextBox1.Text)
                    End If
                    CmdBuffer.AddLast(TextBox1.Text)
                    TextBox1.Text = ""
                End If
                e.SuppressKeyPress = True
                e.Handled = True

            ElseIf e.KeyCode = Keys.Up Then
                If CmdBuffer.Count > 0 Then
                    TextBox1.Text = CmdBuffer.Last.Value
                    CmdBuffer.AddFirst(TextBox1.Text)
                    CmdBuffer.RemoveLast()
                    TextBox1.Select(0, TextBox1.Text.Length)
                End If
                e.Handled = True
            ElseIf e.KeyCode = Keys.Down Then
                If CmdBuffer.Count > 0 Then
                    TextBox1.Text = CmdBuffer.First.Value
                    CmdBuffer.AddLast(TextBox1.Text)
                    CmdBuffer.RemoveFirst()
                    TextBox1.Select(0, TextBox1.Text.Length)
                ElseIf e.KeyCode = Keys.Escape Then
                    TextBox1.Text = ""
                    e.Handled = True

                End If

            End If

        Catch ex As Exception
            If ex.Message.Contains("Object reference") Then
                box_output.AppendText("Not connected to the server" + vbNewLine)
            ElseIf ex.Message.Contains("not currently connected") Then
                box_output.AppendText("Connection to the server lost." + vbNewLine + "Type !reconect to connect again.")
            Else
                box_output.AppendText(ex.Message)
            End If
        End Try
    End Sub

    Private Sub ClientConnect()
        Try
            If ComboBox1.Text.Length > 0 Then
                mc = New Server(ComboBox1.Text, 25565)
                mc.authenticate(LoginForm.usernameProperty, LoginForm.PassProperty)
                mc.startChatConnection()

                My.Settings.lastServer = ComboBox1.Text
                Me.AcceptButton = Nothing

                Dim b As Boolean
                For Each a As String In My.Settings.ServerList
                    If a = ComboBox1.Text Then
                        b = True
                        Exit For
                    End If
                Next

                If b = False Then My.Settings.ServerList.Add(ComboBox1.Text)
            End If
        Catch ex As Exception
            Me.Text = ex.Message
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End Try

        My.Settings.Save()
        ButtonConnect.Enabled = False
    End Sub
    Private Sub ButtonConnect_Click_1(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        ClientConnect()
    End Sub

    Private Sub LoadAlerts()
        AlertList.Clear()
        Dim l As String() = File.ReadAllLines(Application.StartupPath + "/configs/alerts.txt")

        For Each alert As String In l
            AlertList.Add(alert)
        Next
    End Sub

    Private Sub LoadInternalCommands()
        InternalCommandList.Clear()
        Dim list As String() = File.ReadAllLines(Application.StartupPath + "/configs/InternalCommands.txt")

        For Each c As String In list
            InternalCommandList.Add(c)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath + "/configs/alerts.txt") Then
            LoadAlerts()
        Else
            Directory.CreateDirectory(Application.StartupPath + "/configs")
            Dim f As FileStream

            f = File.Create(Application.StartupPath + "/configs/alerts.txt")
            'adding -> alert
            Dim alertPreset As String = "-> me" + vbNewLine + "Yourname" + vbNewLine + "whispers"
            Dim b As Byte() = System.Text.Encoding.UTF8.GetBytes(alertPreset)
            f.Write(b, 0, b.Length)
            f.Close()

            LoadAlerts()
        End If

        If My.Settings.Math = True Then
            MathGame = True
            MathGamesToolStripMenuItem.Checked = True
        End If

        If My.Settings.Type = True Then
            TypeToWin = True
            TypeToWinToolStripMenuItem.Checked = True
        End If

        If My.Settings.AntiAFk = True Then
            AntiAFk = True
            AntiAFKToolStripMenuItem.Checked = True
        End If

        If My.Settings.Alerts = True Then
            AlertState = True
            EnableDisableAlertsToolStripMenuItem.Checked = True
        End If

        If File.Exists(Application.StartupPath + "/configs/InternalCommands.txt") Then
            LoadInternalCommands()
        Else
            Dim f As FileStream = File.Create(Application.StartupPath + "/configs/InternalCommands.txt")
            Dim b As Byte() = System.Text.Encoding.UTF8.GetBytes(My.Resources.InternalCommands, 0, My.Resources.InternalCommands.Length)
            f.Write(b, 0, b.Length)
            f.Close()

            LoadInternalCommands()
        End If
        LoadServers()
        box_output.AppendText("Type !help to see a list of the available commands!" + vbNewLine)
    End Sub


    Private Sub LoadServers()
        ComboBox1.Items.Clear()

        For Each s As String In My.Settings.ServerList
            ComboBox1.Items.Add(s)
        Next

        ComboBox1.Text = My.Settings.lastServer
    End Sub
    Private Sub StopChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopChatToolStripMenuItem.Click
        mc.stopChatConnection()
        ButtonConnect.Enabled = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        mc.stopChatConnection()
        End
    End Sub

    Private Sub EditAlertsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAlertsToolStripMenuItem.Click
        Dim p As New Process()
        p.StartInfo.FileName = Application.StartupPath + "\configs\alerts.txt"
        p.Start()
    End Sub

    Private Sub ReloadAlertsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadAlertsToolStripMenuItem.Click
        LoadAlerts()
        box_output.AppendText("Alerts reloaded!" + vbNewLine)
    End Sub

    Private Sub SaveChatLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChatLogToolStripMenuItem.Click
        Dim name As String = "log-" + DateTime.Now.ToString("ddMMMyyyy") & "_" & DateTime.Now.ToString("HHmmss") + ".txt"

        If Not Directory.Exists(Application.StartupPath + "\ChatLogs") Then Directory.CreateDirectory(Application.StartupPath + "\ChatLogs")

        Dim f As FileStream = File.Create(Application.StartupPath + "\ChatLogs\" + name)
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(box_output.Text)
        f.Write(byt, 0, byt.Length)
        f.Close()

        box_output.Text = Nothing
        box_output.AppendText("Chat log saved to file!" + vbNewLine)
        box_output.AppendText("File location:" + name + vbNewLine)
    End Sub

    Private Sub ClearChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearChatToolStripMenuItem.Click
        box_output.Text = Nothing
    End Sub

    Private Sub MathGamesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MathGamesToolStripMenuItem.Click
        If MathGame = True Then
            MathGame = False
            My.Settings.Math = False
            box_output.AppendText("Math bot disabled!" + vbNewLine)
        Else
            MathGame = True
            My.Settings.Math = True
            box_output.AppendText("Math bot enabled!" + vbNewLine)
        End If
        My.Settings.Save()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles box_output.TextChanged
        If MathResult <> Nothing Then
            Threading.Thread.Sleep(1400)
            mc.sendChatMessage(MathResult)
            MathResult = Nothing
        End If

        If TypeResult <> Nothing Then
            Select Case TypeResult.Length
                Case 6 To 8
                    Threading.Thread.Sleep(4000)
                    mc.sendChatMessage(TypeResult)
                    TypeResult = Nothing
                    Exit Select
                Case <= 5
                    Threading.Thread.Sleep(2000)
                    mc.sendChatMessage(TypeResult)
                    TypeResult = Nothing
                    Exit Select
                Case 9 To 10
                    Threading.Thread.Sleep(4800)
                    mc.sendChatMessage(TypeResult)
                    TypeResult = Nothing
                    Exit Select
                Case 11 To 12
                    Threading.Thread.Sleep(5200)
                    mc.sendChatMessage(TypeResult)
                    TypeResult = Nothing
                    Exit Select
                Case > 12
                    Threading.Thread.Sleep(6000)
                    mc.sendChatMessage(TypeResult)
                    TypeResult = Nothing
                    Exit Select
            End Select
        End If

        If box_output.Lines.Count() > 75 Then
            box_output.Select(0, box_output.GetFirstCharIndexFromLine(1))
            box_output.SelectedText = ""
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            mc = Nothing
            Application.Exit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TypeToWinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypeToWinToolStripMenuItem.Click
        If TypeToWin = True Then
            TypeToWin = False
            My.Settings.Type = False
            box_output.AppendText("Type to win bot disabled!" + vbNewLine)
        Else
            TypeToWin = True
            My.Settings.Type = True
            box_output.AppendText("Type to win bot enabled!" + vbNewLine)
        End If
        My.Settings.Save()
    End Sub

    Private Sub AppendTextBox(box As RichTextBox, text As String, color As Color, style As FontStyle)
        If InvokeRequired Then
            Me.Invoke(New Action(Of RichTextBox, String, Color, FontStyle)(AddressOf AppendTextBox), New Object() {box, text, color, style})
        Else
            box.SelectionStart = box.TextLength
            box.SelectionLength = 0
            box.SelectionColor = color
            box.SelectionFont = New Font(box.Font, style)
            box.AppendText(text)
            box.SelectionColor = box.ForeColor
            box.SelectionStart = box.Text.Length
            ' box.ScrollToCaret()
        End If
    End Sub

    Delegate Sub AlertCallBack(t As String, c As Color)
    Public Sub SendAlert(t As String, c As Color)
        If RichTextBox2.InvokeRequired Then
            Dim d As New AlertCallBack(AddressOf SendAlert)
            RichTextBox2.Invoke(d, New Object() {t, c})
        Else

            If RichTextBox2.Visible = False Then
                box_output.Size = New Size(709, 386)
                RichTextBox2.Visible = True
            End If
            RichTextBox2.SelectionStart = RichTextBox2.TextLength
            RichTextBox2.SelectionLength = 0
            RichTextBox2.SelectionColor = c
            RichTextBox2.AppendText(t)
            RichTextBox2.SelectionColor = RichTextBox2.ForeColor
            RichTextBox2.SelectionStart = RichTextBox2.Text.Length
        End If
    End Sub

    Private Sub MsgAlert(s As String)
        For Each a As String In AlertList
            If s.Contains(a) Then
                My.Computer.Audio.Play(My.Resources._20d06589bd5ab81a73989bdac8ca59ecd4d66932, AudioPlayMode.Background)

                SendAlert("Triggered alert: " + a + " at " + Date.Now.ToShortTimeString + vbNewLine, Color.Red)
                SendAlert("Message: " + s + vbNewLine, Color.Green)
                Exit For
            End If
        Next
    End Sub

    Private Sub printstring(str As String)
        If Not [String].IsNullOrEmpty(str) Then
            Dim color__1 As Color = Color.Black
            Dim style As FontStyle = FontStyle.Regular
            Dim subs As String() = str.Split("§"c)
            If subs(0).Length > 0 Then
                AppendTextBox(box_output, subs(0), Color.WhiteSmoke, FontStyle.Regular)
            End If
            For i As Integer = 1 To subs.Length - 1
                If subs(i).Length > 0 Then
                    If subs(i).Length > 1 Then
                        Select Case subs(i)(0)
                        'Font colors
                            Case "0"c
                                color__1 = Color.DarkSlateGray
                                Exit Select
                            Case "1"c
                                color__1 = Color.Blue
                                Exit Select
                            Case "2"c
                                color__1 = Color.ForestGreen
                                Exit Select
                            Case "3"c
                                color__1 = Color.MediumTurquoise
                                Exit Select
                            Case "4"c
                                color__1 = Color.Crimson
                                Exit Select
                            Case "5"c
                                color__1 = Color.DarkMagenta
                                Exit Select
                            Case "6"c
                                color__1 = Color.Gold
                                Exit Select
                            Case "7"c
                                color__1 = Color.DimGray
                                Exit Select
                            Case "8"c
                                color__1 = Color.Gray
                                Exit Select
                            Case "9"c
                                color__1 = Color.CornflowerBlue
                                Exit Select
                            Case "a"c
                                color__1 = Color.LimeGreen
                                Exit Select
                            Case "b"c
                                color__1 = Color.Cyan
                                Exit Select
                            Case "c"c
                                color__1 = Color.DeepPink
                                Exit Select
                            Case "d"c
                                color__1 = Color.Magenta
                                Exit Select
                            Case "e"c
                                color__1 = Color.Yellow
                                Exit Select

                        'White on white = invisible so use gray instead
                            Case "f"c
                                color__1 = Color.LightGray
                                Exit Select

                        'Font styles. Can use several styles eg Bold + Underline
                            Case "l"c
                                style = style Or FontStyle.Bold
                                Exit Select
                            Case "m"c
                                style = style Or FontStyle.Strikeout
                                Exit Select
                            Case "n"c
                                style = style Or FontStyle.Underline
                                Exit Select
                            Case "o"c
                                style = style Or FontStyle.Italic
                                Exit Select

                        'Reset font color & style
                            Case "r"c
                                color__1 = Color.LightGray
                                style = FontStyle.Regular
                                Exit Select
                        End Select

                        AppendTextBox(box_output, subs(i).Substring(1, subs(i).Length - 1), color__1, style)
                    End If
                End If
            Next
            AppendTextBox(box_output, vbLf, Color.DarkSlateGray, FontStyle.Regular)
        End If
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    Private Sub TimerAntiAFK_Tick(sender As Object, e As EventArgs) Handles TimerAntiAFK.Tick
        Try
            mc.sendChatMessage("/ping")
            box_output.AppendText("cmd: /ping" + vbNewLine)
        Catch ex As Exception
            If ex.Message.Contains("Object reference") Then
                box_output.AppendText("Not connected to the server" + vbNewLine)
            ElseIf ex.Message.Contains("not currently connected") Then
                box_output.AppendText("Connection to the server lost." + vbNewLine + "Type !reconect to connect again.")
            Else
                box_output.AppendText(ex.Message)
            End If
        End Try
    End Sub

    Private Sub AntiAFKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AntiAFKToolStripMenuItem.Click
        If AntiAFk = False Then
            AntiAFk = True
            My.Settings.AntiAFk = True
            TimerAntiAFK.Start()
            box_output.AppendText("AntiAFk enabled!" + vbNewLine)
        Else
            AntiAFk = False
            My.Settings.AntiAFk = False
            TimerAntiAFK.Stop()
            box_output.AppendText("AntiAFK disabled!" + vbNewLine)
        End If
        My.Settings.Save()
    End Sub

    Private Sub InternalCommand(command As String)
        ' box_output.AppendText("Internal command: " + TextBox1.Text + vbNewLine)
        Select Case command

            Case "!help"
                For Each s As String In InternalCommandList
                    box_output.AppendText(s + vbNewLine)
                    box_output.SelectionStart = box_output.Text.Length
                    ' box_output.ScrollToCaret()
                Next
            Case "!reconnect"
                ClientConnect()
            Case "!autorelog"

            Case "!antiafk"
                AntiAFKToolStripMenuItem.PerformClick()
            Case "!math"
                MathGamesToolStripMenuItem.PerformClick()
            Case "!type"
                TypeToWinToolStripMenuItem.PerformClick()
            Case "!quit"
                mc = Nothing
                Application.Exit()
            Case "!clearchat"
                ClearChatToolStripMenuItem.PerformClick()
            Case "!alerts"
                EnableDisableAlertsToolStripMenuItem.PerformClick()
            Case Else
                box_output.AppendText("Unknow command!" + vbNewLine)
        End Select

    End Sub

    Private Sub EnableDisableAlertsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableDisableAlertsToolStripMenuItem.Click
        If AlertState = False Then
            AlertState = True
            My.Settings.Alerts = True
            box_output.AppendText("Alerts enabled!" + vbNewLine)
        Else
            AlertState = False
            My.Settings.Alerts = False
            box_output.AppendText("Alerts disabled!" + vbNewLine)
        End If
        My.Settings.Save()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        RichTextBox2.Visible = False
        box_output.Size = New Size(949, 386)
    End Sub
End Class
