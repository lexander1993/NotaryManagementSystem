<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraNotaryOrderProcess
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
        Me.lblHead = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.txtRemarks = New NMS.usTextBox()
        Me.rdCancelProcess = New System.Windows.Forms.RadioButton()
        Me.rdProcess = New System.Windows.Forms.RadioButton()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.BarExit = New System.Windows.Forms.ToolBarButton()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.pnlDetail.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHead.BackColor = System.Drawing.Color.CadetBlue
        Me.lblHead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(7, 13)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(547, 22)
        Me.lblHead.TabIndex = 1
        Me.lblHead.Text = "« Notary Order Process"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.txtRemarks)
        Me.pnlDetail.Controls.Add(Me.rdCancelProcess)
        Me.pnlDetail.Controls.Add(Me.rdProcess)
        Me.pnlDetail.Controls.Add(Me.lblType)
        Me.pnlDetail.Controls.Add(Me.lblRemarks)
        Me.pnlDetail.Location = New System.Drawing.Point(7, 38)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(547, 142)
        Me.pnlDetail.TabIndex = 0
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(79, 39)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(449, 87)
        Me.txtRemarks.TabIndex = 191
        '
        'rdCancelProcess
        '
        Me.rdCancelProcess.AutoSize = True
        Me.rdCancelProcess.Location = New System.Drawing.Point(171, 12)
        Me.rdCancelProcess.Name = "rdCancelProcess"
        Me.rdCancelProcess.Size = New System.Drawing.Size(97, 17)
        Me.rdCancelProcess.TabIndex = 182
        Me.rdCancelProcess.TabStop = True
        Me.rdCancelProcess.Text = "Cancel Process"
        Me.rdCancelProcess.UseVisualStyleBackColor = True
        '
        'rdProcess
        '
        Me.rdProcess.AutoSize = True
        Me.rdProcess.Location = New System.Drawing.Point(79, 12)
        Me.rdProcess.Name = "rdProcess"
        Me.rdProcess.Size = New System.Drawing.Size(62, 17)
        Me.rdProcess.TabIndex = 180
        Me.rdProcess.TabStop = True
        Me.rdProcess.Text = "Process"
        Me.rdProcess.UseVisualStyleBackColor = True
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.ForeColor = System.Drawing.Color.Black
        Me.lblType.Location = New System.Drawing.Point(10, 12)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(31, 13)
        Me.lblType.TabIndex = 179
        Me.lblType.Text = "Type"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(10, 42)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(48, 13)
        Me.lblRemarks.TabIndex = 178
        Me.lblRemarks.Text = "Remarks"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.pnlDetail)
        Me.gbDetail.Controls.Add(Me.lblHead)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(560, 186)
        Me.gbDetail.TabIndex = 10
        Me.gbDetail.TabStop = False
        '
        'BarExit
        '
        Me.BarExit.Name = "BarExit"
        Me.BarExit.Text = "Close"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarSave, Me.BarExit})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(560, 28)
        Me.ToolBar.TabIndex = 11
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarSave
        '
        Me.BarSave.Name = "BarSave"
        Me.BarSave.Text = "Save"
        '
        'frmTraNotaryOrderProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 214)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraNotaryOrderProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRemarks As NMS.usTextBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents rdCancelProcess As System.Windows.Forms.RadioButton
    Friend WithEvents rdProcess As System.Windows.Forms.RadioButton
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents BarExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
End Class
