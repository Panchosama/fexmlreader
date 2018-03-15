Imports Microsoft.Reporting.WinForms

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim pemisor As ReportParameter
        Dim pfolio As ReportParameter
        Dim prut As ReportParameter
        Dim pgiro As ReportParameter
        Dim pfecha As ReportParameter
        Dim pneto As ReportParameter
        Dim pexento As ReportParameter
        Dim piva As ReportParameter
        Dim ptotal As ReportParameter
        Dim piadic As ReportParameter
        Dim piadtx As ReportParameter

        pemisor = New ReportParameter("EmisorParam", Form1.txtRazonSocial.Text, False)
        pfolio = New ReportParameter("FolioParam", Form1.txtFolio.Text, False)
        prut = New ReportParameter("RutParam", Form1.txtRut.Text, False)
        pgiro = New ReportParameter("GiroParam", Form1.txtGiro.Text, False)
        pfecha = New ReportParameter("FechaParam", Form1.txtFecha.Text, False)
        pneto = New ReportParameter("NetoParam", Form1.txtNeto.Text, False)
        pexento = New ReportParameter("ExentoParam", Form1.txtExento.Text, False)
        piva = New ReportParameter("IvaParam", Form1.txtIva.Text, False)
        ptotal = New ReportParameter("TotalParam", Form1.txtTotal.Text, False)
        piadic = New ReportParameter("ImpAdicMntParam", Form1.txtMntAdic.Text, False)
        piadtx = New ReportParameter("ImpAdicTxtParam", Form1.txtImpAdic.Text, False)

        Me.ReportViewer1.LocalReport.SetParameters(pemisor)
        Me.ReportViewer1.LocalReport.SetParameters(pfolio)
        Me.ReportViewer1.LocalReport.SetParameters(prut)
        Me.ReportViewer1.LocalReport.SetParameters(pgiro)
        Me.ReportViewer1.LocalReport.SetParameters(pfecha)
        Me.ReportViewer1.LocalReport.SetParameters(pneto)
        Me.ReportViewer1.LocalReport.SetParameters(pexento)
        Me.ReportViewer1.LocalReport.SetParameters(piva)
        Me.ReportViewer1.LocalReport.SetParameters(ptotal)
        Me.ReportViewer1.LocalReport.SetParameters(piadic)
        Me.ReportViewer1.LocalReport.SetParameters(piadtx)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class