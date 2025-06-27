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

    Public Shared exclusiveStandStrong As Boolean
    Public Shared exclusiveBedFlex As Boolean
    Public Shared exclusiveChairForce As Boolean
    Public Shared exclusiveChairWarrior As Boolean
    Public Shared exclusiveJacked As Boolean
    Public Shared includeStandStrong As Boolean
    Public Shared includeBedFlex As Boolean
    Public Shared includeChairForce As Boolean
    Public Shared includeChairWarrior As Boolean
    Public Shared includeJacked As Boolean
    Public Shared includeDD As Boolean
End Class

