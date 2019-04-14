<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDI_PARENT
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDI_PARENT))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.IDM_USUARIO = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_CLIENTES = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_TURNOS = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.CONTROL = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.IDM_REGISTRO = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.xtrerrormsg = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        Me.xtrOkMsg = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.IDM_USUARIO, Me.IDM_CLIENTES, Me.IDM_TURNOS})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 4
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.CONTROL})
        Me.RibbonControl.Size = New System.Drawing.Size(860, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'IDM_USUARIO
        '
        Me.IDM_USUARIO.Caption = "Usuarios"
        Me.IDM_USUARIO.Id = 1
        Me.IDM_USUARIO.ImageOptions.Image = CType(resources.GetObject("IDM_USUARIO.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_USUARIO.Name = "IDM_USUARIO"
        '
        'IDM_CLIENTES
        '
        Me.IDM_CLIENTES.Caption = "Clientes"
        Me.IDM_CLIENTES.Id = 2
        Me.IDM_CLIENTES.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_CLIENTES.Name = "IDM_CLIENTES"
        '
        'IDM_TURNOS
        '
        Me.IDM_TURNOS.Caption = "Turnos"
        Me.IDM_TURNOS.Id = 3
        Me.IDM_TURNOS.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_TURNOS.Name = "IDM_TURNOS"
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonPageCategory1.Text = "RibbonPageCategory1"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'CONTROL
        '
        Me.CONTROL.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.IDM_REGISTRO, Me.RibbonPageGroup1})
        Me.CONTROL.Name = "CONTROL"
        Me.CONTROL.Text = "RibbonPage1"
        '
        'IDM_REGISTRO
        '
        Me.IDM_REGISTRO.ItemLinks.Add(Me.IDM_USUARIO)
        Me.IDM_REGISTRO.ItemLinks.Add(Me.IDM_CLIENTES)
        Me.IDM_REGISTRO.Name = "IDM_REGISTRO"
        Me.IDM_REGISTRO.Text = "REGISTRO"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.IDM_TURNOS)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(860, 31)
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'MDI_PARENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 449)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IsMdiContainer = True
        Me.Name = "MDI_PARENT"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "MDI_PARENT"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents CONTROL As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents IDM_REGISTRO As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IDM_USUARIO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents xtrerrormsg As DevExpress.XtraBars.Alerter.AlertControl
    Friend WithEvents xtrOkMsg As DevExpress.XtraBars.Alerter.AlertControl
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents IDM_CLIENTES As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_TURNOS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
