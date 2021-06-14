
Imports System.IO

''' <summary>
''' Conector de QRQC para la administracion de respuesta rapida
''' menymp jun 2021
''' </summary>

Public Class QRQCConnector

    Dim _FilePath As String
    Dim _LocalScopeFilePath As String

    ''' <summary>
    ''' Obtiene o establece la ruta de trabajo para los eventos de QRQC
    ''' </summary>
    ''' <returns></returns>
    Public Property FilePath
        Get
            Return _FilePath
        End Get
        Set(value)
            _FilePath = value
        End Set
    End Property
    ''' <summary>
    ''' Obtiene o establece la ruta de trabajo para los eventos de QRQC generados recientemente
    ''' </summary>
    ''' <returns></returns>
    Public Property LocalScopeFilePath
        Get
            Return _LocalScopeFilePath
        End Get
        Set(value)
            _LocalScopeFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' Crea una nueva instancia de la clase QRQC conector
    ''' </summary>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de un evento QRQC con la informacion necesaria para el procesamiento
    ''' </summary>
    ''' <returns>TRUE si se ha creado la instancia correctamente</returns>
    Public Function CreateNewQRQC(QRQCEventInfo As QRQCDataContainer) As Boolean
        Try
            Dim FileData As String = File.ReadAllText(_FilePath)
            'busca el numero de ocurrencias 
            Dim Counter As Integer = fnStrCnt(FileData, "[" & QRQCEventInfo.SerialNumber & "]")
            QRQCEventInfo.OcurrenceCase = Counter
            FileData &= QRQCEventInfo.ToString
            File.WriteAllText(_FilePath, FileData)

            'escribimos el qrqc en el contexto local
            Dim LocalFileData As String = File.ReadAllText(_LocalScopeFilePath)
            LocalFileData &= QRQCEventInfo.ToString
            File.WriteAllText(_LocalScopeFilePath, LocalFileData)
            Return True
        Catch
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Cierra una instancia existente de QRQC
    ''' </summary>
    ''' <param name="QRQCEventInfo"></param>
    ''' <returns>TRUE si se realizo correctamente</returns>
    Public Function CloseQRQC(QRQCEventInfo As QRQCDataContainer)
        Try
            Dim LocalFileData As String = File.ReadAllText(_LocalScopeFilePath)
            Dim RemovedData = LocalFileData.Replace(QRQCEventInfo.ToString, "")
            File.WriteAllText(_LocalScopeFilePath, RemovedData)

            Dim FileData As String = File.ReadAllText(_FilePath)
            RemovedData = FileData.Replace(QRQCEventInfo.ToString, "")
            File.WriteAllText(_FilePath, RemovedData)
            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Cuenta la cantidad de ocurrencias de una sub cadena en un string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="substr"></param>
    ''' <returns></returns>
    Private Function fnStrCnt(ByVal str As String, ByVal substr As String) As Integer
        fnStrCnt = UBound(Split(LCase(str), substr))
    End Function
End Class
