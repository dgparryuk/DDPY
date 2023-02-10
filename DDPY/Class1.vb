Public Class GlobalVariables
    Public Shared daycount As Integer = 0
    Public Shared splitString As String()
    Public Shared totalworkouts As Integer = 0
    Public Shared workoutsdone As Integer = 0
    Public Shared fileLines As String() = System.IO.File.ReadAllLines("DDPY.csv")
    Public Shared linegrab As Integer
    Public Shared workoutlist(92) As String
    Public Shared instructorlist(92) As String
    Public Shared Lengthlist(92) As String
    Public Shared Difflist(92) As String
    Public Shared days(7) As String
    Public Shared banged As Boolean
    Public Shared presorted As String

    Public Shared MinDif As Integer
    Public Shared MaxDif As Integer
    Public Shared MinLen As Integer
    Public Shared MaxLen As Integer
    Public Shared ListofInstructors(22) As String
    Public Shared ListofInstructorsChecked(22) As String
End Class

