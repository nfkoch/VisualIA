Imports System.Data.SqlClient

Public Class ViaulIA
    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try

            Dim ollama As New OllamaService()

            Dim sql =
            Await ollama.GenerarSQL(
                txtPregunta.Text)

            txtSQL.Text = sql
            'aca controlamos que el SQL generado sea seguro y solo contenga SELECT
            If Not EsSQLSeguro(sql) Then

                MessageBox.Show(
                "SQL no permitido")

                Exit Sub

            End If

            'Dim db As New SqlService()

            'DataGridView1.DataSource = db.EjecutarConsulta(sql)

            Try

                'Dim sql As String = txtSQL.Text.Trim()
                'Dim ollama As New OllamaService()
                If String.IsNullOrWhiteSpace(sql) Then
                    MessageBox.Show("No hay SQL para ejecutar.")
                    Exit Sub
                End If

                ' Seguridad básica para no tener nada mas que un select
                Dim sqlUpper As String = sql.ToUpper()

                If sqlUpper.Contains("DELETE") OrElse
                   sqlUpper.Contains("UPDATE") OrElse
                   sqlUpper.Contains("INSERT") OrElse
                   sqlUpper.Contains("DROP") OrElse
                   sqlUpper.Contains("ALTER") OrElse
                   sqlUpper.Contains("TRUNCATE") Then

                    MessageBox.Show("Solo se permiten consultas SELECT")
                    Exit Sub

                End If

                If Not sqlUpper.StartsWith("SELECT") Then
                    MessageBox.Show("La consulta debe comenzar con SELECT")
                    Exit Sub
                End If

                Dim dt As New DataTable()

                Using cn As New SqlConnection(
                            "Server=ServdiorSQL ;" &
            "Database=TU BASE;" &
            "User Id=TU USUARIO;" &
            "Password=LA CLAVE;"
    )

                    cn.Open()

                    Using da As New SqlDataAdapter(sql, cn)

                        da.SelectCommand.CommandTimeout = 300
                        da.Fill(dt)

                    End Using

                End Using

                DataGridView1.DataSource = dt
                Dim textoResultados As String = DataTableATexto(dt)


                Dim resumen As String = Await ollama.GenerarResumen(txtPregunta.Text, textoResultados)
                rtbresumen.Text = resumen

                MessageBox.Show(
                    $"Se encontraron {dt.Rows.Count} registros.")

            Catch ex As Exception

                MessageBox.Show(ex.Message)

            End Try

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Async Sub btnEjecutarSQL_Click(sender As Object, e As EventArgs) Handles btnEjecutarSQL.Click

    End Sub
    'controlamos que el SQL generado sea seguro y solo contenga SELECT
    Private Function EsSQLSeguro(
  sql As String
) As Boolean

        Dim texto =
            sql.ToUpper()

        If texto.Contains("DELETE") Then Return False
        If texto.Contains("UPDATE") Then Return False
        If texto.Contains("INSERT") Then Return False
        If texto.Contains("DROP") Then Return False
        If texto.Contains("ALTER") Then Return False
        If texto.Contains("TRUNCATE") Then Return False

        Return texto.Trim().StartsWith("SELECT")

    End Function

    Private Function DataTableATexto(
    dt As DataTable
) As String

        Dim sb As New System.Text.StringBuilder()

        For Each row As DataRow In dt.Rows

            For Each col As DataColumn In dt.Columns

                sb.Append(col.ColumnName)
                sb.Append(": ")
                sb.Append(row(col.ColumnName).ToString())
                sb.Append(" | ")

            Next

            sb.AppendLine()

        Next

        Return sb.ToString()

    End Function

End Class
