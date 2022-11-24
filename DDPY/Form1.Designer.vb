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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.sldMinLen = New System.Windows.Forms.TrackBar()
        Me.sldMinDif = New System.Windows.Forms.TrackBar()
        Me.sldMaxLen = New System.Windows.Forms.TrackBar()
        Me.sldMaxDif = New System.Windows.Forms.TrackBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtMinLen = New System.Windows.Forms.TextBox()
        Me.txtMaxLen = New System.Windows.Forms.TextBox()
        Me.txtMinDif = New System.Windows.Forms.TextBox()
        Me.txtMaxDif = New System.Windows.Forms.TextBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.openFD = New System.Windows.Forms.OpenFileDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.sldMinLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMinDif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMaxLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMaxDif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sldMinLen
        '
        Me.sldMinLen.Location = New System.Drawing.Point(23, 226)
        Me.sldMinLen.Maximum = 90
        Me.sldMinLen.Name = "sldMinLen"
        Me.sldMinLen.Size = New System.Drawing.Size(521, 45)
        Me.sldMinLen.TabIndex = 0
        '
        'sldMinDif
        '
        Me.sldMinDif.LargeChange = 1
        Me.sldMinDif.Location = New System.Drawing.Point(599, 226)
        Me.sldMinDif.Maximum = 5
        Me.sldMinDif.Minimum = 1
        Me.sldMinDif.Name = "sldMinDif"
        Me.sldMinDif.Size = New System.Drawing.Size(120, 45)
        Me.sldMinDif.TabIndex = 1
        Me.sldMinDif.Value = 1
        '
        'sldMaxLen
        '
        Me.sldMaxLen.AutoSize = False
        Me.sldMaxLen.Location = New System.Drawing.Point(23, 267)
        Me.sldMaxLen.Maximum = 90
        Me.sldMaxLen.Name = "sldMaxLen"
        Me.sldMaxLen.Size = New System.Drawing.Size(521, 45)
        Me.sldMaxLen.TabIndex = 2
        Me.sldMaxLen.Value = 90
        '
        'sldMaxDif
        '
        Me.sldMaxDif.LargeChange = 1
        Me.sldMaxDif.Location = New System.Drawing.Point(599, 277)
        Me.sldMaxDif.Maximum = 5
        Me.sldMaxDif.Minimum = 1
        Me.sldMaxDif.Name = "sldMaxDif"
        Me.sldMaxDif.Size = New System.Drawing.Size(120, 45)
        Me.sldMaxDif.TabIndex = 3
        Me.sldMaxDif.Value = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(745, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Bang!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(23, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'txtMinLen
        '
        Me.txtMinLen.Enabled = False
        Me.txtMinLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinLen.Location = New System.Drawing.Point(550, 226)
        Me.txtMinLen.MaxLength = 2
        Me.txtMinLen.Name = "txtMinLen"
        Me.txtMinLen.Size = New System.Drawing.Size(43, 35)
        Me.txtMinLen.TabIndex = 6
        Me.txtMinLen.Text = "0"
        Me.txtMinLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxLen
        '
        Me.txtMaxLen.Enabled = False
        Me.txtMaxLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxLen.Location = New System.Drawing.Point(550, 277)
        Me.txtMaxLen.MaxLength = 2
        Me.txtMaxLen.Name = "txtMaxLen"
        Me.txtMaxLen.Size = New System.Drawing.Size(43, 35)
        Me.txtMaxLen.TabIndex = 7
        Me.txtMaxLen.Text = "90"
        Me.txtMaxLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMinDif
        '
        Me.txtMinDif.Enabled = False
        Me.txtMinDif.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinDif.Location = New System.Drawing.Point(725, 226)
        Me.txtMinDif.MaxLength = 1
        Me.txtMinDif.Name = "txtMinDif"
        Me.txtMinDif.Size = New System.Drawing.Size(43, 35)
        Me.txtMinDif.TabIndex = 8
        Me.txtMinDif.Text = "1"
        Me.txtMinDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxDif
        '
        Me.txtMaxDif.Enabled = False
        Me.txtMaxDif.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxDif.Location = New System.Drawing.Point(725, 277)
        Me.txtMaxDif.MaxLength = 1
        Me.txtMaxDif.Name = "txtMaxDif"
        Me.txtMaxDif.Size = New System.Drawing.Size(43, 35)
        Me.txtMaxDif.TabIndex = 9
        Me.txtMaxDif.Text = "5"
        Me.txtMaxDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Arinitra Chandler", "Bobby ", "Christina Russell", "Dave Orth", "DDP", "Dylan ", "Garett Sakahara", "Haydn Walden", "Jen ", "Jim Mabes", "Josh ", "King Warren", "Lexy ", "Paal ", "Pat McDermott", "Payge McMahon", "Ricky Tran ", "Roman ", "Scott French ", "Stevie Richards", "Travis ", "Yoga Doc"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(23, 351)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(570, 109)
        Me.CheckedListBox1.TabIndex = 10
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(599, 351)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(169, 109)
        Me.CheckedListBox2.TabIndex = 11
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(599, 328)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Everyday"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(23, 328)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(71, 17)
        Me.CheckBox2.TabIndex = 13
        Me.CheckBox2.Text = "Everyone"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Workout Length - Min && Max"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(596, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Workout Difficulty - Min && Max"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(23, 495)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(745, 23)
        Me.ProgressBar1.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(668, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Import CSV"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'openFD
        '
        Me.openFD.FileName = "OpenFileDialog1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(668, 41)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 23)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Import HTML"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 525)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.txtMaxDif)
        Me.Controls.Add(Me.txtMinDif)
        Me.Controls.Add(Me.txtMaxLen)
        Me.Controls.Add(Me.txtMinLen)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.sldMaxDif)
        Me.Controls.Add(Me.sldMaxLen)
        Me.Controls.Add(Me.sldMinDif)
        Me.Controls.Add(Me.sldMinLen)
        Me.Name = "Form1"
        Me.Text = "DDPY Workout Generator"
        CType(Me.sldMinLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMinDif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMaxLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMaxDif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sldMinLen As Windows.Forms.TrackBar
    Friend WithEvents sldMinDif As Windows.Forms.TrackBar
    Friend WithEvents sldMaxLen As Windows.Forms.TrackBar
    Friend WithEvents sldMaxDif As Windows.Forms.TrackBar
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents txtMinLen As Windows.Forms.TextBox
    Friend WithEvents txtMaxLen As Windows.Forms.TextBox
    Friend WithEvents txtMinDif As Windows.Forms.TextBox
    Friend WithEvents txtMaxDif As Windows.Forms.TextBox
    Friend WithEvents CheckedListBox1 As Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As Windows.Forms.CheckBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents openFD As Windows.Forms.OpenFileDialog
    Friend WithEvents Button3 As Windows.Forms.Button
End Class
