Imports System.CodeDom
Imports System.Collections.Generic
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Security.Policy
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Module mainModule

    Sub Main()

    End Sub
End Module

Public Class Form1
    Private Async Sub CheckAndUpdateFilesFromGitHub()
        ' Replace with your actual GitHub username and repo
        Dim githubUser As String = "dgparryuk"
        Dim githubRepo As String = "DDPY"
        Dim branch As String = "master" ' or "master" or your branch name

        Dim files As String() = {"DDPY.csv", "InstructorSummary.txt", "WorkoutNumbers.txt"}

        For Each file In files
            Dim rawUrl As String = $"https://raw.githubusercontent.com/dgparryuk/DDPY/refs/heads/master/DDPY/{file}"
            Dim localPath As String = Path.Combine(Application.StartupPath, file)
            Try
                Using client As New WebClient()
                    ' Download the remote file content
                    Dim remoteContent As String = Await client.DownloadStringTaskAsync(rawUrl)

                    ' If the file does not exist locally, or the content is different, update it
                    Dim needsUpdate As Boolean = True
                    If System.IO.File.Exists(localPath) Then
                        Dim localContent As String = System.IO.File.ReadAllText(localPath)
                        If localContent = remoteContent Then
                            needsUpdate = False
                        End If
                    End If

                    If needsUpdate Then
                        System.IO.File.WriteAllText(localPath, remoteContent)
                        MessageBox.Show($"{file} updated from GitHub.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalVariables.banged = 0
        Dim WorkoutNumbers = System.IO.File.ReadAllLines("WorkoutNumbers.txt")
        Dim WorkoutNumbersText As String = ""
        For i = 0 To WorkoutNumbers.GetUpperBound(0)
            WorkoutNumbersText = WorkoutNumbersText & WorkoutNumbers(i) & vbCrLf
        Next
        TextBox4.Text = WorkoutNumbersText
        Dim summaryTxtPath As String = "InstructorSummary.txt"
        If File.Exists(summaryTxtPath) Then
            CheckedListBox1.Items.Clear()
            Dim instructorLines = File.ReadAllLines(summaryTxtPath)
            CheckedListBox1.Items.AddRange(instructorLines)
        End If
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, CheckState.Checked)
        Next
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
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\green.png")
            Case 2
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\blue.png")
            Case 3
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\yellow.png")
            Case 4
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\orange.png")
            Case 5
                picMinDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\red.png")

        End Select
    End Sub
    Private Sub sldMaxDif_Scroll(sender As Object, e As EventArgs) Handles sldMaxDif.Scroll
        If sldMaxDif.Value < sldMinDif.Value Then sldMinDif.Value = sldMaxDif.Value
        Select Case sldMaxDif.Value
            Case 1
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\green.png")
            Case 2
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\blue.png")
            Case 3
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\yellow.png")
            Case 4
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\orange.png")
            Case 5
                picMaxDiff.Image = New System.Drawing.Bitmap("C:\\Users\\david\\source\\repos\\dgparryuk\\DDPY\\Bits\\red.png")

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
                Case "Diamond Dozen"
                    GlobalVariables.includeDD = clbInclude.GetItemChecked(i)
            End Select
        Next

        ' Ensure include is set if exclusive is set
        If GlobalVariables.exclusiveStandStrong = "True" Then GlobalVariables.includeStandStrong = "True"
        If GlobalVariables.exclusiveBedFlex = "True" Then GlobalVariables.includeBedFlex = "True"
        If GlobalVariables.exclusiveChairForce = "True" Then GlobalVariables.includeChairForce = "True"
        If GlobalVariables.exclusiveJacked = "True" Then GlobalVariables.includeJacked = "True"

        For i = 0 To 6
            GlobalVariables.days(i) = CheckedListBox2.GetItemChecked(i)
        Next

        ' Use actual count of instructors
        Dim instructorCount As Integer = CheckedListBox1.Items.Count
        For i = 0 To instructorCount - 1
            Dim itemText As String = CheckedListBox1.Items(i).ToString()
            Dim instructorName As String = itemText.Split("-"c)(0).Trim()
            GlobalVariables.ListofInstructors(i) = instructorName
            GlobalVariables.ListofInstructorsChecked(i) = CheckedListBox1.GetItemChecked(i)

        Next

        GlobalVariables.totalworkouts = GlobalVariables.daycount * 13

        Do Until GlobalVariables.workoutsdone = GlobalVariables.totalworkouts
            Randomize()
            GlobalVariables.linegrab = Int(GlobalVariables.fileLines.GetUpperBound(0) * Rnd())
            GlobalVariables.splitString = Split(GlobalVariables.fileLines(GlobalVariables.linegrab), ",")

            ' Defensive: skip if not enough columns
            If GlobalVariables.splitString.Length < 5 Then Continue Do

            Dim tags As String = GlobalVariables.splitString(4)
            Dim allowed As String = ""

            If GlobalVariables.exclusiveBedFlex = "True" And tags.Contains("Bed Flex") Then allowed = "yes"
            If GlobalVariables.exclusiveStandStrong = "True" And tags.Contains("Stand Strong") Then allowed = "yes"
            If GlobalVariables.exclusiveChairForce = "True" And tags.Contains("Chair Force") Then allowed = "yes"
            If GlobalVariables.exclusiveJacked = "True" And tags.Contains("JACKED") Then allowed = "yes"

            If GlobalVariables.exclusiveStandStrong = "False" And GlobalVariables.exclusiveBedFlex = "False" And GlobalVariables.exclusiveChairForce = "False" And GlobalVariables.exclusiveJacked = "False" Then allowed = "yes"

            If GlobalVariables.includeBedFlex = "False" And tags.Contains("Bed Flex") Then allowed = ""
            If GlobalVariables.includeStandStrong = "False" And tags.Contains("Stand Strong") Then allowed = ""
            If GlobalVariables.includeChairForce = "False" And tags.Contains("Chair Force") Then allowed = ""
            If GlobalVariables.includeJacked = "False" And tags.Contains("JACKED") Then allowed = ""
            If GlobalVariables.includeDD = "False" And tags.Contains("Diamond Dozen") Then allowed = ""

            ' Convert to integer for comparison
            Dim workoutDif As Integer
            Dim workoutLen As Integer
            If Not Integer.TryParse(GlobalVariables.splitString(3), workoutDif) Then Continue Do
            If Not Integer.TryParse(GlobalVariables.splitString(2), workoutLen) Then Continue Do

            If workoutDif >= GlobalVariables.MinDif AndAlso workoutDif <= GlobalVariables.MaxDif Then
                If workoutLen >= GlobalVariables.MinLen AndAlso workoutLen <= GlobalVariables.MaxLen Then
                    If allowed = "yes" Then
                        For i = 0 To instructorCount - 1
                            Dim Item As Object = GlobalVariables.ListofInstructors(i)
                            If GlobalVariables.ListofInstructorsChecked(i) = True AndAlso Item = GlobalVariables.splitString(1) Then
                                GlobalVariables.workoutsdone = GlobalVariables.workoutsdone + 1
                                ProgressBar1.Value = CInt((GlobalVariables.workoutsdone / GlobalVariables.totalworkouts) * 100)
                                GlobalVariables.workoutlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(0)
                                GlobalVariables.instructorlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(1)
                                GlobalVariables.Lengthlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(2)
                                GlobalVariables.Difflist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(3)
                                xyz = xyz + 1
                                If cbEnableIncDif.Checked = True Then
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
                                            Case "Pat McDermott"
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

    Private Sub cmdImportcsv_Click(sender As Object, e As EventArgs) Handles cmdImportcsv.Click
        'MsgBox("log into DDPYnow website and click on workouts, make sure all work outs are visible")
        'MsgBox("save page as and then open page in a text editor, goto about line 180 (it can change) that starts 'var catergorized' and copy that entire line from [ to the last ] and remove the ;")
        'MsgBox("Goto https://csvjson.com/json2csv and paste in the Seperator to semi-colon, tick flatten, tick json varient")
        'MsgBox("click convert then download and it will save in the downloads folder, now you can carry on")


        Try
            Application.EnableVisualStyles()

            ' Folder picker
            Using folderDialog As New FolderBrowserDialog()
                folderDialog.Description = "Select the folder containing csvjson.csv"
                If folderDialog.ShowDialog() <> DialogResult.OK Then
                    MessageBox.Show("No folder selected. Exiting.")
                    Return
                End If

                Dim folderPath As String = folderDialog.SelectedPath
                Dim inputPath As String = Path.Combine(folderPath, "csvjson.csv")
                Dim outputCsvPath As String = "DDPY.csv"
                Dim summaryTxtPath As String = "InstructorSummary.txt"
                Dim difficultyTxtPath As String = "WorkoutNumbers.txt"
                'Dim outputCsvPath As String = Path.Combine(Application.StartupPath, "DDPY.csv")
                'Dim summaryTxtPath As String = Path.Combine(Application.StartupPath, "InstructorSummary.txt")
                'Dim difficultyTxtPath As String = Path.Combine(Application.StartupPath, "WorkoutNumbers.txt")

                If Not File.Exists(inputPath) Then
                    MessageBox.Show("File 'csvjson.csv' not found in the selected folder.")
                    Return
                End If

                ' Instructors dictionary with aliases mapped to canonical names
                Dim instructors As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
                    {"Arinitra", "Arinitra Chandler"},
                    {"Christina", "Christina Russell"},
                    {"Dave", "Dave Orth"},
                    {"Dr. Tom", "Dr. Tom Walent"},
                    {"Garett", "Garett Sakahara"},
                    {"G-Money", "Garett Sakahara"},
                    {"G-Money!", "Garett Sakahara"},
                    {"Big G", "Garett Sakahara"},
                    {"Big G!", "Garett Sakahara"},
                    {"Garett Sakahara", "Garett Sakahara"},
                    {"Haydn", "Haydn Walden"},
                    {"Jim", "Jim Mabes"},
                    {"Josh", "Josh Nair"},
                    {"King", "King Warren"},
                    {"Pat", "Pat McDermott"},
                    {"Payge", "Payge McMahon"},
                    {"Scott", "Scott French"},
                    {"Yoga Doc", "Yoga Doc"},
                    {"DDP", "DDP"},
                    {"Dallas", "DDP"},
                    {"DPP", "DDP"},
                    {"DDP + John Morrison", "DDP"},
                    {"Dallas and Payge", "DDP"},
                    {"Dallas Steve and Zach Gowen", "DDP"},
                    {"Stevie", "Stevie Richards"},
                    {"Stevie Richards", "Stevie Richards"}
                }

                Dim instructorCounts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
                Dim difficultyCounts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

                Dim lines = File.ReadAllLines(inputPath)
                Dim headers = lines(0).Split(","c).Select(Function(h) h.Trim(""""c)).ToList()
                Dim titleIdx = headers.IndexOf("Videos.Title")
                Dim diffIdx = headers.IndexOf("Videos.Difficulty")
                Dim durIdx = headers.IndexOf("Videos.Duration")
                Dim tagIdx = headers.IndexOf("Videos.Tags.Name")

                If titleIdx = -1 OrElse diffIdx = -1 OrElse durIdx = -1 OrElse tagIdx = -1 Then
                    MessageBox.Show("Required columns not found in csvjson.csv.")
                    Return
                End If

                Dim outputLines As New List(Of String) From {
                "Videos.Title,Instructor,Videos.Duration,Videos.Difficulty,Videos.Tags.Name"
            }

                ' Group by unique video identity (no description)
                Dim grouped = lines.Skip(1).
                Select(Function(line)
                           ' Replace unicode escapes with actual characters
                           line = line.Replace("\u0026", "&").Replace("\u0027", "'")
                           Return line.Split(","c)
                       End Function).
                GroupBy(Function(x) String.Join("|", x(titleIdx), x(diffIdx), x(durIdx)))

                For Each g In grouped
                    Dim first = g.First()
                    Dim tags = g.Select(Function(x) x(tagIdx)).Distinct().ToList()
                    Dim allText = first(titleIdx) & " " & String.Join(";", tags)

                    Dim possibleInstructor As String = ""
                    Dim titleDesc As String = first(titleIdx)

                    ' Regex for " w/ Name", " w Name", or " with Name"
                    Dim match = Regex.Match(titleDesc, "\b(?:w/|w|with)\s+([A-Za-z\s\.\-'\!]+)", RegexOptions.IgnoreCase)
                    If match.Success Then
                        possibleInstructor = match.Groups(1).Value.Trim()
                        possibleInstructor = possibleInstructor.TrimEnd(".", "-", "'", "!")
                        ' Map to canonical name if alias exists
                        If instructors.ContainsKey(possibleInstructor) Then
                            possibleInstructor = instructors(possibleInstructor)
                        End If
                        ' Check for substring matches to avoid duplicates
                        Dim alreadyExists As Boolean = False
                        For Each existing In instructors.Keys
                            If possibleInstructor.IndexOf(existing, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                               existing.IndexOf(possibleInstructor, StringComparison.OrdinalIgnoreCase) >= 0 Then
                                alreadyExists = True
                                Exit For
                            End If
                        Next
                        If Not alreadyExists AndAlso possibleInstructor.Length > 1 Then
                            instructors(possibleInstructor) = possibleInstructor
                        End If
                    End If

                    ' Detect instructors
                    Dim foundInstructors = instructors.
                    Where(Function(kv) Regex.IsMatch(allText, "\b" & Regex.Escape(kv.Key) & "\b", RegexOptions.IgnoreCase)).
                    Select(Function(kv) kv.Value).Distinct().ToList()

                    If foundInstructors.Count = 0 Then foundInstructors.Add("Unknown")

                    ' Convert duration
                    Dim durSec As Integer
                    Integer.TryParse(first(durIdx), durSec)
                    Dim durMin = durSec \ 60

                    ' Count difficulty
                    Dim difficulty = first(diffIdx)
                    If difficultyCounts.ContainsKey(difficulty) Then
                        difficultyCounts(difficulty) += foundInstructors.Count
                    Else
                        difficultyCounts(difficulty) = foundInstructors.Count
                    End If

                    ' Add instructor lines
                    For Each instructorName In foundInstructors
                        Dim namesToWrite As New List(Of String)

                        ' Split on +, and, & (with spaces), and trim
                        Dim splitNames = Regex.Split(instructorName, "\s*(\+| and |&)\s*", RegexOptions.IgnoreCase).
                            Where(Function(n) Not String.IsNullOrWhiteSpace(n) AndAlso n <> "+" AndAlso n.ToLower() <> "and" AndAlso n <> "&").
                            Select(Function(n) n.Trim()).ToList()

                        If splitNames.Count > 1 Then
                            namesToWrite.AddRange(splitNames)
                        Else
                            namesToWrite.Add(instructorName)
                        End If

                        For Each inName In namesToWrite
                            Dim canonicalName As String = inName
                            ' Map aliases to canonical names
                            Select Case canonicalName.ToLower()
                                Case "dallas", "dpp", "ddp"
                                    canonicalName = "DDP"
                                Case "payge"
                                    canonicalName = "Payge McMahon"
                                Case "stevie"
                                    canonicalName = "Stevie Richards"
                                Case "g-money", "g-money!", "big g", "big g!", "garett"
                                    canonicalName = "Garett Sakahara"
                                Case Else
                                    ' Try to match known aliases in instructors dictionary
                                    If instructors.ContainsKey(canonicalName) Then
                                        canonicalName = instructors(canonicalName)
                                    End If
                            End Select

                            If String.Equals(canonicalName, "Unknown", StringComparison.OrdinalIgnoreCase) Then
                                canonicalName = "DDP"
                            End If

                            If instructorCounts.ContainsKey(canonicalName) Then
                                instructorCounts(canonicalName) += 1
                            Else
                                instructorCounts(canonicalName) = 1
                            End If

                            Dim safeTitle = first(titleIdx).Replace("""", """""")
                            Dim safeInstructor = canonicalName.Replace("""", """""")
                            Dim safeTags = String.Join("; ", tags).Replace("""", """""")
                            Dim lineOut = $"{safeTitle},{safeInstructor},{durMin},{difficulty},{safeTags}"
                            outputLines.Add(lineOut)
                        Next
                    Next
                Next

                ' Write CSV
                File.WriteAllLines(outputCsvPath, outputLines)

                ' Instructor summary
                Dim instructorSummary = instructorCounts.
                OrderBy(Function(kv) kv.Key).
                Select(Function(kv) $"{kv.Key} - ({kv.Value})").ToList()
                File.WriteAllLines(summaryTxtPath, instructorSummary)

                ' Difficulty summary
                Dim total = difficultyCounts.Values.Sum()
                Dim difficultySummary = difficultyCounts.
                OrderBy(Function(kv) kv.Key).
                Select(Function(kv)
                           Dim lvl = "Level " & kv.Key.Trim()
                           Dim count = kv.Value.ToString()
                           Return $"{lvl} - {count}"
                       End Function).ToList()
                difficultySummary.Add($"Total   - {total}")
                File.WriteAllLines(difficultyTxtPath, difficultySummary)

                ' Load WorkoutNumbers.txt into TextBox4
                If File.Exists(difficultyTxtPath) Then
                    TextBox4.Text = File.ReadAllText(difficultyTxtPath)
                End If

                ' Load InstructorSummary.txt into CheckedListBox1
                If File.Exists(summaryTxtPath) Then
                    CheckedListBox1.Items.Clear()
                    Dim instructorLines = File.ReadAllLines(summaryTxtPath)
                    CheckedListBox1.Items.AddRange(instructorLines)
                End If

                MessageBox.Show("Import and summary complete.")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        CheckBox2.Checked = False
        CheckBox2.Checked = True

    End Sub

    Private Sub cmdDownload_Click(sender As Object, e As EventArgs) Handles cmdDownload.Click
        CheckAndUpdateFilesFromGitHub()
        Dim summaryTxtPath As String = "InstructorSummary.txt"
        Dim difficultyTxtPath As String = "WorkoutNumbers.txt"

        ' Load WorkoutNumbers.txt into TextBox4
        If File.Exists(difficultyTxtPath) Then
            TextBox4.Text = File.ReadAllText(difficultyTxtPath)
        End If

        ' Load InstructorSummary.txt into CheckedListBox1
        If File.Exists(summaryTxtPath) Then
            CheckedListBox1.Items.Clear()
            Dim instructorLines = File.ReadAllLines(summaryTxtPath)
            CheckedListBox1.Items.AddRange(instructorLines)
        End If
        CheckBox2.Checked = False
        CheckBox2.Checked = True
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
