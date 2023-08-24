Imports MySql.Data.MySqlClient
Public Class Form4
    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form3.Show()


    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Dim Query2 = "SELECT * FROM swabinfodb.physicianinfotable"
            Dim command1 = New MySqlCommand(Query2, connection)
            Dim reader1 = command1.ExecuteReader
            While reader1.Read
                Dim PhysCode = reader1.GetString("Physician_Code")
                ComboBox2.Items.Add(PhysCode)


            End While

            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click

    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim reader As MySqlDataReader

        Try

            connection.Open()

            Dim Query As String

            Query = "SELEct * FROM swabinfodb.physicianinfotable where Physician_Code = '" & ComboBox2.Text & "'"

            command = New MySqlCommand(Query, connection)
            reader = Command.ExecuteReader
            While reader.Read
                TextBox1.Text = reader.GetString("Physician_Name")
                TextBox2.Text = reader.GetString("Physician_ContactNo")
                TextBox3.Text = reader.GetString("Pysician_EmailAdd")

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
            ComboBox2.Text = "" Then
            MsgBox("Field cannot be blank.", MsgBoxStyle.Critical, "WARNING!")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
            Dim reader As MySqlDataReader

            Try

                connection.Open()

                Dim Query As String

                Query = "update swabinfodb.patientrecordtable set Physician_Code ='" & ComboBox2.Text & "' where Patient_Code='" & ComboBox1.Text & "'"

                command = New MySqlCommand(Query, connection)
                reader = command.ExecuteReader

                MsgBox("A physician has been successfully assigned to the patient.", MsgBoxStyle.Information, "Assign Physician")

                connection.Close()



            Catch ex As MySqlException

                MessageBox.Show(ex.Message)


            Finally

                connection.Dispose()

            End Try
        End If
        Me.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = "DXC-0"
        ComboBox2.Text = "PHYS-A0"
        Form3.Show()

    End Sub
End Class