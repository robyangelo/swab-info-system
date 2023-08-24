Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class Form3
    Dim connection As MySqlConnection

    Dim command As MySqlCommand
    Dim dt As New DataTable



    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SwabinfodbDataSet3.patientrecordtable' table. You can move, or remove it, as needed.
        Me.PatientrecordtableTableAdapter.Fill(Me.SwabinfodbDataSet3.patientrecordtable)
        DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
        Label4.Text = DataGridView1.RowCount
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim da As MySqlDataAdapter

        Try

            connection.Open()


            da = New MySqlDataAdapter("select SwabDate, Patient_Code, Specimen_Code, Physician_Code, Transport_Temperature, SpecimenReceiver_Name from swabinfodb.patientrecordtable 
            where Patient_Code like '" & TextBox1.Text & "'", connection)
            dt = New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim da As MySqlDataAdapter

        Try

            connection.Open()


            da = New MySqlDataAdapter("select SwabDate, Patient_Code, Specimen_Code, Physician_Code, Time_Collected, Transport_Temperature, SpecimenReceiver_Name, DateTime_Received from swabinfodb.patientrecordtable ", connection)
            dt = New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
        Label4.Text = DataGridView1.RowCount
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim da As MySqlDataAdapter

        Try

            connection.Open()


            da = New MySqlDataAdapter("select SwabDate, Patient_Code, Specimen_Code, Physician_Code, Transport_Temperature, SpecimenReceiver_Name from swabinfodb.patientrecordtable 
            where SwabDate like '" & DateTimePicker1.Text & "'", connection)
            dt = New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=robyboyyy020218;database=swabinfodb"
        Dim da As MySqlDataAdapter

        Try

            connection.Open()


            da = New MySqlDataAdapter("select SwabDate, Patient_Code, Specimen_Code, Physician_Code, Transport_Temperature, SpecimenReceiver_Name from swabinfodb.patientrecordtable 
            where Physician_Code like '" & ComboBox1.Text & "'", connection)
            dt = New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
            connection.Close()



        Catch ex As MySqlException

            MessageBox.Show(ex.Message)


        Finally

            connection.Dispose()

        End Try
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class