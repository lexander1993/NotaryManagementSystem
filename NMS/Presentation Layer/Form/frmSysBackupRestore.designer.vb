<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysBackupRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysBackupRestore))
        Me.BarExit = New System.Windows.Forms.ToolBarButton()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
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
        Me.gbDetail.SuspendLayout()
        Me.PanelBackup.SuspendLayout()
        Me.PanelRestore.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarExit
        '
        Me.BarExit.Name = "BarExit"
        Me.BarExit.Text = "Exit"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.cbType)
        Me.gbDetail.Controls.Add(Me.PanelBackup)
        Me.gbDetail.Controls.Add(Me.PanelRestore)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(557, 91)
        Me.gbDetail.TabIndex = 1
        Me.gbDetail.TabStop = False
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
        Me.PanelBackup.Location = New System.Drawing.Point(28, 47)
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
        Me.ToolBar.Size = New System.Drawing.Size(557, 28)
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
        'frmSysBackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 119)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSysBackupRestore"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup and Restore Database"
        Me.gbDetail.ResumeLayout(False)
        Me.PanelBackup.ResumeLayout(False)
        Me.PanelBackup.PerformLayout()
        Me.PanelRestore.ResumeLayout(False)
        Me.PanelRestore.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents txtRestore As usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBackup As usTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents BarBackup As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarRestore As System.Windows.Forms.ToolBarButton
    Friend WithEvents PanelRestore As System.Windows.Forms.Panel
    Friend WithEvents PanelBackup As System.Windows.Forms.Panel
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
