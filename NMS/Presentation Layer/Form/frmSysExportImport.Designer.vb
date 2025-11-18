<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysExportImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysExportImport))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboJenisTransaksi = New System.Windows.Forms.ComboBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnMasterUserExport = New System.Windows.Forms.Button()
        Me.btnMasterUserImport = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnNETmail = New System.Windows.Forms.Button()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSendEmail = New System.Windows.Forms.Button()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(230, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "To"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(122, 14)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(102, 21)
        Me.dtpDateFrom.TabIndex = 18
        Me.dtpDateFrom.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(257, 14)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateTo.TabIndex = 20
        Me.dtpDateTo.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Tanggal Akta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpDateFrom)
        Me.Panel1.Controls.Add(Me.dtpDateTo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(12, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(375, 96)
        Me.Panel1.TabIndex = 22
        Me.Panel1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(257, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Export "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboJenisTransaksi
        '
        Me.cboJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJenisTransaksi.FormattingEnabled = True
        Me.cboJenisTransaksi.Items.AddRange(New Object() {"Export", "Import"})
        Me.cboJenisTransaksi.Location = New System.Drawing.Point(12, 22)
        Me.cboJenisTransaksi.Name = "cboJenisTransaksi"
        Me.cboJenisTransaksi.Size = New System.Drawing.Size(121, 21)
        Me.cboJenisTransaksi.TabIndex = 23
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.Transparent
        Me.btnImport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(139, 23)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(19, 20)
        Me.btnImport.TabIndex = 103
        Me.btnImport.TabStop = False
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'btnMasterUserExport
        '
        Me.btnMasterUserExport.Location = New System.Drawing.Point(12, 169)
        Me.btnMasterUserExport.Name = "btnMasterUserExport"
        Me.btnMasterUserExport.Size = New System.Drawing.Size(146, 23)
        Me.btnMasterUserExport.TabIndex = 23
        Me.btnMasterUserExport.Text = "Master User Export"
        Me.btnMasterUserExport.UseVisualStyleBackColor = True
        '
        'btnMasterUserImport
        '
        Me.btnMasterUserImport.Location = New System.Drawing.Point(205, 169)
        Me.btnMasterUserImport.Name = "btnMasterUserImport"
        Me.btnMasterUserImport.Size = New System.Drawing.Size(146, 23)
        Me.btnMasterUserImport.TabIndex = 104
        Me.btnMasterUserImport.Text = "Master User Import"
        Me.btnMasterUserImport.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtPort)
        Me.Panel2.Controls.Add(Me.txtHost)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtFrom)
        Me.Panel2.Controls.Add(Me.btnNETmail)
        Me.Panel2.Controls.Add(Me.txtContent)
        Me.Panel2.Controls.Add(Me.txtSubject)
        Me.Panel2.Controls.Add(Me.txtTo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnSendEmail)
        Me.Panel2.Location = New System.Drawing.Point(429, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(632, 226)
        Me.Panel2.TabIndex = 105
        '
        'btnNETmail
        '
        Me.btnNETmail.Location = New System.Drawing.Point(124, 182)
        Me.btnNETmail.Name = "btnNETmail"
        Me.btnNETmail.Size = New System.Drawing.Size(103, 23)
        Me.btnNETmail.TabIndex = 7
        Me.btnNETmail.Text = "Email NET. Mail"
        Me.btnNETmail.UseVisualStyleBackColor = True
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(73, 70)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(323, 89)
        Me.txtContent.TabIndex = 6
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(73, 46)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(323, 21)
        Me.txtSubject.TabIndex = 5
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(73, 16)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(176, 21)
        Me.txtTo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Content"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Subject"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To"
        '
        'btnSendEmail
        '
        Me.btnSendEmail.Location = New System.Drawing.Point(15, 182)
        Me.btnSendEmail.Name = "btnSendEmail"
        Me.btnSendEmail.Size = New System.Drawing.Size(103, 23)
        Me.btnSendEmail.TabIndex = 0
        Me.btnSendEmail.Text = "Email Outlook"
        Me.btnSendEmail.UseVisualStyleBackColor = True
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(292, 16)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(212, 21)
        Me.txtFrom.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "From"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(435, 43)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(154, 21)
        Me.txtHost.TabIndex = 10
        Me.txtHost.Text = "email.musimmas.com"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(435, 70)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(68, 21)
        Me.txtPort.TabIndex = 11
        Me.txtPort.Text = "25"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(402, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Host"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(402, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Port"
        '
        'frmSysExportImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 290)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnMasterUserImport)
        Me.Controls.Add(Me.btnMasterUserExport)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.cboJenisTransaksi)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSysExportImport"
        Me.Text = "Export Import Data"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboJenisTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnMasterUserExport As System.Windows.Forms.Button
    Friend WithEvents btnMasterUserImport As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSendEmail As System.Windows.Forms.Button
    Friend WithEvents btnNETmail As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
End Class
