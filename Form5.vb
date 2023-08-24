Imports MySql.Data.MySqlClient
Public Class Form5
    Dim connection As MySqlConnection

    Dim command As MySqlCommand
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim reader As MySqlDataReader

        Try

            connection.Open()

            Dim Query As String

            Query = "SELECT * FROM swabinfodb.patientinfotable"
            command = New MySqlCommand(Query, connection)
            reader = command.ExecuteReader
            While reader.Read
                Dim PCode = reader.GetString("Patient_Code")
                ComboBox1.Items.Add(PCode)

            End While


            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try

        Try

            connection.Open()

            Dim Query2 = "SELECT * FROM swabinfodb.specimentable"
            Dim command1 = New MySqlCommand(Query2, connection)
            Dim reader1 = command1.ExecuteReader
            While reader1.Read
                Dim SCode = reader1.GetString("Specimen_Code")
                ComboBox2.Items.Add(SCode)


            End While

            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim reader As MySqlDataReader

        Try

            connection.Open()

            Dim Query As String

            Query = "SELEct * FROM swabinfodb.specimentable where Specimen_Code = '" & ComboBox2.Text & "'"

            command = New MySqlCommand(Query, connection)
            reader = command.ExecuteReader
            While reader.Read
                TextBox1.Text = reader.GetString("Specimen_Name")
            End While

            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or
             TextBox2.Text = "" Or
            TextBox3.Text = "" Or
            ComboBox1.Text = "" Or
            ComboBox2.Text = "" Or
            DateTimePicker1.Text = "" Or
            DateTimePicker2.Text = "" Or
            DateTimePicker3.Text = "" Then
            MsgBox("Field cannot be blank.", MsgBoxStyle.Critical, "WARNING!")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
            Dim reader As MySqlDataReader

            Try

                connection.Open()

                Dim Query As String

                Query = "insert into swabinfodb.patientrecordtable (SwabDate, Patient_Code, Specimen_Code, Time_Collected, Transport_Temperature, SpecimenReceiver_Name,DateTime_Received) 
            VALUES ('" & DateTimePicker1.Text & "','" & ComboBox1.Text & "', '" & ComboBox2.Text & "', '" & DateTimePicker2.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & DateTimePicker3.Text & "')"

                command = New MySqlCommand(Query, connection)
                reader = command.ExecuteReader

                MsgBox("Patient Record has been successfully saved.", MsgBoxStyle.Information, "Specimen Information")


                connection.Close()



            Catch ex As MySqlException

                MessageBox.Show(ex.Message)


            Finally

                connection.Dispose()

            End Try
            Me.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = "DXC-0"
            ComboBox2.Text = "A0"
            DateTimePicker1.Text = ""
            DateTimePicker2.Text = ""
            DateTimePicker3.Text = ""
            Form4.Show()
            End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class