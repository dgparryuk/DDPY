Imports System.Linq
Imports System.CodeDom
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Module mainModule

    Sub Main()

    End Sub
End Module



Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalVariables.banged = 0
    End Sub
    Private Sub sldMinLen_Scroll(sender As Object, e As EventArgs) Handles sldMinLen.Scroll
        If sldMinLen.Value > sldMaxLen.Value Then sldMaxLen.Value = sldMinLen.Value
        txtMinLen.Text = sldMinLen.Value
        txtMaxLen.Text = sldMaxLen.Value
    End Sub
    Private Sub sldMaxLen_Scroll(sender As Object, e As EventArgs) Handles sldMaxLen.Scroll
        If sldMaxLen.Value < sldMinLen.Value Then sldMinLen.Value = sldMaxLen.Value
        txtMaxLen.Text = sldMaxLen.Value
        txtMinLen.Text = sldMinLen.Value
    End Sub
    Private Sub sldMinDif_Scroll(sender As Object, e As EventArgs) Handles sldMinDif.Scroll
        If sldMinDif.Value > sldMaxDif.Value Then sldMaxDif.Value = sldMinDif.Value
        Select Case sldMinDif.Value
            Case 1
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\green.png")
            Case 2
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\blue.png")
            Case 3
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\yellow.png")
            Case 4
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\orange.png")
            Case 5
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\red.png")

        End Select
        txtMinDif.Text = sldMinDif.Value
        txtMaxDif.Text = sldMaxDif.Value
    End Sub
    Private Sub sldMaxDif_Scroll(sender As Object, e As EventArgs) Handles sldMaxDif.Scroll
        If sldMaxDif.Value < sldMinDif.Value Then sldMinDif.Value = sldMaxDif.Value
        Select Case sldMinDif.Value
            Case 1
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\green.png")
            Case 2
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\blue.png")
            Case 3
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\yellow.png")
            Case 4
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\orange.png")
            Case 5
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\Parry\\source\\repos\\DDPY\\Bits\\red.png")

        End Select
        txtMaxDif.Text = sldMaxDif.Value
        txtMinDif.Text = sldMinDif.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GlobalVariables.workoutsdone = 0
        GlobalVariables.daycount = CheckedListBox2.CheckedItems.Count
        For i = 0 To 6
            GlobalVariables.days(i) = CheckedListBox2.GetItemChecked(i)
        Next
        GlobalVariables.totalworkouts = GlobalVariables.daycount * 13
        Do Until GlobalVariables.workoutsdone = GlobalVariables.totalworkouts
            Randomize()
            GlobalVariables.linegrab = Int(GlobalVariables.fileLines.GetUpperBound(0) * Rnd())
            GlobalVariables.splitString = Split(GlobalVariables.fileLines(GlobalVariables.linegrab), ",")
            'GlobalVariables.splitString(0) = Workout Name
            'GlobalVariables.splitString(1) = Instructor
            'GlobalVariables.splitString(2) = Workout Length
            'GlobalVariables.splitString(3) = Workout Difficulty
            'GlobalVariables.splitString(4) = Tags

            If GlobalVariables.splitString(3) >= sldMinDif.Value And GlobalVariables.splitString(3) <= sldMaxDif.Value Then
                If GlobalVariables.splitString(2) >= sldMinLen.Value And GlobalVariables.splitString(2) <= sldMaxLen.Value Then
                    'if GlobalVariables.splitString(2) doesnt contain contains
                    For i = 0 To CheckedListBox1.Items.Count - 1
                        Dim Item As Object = CheckedListBox1.Items(i)
                        If CheckedListBox1.GetItemChecked(i) = True And Item = GlobalVariables.splitString(1) Then
                            GlobalVariables.workoutsdone = GlobalVariables.workoutsdone + 1
                            ProgressBar1.Value = (GlobalVariables.workoutsdone \ GlobalVariables.totalworkouts) * 100
                            GlobalVariables.workoutlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(0)
                            GlobalVariables.instructorlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(1)
                            GlobalVariables.Lengthlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(2)
                            GlobalVariables.Difflist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(3)
                        End If
                    Next
                    'end if
                End If
            End If
        Loop
        GlobalVariables.banged = True
        Call New Form2().Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            For i As Integer = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, CheckState.Checked)
            Next
        End If
        If CheckBox1.Checked = False Then
            For i As Integer = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, CheckState.Unchecked)
            Next
        End If

    End Sub


    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, CheckState.Checked)
            Next
        End If
        If CheckBox2.Checked = False Then
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub txtMinLen_TextChanged(sender As Object, e As EventArgs) Handles txtMinLen.TextChanged

    End Sub

    Private Sub txtMaxLen_TextChanged(sender As Object, e As EventArgs) Handles txtMaxLen.TextChanged

    End Sub

    Private Sub txtMinDif_TextChanged(sender As Object, e As EventArgs) Handles txtMinDif.TextChanged
    End Sub

    Private Sub txtMaxDif_TextChanged(sender As Object, e As EventArgs) Handles txtMaxDif.TextChanged


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim update As String = Application.StartupPath & "\DDPY.csv"
        Dim NewCopy As String

        openFD.Title = "Import new csv file"
        openFD.Filter = "DDPY|DDPY.csv"
        openFD.ShowDialog()
        NewCopy = openFD.FileName
        If System.IO.File.Exists(NewCopy) = True Then
            System.IO.File.Delete(update)
            System.IO.File.Copy(NewCopy, update)
            MessageBox.Show("File Copied")
        End If
    End Sub

    Private Sub openFD_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openFD.FileOk

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("log onto DDPYNOW, click on workouts, click on pencil and make sure everyone is ticked, then goto file and 'save page as' then once you've clicked OK on this box select the HTM file you just saved and it will update to the latest workout list")

        'system.IO.File.ReadAllLines("DDPY.csv") 'only for memory

        'Start of actual code
        openFD.InitialDirectory = "C:\"
        openFD.Title = "Open a HTML File"
        openFD.Filter = "DDP Yoga Workouts.htm|DDP Yoga Workouts.htm"
        openFD.ShowDialog()
        Dim HTMLFiletext As String() = System.IO.File.ReadAllLines(openFD.FileName)
        Dim csvFilename As String
        csvFilename = openFD.FileName
        csvFilename = csvFilename.Substring(0, Len(csvFilename) - 3) & "csv"
        Dim x As Integer
        Dim s As Integer
        Dim t As Integer
        Dim p As String
        Dim f As Integer
        Dim sample As String
        Dim linelen As String
        Dim Heading As String
        Dim tester As String
        Dim wname As String
        Dim wcolour As String
        Dim Wdifficulty As String
        Dim Wlength As String
        Dim csvoutput As Integer
        Dim dupecheck As Integer
        Dim Instructorsname As String
        Dim outputtext As String
        Dim outputtext2 As String

        csvoutput = 1
        For x = 1 To HTMLFiletext.GetUpperBound(0)
            '''''''START of EXCEL CODE''''''
            '    Line = Range("A" & i).Value
            '    sample = Left(Line, 4)

            HTMLFiletext(x) = Trim(HTMLFiletext(x))
            If HTMLFiletext(x) <> "" And Len(HTMLFiletext(x)) > 4 Then
                sample = HTMLFiletext(x).Substring(0, 4)
                linelen = Len(HTMLFiletext(x))
                If sample = "<h2>" Then
                    If linelen > 4 Then
                        Heading = HTMLFiletext(x).Substring(4, linelen - 9)
                    End If
                End If

                If sample = "<img" Then
                    For s = 1 To linelen - 3
                        tester = HTMLFiletext(x).Substring(s, 3)
                        If tester = "alt" Then
                            t = s + 5
                            s = linelen
                            If linelen - t - 12 > 0 Then
                                wname = HTMLFiletext(x).Substring(t, (linelen - t - 12))
                                wname = Trim(wname)
                            End If
                        End If
                    Next
                End If

                If sample = "<i c" Then

                    wcolour = HTMLFiletext(x).Substring(26, linelen - 32)
                    If wcolour = "green" Then
                        Wdifficulty = "1"
                    End If
                    If wcolour = "blue" Then
                        Wdifficulty = "2"
                    End If
                    If wcolour = "yellow" Then
                        Wdifficulty = "3"
                    End If
                    If wcolour = "orange" Then
                        Wdifficulty = "4"
                    End If
                    If wcolour = "red" Then
                        Wdifficulty = "5"
                    End If
                End If
                If sample = "<h5>" Then
                    'MsgBox(HTMLFiletext(x))
                    Wlength = HTMLFiletext(x).Substring(4, (Len(HTMLFiletext(x))) - 9)
                    'All Data for line in variables
                    Select Case Heading
                        Case "RECENTLY ADDED"
                            '                'do nothing
                        Case Else '"60+ Minute Workouts", "50 Minute Workouts", "40 Minute Workouts", "30 Minute Workouts", "20 Minute Workouts"
                            wname = Replace(wname, "&amp;", "&")
                            wname = Replace(wname, "&#39;", "'")
                            wname = Replace(wname, "&quot;", """")
                            wname = Replace(wname, "&#233;", "e")
                            wname = Replace(wname, ",", "")
                            Heading = Replace(Heading, "&amp;", "&")
                            Heading = Replace(Heading, "&#39;", "'")
                            Heading = Replace(Heading, "&quot;", """")
                            Heading = Replace(Heading, "&#233;", "e")
                            Heading = Trim(Heading)

                            dupecheck = 0
                            'For Z = 2 To i
                            '    If Worksheets("list of workouts").Range("B" & Z).Value = wname Then
                            '        dupecheck = dupecheck + 1
                            '    End If
                            'Next
                            If dupecheck = 0 Then
                                If wname <> "#= data[i].Title #" Then
                                    If Len(Wlength.Substring(Len(Wlength) - 4)) <> 1 Then
                                        Instructorsname = ""
                                        Select Case Heading
                                            Case "Arinitra Chandler"
                                                Instructorsname = Heading
                                            Case "Christina Russell", "Prenatal", "Christina & Elves "
                                                Instructorsname = "Christina Russell"
                                            Case "Dave Orth"
                                                Instructorsname = Heading
                                            Case "DDP LIVE"
                                                Instructorsname = "DDP"
                                            Case "Garett Sakahara"
                                                Instructorsname = Heading
                                            Case "Haydn Walden"
                                                Instructorsname = Heading
                                            Case "Jim Mabes"
                                                Instructorsname = Heading
                                            Case "King Warren"
                                                Instructorsname = Heading
                                            Case "Pat McDermott"
                                                Instructorsname = Heading
                                            Case "Payge McMahon"
                                                Instructorsname = Heading
                                            Case "Yoga Doc"
                                                Instructorsname = Heading
                                        End Select
                                        If Instructorsname = "" Then
                                            f = Len(wname)
                                            For q = 1 To f - 3
                                                p = wname.Substring(q, 3)
                                                If p = "w/ " Then
                                                    Instructorsname = wname.Substring(q + 3, f - q - 3)
                                                End If
                                            Next
                                        End If
                                        If Instructorsname = "" Then
                                            For q = 1 To f - 2
                                                p = wname.Substring(q, 2)
                                                If p = "w " Then
                                                    Instructorsname = wname.Substring(q + 2, f - q - 2)
                                                End If
                                            Next
                                        End If
                                        If Instructorsname = "" Then
                                            For q = 1 To f - 5
                                                p = wname.Substring(q, 5)
                                                If p = "with " Then
                                                    Instructorsname = wname.Substring(q + 5, f - q - 5)

                                                End If
                                            Next
                                        End If
                                        Trim(Instructorsname)

                                        Select Case Instructorsname
                                            Case "Arinitra", "Arinitra Chandler"
                                                Instructorsname = "Arinitra Chandler"
                                            Case "Bobby"
                                                Instructorsname = "Bobby"
                                            Case "Christina", "Christina & Elves", "Christina Russell"
                                                Instructorsname = "Christina Russell"
                                            Case "Dave Orth"
                                                Instructorsname = "Dave Orth"
                                            Case "Dylan"
                                                Instructorsname = "Dylan"
                                            Case "Garett", "Garett Sakahara", "G-Money!", "Big G!"
                                                Instructorsname = "Garett Sakahara"
                                            Case "Haydn - Advanced", "Haydn", "Haydn Walden", "Haydn - Beginner"
                                                Instructorsname = "Haydn Walden"
                                            Case "Jen"
                                                Instructorsname = "Jen"
                                            Case "Jim", "Jim Mabes"
                                                Instructorsname = "Jim Mabes"
                                            Case "Josh", "Josh and Payge"
                                                Instructorsname = "Josh"
                                            Case "King", "King Warren"
                                                Instructorsname = "King Warren"
                                            Case "Lexy"
                                                Instructorsname = "Lexy"
                                            Case "Paal"
                                                Instructorsname = "Paal"
                                            Case "Pat", "Pat McDermott"
                                                Instructorsname = "Pat McDermott"
                                            Case "Payge", "Payge McMahon"
                                                Instructorsname = "Payge McMahon"
                                            Case "Ricky", "Ricky Tran"
                                                Instructorsname = "Ricky Tran"
                                            Case "Roman"
                                                Instructorsname = "Roman"
                                            Case "Scott French"
                                                Instructorsname = "Scott French"
                                            Case "Stevie", "Stevie Richards"
                                                Instructorsname = "Stevie Richards"
                                            Case "Travis"
                                                Instructorsname = "Travis"
                                            Case "Yoga Doc"
                                                Instructorsname = "Yoga Doc"
                                            Case "The Belt 2.0", "The Belt Classic", "Burn & Exploding", "Dallas", "Dallas and Payge", "DDP - 09.06.2022", "DDP + John Morrison", "DDP 08.23.2022", "Easy Flow", "Stoppers", "Workout", "Dallas Steve and Zach Gowen", "DDP and Payge", "DPP", "Jake The Snake"
                                                Instructorsname = "DDP"
                                        End Select
                                        If Instructorsname = "" Then
                                            Select Case wname
                                                Case "Alligator Planks", "Gator Country", "Gator Sphinx Mania", "Hard & Heavy Technical Package", "Harrier Jet"
                                                    Instructorsname = "Haydn Walden"
                                                Case "Back & Buns 01", "DDPY Pilates", "Roadtrip Edition: Stretching"
                                                    Instructorsname = "Payge McMahon"
                                                Case "Chillin' Light", "Hot Chili"
                                                    Instructorsname = "Jim Mabes"
                                                Case "Core Cracker", "Double Black & Diamond Cutter Hybrid", "Lunge Kick n' Burn", "Rock n Roll Butt Blaster", "Sweatin' Swearin' Shoulders & Legs Flailin'"
                                                    Instructorsname = "Christina Russell"
                                                Case "Total body in 30", "Y.D. Get's Weird", "Get Twisted & Split", "Kickin' Old School"
                                                    Instructorsname = "Yoga Doc"
                                                Case Else
                                                    Instructorsname = "DDP"
                                            End Select
                                        End If
                                        'Write out to file only use wname, wlength, wdifficulty and instructorsname
                                        outputtext = outputtext & wname & "," & Instructorsname & "," & Wlength.Substring(0, (Len(Wlength) - 4)) & "," & Wdifficulty & vbCrLf
                                        'csvoutput = csvoutput + 1

                                    End If
                                End If
                                'End If
                            End If
                    End Select
                End If
            End If
        Next
        System.IO.File.WriteAllText(csvFilename, outputtext)

        Dim lines As New HashSet(Of String)()
        'Read to file
        Using sr As StreamReader = New StreamReader(csvFilename)
            Do While sr.Peek() >= 0
                lines.Add(sr.ReadLine())
            Loop
        End Using

        'Write to file
        Using sw As StreamWriter = New StreamWriter(csvFilename)
            For Each line As String In lines
                sw.WriteLine(line)
            Next
        End Using

        Dim update As String = Application.StartupPath & "\DDPY.csv"

        If System.IO.File.Exists(csvFilename) = True Then
            System.IO.File.Delete(update)
            System.IO.File.Copy(csvFilename, update)
            MessageBox.Show("Workouts Updated")
        End If
    End Sub

    Private Sub txtMinLen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinLen.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If txtMaxLen.Text <> "" And txtMinLen.Text <> "" Then
            If sldMinLen.Value > sldMaxLen.Value Then
                sldMaxLen.Value = sldMinLen.Value
            End If
            sldMinLen.Value = txtMinLen.Text
            sldMaxLen.Value = txtMaxLen.Text
        End If

    End Sub

    Private Sub txtMaxLen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxLen.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If txtMaxLen.Text <> "" And txtMinLen.Text <> "" Then
            If sldMaxLen.Value < sldMinLen.Value Then
                sldMinLen.Value = sldMaxLen.Value
            End If
            sldMaxLen.Value = txtMaxLen.Text
            sldMinLen.Value = txtMinLen.Text
        End If

    End Sub

    Private Sub txtMinDif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinDif.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If txtMaxDif.Text <> "" And txtMinDif.Text <> "" Then
            If sldMinDif.Value > sldMaxDif.Value Then
                sldMaxDif.Value = sldMinDif.Value
            End If
            sldMinDif.Value = txtMinDif.Text
            sldMaxDif.Value = txtMaxDif.Text
        End If

    End Sub

    Private Sub txtMaxDif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxDif.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If txtMaxDif.Text <> "" And txtMinDif.Text <> "" Then
            If sldMaxDif.Value > sldMinDif.Value Then
                sldMinDif.Value = sldMaxDif.Value
            End If
            sldMinDif.Value = txtMinDif.Text
            sldMaxDif.Value = txtMaxDif.Text
        End If
    End Sub

    Private Sub picDiff_Click(sender As Object, e As EventArgs) Handles picMinDiff.Click

    End Sub
End Class