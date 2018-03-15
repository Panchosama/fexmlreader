Imports Microsoft.Reporting.WinForms

Public Class Form1
    'Dim archivo As String

    Private Function AbrirArchivo()
        Dim ofd = OpenFileDialog1
        Dim archivo As String = " "
        ofd.Filter = "Archivo XML (*.xml)|*.xml"
        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            archivo = ofd.FileName
        End If
        Return archivo
    End Function
    Sub CargaEmisor(archivo As String)

        Dim xmld As Xml.XmlDocument
        Dim xmlist As Xml.XmlNodeList
        Dim xmlistdoc As Xml.XmlNodeList
        Dim xmlisttot As Xml.XmlNodeList
        Dim xmln As Xml.XmlNode
        xmld = New Xml.XmlDocument()
        xmld.Load(archivo)
        lblArchivo.Text = System.IO.Path.GetFileName(archivo)

        'MessageBox.Show(xmlist)
        xmlist = xmld.GetElementsByTagName("Emisor")
        For Each xmln In xmlist

            Dim rutEmisor = xmln.ChildNodes.Item(0).InnerText
            Dim rznSocial = xmln.ChildNodes.Item(1).InnerText
            Dim giroEmis = xmln.ChildNodes.Item(2).InnerText

            txtRut.Text = rutEmisor
            txtRazonSocial.Text = rznSocial
            txtGiro.Text = giroEmis

        Next
        xmlistdoc = xmld.GetElementsByTagName("IdDoc")
        For Each xmln In xmlistdoc
            Dim folio = xmln.ChildNodes.Item(1).InnerText
            Dim fechaEm = xmln.ChildNodes.Item(2).InnerText

            txtFolio.Text = folio
            txtFecha.Text = fechaEm

        Next
        xmlisttot = xmld.GetElementsByTagName("Totales")
        For Each xmln In xmlisttot
            Dim mntNeto As String
            Dim iva As String
            Dim exento As String
            Dim iadic As String
            Dim iadictxt As String
            Dim monadic As String

            Dim total = xmln.Item("MntTotal").InnerText

            ' Caso de factura exenta 
            Try
                exento = xmln.Item("MntExe").InnerText
                mntNeto = "0"
                iva = "0"
            Catch e As System.NullReferenceException
                exento = "0"
                mntNeto = xmln.Item("MntNeto").InnerText
                iva = xmln.Item("IVA").InnerText
                'End If
            End Try
            ' Impuesto adicional
            monadic = ""
            iadictxt = ""
            Try
                iadic = xmln.Item("ImptoReten").ChildNodes.Item(0).InnerText
                Select Case iadic
                    Case "28"
                        iadictxt = "Impuesto adicional al Diesel"
                        monadic = xmln.Item("ImptoReten").ChildNodes.Item(1).InnerText

                End Select
            Catch e As System.NullReferenceException
                iadictxt = "Sin impuesto adicional"
                monadic = "0"
            End Try

            'MessageBox.Show("tipo: " + iadictxt + " - Monto: $" + monadic)

            txtNeto.Text = mntNeto
            txtIva.Text = iva
            txtTotal.Text = total
            txtExento.Text = exento
            txtMntAdic.Text = monadic
            txtImpAdic.Text = iadictxt
        Next
    End Sub
    Private Sub LeerXMLButton_Click(sender As System.Object, e As EventArgs) Handles LeerXMLButton.Click
        'Dim filePath As String = "C:\Users\Informática\Desktop\fe xml\prisa.xml"
        Try
            Dim filePath As String = AbrirArchivo()
            FacturaDataSet.Clear()

            FacturaDataSet.ReadXml(filePath)
            CargaEmisor(filePath)

        Catch ex As System.ArgumentNullException
            'MessageBox.Show("Error: " + ex.Message)
            Exit Sub

        End Try

        DataGridView1.DataSource = FacturaDataSet
        DataGridView1.DataMember = "Detalle"

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim frmInf As New Form2
        frmInf.Show()
        'MessageBox.Show(f.Emisor)

    End Sub

    Public Class Factura
        Public Property Folio() As String
        Public Property FechaFact() As String
        Public Property Emisor() As String
        Public Property Rut() As String
        Public Property Giro() As String
        Public Property MntNeto() As String
        Public Property MntExento() As String
        Public Property ImpAdicTxt() As String
        Public Property ImpAdicMnt() As String
        Public Property IVA() As String
        Public Property Total() As String

    End Class

    Public Class Detalle
        Public Property Numero() As String
        Public Property Dato() As String

    End Class

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class
