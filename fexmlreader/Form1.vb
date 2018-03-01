Public Class Form1
    'Dim archivo As String

    Private Function AbrirArchivo()
        Dim ofd = OpenFileDialog1
        ofd.Filter = "Archivo XML (*.xml)|*.xml"
        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Return ofd.FileName
        End If
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
            Dim mntNeto = xmln.ChildNodes.Item(0).InnerText
            Dim iva = xmln.ChildNodes.Item(2).InnerText
            Dim total = xmln.ChildNodes.Item(3).InnerText

            txtNeto.Text = mntNeto
            txtIva.Text = iva
            txtTotal.Text = total
        Next
    End Sub
    Private Sub LeerXMLButton_Click(sender As System.Object, e As EventArgs) Handles LeerXMLButton.Click
        'Dim filePath As String = "C:\Users\Informática\Desktop\fe xml\prisa.xml"
        Try
            Dim filePath As String = AbrirArchivo()
            FacturaDataSet.Clear()

            FacturaDataSet.ReadXml(filePath)
            CargaEmisor(filePath)

        Catch ex As System.NullReferenceException
            'MessageBox.Show("Error: " + ex.Message)
            Exit Sub

        End Try


        DataGridView1.DataSource = FacturaDataSet
        DataGridView1.DataMember = "Detalle"
    End Sub

    Private Sub MostrarSchemaButton_Click(sender As System.Object, e As System.EventArgs)
        Dim swXML As New System.IO.StringWriter()
        FacturaDataSet.WriteXmlSchema(swXML)
        txtRut.Text = swXML.ToString
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
