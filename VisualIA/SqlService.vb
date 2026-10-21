Imports System.Data.SqlClient

Public Class SqlService

    Private ReadOnly CadenaConexion As String =
        "Server=TU SERVIDOR ;" &
        "Database=TU BASE;" &
        "User Id=TU USUARIO;" &
        "Password=LA CLAVE;"

    Public Function EjecutarConsulta(
        sql As String
    ) As DataTable

        Dim dt As New DataTable

        Using cn As New SqlConnection(CadenaConexion)

            cn.Open()

            Dim da As New SqlDataAdapter(sql, cn)

            da.Fill(dt)

        End Using

        Return dt

    End Function



End Class