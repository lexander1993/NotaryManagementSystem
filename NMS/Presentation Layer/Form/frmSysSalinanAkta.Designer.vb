<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysSalinanAkta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysSalinanAkta))
        Me.pbSearch = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtPrintOutLocation = New System.Windows.Forms.TextBox()
        Me.CachedrptPrintAkta1 = New NMS.CachedrptPrintAkta()
        Me.btn30lines = New System.Windows.Forms.Button()
        Me.btnSalinanAkta = New System.Windows.Forms.Button()
        Me.btnCekDirektory = New System.Windows.Forms.Button()
        Me.txtCekDirektori = New System.Windows.Forms.TextBox()
        CType(Me.pbSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbSearch
        '
        Me.pbSearch.Image = CType(resources.GetObject("pbSearch.Image"), System.Drawing.Image)
        Me.pbSearch.Location = New System.Drawing.Point(23, 70)
        Me.pbSearch.Name = "pbSearch"
        Me.pbSearch.Size = New System.Drawing.Size(113, 116)
        Me.pbSearch.TabIndex = 4
        Me.pbSearch.TabStop = False
        Me.pbSearch.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtPrintOutLocation
        '
        Me.txtPrintOutLocation.Location = New System.Drawing.Point(3, 86)
        Me.txtPrintOutLocation.Name = "txtPrintOutLocation"
        Me.txtPrintOutLocation.Size = New System.Drawing.Size(26, 20)
        Me.txtPrintOutLocation.TabIndex = 130
        Me.txtPrintOutLocation.Visible = False
        '
        'btn30lines
        '
        Me.btn30lines.Location = New System.Drawing.Point(41, 41)
        Me.btn30lines.Name = "btn30lines"
        Me.btn30lines.Size = New System.Drawing.Size(101, 23)
        Me.btn30lines.TabIndex = 131
        Me.btn30lines.Text = "Set Akta 30 Baris"
        Me.btn30lines.UseVisualStyleBackColor = True
        '
        'btnSalinanAkta
        '
        Me.btnSalinanAkta.Location = New System.Drawing.Point(41, 12)
        Me.btnSalinanAkta.Name = "btnSalinanAkta"
        Me.btnSalinanAkta.Size = New System.Drawing.Size(101, 23)
        Me.btnSalinanAkta.TabIndex = 132
        Me.btnSalinanAkta.Text = "Buat Salinan Akta"
        Me.btnSalinanAkta.UseVisualStyleBackColor = True
        '
        'btnCekDirektory
        '
        Me.btnCekDirektory.Location = New System.Drawing.Point(178, 12)
        Me.btnCekDirektory.Name = "btnCekDirektory"
        Me.btnCekDirektory.Size = New System.Drawing.Size(101, 23)
        Me.btnCekDirektory.TabIndex = 133
        Me.btnCekDirektory.Text = "Cek Direktori"
        Me.btnCekDirektory.UseVisualStyleBackColor = True
        '
        'txtCekDirektori
        '
        Me.txtCekDirektori.Location = New System.Drawing.Point(178, 41)
        Me.txtCekDirektori.Name = "txtCekDirektori"
        Me.txtCekDirektori.Size = New System.Drawing.Size(100, 20)
        Me.txtCekDirektori.TabIndex = 134
        '
        'frmSysSalinanAkta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(302, 71)
        Me.Controls.Add(Me.txtCekDirektori)
        Me.Controls.Add(Me.btnCekDirektory)
        Me.Controls.Add(Me.btnSalinanAkta)
        Me.Controls.Add(Me.btn30lines)
        Me.Controls.Add(Me.txtPrintOutLocation)
        Me.Controls.Add(Me.pbSearch)
        Me.Name = "frmSysSalinanAkta"
        Me.Text = "Salinan Akta"
        CType(Me.pbSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbSearch As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtPrintOutLocation As System.Windows.Forms.TextBox
    Friend WithEvents CachedrptPrintAkta1 As NMS.CachedrptPrintAkta
    Friend WithEvents btn30lines As System.Windows.Forms.Button
    Friend WithEvents btnSalinanAkta As System.Windows.Forms.Button
    Friend WithEvents btnCekDirektory As System.Windows.Forms.Button
    Friend WithEvents txtCekDirektori As System.Windows.Forms.TextBox
End Class
