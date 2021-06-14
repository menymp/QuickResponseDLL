''' <summary>
''' Contenedor de datos para un evento de QRQC
''' </summary>

Public Class QRQCDataContainer
    ''' <summary>
    ''' numero serial bajo el cual se bloqueara los eventos relacionados
    ''' </summary>
    ''' <returns></returns>
    Public Property SerialNumber As String
    ''' <summary>
    ''' Fecha de acontecimiento del evento
    ''' </summary>
    ''' <returns></returns>
    Public Property DateEvent As String
    ''' <summary>
    ''' Razon 1
    ''' </summary>
    ''' <returns></returns>
    Public Property Reason1 As String
    ''' <summary>
    ''' Razon 2
    ''' </summary>
    ''' <returns></returns>
    Public Property Reason2 As String
    ''' <summary>
    ''' Razon 3
    ''' </summary>
    ''' <returns></returns>
    Public Property Reason3 As String
    ''' <summary>
    ''' Razon 4
    ''' </summary>
    ''' <returns></returns>
    Public Property Reason4 As String
    ''' <summary>
    ''' Razon 5
    ''' </summary>
    ''' <returns></returns>
    Public Property Reason5 As String
    ''' <summary>
    ''' Accion correctiva
    ''' </summary>
    ''' <returns></returns>
    Public Property CorrectiveAction As String
    ''' <summary>
    ''' Accion de contencion
    ''' </summary>
    ''' <returns></returns>
    Public Property ContentionAction As String
    ''' <summary>
    ''' numero de identificador de evento, en caso de existir varios problemas
    ''' </summary>
    ''' <returns></returns>
    Public Property OcurrenceCase As Integer

    Public Overrides Function ToString() As String
        Dim stringRepresentation As String = ""

        stringRepresentation &= vbCrLf
        stringRepresentation &= "[" & SerialNumber & "]" & vbCrLf
        stringRepresentation &= "OcurrenceCase=" & OcurrenceCase.ToString & vbCrLf
        stringRepresentation &= "DateEvent=" & DateEvent & vbCrLf
        stringRepresentation &= "Reason1=" & Reason1 & vbCrLf
        stringRepresentation &= "Reason2=" & Reason2 & vbCrLf
        stringRepresentation &= "Reason3=" & Reason3 & vbCrLf
        stringRepresentation &= "Reason4=" & Reason4 & vbCrLf
        stringRepresentation &= "Reason5=" & Reason5 & vbCrLf
        stringRepresentation &= "CorrectiveAction=" & CorrectiveAction & vbCrLf
        stringRepresentation &= "ContentionAction=" & ContentionAction & vbCrLf

        Return stringRepresentation
    End Function
End Class
