Public Class Form5

    Private Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case answer
            Case "tryupper"
                Label1.Text = "Моё число больше"
                PictureBox1.Image = My.Resources.up
            Case "trylower"
                Label1.Text = "Моё число меньше"
                PictureBox1.Image = My.Resources.down
            Case "verycold"
                Label1.Text = "Очень холодно!"
                PictureBox1.Image = My.Resources.temp1
            Case "cold"
                Label1.Text = "Холодно!"
                PictureBox1.Image = My.Resources.temp2
            Case "warm"
                Label1.Text = "Тепло!"
                PictureBox1.Image = My.Resources.temp3
            Case "verywarm"
                Label1.Text = "Очень жарко!!!"
                PictureBox1.Image = My.Resources.temp4
            Case "guessed"
                Randomize()
                Dim greetings = CInt(Int((Rnd() * 5) + 1))
                Select Case greetings
                    Case 1
                        Label1.Text = "Поздравляем! Вы угадали число """ & number & """ с " & tries - triesLeft + 1 & "-й попытки!"
                    Case 2
                        Label1.Text = "Класс! Вы угадали число """ & number & """ с " & tries - triesLeft + 1 & "-й попытки!"
                    Case 3
                        Label1.Text = "Отлично! Вы угадали число """ & number & """ с " & tries - triesLeft + 1 & "-й попытки!"
                    Case 4
                        Label1.Text = "Замечательно! Вы угадали число """ & number & """ с " & tries - triesLeft + 1 & "-й попытки!"
                    Case 5
                        Label1.Text = "Супер! Вы угадали число """ & number & """ с " & tries - triesLeft + 1 & "-й попытки!"
                End Select
                PictureBox1.Image = My.Resources.checkmark
            Case "gameover"
                Label1.Text = "Игра окончена!" & vbCrLf & "Моё число было " & number & "."
                PictureBox1.Image = My.Resources.game_over
        End Select
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class