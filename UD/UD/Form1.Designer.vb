<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("Papyrus", 22F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(55, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(256, 58)
        Label1.TabIndex = 0
        Label1.Text = "Библиотека"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(79, 116)
        Button1.Name = "Button1"
        Button1.Size = New Size(232, 43)
        Button1.TabIndex = 1
        Button1.Text = "Внести данные"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(79, 190)
        Button2.Name = "Button2"
        Button2.Size = New Size(232, 43)
        Button2.TabIndex = 2
        Button2.Text = "Просмотреть данные"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button3.Location = New Point(79, 259)
        Button3.Name = "Button3"
        Button3.Size = New Size(232, 43)
        Button3.TabIndex = 3
        Button3.Text = "Режим администр."
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.ButtonShadow
        Button4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button4.ForeColor = SystemColors.ButtonHighlight
        Button4.Location = New Point(79, 360)
        Button4.Name = "Button4"
        Button4.Size = New Size(232, 43)
        Button4.TabIndex = 4
        Button4.Text = "Выход"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(378, 450)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Главная форма"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
