Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = tries
        NumericUpDown2.Value = minNumber
        NumericUpDown3.Value = maxNumber
        CheckBox1.Checked = endless
        Select Case gamemode
            Case 0
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Case 1
                RadioButton1.Checked = False
                RadioButton2.Checked = True
        End Select
        If CheckBox1.Checked = True Then
            NumericUpDown1.Enabled = False
        Else
            NumericUpDown1.Enabled = True
        End If
        Button2.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            NumericUpDown1.Enabled = False
        Else
            NumericUpDown1.Enabled = True
        End If

        Button2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If NumericUpDown3.Value - NumericUpDown2.Value > 0 Then
            tries = NumericUpDown1.Value
            minNumber = NumericUpDown2.Value
            maxNumber = NumericUpDown3.Value
            endless = CheckBox1.Checked
            If RadioButton1.Checked Then gamemode = 0
            If RadioButton2.Checked Then gamemode = 1
            If endless Then
                Form1.ProgressBar1.Visible = False
                Form1.Label2.Visible = False
            Else
                Form1.ProgressBar1.Visible = True
                Form1.Label2.Visible = True
            End If

            My.Settings.minNumber = minNumber
            My.Settings.maxNumber = maxNumber
            My.Settings.tries = tries
            My.Settings.endless = endless
            My.Settings.gamemode = gamemode
            My.Settings.Save()

            Form1.TextBox1.Text = ""
            triesLeft = tries
            Form1.Label1.Text = "Программа загадала число от " & minNumber & " до " & maxNumber & "." & vbCrLf & "Вам нужно его отгадать :)"
            Form1.Label2.Text = "Осталось попыток: " & triesLeft
            Form1.ProgressBar1.Value = triesLeft / tries * 100
            Randomize()
            number = CInt(Int((Rnd() * maxNumber - minNumber) + 1 + minNumber))

            Me.Close()
        Else
            If NumericUpDown3.Value < NumericUpDown2.Value Then
                MsgBox("Максимальное число должно быть больше минимального", MsgBoxStyle.Information, "Недопустимые значения")
            Else
                MsgBox("Максимальное число должно отличаться от минимального", MsgBoxStyle.Information, "Недопустимые значения")
            End If
        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Button2.Enabled = True
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        Button2.Enabled = True
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        Button2.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Process.Start("https://vk.com/artez0n")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form4.ShowDialog()
    End Sub
End Class