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
    Public Shared ListofInstructors(50) As String
    Public Shared ListofInstructorsChecked(50) As String

    Public Shared exclusiveStandStrong As String
    Public Shared exclusiveBedFlex As String
    Public Shared exclusiveChairForce As String
    Public Shared exclusiveJacked As String
    Public Shared includeStandStrong As String
    Public Shared includeBedFlex As String
    Public Shared includeChairForce As String
    Public Shared includeJacked As String
    Public Shared includeDD As String
End Class

