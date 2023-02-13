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
                                Me.Controls("txtSun" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 1
                                Me.Controls("txtMon" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 2
                                Me.Controls("txtTue" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 3
                                Me.Controls("txtWed" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 4
                                Me.Controls("txtThur" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 5
                                Me.Controls("txtFri" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
                            Case 6
                                Me.Controls("txtSat" & x).Text = workoutsout & " " & GlobalVariables.workoutlist(workoutsout) & Chr(13) & Chr(10) & GlobalVariables.instructorlist(workoutsout) & " - L" & GlobalVariables.Difflist(workoutsout) & " - " & GlobalVariables.Lengthlist(workoutsout) & "mins"
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
End Class