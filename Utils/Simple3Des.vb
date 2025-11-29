Imports System.Security.Cryptography
Imports System.Text

Public Class Simple3Des
    Private ReadOnly TripleDes As New TripleDESCryptoServiceProvider

    Private Function TruncateHash(key As String, length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider
        Dim keyBytes() As Byte = Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Public Sub New(key As String)
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Public Function EncryptData(plaintext As String) As String
        Dim plaintextBytes() As Byte = Encoding.Unicode.GetBytes(plaintext)
        Using ms As New IO.MemoryStream()
            Using encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write)
                encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
                encStream.FlushFinalBlock()
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    Public Function DecryptData(encryptedtext As String) As String
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
        Using ms As New IO.MemoryStream()
            Using decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), CryptoStreamMode.Write)
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
                decStream.FlushFinalBlock()
                Return Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
    End Function
End Class
