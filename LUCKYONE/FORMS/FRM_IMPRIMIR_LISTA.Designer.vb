<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IMPRIMIR_LISTA
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Chkconvertir = New DevExpress.XtraEditors.CheckEdit()
        Me.txtsumtotal = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TXTSUM3 = New DevExpress.XtraEditors.TextEdit()
        Me.TXTSUM2 = New DevExpress.XtraEditors.TextEdit()
        Me.TXTSUM1 = New DevExpress.XtraEditors.TextEdit()
        Me.BTNEXCEL = New DevExpress.XtraEditors.SimpleButton()
        Me.GRD = New DevExpress.XtraGrid.GridControl()
        Me.GRV = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.Chkconvertir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsumtotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTSUM3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTSUM2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTSUM1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Chkconvertir)
        Me.PanelControl1.Controls.Add(Me.txtsumtotal)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TXTSUM3)
        Me.PanelControl1.Controls.Add(Me.TXTSUM2)
        Me.PanelControl1.Controls.Add(Me.TXTSUM1)
        Me.PanelControl1.Controls.Add(Me.BTNEXCEL)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 460)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(760, 68)
        Me.PanelControl1.TabIndex = 1
        '
        'Chkconvertir
        '
        Me.Chkconvertir.Location = New System.Drawing.Point(440, 45)
        Me.Chkconvertir.Name = "Chkconvertir"
        Me.Chkconvertir.Properties.Caption = "Ver Premio"
        Me.Chkconvertir.Size = New System.Drawing.Size(75, 19)
        Me.Chkconvertir.TabIndex = 18
        Me.Chkconvertir.Visible = False
        '
        'txtsumtotal
        '
        Me.txtsumtotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtsumtotal.Location = New System.Drawing.Point(323, 36)
        Me.txtsumtotal.Name = "txtsumtotal"
        Me.txtsumtotal.Properties.AllowFocused = False
        Me.txtsumtotal.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsumtotal.Properties.Appearance.Options.UseFont = True
        Me.txtsumtotal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtsumtotal.Properties.Mask.EditMask = "n"
        Me.txtsumtotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtsumtotal.Size = New System.Drawing.Size(100, 28)
        Me.txtsumtotal.TabIndex = 17
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(217, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 17)
        Me.LabelControl3.TabIndex = 16
        Me.LabelControl3.Text = "67- 99"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(111, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(41, 17)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "34 - 66"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(5, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 17)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "00 - 33"
        '
        'TXTSUM3
        '
        Me.TXTSUM3.Location = New System.Drawing.Point(217, 36)
        Me.TXTSUM3.Name = "TXTSUM3"
        Me.TXTSUM3.Properties.AllowFocused = False
        Me.TXTSUM3.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUM3.Properties.Appearance.Options.UseFont = True
        Me.TXTSUM3.Properties.Mask.EditMask = "n"
        Me.TXTSUM3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TXTSUM3.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TXTSUM3.Size = New System.Drawing.Size(100, 28)
        Me.TXTSUM3.TabIndex = 13
        '
        'TXTSUM2
        '
        Me.TXTSUM2.Location = New System.Drawing.Point(111, 36)
        Me.TXTSUM2.Name = "TXTSUM2"
        Me.TXTSUM2.Properties.AllowFocused = False
        Me.TXTSUM2.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUM2.Properties.Appearance.Options.UseFont = True
        Me.TXTSUM2.Properties.Mask.EditMask = "n"
        Me.TXTSUM2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TXTSUM2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TXTSUM2.Size = New System.Drawing.Size(100, 28)
        Me.TXTSUM2.TabIndex = 12
        '
        'TXTSUM1
        '
        Me.TXTSUM1.Location = New System.Drawing.Point(5, 36)
        Me.TXTSUM1.Name = "TXTSUM1"
        Me.TXTSUM1.Properties.AllowFocused = False
        Me.TXTSUM1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUM1.Properties.Appearance.Options.UseFont = True
        Me.TXTSUM1.Properties.Mask.EditMask = "n"
        Me.TXTSUM1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TXTSUM1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TXTSUM1.Size = New System.Drawing.Size(100, 28)
        Me.TXTSUM1.TabIndex = 11
        '
        'BTNEXCEL
        '
        Me.BTNEXCEL.BackgroundImage = Global.LUCKYONE.My.Resources.Resources._10_percent_off
        Me.BTNEXCEL.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.book_download1
        Me.BTNEXCEL.Location = New System.Drawing.Point(582, 36)
        Me.BTNEXCEL.Name = "BTNEXCEL"
        Me.BTNEXCEL.Size = New System.Drawing.Size(117, 28)
        Me.BTNEXCEL.TabIndex = 10
        Me.BTNEXCEL.Text = "Guardar Lista"
        Me.BTNEXCEL.Visible = False
        '
        'GRD
        '
        Me.GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GRD.Location = New System.Drawing.Point(0, 0)
        Me.GRD.MainView = Me.GRV
        Me.GRD.Name = "GRD"
        Me.GRD.Size = New System.Drawing.Size(760, 460)
        Me.GRD.TabIndex = 4
        Me.GRD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRV})
        '
        'GRV
        '
        Me.GRV.Appearance.Row.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRV.Appearance.Row.Options.UseFont = True
        Me.GRV.GridControl = Me.GRD
        Me.GRV.Name = "GRV"
        Me.GRV.OptionsView.ShowColumnHeaders = False
        Me.GRV.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GRV.OptionsView.ShowGroupPanel = False
        '
        'FRM_IMPRIMIR_LISTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 528)
        Me.Controls.Add(Me.GRD)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FRM_IMPRIMIR_LISTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODO IMPRESION"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.Chkconvertir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsumtotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTSUM3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTSUM2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTSUM1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Chkconvertir As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtsumtotal As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXTSUM3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TXTSUM2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TXTSUM1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BTNEXCEL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GRD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRV As DevExpress.XtraGrid.Views.Grid.GridView
End Class
