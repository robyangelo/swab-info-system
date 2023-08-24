Imports MySql.Data.MySqlClient
Public Class Form2

    Dim connection As MySqlConnection

    Dim command As MySqlCommand



    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If TextBox1.Text = "" Or
        DateTimePicker1.Text = "" Or
        TextBox12.Text = "" Or
        ComboBox2.Text = "" Or
        TextBox7.Text = "" Or
        TextBox5.Text = "" Or
        TextBox4.Text = "" Or
        TextBox8.Text = "" Or
        TextBox17.Text = "" Or
        TextBox16.Text = "" Then
            MsgBox("Field cannot be blank.", MsgBoxStyle.Critical, "WARNING!")

        ElseIf TextBox12.Text < 12 Or TextBox12.Text > 65 Then
            MsgBox("Valid age is 12 to 65 years old.", MsgBoxStyle.Critical, "WARNING!")

        Else

            connection = New MySqlConnection
            connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
            Dim reader As MySqlDataReader

            Try

                connection.Open()

                Dim Query As String

                Query = "insert into swabinfodb.patientinfotable (Patient_Code, Patient_Name, Patient_Birthdate, Patient_Age, Patient_Sex,Patient_ContactNo,Patient_EmailAdd, Patient_Address, ResultsReceiver_Name, ResultsReceiver_ContactNo, ResultsReceiver_EmailAdd ) 
            VALUES ('" & Label10.Text & "','" & TextBox1.Text & "', '" & DateTimePicker1.Text & "', '" & TextBox12.Text & "', '" & ComboBox2.Text & "', '" & TextBox7.Text & "', '" & TextBox5.Text & "', '" & TextBox4.Text & "', '" & TextBox8.Text & "', '" & TextBox17.Text & "', '" & TextBox16.Text & "')"

                command = New MySqlCommand(Query, connection)
                reader = command.ExecuteReader

                MsgBox("You have been successfully registered.", MsgBoxStyle.Information, "Register")

                connection.Close()



            Catch ex As MySqlException

                MessageBox.Show(ex.Message)


            Finally

                connection.Dispose()

            End Try



        End If
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"


        Try

            connection.Open()

            Dim Query1 As String

            Query1 = "SELECT COUNT(`Patient_Code`) FROM `patientinfotable`"
            Dim command1 = New MySqlCommand(Query1, connection)
            Label4.Text = command1.ExecuteScalar().ToString()
            Label5.Text = Val(Label4.Text) + 1
            Label10.Text = "DXC-" + Label5.Text
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try

        TextBox1.Text = ""
        DateTimePicker1.ResetText()
        TextBox12.Text = ""
        ComboBox2.Text = ""
        TextBox7.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        TextBox17.Text = ""
        TextBox16.Text = ""

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"


        Try

            connection.Open()

            Dim Query1 As String

            Query1 = "SELECT COUNT(`Patient_Code`) FROM `patientinfotable`"
            Dim command1 = New MySqlCommand(Query1, connection)
            Label4.Text = command1.ExecuteScalar().ToString()
            Label5.Text = Val(Label4.Text) + 1
            Label10.Text = "DXC-" + Label5.Text
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class