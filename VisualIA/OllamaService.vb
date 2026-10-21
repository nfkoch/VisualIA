Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
'CLASE QUE ITERACTUA CON OLLAMA PARA GENERAR SQL Y RESUMENES
Public Class OllamaService

    Private ReadOnly _url As String =
        "http://localhost:11434/api/generate"

    Public Async Function GenerarSQL(
        pregunta As String
    ) As Task(Of String)

        Dim prompt As String = $"
Eres un experto en SQL Server.

Tablas:

ACA VAN LAS TABLAS QUE VAS A UTILIZAR

Genera únicamente SQL Server válido.

Reglas:
- Responde solo SQL.
- No expliques nada.
- No uses markdown.
- No uses comentarios.
- La respuesta debe comenzar con SELECT.

Pregunta:
{pregunta}
"

        Dim body = New With {
            .model = "llama3.1:8b",
            .prompt = prompt,
            .stream = False
        }

        Using cliente As New HttpClient()
            cliente.Timeout = TimeSpan.FromMinutes(10)
            Dim json =
                JsonConvert.SerializeObject(body)

            Dim contenido =
                New StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json")

            Dim respuesta =
                Await cliente.PostAsync(
                    _url,
                    contenido)

            Dim resultado =
                Await respuesta.Content.ReadAsStringAsync()

            '  MessageBox.Show(resultado)
            Dim obj =
                JsonConvert.DeserializeObject(Of Object)(resultado)

            Return obj("response").ToString()

        End Using

    End Function

    Public Async Function GenerarResumen(
    preguntaOriginal As String,
    datos As String
) As Task(Of String)

        Dim prompt As String =
    $"
Eres un analista de negocio.

El usuario preguntó:

{preguntaOriginal}

Los resultados obtenidos fueron:

{datos}

Analiza los resultados.

Responde en español.
Utiliza lenguaje simple.
No muestres SQL.
No expliques aspectos técnicos.
Genera una conclusión para un gerente o usuario final.
"

        Dim body = New With {
            .model = "llama3.1:8b",
            .prompt = prompt,
            .stream = False
        }

        Using cliente As New HttpClient()

            cliente.Timeout = TimeSpan.FromMinutes(5)

            Dim json =
                Newtonsoft.Json.JsonConvert.SerializeObject(body)

            Dim contenido =
                New StringContent(
                    json,
                    Text.Encoding.UTF8,
                    "application/json")

            Dim respuesta =
                Await cliente.PostAsync(
                    "http://127.0.0.1:11434/api/generate",
                    contenido)

            Dim resultado =
                Await respuesta.Content.ReadAsStringAsync()

            Dim obj =
                Newtonsoft.Json.Linq.JObject.Parse(resultado)

            Return obj("response").ToString()

        End Using

    End Function

End Class