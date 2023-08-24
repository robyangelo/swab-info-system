Imports MySql.Data.MySqlClient
Public Class Form7
    Dim connection As MySqlConnection

    Dim command As MySqlCommand
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim reader As MySqlDataReader

        Try

            connection.Open()

            Dim Query As String

            Query = "SELEct * FROM swabinfodb.patientinfotable where Patient_Code = '" & TextBox1.Text & "'"

            command = New MySqlCommand(Query, connection)
            reader = command.ExecuteReader
            While reader.Read
                Form8.TextBox1.Text = reader.GetString("Patient_Name")
                Form8.DateTimePicker1.Text = reader.GetDateTime("Patient_Birthdate")
                Form8.TextBox12.Text = reader.GetInt32("Patient_Age")
                Form8.ComboBox2.Text = reader.GetString("Patient_Sex")
                Form8.TextBox7.Text = reader.GetString("Patient_ContactNo")
                Form8.TextBox5.Text = reader.GetString("Patient_EmailAdd")
                Form8.TextBox4.Text = reader.GetString("Patient_Address")
                Form8.TextBox8.Text = reader.GetString("ResultsReceiver_Name")
                Form8.TextBox17.Text = reader.GetString("ResultsReceiver_ContactNo")
                Form8.TextBox16.Text = reader.GetString("ResultsReceiver_EmailAdd")

            End While

            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
        If Form8.TextBox1.Text = "" Then
            MsgBox("There is no existing record.", MsgBoxStyle.Critical, "Record Not Found!")
        Else
            MsgBox("Record found!", MsgBoxStyle.Information, "Search Patient Records")
            Me.Hide()
            Form8.Show()

        End If


    End Sub
End Class