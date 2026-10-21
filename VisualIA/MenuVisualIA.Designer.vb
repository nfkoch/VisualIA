<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViaulIA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtPregunta = New RichTextBox()
        btnConsultar = New Button()
        Label1 = New Label()
        txtSQL = New RichTextBox()
        DataGridView1 = New DataGridView()
        btnEjecutarSQL = New Button()
        rtbresumen = New RichTextBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtPregunta
        ' 
        txtPregunta.Location = New Point(135, 27)
        txtPregunta.Name = "txtPregunta"
        txtPregunta.Size = New Size(403, 145)
        txtPregunta.TabIndex = 0
        txtPregunta.Text = ""
        ' 
        ' btnConsultar
        ' 
        btnConsultar.Location = New Point(463, 188)
        btnConsultar.Name = "btnConsultar"
        btnConsultar.Size = New Size(75, 23)
        btnConsultar.TabIndex = 1
        btnConsultar.Text = "Consultar"
        btnConsultar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 15)
        Label1.TabIndex = 2
        Label1.Text = "QUE QUERES SABER?"
        ' 
        ' txtSQL
        ' 
        txtSQL.Location = New Point(135, 213)
        txtSQL.Name = "txtSQL"
        txtSQL.Size = New Size(403, 134)
        txtSQL.TabIndex = 3
        txtSQL.Text = ""
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(562, 27)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(414, 161)
        DataGridView1.TabIndex = 4
        ' 
        ' btnEjecutarSQL
        ' 
        btnEjecutarSQL.Location = New Point(463, 353)
        btnEjecutarSQL.Name = "btnEjecutarSQL"
        btnEjecutarSQL.Size = New Size(75, 23)
        btnEjecutarSQL.TabIndex = 5
        btnEjecutarSQL.Text = "Ejecutar"
        btnEjecutarSQL.UseVisualStyleBackColor = True
        ' 
        ' rtbresumen
        ' 
        rtbresumen.Location = New Point(585, 216)
        rtbresumen.Name = "rtbresumen"
        rtbresumen.Size = New Size(526, 131)
        rtbresumen.TabIndex = 6
        rtbresumen.Text = ""
        ' 
        ' ViaulIA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1327, 380)
        Controls.Add(rtbresumen)
        Controls.Add(btnEjecutarSQL)
        Controls.Add(DataGridView1)
        Controls.Add(txtSQL)
        Controls.Add(Label1)
        Controls.Add(btnConsultar)
        Controls.Add(txtPregunta)
        Name = "ViaulIA"
        Text = "VISUAL IA"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPregunta As RichTextBox
    Friend WithEvents btnConsultar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSQL As RichTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnEjecutarSQL As Button
    Friend WithEvents rtbresumen As RichTextBox

End Class
