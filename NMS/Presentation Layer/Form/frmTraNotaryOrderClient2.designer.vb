<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraNotaryOrderClient2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraNotaryOrderClient2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPekerjaan = New System.Windows.Forms.ComboBox()
        Me.txtTglLahirStr = New System.Windows.Forms.TextBox()
        Me.cboTitle = New System.Windows.Forms.ComboBox()
        Me.txtNoNPWP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPekerjaan = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpTglLahir = New System.Windows.Forms.DateTimePicker()
        Me.txtTempatLahir = New System.Windows.Forms.TextBox()
        Me.txtKet = New System.Windows.Forms.TextBox()
        Me.txtNoHp = New System.Windows.Forms.TextBox()
        Me.txtNoTelepon = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNegara = New System.Windows.Forms.TextBox()
        Me.cboWargaNegara = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboJenisID = New System.Windows.Forms.ComboBox()
        Me.txtNoID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnID = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarItemAdd = New System.Windows.Forms.ToolBarButton()
        Me.BarItemClose = New System.Windows.Forms.ToolBarButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 444)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtPekerjaan)
        Me.Panel1.Controls.Add(Me.txtTglLahirStr)
        Me.Panel1.Controls.Add(Me.cboTitle)
        Me.Panel1.Controls.Add(Me.txtNoNPWP)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblPekerjaan)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtpTglLahir)
        Me.Panel1.Controls.Add(Me.txtTempatLahir)
        Me.Panel1.Controls.Add(Me.txtKet)
        Me.Panel1.Controls.Add(Me.txtNoHp)
        Me.Panel1.Controls.Add(Me.txtNoTelepon)
        Me.Panel1.Controls.Add(Me.txtAlamat)
        Me.Panel1.Controls.Add(Me.txtNama)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNegara)
        Me.Panel1.Controls.Add(Me.cboWargaNegara)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cboJenisID)
        Me.Panel1.Controls.Add(Me.txtNoID)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnID)
        Me.Panel1.Location = New System.Drawing.Point(6, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 398)
        Me.Panel1.TabIndex = 2
        '
        'txtPekerjaan
        '
        Me.txtPekerjaan.FormattingEnabled = True
        Me.txtPekerjaan.Items.AddRange(New Object() {"Belum / Tidak Bekerja", "Mengurus Rumah Tangga", "Pelajar / Mahasiswa", "Pensiunan", "Pegawai Negeri Sipil (PNS)", "Kepolisian RI", "Petani / Pekebun", "Karyawan Swasta", "Karyawan BUMN", "Dokter", "Pedagang", "Wiraswasta"})
        Me.txtPekerjaan.Location = New System.Drawing.Point(194, 223)
        Me.txtPekerjaan.Name = "txtPekerjaan"
        Me.txtPekerjaan.Size = New System.Drawing.Size(302, 21)
        Me.txtPekerjaan.TabIndex = 74
        '
        'txtTglLahirStr
        '
        Me.txtTglLahirStr.Location = New System.Drawing.Point(402, 133)
        Me.txtTglLahirStr.Name = "txtTglLahirStr"
        Me.txtTglLahirStr.Size = New System.Drawing.Size(94, 21)
        Me.txtTglLahirStr.TabIndex = 62
        Me.txtTglLahirStr.Visible = False
        '
        'cboTitle
        '
        Me.cboTitle.FormattingEnabled = True
        Me.cboTitle.Items.AddRange(New Object() {"Tuan", "Nyonya", "Nona", "Wanita"})
        Me.cboTitle.Location = New System.Drawing.Point(193, 100)
        Me.cboTitle.Name = "cboTitle"
        Me.cboTitle.Size = New System.Drawing.Size(63, 21)
        Me.cboTitle.TabIndex = 57
        '
        'txtNoNPWP
        '
        Me.txtNoNPWP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoNPWP.Location = New System.Drawing.Point(194, 250)
        Me.txtNoNPWP.Name = "txtNoNPWP"
        Me.txtNoNPWP.Size = New System.Drawing.Size(204, 21)
        Me.txtNoNPWP.TabIndex = 64
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "No NPWP"
        '
        'lblPekerjaan
        '
        Me.lblPekerjaan.AutoSize = True
        Me.lblPekerjaan.Location = New System.Drawing.Point(16, 226)
        Me.lblPekerjaan.Name = "lblPekerjaan"
        Me.lblPekerjaan.Size = New System.Drawing.Size(55, 13)
        Me.lblPekerjaan.TabIndex = 72
        Me.lblPekerjaan.Text = "Pekerjaan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Tempat, Tanggal Lahir"
        '
        'dtpTglLahir
        '
        Me.dtpTglLahir.CustomFormat = "dd/MM/yyyy"
        Me.dtpTglLahir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglLahir.Location = New System.Drawing.Point(298, 133)
        Me.dtpTglLahir.Name = "dtpTglLahir"
        Me.dtpTglLahir.Size = New System.Drawing.Size(99, 21)
        Me.dtpTglLahir.TabIndex = 61
        Me.dtpTglLahir.Value = New Date(2014, 9, 2, 0, 0, 0, 0)
        '
        'txtTempatLahir
        '
        Me.txtTempatLahir.Location = New System.Drawing.Point(193, 133)
        Me.txtTempatLahir.Name = "txtTempatLahir"
        Me.txtTempatLahir.Size = New System.Drawing.Size(99, 21)
        Me.txtTempatLahir.TabIndex = 60
        '
        'txtKet
        '
        Me.txtKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKet.Location = New System.Drawing.Point(194, 328)
        Me.txtKet.Multiline = True
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(297, 61)
        Me.txtKet.TabIndex = 68
        '
        'txtNoHp
        '
        Me.txtNoHp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoHp.Location = New System.Drawing.Point(194, 301)
        Me.txtNoHp.Name = "txtNoHp"
        Me.txtNoHp.Size = New System.Drawing.Size(204, 21)
        Me.txtNoHp.TabIndex = 66
        '
        'txtNoTelepon
        '
        Me.txtNoTelepon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTelepon.Location = New System.Drawing.Point(194, 276)
        Me.txtNoTelepon.Name = "txtNoTelepon"
        Me.txtNoTelepon.Size = New System.Drawing.Size(204, 21)
        Me.txtNoTelepon.TabIndex = 65
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(193, 160)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(303, 57)
        Me.txtAlamat.TabIndex = 62
        '
        'txtNama
        '
        Me.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNama.Location = New System.Drawing.Point(256, 100)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(240, 21)
        Me.txtNama.TabIndex = 58
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Remarks"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "No Hp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "No Telp"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Nama"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Alamat"
        '
        'txtNegara
        '
        Me.txtNegara.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNegara.Location = New System.Drawing.Point(283, 70)
        Me.txtNegara.Name = "txtNegara"
        Me.txtNegara.Size = New System.Drawing.Size(114, 21)
        Me.txtNegara.TabIndex = 36
        Me.txtNegara.Visible = False
        '
        'cboWargaNegara
        '
        Me.cboWargaNegara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWargaNegara.FormattingEnabled = True
        Me.cboWargaNegara.Items.AddRange(New Object() {"WNI", "WNA"})
        Me.cboWargaNegara.Location = New System.Drawing.Point(193, 70)
        Me.cboWargaNegara.Name = "cboWargaNegara"
        Me.cboWargaNegara.Size = New System.Drawing.Size(84, 21)
        Me.cboWargaNegara.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Warga Negara"
        '
        'cboJenisID
        '
        Me.cboJenisID.FormattingEnabled = True
        Me.cboJenisID.Items.AddRange(New Object() {"KTP", "PASPOR"})
        Me.cboJenisID.Location = New System.Drawing.Point(193, 13)
        Me.cboJenisID.Name = "cboJenisID"
        Me.cboJenisID.Size = New System.Drawing.Size(204, 21)
        Me.cboJenisID.TabIndex = 33
        '
        'txtNoID
        '
        Me.txtNoID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoID.Location = New System.Drawing.Point(193, 45)
        Me.txtNoID.Name = "txtNoID"
        Me.txtNoID.Size = New System.Drawing.Size(204, 21)
        Me.txtNoID.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "No Identitas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Jenis Identitas"
        '
        'btnID
        '
        Me.btnID.BackColor = System.Drawing.Color.Transparent
        Me.btnID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnID.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnID.Image = CType(resources.GetObject("btnID.Image"), System.Drawing.Image)
        Me.btnID.Location = New System.Drawing.Point(402, 15)
        Me.btnID.Name = "btnID"
        Me.btnID.Size = New System.Drawing.Size(19, 20)
        Me.btnID.TabIndex = 35
        Me.btnID.TabStop = False
        Me.btnID.UseVisualStyleBackColor = False
        '
        'Label36
        '
        Me.Label36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.BackColor = System.Drawing.Color.CadetBlue
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(6, 13)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(512, 22)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "« Pihak II"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarItemAdd, Me.BarItemClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(524, 28)
        Me.ToolBar.TabIndex = 12
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarItemAdd
        '
        Me.BarItemAdd.Name = "BarItemAdd"
        Me.BarItemAdd.Text = "Add"
        '
        'BarItemClose
        '
        Me.BarItemClose.Name = "BarItemClose"
        Me.BarItemClose.Text = "Close"
        '
        'frmTraNotaryOrderClient2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 472)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraNotaryOrderClient2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pihak II"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarItemAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarItemClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNegara As System.Windows.Forms.TextBox
    Friend WithEvents cboWargaNegara As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboJenisID As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnID As System.Windows.Forms.Button
    Friend WithEvents txtTglLahirStr As System.Windows.Forms.TextBox
    Friend WithEvents cboTitle As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoNPWP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPekerjaan As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpTglLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTempatLahir As System.Windows.Forms.TextBox
    Friend WithEvents txtKet As System.Windows.Forms.TextBox
    Friend WithEvents txtNoHp As System.Windows.Forms.TextBox
    Friend WithEvents txtNoTelepon As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPekerjaan As System.Windows.Forms.ComboBox
End Class
