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
        Me.txtMinLen = New System.Windows.Forms.TextBox()
        Me.txtMaxLen = New System.Windows.Forms.TextBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.openFD = New System.Windows.Forms.OpenFileDialog()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.clbInclude = New System.Windows.Forms.CheckedListBox()
        Me.picMinDiff = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picMaxDiff = New System.Windows.Forms.PictureBox()
        Me.cblExclusive = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        CType(Me.sldMinLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMinDif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMaxLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldMaxDif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMaxDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'sldMinLen
        '
        Me.sldMinLen.Location = New System.Drawing.Point(22, 181)
        Me.sldMinLen.Maximum = 90
        Me.sldMinLen.Name = "sldMinLen"
        Me.sldMinLen.Size = New System.Drawing.Size(473, 45)
        Me.sldMinLen.TabIndex = 0
        '
        'sldMinDif
        '
        Me.sldMinDif.LargeChange = 1
        Me.sldMinDif.Location = New System.Drawing.Point(6, 16)
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
        Me.sldMaxLen.Location = New System.Drawing.Point(10, 54)
        Me.sldMaxLen.Maximum = 90
        Me.sldMaxLen.Name = "sldMaxLen"
        Me.sldMaxLen.Size = New System.Drawing.Size(473, 45)
        Me.sldMaxLen.TabIndex = 2
        Me.sldMaxLen.Value = 90
        '
        'sldMaxDif
        '
        Me.sldMaxDif.LargeChange = 1
        Me.sldMaxDif.Location = New System.Drawing.Point(6, 60)
        Me.sldMaxDif.Maximum = 5
        Me.sldMaxDif.Minimum = 1
        Me.sldMaxDif.Name = "sldMaxDif"
        Me.sldMaxDif.Size = New System.Drawing.Size(120, 45)
        Me.sldMaxDif.TabIndex = 3
        Me.sldMaxDif.Value = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 525)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(765, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Bang!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtMinLen
        '
        Me.txtMinLen.Enabled = False
        Me.txtMinLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinLen.Location = New System.Drawing.Point(489, 16)
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
        Me.txtMaxLen.Location = New System.Drawing.Point(489, 57)
        Me.txtMaxLen.MaxLength = 2
        Me.txtMaxLen.Name = "txtMaxLen"
        Me.txtMaxLen.Size = New System.Drawing.Size(43, 35)
        Me.txtMaxLen.TabIndex = 7
        Me.txtMaxLen.Text = "90"
        Me.txtMaxLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Arinitra Chandler", "Bobby", "Christina Russell", "Dave Orth", "DDP", "Dylan", "Garett Sakahara", "Haydn Walden", "Jen", "Jim Mabes", "Josh", "King Warren", "Lexy", "Paal", "Pat McDermott", "Payge McMahon", "Ricky Tran", "Roman", "Scott French", "Stevie Richards", "Tom Walent", "Travis", "Yoga Doc"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(10, 42)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(244, 184)
        Me.CheckedListBox1.Sorted = True
        Me.CheckedListBox1.TabIndex = 10
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(6, 19)
        Me.CheckedListBox2.MultiColumn = True
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(166, 109)
        Me.CheckedListBox2.TabIndex = 11
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(6, 134)
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
        Me.CheckBox2.Location = New System.Drawing.Point(10, 17)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(71, 17)
        Me.CheckBox2.TabIndex = 13
        Me.CheckBox2.Text = "Everyone"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 554)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(765, 23)
        Me.ProgressBar1.TabIndex = 17
        '
        'openFD
        '
        Me.openFD.FileName = "OpenFileDialog1"
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(6, 19)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(286, 23)
        Me.cmdImport.TabIndex = 21
        Me.cmdImport.Text = "Import HTML to CSV"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'clbInclude
        '
        Me.clbInclude.FormattingEnabled = True
        Me.clbInclude.Items.AddRange(New Object() {"Bed Flex", "Chair Force", "Jacked", "Stand Strong"})
        Me.clbInclude.Location = New System.Drawing.Point(8, 17)
        Me.clbInclude.Name = "clbInclude"
        Me.clbInclude.Size = New System.Drawing.Size(102, 64)
        Me.clbInclude.Sorted = True
        Me.clbInclude.TabIndex = 22
        '
        'picMinDiff
        '
        Me.picMinDiff.Image = CType(resources.GetObject("picMinDiff.Image"), System.Drawing.Image)
        Me.picMinDiff.InitialImage = Nothing
        Me.picMinDiff.Location = New System.Drawing.Point(165, 11)
        Me.picMinDiff.Name = "picMinDiff"
        Me.picMinDiff.Size = New System.Drawing.Size(50, 50)
        Me.picMinDiff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMinDiff.TabIndex = 25
        Me.picMinDiff.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'picMaxDiff
        '
        Me.picMaxDiff.Image = CType(resources.GetObject("picMaxDiff.Image"), System.Drawing.Image)
        Me.picMaxDiff.Location = New System.Drawing.Point(165, 60)
        Me.picMaxDiff.Name = "picMaxDiff"
        Me.picMaxDiff.Size = New System.Drawing.Size(50, 50)
        Me.picMaxDiff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMaxDiff.TabIndex = 26
        Me.picMaxDiff.TabStop = False
        '
        'cblExclusive
        '
        Me.cblExclusive.FormattingEnabled = True
        Me.cblExclusive.Items.AddRange(New Object() {"Bed Flex", "Chair Force", "Jacked", "Stand Strong"})
        Me.cblExclusive.Location = New System.Drawing.Point(8, 17)
        Me.cblExclusive.Name = "cblExclusive"
        Me.cblExclusive.Size = New System.Drawing.Size(102, 64)
        Me.cblExclusive.Sorted = True
        Me.cblExclusive.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.sldMaxLen)
        Me.GroupBox1.Controls.Add(Me.txtMinLen)
        Me.GroupBox1.Controls.Add(Me.txtMaxLen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 112)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Workout Length - Min && Max"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.sldMinDif)
        Me.GroupBox2.Controls.Add(Me.sldMaxDif)
        Me.GroupBox2.Controls.Add(Me.picMaxDiff)
        Me.GroupBox2.Controls.Add(Me.picMinDiff)
        Me.GroupBox2.Location = New System.Drawing.Point(556, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 112)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Workout Difficulty - Min && Max"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox2)
        Me.GroupBox3.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(265, 236)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Instructors"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(283, 278)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(184, 156)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Days"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.clbInclude)
        Me.GroupBox5.Enabled = False
        Me.GroupBox5.Location = New System.Drawing.Point(657, 373)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(120, 94)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Include"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cblExclusive)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Location = New System.Drawing.Point(657, 278)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(120, 89)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Exclusively"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TextBox3)
        Me.GroupBox7.Controls.Add(Me.TextBox2)
        Me.GroupBox7.Controls.Add(Me.TextBox1)
        Me.GroupBox7.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox7.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Location = New System.Drawing.Point(473, 278)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(178, 102)
        Me.GroupBox7.TabIndex = 13
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Difficulty"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(6, 19)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(166, 20)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = "Increase Min/Max time by "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(66, 41)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(106, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "minutes every"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(66, 65)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(106, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "weeks"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(6, 66)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(54, 20)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(6, 42)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(54, 20)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdImport)
        Me.GroupBox8.Location = New System.Drawing.Point(473, 12)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(298, 141)
        Me.GroupBox8.TabIndex = 33
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Admin-y Stuff"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(787, 589)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.sldMinLen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox8)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DDPY Workout Generator"
        CType(Me.sldMinLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMinDif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMaxLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldMaxDif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinDiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMaxDiff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
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
    Friend WithEvents CheckedListBox1 As Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents openFD As Windows.Forms.OpenFileDialog
    Friend WithEvents cmdImport As Windows.Forms.Button
    Friend WithEvents clbInclude As Windows.Forms.CheckedListBox
    Friend WithEvents picMinDiff As Windows.Forms.PictureBox
    Friend WithEvents picMaxDiff As Windows.Forms.PictureBox
    Friend WithEvents cblExclusive As Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents NumericUpDown2 As Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown1 As Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox8 As Windows.Forms.GroupBox
End Class
