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
        Me.IDM_TICKETES = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_RECORTE = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_LISTAS = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_TICKET_GANADORAS = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_LIMPIAR_USUARIO = New DevExpress.XtraBars.BarButtonItem()
        Me.IDM_CAMBIAR_USUARIO = New DevExpress.XtraBars.BarButtonItem()
        Me.CONTROL = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.IDM_REGISTRO = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.IDM_DOCUMENTOS = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.IDM_ACCIONES = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.REPORTES = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.xtrerrormsg = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        Me.xtrOkMsg = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.IDM_CONFIG_SERVER = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.IDM_USUARIO, Me.IDM_CLIENTES, Me.IDM_TURNOS, Me.IDM_TICKETES, Me.IDM_RECORTE, Me.IDM_LISTAS, Me.IDM_TICKET_GANADORAS, Me.IDM_LIMPIAR_USUARIO, Me.IDM_CAMBIAR_USUARIO, Me.IDM_CONFIG_SERVER})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 11
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.CONTROL})
        Me.RibbonControl.Size = New System.Drawing.Size(1190, 143)
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
        Me.IDM_CLIENTES.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.business_male_female_users
        Me.IDM_CLIENTES.Name = "IDM_CLIENTES"
        '
        'IDM_TURNOS
        '
        Me.IDM_TURNOS.Caption = "Turnos"
        Me.IDM_TURNOS.Id = 3
        Me.IDM_TURNOS.ImageOptions.Image = CType(resources.GetObject("IDM_TURNOS.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_TURNOS.Name = "IDM_TURNOS"
        '
        'IDM_TICKETES
        '
        Me.IDM_TICKETES.Caption = "Ventas/Ticketes"
        Me.IDM_TICKETES.Id = 4
        Me.IDM_TICKETES.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.Cash___Stack__Share__24x24
        Me.IDM_TICKETES.Name = "IDM_TICKETES"
        '
        'IDM_RECORTE
        '
        Me.IDM_RECORTE.Caption = "Resumen de Ticket"
        Me.IDM_RECORTE.Id = 5
        Me.IDM_RECORTE.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.chart_pie
        Me.IDM_RECORTE.Name = "IDM_RECORTE"
        '
        'IDM_LISTAS
        '
        Me.IDM_LISTAS.Caption = "Listas"
        Me.IDM_LISTAS.Id = 6
        Me.IDM_LISTAS.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.book_accept2
        Me.IDM_LISTAS.Name = "IDM_LISTAS"
        '
        'IDM_TICKET_GANADORAS
        '
        Me.IDM_TICKET_GANADORAS.Caption = "Tickets Ganadoras"
        Me.IDM_TICKET_GANADORAS.Id = 7
        Me.IDM_TICKET_GANADORAS.ImageOptions.Image = Global.LUCKYONE.My.Resources.Resources.Documentos
        Me.IDM_TICKET_GANADORAS.Name = "IDM_TICKET_GANADORAS"
        '
        'IDM_LIMPIAR_USUARIO
        '
        Me.IDM_LIMPIAR_USUARIO.Caption = "Limpiar Sorteos"
        Me.IDM_LIMPIAR_USUARIO.Id = 8
        Me.IDM_LIMPIAR_USUARIO.ImageOptions.Image = CType(resources.GetObject("IDM_LIMPIAR_USUARIO.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_LIMPIAR_USUARIO.Name = "IDM_LIMPIAR_USUARIO"
        '
        'IDM_CAMBIAR_USUARIO
        '
        Me.IDM_CAMBIAR_USUARIO.Caption = "Cambiar Usuario"
        Me.IDM_CAMBIAR_USUARIO.Id = 9
        Me.IDM_CAMBIAR_USUARIO.ImageOptions.Image = CType(resources.GetObject("IDM_CAMBIAR_USUARIO.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_CAMBIAR_USUARIO.Name = "IDM_CAMBIAR_USUARIO"
        '
        'CONTROL
        '
        Me.CONTROL.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.IDM_REGISTRO, Me.IDM_DOCUMENTOS, Me.IDM_ACCIONES, Me.REPORTES})
        Me.CONTROL.Name = "CONTROL"
        Me.CONTROL.Text = "LUCKYONE"
        '
        'IDM_REGISTRO
        '
        Me.IDM_REGISTRO.ItemLinks.Add(Me.IDM_USUARIO)
        Me.IDM_REGISTRO.ItemLinks.Add(Me.IDM_CLIENTES)
        Me.IDM_REGISTRO.Name = "IDM_REGISTRO"
        Me.IDM_REGISTRO.Text = "REGISTRO"
        '
        'IDM_DOCUMENTOS
        '
        Me.IDM_DOCUMENTOS.ItemLinks.Add(Me.IDM_TURNOS)
        Me.IDM_DOCUMENTOS.ItemLinks.Add(Me.IDM_TICKETES)
        Me.IDM_DOCUMENTOS.ItemLinks.Add(Me.IDM_RECORTE)
        Me.IDM_DOCUMENTOS.ItemLinks.Add(Me.IDM_LISTAS)
        Me.IDM_DOCUMENTOS.Name = "IDM_DOCUMENTOS"
        Me.IDM_DOCUMENTOS.Text = "DOCUMENTOS"
        '
        'IDM_ACCIONES
        '
        Me.IDM_ACCIONES.ItemLinks.Add(Me.IDM_LIMPIAR_USUARIO)
        Me.IDM_ACCIONES.ItemLinks.Add(Me.IDM_CAMBIAR_USUARIO)
        Me.IDM_ACCIONES.ItemLinks.Add(Me.IDM_CONFIG_SERVER)
        Me.IDM_ACCIONES.Name = "IDM_ACCIONES"
        Me.IDM_ACCIONES.Text = "OTROS"
        '
        'REPORTES
        '
        Me.REPORTES.ItemLinks.Add(Me.IDM_TICKET_GANADORAS)
        Me.REPORTES.Name = "REPORTES"
        Me.REPORTES.Text = "REPORTES"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 798)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1190, 31)
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'IDM_CONFIG_SERVER
        '
        Me.IDM_CONFIG_SERVER.Caption = "Config de servidor"
        Me.IDM_CONFIG_SERVER.Id = 10
        Me.IDM_CONFIG_SERVER.ImageOptions.Image = CType(resources.GetObject("IDM_CONFIG_SERVER.ImageOptions.Image"), System.Drawing.Image)
        Me.IDM_CONFIG_SERVER.ImageOptions.LargeImage = CType(resources.GetObject("IDM_CONFIG_SERVER.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.IDM_CONFIG_SERVER.Name = "IDM_CONFIG_SERVER"
        '
        'MDI_PARENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1190, 829)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IsMdiContainer = True
        Me.Name = "MDI_PARENT"
        Me.Ribbon = Me.RibbonControl
        Me.RibbonAlwaysAtBack = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "SISTEMA DE CONTROL LUCKYONE"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents CONTROL As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents IDM_REGISTRO As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents IDM_USUARIO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents xtrerrormsg As DevExpress.XtraBars.Alerter.AlertControl
    Friend WithEvents xtrOkMsg As DevExpress.XtraBars.Alerter.AlertControl
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents IDM_CLIENTES As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_TURNOS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_DOCUMENTOS As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IDM_TICKETES As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents IDM_RECORTE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_LISTAS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_TICKET_GANADORAS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents REPORTES As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IDM_LIMPIAR_USUARIO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_ACCIONES As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IDM_CAMBIAR_USUARIO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDM_CONFIG_SERVER As DevExpress.XtraBars.BarButtonItem
End Class
