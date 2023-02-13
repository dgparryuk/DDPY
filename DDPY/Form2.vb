Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim workoutsout As Integer
        If GlobalVariables.banged = True Then
            workoutsout = 1
            For x = 1 To 13
                For i = 0 To 6
                    If GlobalVariables.days(i) = True Then
                        Select Case i
                            Case 0
                                Me.Controls("txtSun" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 1
                                Me.Controls("txtMon" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 2
                                Me.Controls("txtTue" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 3
                                Me.Controls("txtWed" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 4
                                Me.Controls("txtThur" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 5
                                Me.Controls("txtFri" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 6
                                Me.Controls("txtSat" & x).Text = GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                        End Select
                        workoutsout = workoutsout + 1
                    End If
                Next
            Next
        End If
        If GlobalVariables.banged = False Then
            MsgBox("bugger")
        End If
    End Sub

    Private Sub pbSun01_Click(sender As Object, e As EventArgs) Handles pbSun1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub
    Private Sub Updatetxtbox(controlnametext As String)


        Randomize()
        GlobalVariables.workoutsdone = 92
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
                            GlobalVariables.workoutlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(0)
                            GlobalVariables.instructorlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(1)
                            GlobalVariables.Lengthlist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(2)
                            GlobalVariables.Difflist(GlobalVariables.workoutsdone) = GlobalVariables.splitString(3)
                            Me.Controls(controlnametext).Text = GlobalVariables.workoutlist(GlobalVariables.workoutsdone) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(GlobalVariables.workoutsdone) & " - L" & GlobalVariables.Difflist(GlobalVariables.workoutsdone) & " - " & GlobalVariables.Lengthlist(GlobalVariables.workoutsdone) & "mins"
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub pbSun2_Click(sender As Object, e As EventArgs) Handles pbSun2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)
    End Sub

    Private Sub pbSun3_Click(sender As Object, e As EventArgs) Handles pbSun3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun4_Click(sender As Object, e As EventArgs) Handles pbSun4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun5_Click(sender As Object, e As EventArgs) Handles pbSun5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun6_Click(sender As Object, e As EventArgs) Handles pbSun6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun7_Click(sender As Object, e As EventArgs) Handles pbSun7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun8_Click(sender As Object, e As EventArgs) Handles pbSun8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun9_Click(sender As Object, e As EventArgs) Handles pbSun9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun10_Click(sender As Object, e As EventArgs) Handles pbSun10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun11_Click(sender As Object, e As EventArgs) Handles pbSun11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun12_Click(sender As Object, e As EventArgs) Handles pbSun12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSun13_Click(sender As Object, e As EventArgs) Handles pbSun13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon1_Click(sender As Object, e As EventArgs) Handles pbMon1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon2_Click(sender As Object, e As EventArgs) Handles pbMon2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon3_Click(sender As Object, e As EventArgs) Handles pbMon3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon4_Click(sender As Object, e As EventArgs) Handles pbMon4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon5_Click(sender As Object, e As EventArgs) Handles pbMon5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon6_Click(sender As Object, e As EventArgs) Handles pbMon6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon7_Click(sender As Object, e As EventArgs) Handles pbMon7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon8_Click(sender As Object, e As EventArgs) Handles pbMon8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon9_Click(sender As Object, e As EventArgs) Handles pbMon9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon10_Click(sender As Object, e As EventArgs) Handles pbMon10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon11_Click(sender As Object, e As EventArgs) Handles pbMon11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon12_Click(sender As Object, e As EventArgs) Handles pbMon12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbMon13_Click(sender As Object, e As EventArgs) Handles pbMon13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue1_Click(sender As Object, e As EventArgs) Handles pbTue1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue2_Click(sender As Object, e As EventArgs) Handles pbTue2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue3_Click(sender As Object, e As EventArgs) Handles pbTue3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue4_Click(sender As Object, e As EventArgs) Handles pbTue4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue5_Click(sender As Object, e As EventArgs) Handles pbTue5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue6_Click(sender As Object, e As EventArgs) Handles pbTue6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue7_Click(sender As Object, e As EventArgs) Handles pbTue7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue8_Click(sender As Object, e As EventArgs) Handles pbTue8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue9_Click(sender As Object, e As EventArgs) Handles pbTue9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue10_Click(sender As Object, e As EventArgs) Handles pbTue10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue11_Click(sender As Object, e As EventArgs) Handles pbTue11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue12_Click(sender As Object, e As EventArgs) Handles pbTue12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbTue13_Click(sender As Object, e As EventArgs) Handles pbTue13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed1_Click(sender As Object, e As EventArgs) Handles pbWed1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed2_Click(sender As Object, e As EventArgs) Handles pbWed2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed3_Click(sender As Object, e As EventArgs) Handles pbWed3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed4_Click(sender As Object, e As EventArgs) Handles pbWed4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed5_Click(sender As Object, e As EventArgs) Handles pbWed5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed6_Click(sender As Object, e As EventArgs) Handles pbWed6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed7_Click(sender As Object, e As EventArgs) Handles pbWed7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed8_Click(sender As Object, e As EventArgs) Handles pbWed8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed9_Click(sender As Object, e As EventArgs) Handles pbWed9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed10_Click(sender As Object, e As EventArgs) Handles pbWed10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed11_Click(sender As Object, e As EventArgs) Handles pbWed11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed12_Click(sender As Object, e As EventArgs) Handles pbWed12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbWed13_Click(sender As Object, e As EventArgs) Handles pbWed13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur1_Click(sender As Object, e As EventArgs) Handles pbThur1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur2_Click(sender As Object, e As EventArgs) Handles pbThur2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur3_Click(sender As Object, e As EventArgs) Handles pbThur3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur4_Click(sender As Object, e As EventArgs) Handles pbThur4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur5_Click(sender As Object, e As EventArgs) Handles pbThur5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur6_Click(sender As Object, e As EventArgs) Handles pbThur6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur7_Click(sender As Object, e As EventArgs) Handles pbThur7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur8_Click(sender As Object, e As EventArgs) Handles pbThur8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur9_Click(sender As Object, e As EventArgs) Handles pbThur9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur10_Click(sender As Object, e As EventArgs) Handles pbThur10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur11_Click(sender As Object, e As EventArgs) Handles pbThur11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur12_Click(sender As Object, e As EventArgs) Handles pbThur12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbThur13_Click(sender As Object, e As EventArgs) Handles pbThur13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri1_Click(sender As Object, e As EventArgs) Handles pbFri1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri2_Click(sender As Object, e As EventArgs) Handles pbFri2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri3_Click(sender As Object, e As EventArgs) Handles pbFri3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri4_Click(sender As Object, e As EventArgs) Handles pbFri4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri5_Click(sender As Object, e As EventArgs) Handles pbFri5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri6_Click(sender As Object, e As EventArgs) Handles pbFri6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri7_Click(sender As Object, e As EventArgs) Handles pbFri7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri8_Click(sender As Object, e As EventArgs) Handles pbFri8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri9_Click(sender As Object, e As EventArgs) Handles pbFri9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri10_Click(sender As Object, e As EventArgs) Handles pbFri10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri11_Click(sender As Object, e As EventArgs) Handles pbFri11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri12_Click(sender As Object, e As EventArgs) Handles pbFri12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbFri13_Click(sender As Object, e As EventArgs) Handles pbFri13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat1_Click(sender As Object, e As EventArgs) Handles pbSat1.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat2_Click(sender As Object, e As EventArgs) Handles pbSat2.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat3_Click(sender As Object, e As EventArgs) Handles pbSat3.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat4_Click(sender As Object, e As EventArgs) Handles pbSat4.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat5_Click(sender As Object, e As EventArgs) Handles pbSat5.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat6_Click(sender As Object, e As EventArgs) Handles pbSat6.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat7_Click(sender As Object, e As EventArgs) Handles pbSat7.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat8_Click(sender As Object, e As EventArgs) Handles pbSat8.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat9_Click(sender As Object, e As EventArgs) Handles pbSat9.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat10_Click(sender As Object, e As EventArgs) Handles pbSat10.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat11_Click(sender As Object, e As EventArgs) Handles pbSat11.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat12_Click(sender As Object, e As EventArgs) Handles pbSat12.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub

    Private Sub pbSat13_Click(sender As Object, e As EventArgs) Handles pbSat13.Click
        Dim controlname = CType(sender, PictureBox).Name
        Dim controlnamelen = Len(controlname)
        Dim controlnametext = "txt" & controlname.Substring(2, controlnamelen - 2)
        Updatetxtbox(controlnametext)

    End Sub
End Class