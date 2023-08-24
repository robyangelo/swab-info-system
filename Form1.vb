Public Class Form1
    Dim oldH As Integer = 217
    Dim oldW As Integer = 253
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MsgBox("Is it your first time registering?", MsgBoxStyle.YesNo, "Register")
        If result = DialogResult.Yes Then
            Me.Hide()
            Form2.Show()
        Else
            Me.Hide()
            Form7.Show()
        End If


    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        oldH = Button3.Height 'save the old values
        oldW = Button3.Width

        Button3.Height += 10 'grow the button size
        Button3.Width += 20

        Button3.Font = New Font("Century Gothic", 18, FontStyle.Bold)
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.Width = oldW 'restore the old size when mouse
        Button3.Height = oldH 'moves away from button

        Button3.Font = New Font("Century Gothic", 16, FontStyle.Regular)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        oldH = Button3.Height 'save the old values
        oldW = Button3.Width

        Button4.Height += 10 'grow the button size
        Button4.Width += 20

        Button4.Font = New Font("Century Gothic", 18, FontStyle.Bold)
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.Width = oldW 'restore the old size when mouse
        Button4.Height = oldH 'moves away from button

        Button4.Font = New Font("Century Gothic", 16, FontStyle.Regular)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim result As DialogResult = MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit Program")
        If result = DialogResult.Yes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub
End Class
