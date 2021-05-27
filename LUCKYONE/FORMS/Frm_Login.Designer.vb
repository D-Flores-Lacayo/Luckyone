<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Login
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Login))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.txtusuario = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtpass = New DevExpress.XtraEditors.ButtonEdit()
        Me.Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LblInformacion = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = Global.LUCKYONE.My.Resources.Resources.generic_user_purple
        Me.PictureEdit1.Location = New System.Drawing.Point(90, 44)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(170, 169)
        Me.PictureEdit1.TabIndex = 0
        '
        'txtusuario
        '
        Me.txtusuario.Location = New System.Drawing.Point(62, 235)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Properties.Appearance.Options.UseFont = True
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        SerializableAppearanceObject1.Image = CType(resources.GetObject("SerializableAppearanceObject1.Image"), System.Drawing.Image)
        SerializableAppearanceObject1.Options.UseImage = True
        Me.txtusuario.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtusuario.Size = New System.Drawing.Size(220, 38)
        Me.txtusuario.TabIndex = 1
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(62, 288)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.Properties.Appearance.Options.UseFont = True
        EditorButtonImageOptions2.Image = CType(resources.GetObject("EditorButtonImageOptions2.Image"), System.Drawing.Image)
        SerializableAppearanceObject5.Image = CType(resources.GetObject("SerializableAppearanceObject5.Image"), System.Drawing.Image)
        SerializableAppearanceObject5.Options.UseImage = True
        Me.txtpass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, True, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtpass.Properties.UseSystemPasswordChar = True
        Me.txtpass.Size = New System.Drawing.Size(220, 38)
        Me.txtpass.TabIndex = 2
        '
        'Aceptar
        '
        Me.Aceptar.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.Appearance.Options.UseFont = True
        Me.Aceptar.ImageOptions.Image = CType(resources.GetObject("Aceptar.ImageOptions.Image"), System.Drawing.Image)
        Me.Aceptar.Location = New System.Drawing.Point(62, 341)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(85, 34)
        Me.Aceptar.TabIndex = 3
        Me.Aceptar.Text = "Aceptar"
        '
        'cancelar
        '
        Me.cancelar.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelar.Appearance.Options.UseFont = True
        Me.cancelar.ImageOptions.Image = CType(resources.GetObject("cancelar.ImageOptions.Image"), System.Drawing.Image)
        Me.cancelar.Location = New System.Drawing.Point(193, 341)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(89, 34)
        Me.cancelar.TabIndex = 4
        Me.cancelar.Text = "Cancelar"
        '
        'LblInformacion
        '
        Me.LblInformacion.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInformacion.Appearance.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.LblInformacion.Appearance.Options.UseFont = True
        Me.LblInformacion.Appearance.Options.UseForeColor = True
        Me.LblInformacion.Location = New System.Drawing.Point(103, 392)
        Me.LblInformacion.Name = "LblInformacion"
        Me.LblInformacion.Size = New System.Drawing.Size(78, 13)
        Me.LblInformacion.TabIndex = 5
        Me.LblInformacion.Text = "LabelControl1"
        '
        'Frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile
        Me.BackgroundImageStore = Global.LUCKYONE.My.Resources.Resources.soft_cloudy_is_gradient_pastel_abstract_sky_background_sweet_color_6529_628
        Me.ClientSize = New System.Drawing.Size(355, 406)
        Me.Controls.Add(Me.LblInformacion)
        Me.Controls.Add(Me.cancelar)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.PictureEdit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_Login"
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtusuario As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtpass As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblInformacion As DevExpress.XtraEditors.LabelControl
End Class
