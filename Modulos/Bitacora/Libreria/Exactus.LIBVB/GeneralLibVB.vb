Imports System.Net
Imports System.Windows
Imports System.Windows.Forms

Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Public Class GeneralLibVB
    Shared Function ObtenerIpLocal() As String
        '-------------------------------------------------------------------------------------------
        'Descripción: <Obtener la IP del equipo local>
        'Parámetros:  <Ninguno>
        'Regresa:     <La direccion IP en forma de cadena>
        '-------------------------------------------------------------------------------------------
        Dim mIpHostEntry As IPHostEntry

        mIpHostEntry = Dns.GetHostEntry(My.Computer.Name)
        ObtenerIpLocal = mIpHostEntry.AddressList(2).ToString
    End Function

    Shared Function ObtenerIp() As String

        Dim ip As System.Net.IPHostEntry

        ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
        ObtenerIp = ip.AddressList(0).ToString
    End Function

    Shared Function NombrePC() As String

        NombrePC = My.Computer.Name.ToString
    End Function

    Shared Function ObtenerMac() As String
        Dim str As String
        Dim p As New Process

        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = "GetMac.exe"
        p.StartInfo.Arguments = "/fo list"
        p.Start()

        'StandardOutput Obtiene una secuencia que se utiliza
        str = p.StandardOutput.ReadLine
        str = p.StandardOutput.ReadLine
        p.WaitForExit()
        Return str.Substring(23)

    End Function
End Class




'Imports System.Net
'Imports System.Windows
'Imports System.Windows.Forms

'Imports System.DirectoryServices
'Imports System.DirectoryServices.AccountManagement

'Public Class GeneralLibVB
'    Shared Function ObtenerIpLocal() As String
'        '-------------------------------------------------------------------------------------------
'        'Descripción: <Obtener la IP del equipo local>
'        'Parámetros:  <Ninguno>
'        'Regresa:     <La direccion IP en forma de cadena>
'        '-------------------------------------------------------------------------------------------
'        Dim mIpHostEntry As IPHostEntry

'        mIpHostEntry = Dns.GetHostEntry(My.Computer.Name)
'        ObtenerIpLocal = mIpHostEntry.AddressList(2).ToString
'    End Function

'    Shared Function ObtenerIp() As String

'        Dim ip As System.Net.IPHostEntry

'        ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
'        ObtenerIp = ip.AddressList(0).ToString
'    End Function

'    Shared Function NombrePC() As String

'        NombrePC = My.Computer.Name.ToString
'    End Function

'    Shared Function ObtenerMac() As String
'        Dim str As String
'        Dim p As New Process

'        p.StartInfo.UseShellExecute = False
'        p.StartInfo.RedirectStandardOutput = True
'        p.StartInfo.FileName = "GetMac.exe"
'        p.StartInfo.Arguments = "/fo list"
'        p.Start()

'        'StandardOutput Obtiene una secuencia que se utiliza
'        str = p.StandardOutput.ReadLine
'        str = p.StandardOutput.ReadLine
'        p.WaitForExit()
'        Return str.Substring(23)

'    End Function
'End Class
