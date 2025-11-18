<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPPATOrderBPNFinish
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpBPNFinishDate = New System.Windows.Forms.DateTimePicker()
        Me.txtRemarks = New NMS.usTextBox()
        Me.rdCancelBPNFinish = New System.Windows.Forms.RadioButton()
        Me.rdBPNFinish = New System.Windows.Forms.RadioButton()
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
        Me.lblHead.Text = "« PPAT Order BPN Finish ( BPN --> Kantor)"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDetail
        '
        Me.pnlDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetail.Controls.Add(Me.Label1)
        Me.pnlDetail.Controls.Add(Me.dtpBPNFinishDate)
        Me.pnlDetail.Controls.Add(Me.txtRemarks)
        Me.pnlDetail.Controls.Add(Me.rdCancelBPNFinish)
        Me.pnlDetail.Controls.Add(Me.rdBPNFinish)
        Me.pnlDetail.Controls.Add(Me.lblType)
        Me.pnlDetail.Controls.Add(Me.lblRemarks)
        Me.pnlDetail.Location = New System.Drawing.Point(7, 38)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(547, 168)
        Me.pnlDetail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "BPN Finish Date"
        '
        'dtpBPNFinishDate
        '
        Me.dtpBPNFinishDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBPNFinishDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBPNFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBPNFinishDate.Location = New System.Drawing.Point(105, 36)
        Me.dtpBPNFinishDate.Name = "dtpBPNFinishDate"
        Me.dtpBPNFinishDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpBPNFinishDate.TabIndex = 193
        Me.dtpBPNFinishDate.Value = New Date(2014, 9, 12, 0, 0, 0, 0)
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(105, 70)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(424, 87)
        Me.txtRemarks.TabIndex = 191
        '
        'rdCancelBPNFinish
        '
        Me.rdCancelBPNFinish.AutoSize = True
        Me.rdCancelBPNFinish.Location = New System.Drawing.Point(196, 12)
        Me.rdCancelBPNFinish.Name = "rdCancelBPNFinish"
        Me.rdCancelBPNFinish.Size = New System.Drawing.Size(109, 17)
        Me.rdCancelBPNFinish.TabIndex = 182
        Me.rdCancelBPNFinish.TabStop = True
        Me.rdCancelBPNFinish.Text = "Cancel BPN Finish"
        Me.rdCancelBPNFinish.UseVisualStyleBackColor = True
        '
        'rdBPNFinish
        '
        Me.rdBPNFinish.AutoSize = True
        Me.rdBPNFinish.Location = New System.Drawing.Point(104, 12)
        Me.rdBPNFinish.Name = "rdBPNFinish"
        Me.rdBPNFinish.Size = New System.Drawing.Size(74, 17)
        Me.rdBPNFinish.TabIndex = 180
        Me.rdBPNFinish.TabStop = True
        Me.rdBPNFinish.Text = "BPN Finish"
        Me.rdBPNFinish.UseVisualStyleBackColor = True
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
        Me.lblRemarks.Location = New System.Drawing.Point(10, 72)
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
        Me.gbDetail.Size = New System.Drawing.Size(560, 212)
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
        'frmTraPPATOrderBPNFinish
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 240)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraPPATOrderBPNFinish"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BPN Finish"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRemarks As NMS.usTextBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents rdCancelBPNFinish As System.Windows.Forms.RadioButton
    Friend WithEvents rdBPNFinish As System.Windows.Forms.RadioButton
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents BarExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpBPNFinishDate As System.Windows.Forms.DateTimePicker
End Class
