Imports MySql.Data.MySqlClient
Public Class Form8
    Dim connection As MySqlConnection

    Dim command As MySqlCommand
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form1.Show()
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
        Else
            Dim result As DialogResult = MessageBox.Show("Confirm update?",
                              "Update Patient Information",
                              MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                connection = New MySqlConnection
                connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
                Dim reader As MySqlDataReader

                Try

                    connection.Open()

                    Dim Query As String

                    Query = "update swabinfodb.patientinfotable set Patient_Name ='" & TextBox1.Text & "', Patient_Birthdate = '" & DateTimePicker1.Text & "', 
            Patient_Age = '" & TextBox12.Text & "', Patient_Sex =  '" & ComboBox2.Text & "',Patient_ContactNo =  '" & TextBox7.Text & "', Patient_EmailAdd = '" & TextBox5.Text & "', 
            Patient_Address = '" & TextBox4.Text & "', ResultsReceiver_Name = '" & TextBox8.Text & "', ResultsReceiver_ContactNo = '" & TextBox17.Text & "', ResultsReceiver_EmailAdd =  '" & TextBox16.Text & "' 
            where Patient_Code='" & Form7.TextBox1.Text & "'"

                    command = New MySqlCommand(Query, connection)
                    reader = command.ExecuteReader

                    MsgBox("Patient Information has been successfully updated.", MsgBoxStyle.Information, "Update")


                    connection.Close()



                Catch ex As MySqlException

                    MessageBox.Show(ex.Message)


                Finally

                    connection.Dispose()

                End Try

            End If
        End If
    End Sub
End Class