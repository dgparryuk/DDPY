Imports System.Drawing
Imports System.Drawing.Printing
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

    Private WithEvents printDoc As New PrintDocument

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        ' Set landscape orientation
        printDoc.DefaultPageSettings.Landscape = True

        ' Optionally show print dialog
        Dim dlg As New PrintDialog()
        dlg.Document = printDoc
        If dlg.ShowDialog() = DialogResult.OK Then
            printDoc.Print()
        End If
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        ' Capture the form as a bitmap
        Using bmp As New Bitmap(Me.Width, Me.Height)
            Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))

            ' Calculate scaling to fit the page
            Dim scaleX As Single = e.MarginBounds.Width / bmp.Width
            Dim scaleY As Single = e.MarginBounds.Height / bmp.Height
            Dim scale As Single = Math.Min(scaleX, scaleY)

            Dim printWidth As Integer = CInt(bmp.Width * scale)
            Dim printHeight As Integer = CInt(bmp.Height * scale)

            ' Center the image
            Dim x As Integer = e.MarginBounds.Left + (e.MarginBounds.Width - printWidth) \ 2
            Dim y As Integer = e.MarginBounds.Top + (e.MarginBounds.Height - printHeight) \ 2

            e.Graphics.DrawImage(bmp, x, y, printWidth, printHeight)
        End Using

        e.HasMorePages = False
    End Sub
End Class