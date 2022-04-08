Module Settings
    Public minNumber As Integer = My.Settings.minNumber
    Public maxNumber As Integer = My.Settings.maxNumber
    Public tries As Integer = My.Settings.tries
    Public endless As Boolean = My.Settings.endless
    Public gamemode As Integer = My.Settings.gamemode
End Module

Module Variables
    Public number As Integer
    Public triesLeft As Integer
    Public answer As String
    Public button3action As String
End Module

Public Class Form1

#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    Button2.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    Button2.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    Button2.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub

#End Region

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Select()
        TextBox1.Text = ""
        triesLeft = tries
        Label1.Text = "Программа загадала число от " & minNumber & " до " & maxNumber & "." & vbCrLf & "Вам нужно его отгадать :)"
        Label2.Text = "Осталось попыток: " & triesLeft
        ProgressBar1.Value = triesLeft / tries * 100
        button3action = "Answer"
        If endless Then
            ProgressBar1.Visible = False
            Label2.Visible = False
        Else
            ProgressBar1.Visible = True
            Label2.Visible = True
        End If
        Randomize()
        number = CInt(Int((Rnd() * maxNumber - minNumber) + 1 + minNumber))
        Label3.Text = number
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Dim prompt = MsgBox("Выйти из игры?", MsgBoxStyle.OkCancel, "Угадай число")
        'If prompt = vbOK Then Me.Close()
        Form3.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Form2.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If button3action = "replay" Then
            triesLeft = tries
            Label1.Text = "Программа загадала число от " & minNumber & " до " & maxNumber & "." & vbCrLf & "Вам нужно его отгадать :)"
            Label2.Text = "Осталось попыток: " & triesLeft
            ProgressBar1.Value = triesLeft / tries * 100
            Randomize()
            number = CInt(Int((Rnd() * maxNumber - minNumber) + 1 + minNumber))
            Button3.Text = "Ответить"
            TextBox1.Visible = True
            Label1.Visible = True
            If Not endless Then
                ProgressBar1.Visible = True
                Label2.Visible = True
            End If
            Label2.Visible = True
            ProgressBar1.Visible = True
            button3action = ""
        Else
            Try
                If Int(TextBox1.Text) >= minNumber And Int(TextBox1.Text) <= maxNumber Then
                    If Int(TextBox1.Text) = number Then
                        answer = "guessed"
                        TextBox1.Text = ""
                        button3action = "replay"
                        Button3.Text = "Играть заново"
                        TextBox1.Visible = False
                        Label1.Visible = False
                        Label2.Visible = False
                        ProgressBar1.Visible = False
                        Form5.ShowDialog()
                    Else
                        If triesLeft <= 1 And Not endless Then
                            answer = "gameover"
                            TextBox1.Text = ""
                            button3action = "replay"
                            Button3.Text = "Играть заново"
                            TextBox1.Visible = False
                            Label1.Visible = False
                            Label2.Visible = False
                            ProgressBar1.Visible = False
                        Else
                            If gamemode = 0 Then
                                If Int(TextBox1.Text) < number Then
                                    answer = "tryupper"
                                ElseIf Int(TextBox1.Text) > number Then
                                    answer = "trylower"
                                End If
                            ElseIf gamemode = 1 Then
                                Dim diff As Integer = Int(TextBox1.Text) - number
                                If diff < 0 Then diff = diff * -1
                                If maxNumber - minNumber <= 10 Then
                                    If diff = 1 Then
                                        answer = "verywarm"
                                    ElseIf diff <= 2 Then
                                        answer = "warm"
                                    ElseIf diff <= 7 Then
                                        answer = "cold"
                                    Else
                                        answer = "verycold"
                                    End If
                                ElseIf maxNumber - minNumber <= 30 Then
                                    If diff = 1 Then
                                        answer = "verywarm"
                                    ElseIf diff <= 4 Then
                                        answer = "warm"
                                    ElseIf diff <= 8 Then
                                        answer = "cold"
                                    Else
                                        answer = "verycold"
                                    End If
                                ElseIf maxNumber - minNumber <= 60 Then
                                    If diff = 2 Then
                                        answer = "verywarm"
                                    ElseIf diff <= 7 Then
                                        answer = "warm"
                                    ElseIf diff <= 15 Then
                                        answer = "cold"
                                    Else
                                        answer = "verycold"
                                    End If
                                Else
                                    If diff = 3 Then
                                        answer = "verywarm"
                                    ElseIf diff <= 10 Then
                                        answer = "warm"
                                    ElseIf diff <= 25 Then
                                        answer = "cold"
                                    Else
                                        answer = "verycold"
                                    End If
                                End If
                            End If
                        End If
                        If Not endless Then
                            triesLeft = triesLeft - 1
                        End If
                        TextBox1.Text = ""
                        Form5.ShowDialog()
                    End If
                Else
                    MsgBox("Пожалуйста, введите число в заданном диапазоне или измените настройки игры", MsgBoxStyle.Information, "Некорректный ввод")
                End If
            Catch ex As Exception
                MsgBox("Пожалуйста, введите целое число", MsgBoxStyle.Information, "Некорректный ввод")
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = "Программа загадала число от " & minNumber & " до " & maxNumber & "." & vbCrLf & "Вам нужно его отгадать :)"
        Label2.Text = "Осталось попыток: " & triesLeft
        ProgressBar1.Value = triesLeft / tries * 100
    End Sub
End Class
