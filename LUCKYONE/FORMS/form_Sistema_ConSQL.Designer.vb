<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class form_Sistema_ConSQL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents cmdIniciar As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_Sistema_ConSQL))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions4 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject13 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject14 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject15 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject16 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions5 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject17 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject18 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject19 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject20 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions6 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject21 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject22 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject23 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject24 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions7 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject25 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject26 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject27 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject28 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions8 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject29 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject30 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject31 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject32 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.cmdIniciar = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblTítulo = New System.Windows.Forms.Label()
        Me.txtBaseDatos = New System.Windows.Forms.TextBox()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.txtServidorSQL = New System.Windows.Forms.TextBox()
        Me.lblServidorSQL = New System.Windows.Forms.Label()
        Me.chkIniciarAutomáticamente = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtCarpeta = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtNombreBD = New System.Windows.Forms.TextBox()
        Me.lst = New System.Windows.Forms.ListView()
        Me.img = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdRestaurar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtArchivo_BAK = New DevExpress.XtraEditors.ButtonEdit()
        Me.cmbPerfil = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIniciarAutomáticamente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txtCarpeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArchivo_BAK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPerfil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(168, 192)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(171, 62)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(73, 23)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "&Login"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUsuario.Visible = False
        '
        'lblContraseña
        '
        Me.lblContraseña.Location = New System.Drawing.Point(171, 83)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(73, 23)
        Me.lblContraseña.TabIndex = 2
        Me.lblContraseña.Text = "C&ontraseña"
        Me.lblContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblContraseña.Visible = False
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(243, 65)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(151, 20)
        Me.txtUsuario.TabIndex = 0
        Me.txtUsuario.Visible = False
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(243, 86)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(151, 20)
        Me.txtContraseña.TabIndex = 1
        Me.txtContraseña.Visible = False
        '
        'cmdIniciar
        '
        Me.cmdIniciar.Location = New System.Drawing.Point(171, 169)
        Me.cmdIniciar.Name = "cmdIniciar"
        Me.cmdIniciar.Size = New System.Drawing.Size(94, 23)
        Me.cmdIniciar.TabIndex = 5
        Me.cmdIniciar.Text = "&Iniciar"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(300, 169)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(94, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancelar"
        '
        'lblTítulo
        '
        Me.lblTítulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTítulo.Location = New System.Drawing.Point(171, 9)
        Me.lblTítulo.Name = "lblTítulo"
        Me.lblTítulo.Size = New System.Drawing.Size(223, 53)
        Me.lblTítulo.TabIndex = 6
        Me.lblTítulo.Text = "Inicio de Sesión " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SQL Server"
        Me.lblTítulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtBaseDatos
        '
        Me.txtBaseDatos.Location = New System.Drawing.Point(243, 107)
        Me.txtBaseDatos.Name = "txtBaseDatos"
        Me.txtBaseDatos.Size = New System.Drawing.Size(151, 20)
        Me.txtBaseDatos.TabIndex = 2
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.Location = New System.Drawing.Point(171, 104)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(73, 23)
        Me.lblBaseDatos.TabIndex = 7
        Me.lblBaseDatos.Text = "&Base Datos"
        Me.lblBaseDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtServidorSQL
        '
        Me.txtServidorSQL.Location = New System.Drawing.Point(243, 128)
        Me.txtServidorSQL.Name = "txtServidorSQL"
        Me.txtServidorSQL.Size = New System.Drawing.Size(151, 20)
        Me.txtServidorSQL.TabIndex = 3
        '
        'lblServidorSQL
        '
        Me.lblServidorSQL.Location = New System.Drawing.Point(171, 125)
        Me.lblServidorSQL.Name = "lblServidorSQL"
        Me.lblServidorSQL.Size = New System.Drawing.Size(73, 23)
        Me.lblServidorSQL.TabIndex = 9
        Me.lblServidorSQL.Text = "&Servidor"
        Me.lblServidorSQL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkIniciarAutomáticamente
        '
        Me.chkIniciarAutomáticamente.Location = New System.Drawing.Point(241, 150)
        Me.chkIniciarAutomáticamente.Name = "chkIniciarAutomáticamente"
        Me.chkIniciarAutomáticamente.Properties.Caption = "Iniciar Automáticamente"
        Me.chkIniciarAutomáticamente.Size = New System.Drawing.Size(149, 19)
        Me.chkIniciarAutomáticamente.TabIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txtCarpeta)
        Me.PanelControl2.Controls.Add(Me.txtNombreBD)
        Me.PanelControl2.Controls.Add(Me.lst)
        Me.PanelControl2.Controls.Add(Me.cmdRestaurar)
        Me.PanelControl2.Controls.Add(Me.txtArchivo_BAK)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Enabled = False
        Me.PanelControl2.Location = New System.Drawing.Point(0, 215)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(399, 227)
        Me.PanelControl2.TabIndex = 12
        '
        'txtCarpeta
        '
        Me.txtCarpeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCarpeta.Location = New System.Drawing.Point(2, 45)
        Me.txtCarpeta.Name = "txtCarpeta"
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.txtCarpeta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Carpeta Destino", -1, True, True, True, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtCarpeta.Size = New System.Drawing.Size(395, 22)
        Me.txtCarpeta.TabIndex = 16
        '
        'txtNombreBD
        '
        Me.txtNombreBD.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNombreBD.Location = New System.Drawing.Point(2, 24)
        Me.txtNombreBD.Name = "txtNombreBD"
        Me.txtNombreBD.Size = New System.Drawing.Size(395, 21)
        Me.txtNombreBD.TabIndex = 14
        Me.txtNombreBD.Text = "ERPSUC30"
        '
        'lst
        '
        Me.lst.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lst.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lst.Location = New System.Drawing.Point(2, 105)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(395, 120)
        Me.lst.SmallImageList = Me.img
        Me.lst.TabIndex = 2
        Me.lst.UseCompatibleStateImageBehavior = False
        '
        'img
        '
        Me.img.ImageStream = CType(resources.GetObject("img.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img.TransparentColor = System.Drawing.Color.Transparent
        Me.img.Images.SetKeyName(0, "accept.png")
        Me.img.Images.SetKeyName(1, "delete.png")
        Me.img.Images.SetKeyName(2, "block.png")
        Me.img.Images.SetKeyName(3, "star_full.png")
        '
        'cmdRestaurar
        '
        Me.cmdRestaurar.Location = New System.Drawing.Point(171, 72)
        Me.cmdRestaurar.Name = "cmdRestaurar"
        Me.cmdRestaurar.Size = New System.Drawing.Size(94, 27)
        Me.cmdRestaurar.TabIndex = 1
        Me.cmdRestaurar.Text = "Restaurar"
        '
        'txtArchivo_BAK
        '
        Me.txtArchivo_BAK.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtArchivo_BAK.Location = New System.Drawing.Point(2, 2)
        Me.txtArchivo_BAK.Name = "txtArchivo_BAK"
        EditorButtonImageOptions3.Image = CType(resources.GetObject("EditorButtonImageOptions3.Image"), System.Drawing.Image)
        Me.txtArchivo_BAK.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Seleccionar respaldo", -1, True, True, True, EditorButtonImageOptions4, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject13, SerializableAppearanceObject14, SerializableAppearanceObject15, SerializableAppearanceObject16, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtArchivo_BAK.Size = New System.Drawing.Size(395, 22)
        Me.txtArchivo_BAK.TabIndex = 0
        '
        'cmbPerfil
        '
        Me.cmbPerfil.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmbPerfil.Location = New System.Drawing.Point(0, 193)
        Me.cmbPerfil.Name = "cmbPerfil"
        EditorButtonImageOptions6.Image = CType(resources.GetObject("EditorButtonImageOptions6.Image"), System.Drawing.Image)
        EditorButtonImageOptions7.Image = CType(resources.GetObject("EditorButtonImageOptions7.Image"), System.Drawing.Image)
        EditorButtonImageOptions8.Image = CType(resources.GetObject("EditorButtonImageOptions8.Image"), System.Drawing.Image)
        Me.cmbPerfil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Perfil MS-SQL", -1, True, True, True, EditorButtonImageOptions5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject17, SerializableAppearanceObject18, SerializableAppearanceObject19, SerializableAppearanceObject20, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions6, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject21, SerializableAppearanceObject22, SerializableAppearanceObject23, SerializableAppearanceObject24, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, True, EditorButtonImageOptions7, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject25, SerializableAppearanceObject26, SerializableAppearanceObject27, SerializableAppearanceObject28, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions8, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject29, SerializableAppearanceObject30, SerializableAppearanceObject31, SerializableAppearanceObject32, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.cmbPerfil.Size = New System.Drawing.Size(399, 22)
        Me.cmbPerfil.TabIndex = 7
        '
        'form_Sistema_ConSQL
        '
        Me.AcceptButton = Me.cmdIniciar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(399, 442)
        Me.Controls.Add(Me.cmbPerfil)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdIniciar)
        Me.Controls.Add(Me.chkIniciarAutomáticamente)
        Me.Controls.Add(Me.txtServidorSQL)
        Me.Controls.Add(Me.lblServidorSQL)
        Me.Controls.Add(Me.txtBaseDatos)
        Me.Controls.Add(Me.lblBaseDatos)
        Me.Controls.Add(Me.lblTítulo)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_Sistema_ConSQL"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inicio de Sesión SQL Server"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIniciarAutomáticamente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txtCarpeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArchivo_BAK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPerfil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTítulo As System.Windows.Forms.Label
    Friend WithEvents txtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents txtServidorSQL As System.Windows.Forms.TextBox
    Friend WithEvents lblServidorSQL As System.Windows.Forms.Label
    Friend WithEvents chkIniciarAutomáticamente As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtCarpeta As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtNombreBD As System.Windows.Forms.TextBox
    Friend WithEvents lst As System.Windows.Forms.ListView
    Friend WithEvents cmdRestaurar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtArchivo_BAK As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents img As System.Windows.Forms.ImageList
    Friend WithEvents cmbPerfil As DevExpress.XtraEditors.LookUpEdit

End Class
