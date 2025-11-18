<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysCaptureLocation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysCaptureLocation))
        Me.BarExit = New System.Windows.Forms.ToolBarButton()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.PanelBackup = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBackup = New NMS.usTextBox()
        Me.PanelRestore = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRestore = New NMS.usTextBox()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarBackup = New System.Windows.Forms.ToolBarButton()
        Me.BarRestore = New System.Windows.Forms.ToolBarButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.gbDetail.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBackup.SuspendLayout()
        Me.PanelRestore.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarExit
        '
        Me.BarExit.Name = "BarExit"
        Me.BarExit.Text = "Exit"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.PictureBox2)
        Me.gbDetail.Controls.Add(Me.Button4)
        Me.gbDetail.Controls.Add(Me.Button3)
        Me.gbDetail.Controls.Add(Me.GroupBox1)
        Me.gbDetail.Controls.Add(Me.Button2)
        Me.gbDetail.Controls.Add(Me.btnOpen)
        Me.gbDetail.Controls.Add(Me.btnSave)
        Me.gbDetail.Controls.Add(Me.Button1)
        Me.gbDetail.Controls.Add(Me.WebBrowser1)
        Me.gbDetail.Controls.Add(Me.cbType)
        Me.gbDetail.Controls.Add(Me.PanelBackup)
        Me.gbDetail.Controls.Add(Me.PanelRestore)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(764, 457)
        Me.gbDetail.TabIndex = 1
        Me.gbDetail.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button3.Location = New System.Drawing.Point(373, 218)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(19, 20)
        Me.Button3.TabIndex = 113
        Me.Button3.TabStop = False
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(530, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 223)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(21, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(168, 195)
        Me.PictureBox1.TabIndex = 109
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(407, 334)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 111
        Me.Button2.Text = "Folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(617, 52)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 110
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(617, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 108
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(510, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 45)
        Me.Button1.TabIndex = 103
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(28, 112)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(232, 88)
        Me.WebBrowser1.TabIndex = 107
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Back Up", "Restore"})
        Me.cbType.Location = New System.Drawing.Point(38, 20)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(121, 21)
        Me.cbType.TabIndex = 106
        '
        'PanelBackup
        '
        Me.PanelBackup.Controls.Add(Me.Label2)
        Me.PanelBackup.Controls.Add(Me.txtBackup)
        Me.PanelBackup.Location = New System.Drawing.Point(28, 78)
        Me.PanelBackup.Name = "PanelBackup"
        Me.PanelBackup.Size = New System.Drawing.Size(442, 28)
        Me.PanelBackup.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Backup Database To"
        '
        'txtBackup
        '
        Me.txtBackup.BackColor = System.Drawing.Color.NavajoWhite
        Me.txtBackup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBackup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBackup.Location = New System.Drawing.Point(136, 3)
        Me.txtBackup.Name = "txtBackup"
        Me.txtBackup.Size = New System.Drawing.Size(255, 21)
        Me.txtBackup.TabIndex = 0
        '
        'PanelRestore
        '
        Me.PanelRestore.Controls.Add(Me.Label1)
        Me.PanelRestore.Controls.Add(Me.txtRestore)
        Me.PanelRestore.Controls.Add(Me.btnRestore)
        Me.PanelRestore.Location = New System.Drawing.Point(28, 47)
        Me.PanelRestore.Name = "PanelRestore"
        Me.PanelRestore.Size = New System.Drawing.Size(442, 28)
        Me.PanelRestore.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Restore Database From"
        '
        'txtRestore
        '
        Me.txtRestore.BackColor = System.Drawing.Color.LightCyan
        Me.txtRestore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRestore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRestore.Location = New System.Drawing.Point(136, 4)
        Me.txtRestore.Name = "txtRestore"
        Me.txtRestore.ReadOnly = True
        Me.txtRestore.Size = New System.Drawing.Size(255, 21)
        Me.txtRestore.TabIndex = 1
        '
        'btnRestore
        '
        Me.btnRestore.BackColor = System.Drawing.Color.Transparent
        Me.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestore.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnRestore.Image = CType(resources.GetObject("btnRestore.Image"), System.Drawing.Image)
        Me.btnRestore.Location = New System.Drawing.Point(397, 5)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(19, 20)
        Me.btnRestore.TabIndex = 102
        Me.btnRestore.TabStop = False
        Me.btnRestore.UseVisualStyleBackColor = False
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarBackup, Me.BarRestore, Me.BarExit})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(764, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarBackup
        '
        Me.BarBackup.Name = "BarBackup"
        Me.BarBackup.Text = "Backup"
        '
        'BarRestore
        '
        Me.BarRestore.Name = "BarRestore"
        Me.BarRestore.Text = "Restore"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button4.Location = New System.Drawing.Point(381, 226)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(19, 20)
        Me.Button4.TabIndex = 114
        Me.Button4.TabStop = False
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(299, 172)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(76, 74)
        Me.PictureBox2.TabIndex = 115
        Me.PictureBox2.TabStop = False
        '
        'frmSysCaptureLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 485)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSysCaptureLocation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup and Restore Database"
        Me.gbDetail.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBackup.ResumeLayout(False)
        Me.PanelBackup.PerformLayout()
        Me.PanelRestore.ResumeLayout(False)
        Me.PanelRestore.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BarBackup As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarRestore As System.Windows.Forms.ToolBarButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents PanelBackup As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBackup As NMS.usTextBox
    Friend WithEvents PanelRestore As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRestore As NMS.usTextBox
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
