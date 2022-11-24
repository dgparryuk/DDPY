Public Class GlobalVariables
    Public Shared daycount As Integer = 0
    Public Shared splitString As String()
    Public Shared totalworkouts As Integer = 0
    Public Shared workoutsdone As Integer = 0
    Public Shared fileLines As String() = System.IO.File.ReadAllLines("DDPY.csv")
    Public Shared linegrab As Integer
    Public Shared workoutlist(91) As String
    Public Shared instructorlist(91) As String
    Public Shared Lengthlist(91) As String
    Public Shared Difflist(91) As String
    Public Shared days(7) As String
    Public Shared banged As Boolean
    Public Shared presorted As String

End Class

