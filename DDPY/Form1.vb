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
Imports System.ComponentModel.Design
Imports System.Security.Policy

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
    End Sub
    Private Sub sldMaxDif_Scroll(sender As Object, e As EventArgs) Handles sldMaxDif.Scroll
        If sldMaxDif.Value < sldMinDif.Value Then sldMinDif.Value = sldMaxDif.Value
        Select Case sldMaxDif.Value
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xyz = 0
        Dim zyx = 0
        GlobalVariables.MaxDif = sldMaxDif.Value
        GlobalVariables.MinDif = sldMinDif.Value
        GlobalVariables.MaxLen = sldMaxLen.Value
        GlobalVariables.MinLen = sldMinLen.Value

        GlobalVariables.workoutsdone = 0
        GlobalVariables.daycount = CheckedListBox2.CheckedItems.Count
        For i = 0 To 3
            Dim exclusive = cblExclusive.Items(i)
            Dim include = clbInclude.Items(i)
            Select Case exclusive
                Case "Stand Strong"
                    GlobalVariables.exclusiveStandStrong = cblExclusive.GetItemChecked(i)
                Case "Bed Flex"
                    GlobalVariables.exclusiveBedFlex = cblExclusive.GetItemChecked(i)
                Case "Chair Force"
                    GlobalVariables.exclusiveChairForce = cblExclusive.GetItemChecked(i)
                Case "Jacked"
                    GlobalVariables.exclusiveJacked = cblExclusive.GetItemChecked(i)
            End Select
            Select Case include
                Case "Stand Strong"
                    GlobalVariables.includeStandStrong = clbInclude.GetItemChecked(i)
                Case "Bed Flex"
                    GlobalVariables.includeBedFlex = clbInclude.GetItemChecked(i)
                Case "Chair Force"
                    GlobalVariables.includeChairForce = clbInclude.GetItemChecked(i)
                Case "Jacked"
                    GlobalVariables.includeJacked = clbInclude.GetItemChecked(i)
            End Select
            'true 
        Next
        If GlobalVariables.exclusiveStandStrong = "True" Then GlobalVariables.includeStandStrong = "True"
        If GlobalVariables.exclusiveBedFlex = "True" Then GlobalVariables.includeBedFlex = "True"
        If GlobalVariables.exclusiveChairForce = "True" Then GlobalVariables.includeChairForce = "True"
        If GlobalVariables.exclusiveJacked = "True" Then GlobalVariables.includeJacked = "True"

        For i = 0 To 6
            GlobalVariables.days(i) = CheckedListBox2.GetItemChecked(i)
        Next
        For i = 0 To 22
            GlobalVariables.ListofInstructors(i) = CheckedListBox1.Items(i)
            GlobalVariables.ListofInstructorsChecked(i) = CheckedListBox1.GetItemChecked(i)
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
            Dim tags As String = GlobalVariables.splitString(4)
            Dim allowed As String
            If GlobalVariables.exclusiveBedFlex = "True" And tags.Contains("Bed Flex") Then allowed = "yes"
            If GlobalVariables.exclusiveStandStrong = "True" And tags.Contains("Stand Strong") Then allowed = "yes"
            If GlobalVariables.exclusiveChairForce = "True" And tags.Contains("Chair Force") Then allowed = "yes"
            If GlobalVariables.exclusiveJacked = "True" And tags.Contains("JACKED") Then allowed = "yes"

            If GlobalVariables.exclusiveStandStrong = "False" And GlobalVariables.exclusiveBedFlex = "False" And GlobalVariables.exclusiveChairForce = "False" And GlobalVariables.exclusiveJacked = "False" Then allowed = "yes"

            If GlobalVariables.includeBedFlex = "False" And tags.Contains("Bed Flex") Then allowed = ""
            If GlobalVariables.includeStandStrong = "False" And tags.Contains("Stand Strong") Then allowed = ""
            If GlobalVariables.includeChairForce = "False" And tags.Contains("Chair Force") Then allowed = ""
            If GlobalVariables.includeJacked = "False" And tags.Contains("JACKED") Then allowed = ""

            If GlobalVariables.splitString(3) >= GlobalVariables.MinDif And GlobalVariables.splitString(3) <= GlobalVariables.MaxDif Then
                If GlobalVariables.splitString(2) >= GlobalVariables.MinLen And GlobalVariables.splitString(2) <= GlobalVariables.MaxLen Then
                    If allowed = "yes" Then
                        For i = 0 To GlobalVariables.ListofInstructors.Count - 1
                            Dim Item As Object = GlobalVariables.ListofInstructors(i)
                            If GlobalVariables.ListofInstructorsChecked(i) = True And Item = GlobalVariables.splitString(1) Then
                                GlobalVariables.workoutsdone = GlobalVariables.workoutsdone + 1
                                ProgressBar1.Value = (GlobalVariables.workoutsdone \ GlobalVariables.totalworkouts) * 100
                                GlobalVariables.workoutlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(0)
                                GlobalVariables.instructorlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(1)
                                GlobalVariables.Lengthlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(2)
                                GlobalVariables.Difflist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(3)
                                xyz = xyz + 1
                                If cbEnableIncDif.Checked = True Then
                                    'MsgBox(xyz & "-" & NumericUpDown2.Value & "-" & GlobalVariables.MinLen & "-" & GlobalVariables.MaxLen)
                                    If xyz = GlobalVariables.daycount * NumericUpDown2.Value Then
                                        GlobalVariables.MinLen = GlobalVariables.MinLen + NumericUpDown1.Value
                                        GlobalVariables.MaxLen = GlobalVariables.MaxLen + NumericUpDown1.Value
                                        xyz = 0
                                    End If
                                    If GlobalVariables.MinLen > 60 Then
                                        GlobalVariables.MinLen = 60
                                    End If
                                    If GlobalVariables.MaxLen > 90 Then
                                        GlobalVariables.MaxLen = 90
                                    End If

                                End If


                            End If
                        Next
                    End If
                End If
                End If
            allowed = ""


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

    Private Sub txtMinDif_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtMaxDif_TextChanged(sender As Object, e As EventArgs)


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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click

        openFD.InitialDirectory = "C:\"
        openFD.Title = "Open a HTML File"
        openFD.Filter = "DDP Yoga Workouts.htm|DDP Yoga Workouts.htm"
        openFD.ShowDialog()
        Dim HTMLFiletext As String() = System.IO.File.ReadAllLines(openFD.FileName)
        Dim csvFilename As String
        csvFilename = openFD.FileName
        csvFilename = csvFilename.Substring(0, Len(csvFilename) - 3) & "csv"

        Dim a = Trim(HTMLFiletext(180))

        'a = System.Text.RegularExpressions.Regex.Replace(a, "Ordinal.....?.?IsActive", "IsActive")
        ''with comma
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1099,""Name"":""Beginner"",""Ordinal"":1,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Beginner" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1100,""Name"":""Intermediate"",""Ordinal"":3,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Intermediate" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1101,""Name"":""Advanced"",""Ordinal"":4,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Advanced" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1103,""Name"":""DDPY Classics"",""Ordinal"":7,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDPY Classics" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1115,""Name"":""DDPY 4 Kids"",""Ordinal"":8,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDPY 4 Kids" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1119,""Name"":""DDP LIVE"",""Ordinal"":9,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDP LIVE" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1122,""Name"":""Diamond Dozen (The Basics)"",""Ordinal"":10,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Diamond Dozen (The Basics)" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1123,""Name"":""EXTREME"",""Ordinal"":11,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "EXTREME" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1129,""Name"":""No Music"",""Ordinal"":17,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "No Music" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1132,""Name"":""Chair Warrior"",""Ordinal"":77,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Chair Warrior" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1134,""Name"":""Prenatal"",""Ordinal"":12,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Prenatal" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1142,""Name"":""20 Minute Workouts"",""Ordinal"":33,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "20 Minute Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1144,""Name"":""30 Minute Workouts"",""Ordinal"":35,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "30 Minute Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1145,""Name"":""40 Minute Workouts"",""Ordinal"":36,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "40 Minute Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1151,""Name"":""DDPY Rebuild: Bed Flex"",""Ordinal"":13,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDPY Rebuild: Bed Flex" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1152,""Name"":""DDPY Rebuild: Chair Force"",""Ordinal"":14,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDPY Rebuild: Chair Force" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1153,""Name"":""DDPY Rebuild: Stand Strong"",""Ordinal"":15,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "DDPY Rebuild: Stand Strong" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1157,""Name"":""50 Minute Workouts"",""Ordinal"":38,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "50 Minute Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1158,""Name"":""60+ Minute Workouts"",""Ordinal"":39,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "60+ Minute Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1159,""Name"":""Hip, Back and Knee Opener"",""Ordinal"":18,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Hip, Back and Knee Opener" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1169,""Name"":""Christina Russell"",""Ordinal"":19,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Christina Russell" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1170,""Name"":""Haydn Walden"",""Ordinal"":20,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Haydn Walden" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1171,""Name"":""Garett Sakahara"",""Ordinal"":21,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Garett Sakahara" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1172,""Name"":""Jim Mabes"",""Ordinal"":22,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Jim Mabes" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1173,""Name"":""Pat McDermott"",""Ordinal"":23,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Pat McDermott" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1174,""Name"":""Dave Orth"",""Ordinal"":24,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Dave Orth" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1177,""Name"":""Yoga Doc"",""Ordinal"":25,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Yoga Doc" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1178,""Name"":""King Warren"",""Ordinal"":26,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "King Warren" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1179,""Name"":""Arinitra Chandler"",""Ordinal"":27,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Arinitra Chandler" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1180,""Name"":""BONUS DVDs"",""Ordinal"":28,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "BONUS DVDs" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1181,""Name"":""EXTREME 3.0"",""Ordinal"":29,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "EXTREME 3.0" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1183,""Name"":""Stand Up Workouts"",""Ordinal"":30,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Stand Up Workouts" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1184,""Name"":""JACKED 30 min"",""Ordinal"":34,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "JACKED 30 min" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1185,""Name"":""JACKED 50+ min"",""Ordinal"":37,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "JACKED 50+ min" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1195,""Name"":""Chair Force Standing"",""Ordinal"":6,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Chair Force Standing" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1197,""Name"":""Payge McMahon"",""Ordinal"":16,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Payge McMahon" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1198,""Name"":""Holiday/ Novelty"",""Ordinal"":31,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Holiday/ Novelty" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1199,""Name"":""Road Trip Edition"",""Ordinal"":32,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Road Trip Edition" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1200,""Name"":""Josh Nair"",""Ordinal"":111,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Josh Nair" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1201,""Name"":""Ricky Tran"",""Ordinal"":112,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Ricky Tran" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1203,""Name"":""Stand Strong - Warriors Purpose"",""Ordinal"":2,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Stand Strong - Warriors Purpose" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1204,""Name"":""Chair Force - Warriors Purpose"",""Ordinal"":113,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Chair Force - Warriors Purpose" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1205,""Name"":""Bed Flex - Warriors Purpose"",""Ordinal"":114,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Bed Flex - Warriors Purpose" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1206,""Name"":""Scott French"",""Ordinal"":115,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Scott French" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1210,""Name"":""Back Builder"",""Ordinal"":5,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Back Builder" & Chr(34) & "-")
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1211,""Name"":""Tom Walent"",""Ordinal"":121,""IsActive"":true,""IsMilitaryOnly"":false},", Chr(34) & "Tom Walent" & Chr(34) & "-")
        'without comma
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1099,""Name"":""Beginner"",""Ordinal"":1,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Beginner" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1100,""Name"":""Intermediate"",""Ordinal"":3,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Intermediate" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1101,""Name"":""Advanced"",""Ordinal"":4,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Advanced" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1103,""Name"":""DDPY Classics"",""Ordinal"":7,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDPY Classics" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1115,""Name"":""DDPY 4 Kids"",""Ordinal"":8,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDPY 4 Kids" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1119,""Name"":""DDP LIVE"",""Ordinal"":9,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDP LIVE" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1122,""Name"":""Diamond Dozen \(The Basics\)"",""Ordinal"":10,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Diamond Dozen (The Basics)" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1123,""Name"":""EXTREME"",""Ordinal"":11,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "EXTREME" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1129,""Name"":""No Music"",""Ordinal"":17,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "No Music" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1132,""Name"":""Chair Warrior"",""Ordinal"":77,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Chair Warrior" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1134,""Name"":""Prenatal"",""Ordinal"":12,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Prenatal" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1142,""Name"":""20 Minute Workouts"",""Ordinal"":33,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "20 Minute Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1144,""Name"":""30 Minute Workouts"",""Ordinal"":35,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "30 Minute Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1145,""Name"":""40 Minute Workouts"",""Ordinal"":36,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "40 Minute Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1151,""Name"":""DDPY Rebuild: Bed Flex"",""Ordinal"":13,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDPY Rebuild: Bed Flex" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1152,""Name"":""DDPY Rebuild: Chair Force"",""Ordinal"":14,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDPY Rebuild: Chair Force" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1153,""Name"":""DDPY Rebuild: Stand Strong"",""Ordinal"":15,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "DDPY Rebuild: Stand Strong" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1157,""Name"":""50 Minute Workouts"",""Ordinal"":38,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "50 Minute Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1158,""Name"":""60\+ Minute Workouts"",""Ordinal"":39,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "60+ Minute Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1159,""Name"":""Hip, Back and Knee Opener"",""Ordinal"":18,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Hip, Back and Knee Opener" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1169,""Name"":""Christina Russell"",""Ordinal"":19,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Christina Russell" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1170,""Name"":""Haydn Walden"",""Ordinal"":20,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Haydn Walden" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1171,""Name"":""Garett Sakahara"",""Ordinal"":21,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Garett Sakahara" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1172,""Name"":""Jim Mabes"",""Ordinal"":22,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Jim Mabes" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1173,""Name"":""Pat McDermott"",""Ordinal"":23,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Pat McDermott" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1174,""Name"":""Dave Orth"",""Ordinal"":24,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Dave Orth" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1177,""Name"":""Yoga Doc"",""Ordinal"":25,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Yoga Doc" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1178,""Name"":""King Warren"",""Ordinal"":26,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "King Warren" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1179,""Name"":""Arinitra Chandler"",""Ordinal"":27,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Arinitra Chandler" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1180,""Name"":""BONUS DVDs"",""Ordinal"":28,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "BONUS DVDs" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1181,""Name"":""EXTREME 3\.0"",""Ordinal"":29,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "EXTREME 3.0" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1183,""Name"":""Stand Up Workouts"",""Ordinal"":30,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Stand Up Workouts" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1184,""Name"":""JACKED 30 min"",""Ordinal"":34,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "JACKED 30 min" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1185,""Name"":""JACKED 50\+ min"",""Ordinal"":37,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "JACKED 50+ min" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1195,""Name"":""Chair Force Standing"",""Ordinal"":6,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Chair Force Standing" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1197,""Name"":""Payge McMahon"",""Ordinal"":16,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Payge McMahon" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1198,""Name"":""Holiday/ Novelty"",""Ordinal"":31,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Holiday/ Novelty" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1199,""Name"":""Road Trip Edition"",""Ordinal"":32,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Road Trip Edition" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1200,""Name"":""Josh Nair"",""Ordinal"":111,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Josh Nair" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1201,""Name"":""Ricky Tran"",""Ordinal"":112,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Ricky Tran" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1203,""Name"":""Stand Strong - Warriors Purpose"",""Ordinal"":2,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Stand Strong - Warriors Purpose" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1204,""Name"":""Chair Force - Warriors Purpose"",""Ordinal"":113,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Chair Force - Warriors Purpose" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1205,""Name"":""Bed Flex - Warriors Purpose"",""Ordinal"":114,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Bed Flex - Warriors Purpose" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1206,""Name"":""Scott French"",""Ordinal"":115,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Scott French" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1210,""Name"":""Back Builder"",""Ordinal"":5,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Back Builder" & Chr(34))
        a = System.Text.RegularExpressions.Regex.Replace(a, "{""Id"":1211,""Name"":""Tom Walent"",""Ordinal"":121,""IsActive"":true,""IsMilitaryOnly"":false}", Chr(34) & "Tom Walent" & Chr(34))

        a = System.Text.RegularExpressions.Regex.Replace(a, "},{", "}," & Chr(13) & Chr(10) & "{")
        a = System.Text.RegularExpressions.Regex.Replace(a, "\[{", "[" & Chr(13) & Chr(10) & "{")
        a = System.Text.RegularExpressions.Regex.Replace(a, "},""", "}, " & Chr(13) & Chr(10) & """")

        a = System.Text.RegularExpressions.Regex.Replace(a, ":{", ":" & Chr(13) & Chr(10) & "{")

        Dim csv
        Dim wearein
        Dim newstr
        Dim chars
        csv = a ' your lines
        ReDim chars(Len(csv) - 1) 'array for output
        wearein = False
        For i = 1 To Len(csv)
            chars(i - 1) = Mid(csv, i, 1)
            Select Case chars(i - 1)
                Case Chr(34) 'we're in
                    wearein = Not wearein
                Case ","
                    If wearein Then chars(i - 1) = ""
            End Select
        Next
        newstr = Join(chars, "")
        System.IO.File.WriteAllText(csvFilename, newstr)
        Dim outputtext
        Dim CSVFiletext As String() = System.IO.File.ReadAllLines(csvFilename)
        Dim splitString
        Dim Workout
        Dim Instructor
        Dim Wtime
        Dim Difficulty
        Dim Tags
        Dim instructortag
        For x = 1 To CSVFiletext.GetUpperBound(0)
            If Len(CSVFiletext(x)) > 55 Then
                splitString = Split(CSVFiletext(x), ",")
                '1,8,4,3,8
                'Workout,Instructor,time,Difficulty,Tags
                '1 - remove first 7 chars & last char
                '8 - remove first 6 and last char and check for instructor
                '4 - 10-end
                '3 - last character
                '8 - remove first 6 and last char
                Workout = splitString(1).Substring(9, Len(splitString(1)) - 10)
                Workout = Replace(Workout, "\u0026", "&")
                Workout = Replace(Workout, "\u0027", "'")

                instructortag = splitString(8).Substring(8, Len(splitString(8)) - 9)
                Instructor = ""
                If instructortag.contains("Arinitra Chandler") = True Then
                    Instructor = "Arinitra Chandler"
                End If
                If instructortag.contains("Bobby") = True Then
                    Instructor = "Bobby"
                End If
                If instructortag.contains("Christina Russell") = True Then
                    Instructor = "Christina Russell"
                End If
                If instructortag.contains("Dave Orth") = True Then
                    Instructor = "Dave Orth"
                End If
                If instructortag.contains("Dylan") = True Then
                    Instructor = "Dylan"
                End If
                If instructortag.contains("Garett Sakahara") = True Then
                    Instructor = "Garett Sakahara"
                End If
                If instructortag.contains("Haydn Walden") = True Then
                    Instructor = "Haydn Walden"
                End If
                If instructortag.contains("Jen") = True Then
                    Instructor = "Jen"
                End If
                If instructortag.contains("Jim Mabes") = True Then
                    Instructor = "Jim Mabes"
                End If
                If instructortag.contains("Josh") = True Then
                    Instructor = "Josh"
                End If
                If instructortag.contains("King Warren") = True Then
                    Instructor = "King Warren"
                End If
                If instructortag.contains("Lexy") = True Then
                    Instructor = "Lexy"
                End If
                If instructortag.contains("Paal") = True Then
                    Instructor = "Paal"
                End If
                If instructortag.contains("Pat McDermott") = True Then
                    Instructor = "Pat McDermott"
                End If
                If instructortag.contains("Payge McMahon") = True Then
                    Instructor = "Payge McMahon"
                End If
                If instructortag.contains("Ricky Tran") = True Then
                    Instructor = "Ricky Tran"
                End If
                If instructortag.contains("Roman") = True Then
                    Instructor = "Roman"
                End If
                If instructortag.contains("Scott French") = True Then
                    Instructor = "Scott French"
                End If
                If instructortag.contains("Stevie Richards") = True Then
                    Instructor = "Stevie Richards"
                End If
                If instructortag.contains("Travis") = True Then
                    Instructor = "Travis"
                End If
                If instructortag.contains("Tom Walent") = True Then
                    Instructor = "Tom Walent"
                End If
                If instructortag.contains("Yoga Doc") = True Then
                    Instructor = "Yoga Doc"
                End If
                If instructortag.contains("DDP") = True Then
                    Instructor = "DDP"
                End If
                Dim f
                Dim p

                If Instructor = "" Then
                    f = Len(Workout)
                    For q = 1 To f - 3
                        p = Workout.Substring(q, 3)
                        If p = "w/ " Then
                            Instructor = Workout.Substring(q + 3, f - q - 3)
                        End If
                    Next
                End If
                If Instructor = "" Then
                    For q = 1 To f - 2
                        p = Workout.Substring(q, 2)
                        If p = "w " Then
                            Instructor = Workout.Substring(q + 2, f - q - 2)
                        End If
                    Next
                End If
                If Instructor = "" Then
                    For q = 1 To f - 5
                        p = Workout.Substring(q, 5)
                        If p = "with " Then
                            Instructor = Workout.Substring(q + 5, f - q - 5)

                        End If
                    Next
                End If
                If Instructor = "" Or Instructor = "The Belt 2.0" Or Instructor = "Back Pain)" Or Instructor = "Stoppers" Then
                    Instructor = "DDP"
                End If
                If Instructor = "Stevie" Then Instructor = "Stevie Richards"

                Wtime = splitString(4).Substring(11, Len(splitString(4)) - 11)
                Wtime = Wtime \ 60
                Difficulty = splitString(3).Substring(Len(splitString(3)) - 1, 1)
                Tags = splitString(8).Substring(8, Len(splitString(8)) - 9)

                outputtext = outputtext & Trim(Workout) & "," & Trim(Instructor) & "," & Wtime & "," & Difficulty & "," & Tags & vbCrLf

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

End Class