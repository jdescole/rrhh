﻿#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_Partes_SaldoOrdinaria : System.Web.UI.UserControl
{
    private int _DiasDisponibles;
    public int DiasDisponibles
    {
        get { return _DiasDisponibles; }
        set {_DiasDisponibles = value;}
    }

    private int _DiasSolicitados;
    public int DiasSolicitados
    {
        get { return _DiasSolicitados; }
        set {
                _DiasSolicitados = value;
                this.LSolicitadas.Text = value.ToString() + " Días";    
        }
    }

    private ConceptoDeLicencia _Concepto;

    public ConceptoDeLicencia Concepto
    {
        get { return _Concepto; }
        set { _Concepto = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            SaldoLicencia saldo;
            saldo = s.GetSaldoLicencia((Persona)Session["persona"], this.Concepto);
            Session["saldoLicencia"] = saldo;
            foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            {
                InsertarDetalleDeSaldo(d);
            }

            int segmento = s.GetSegmentosUtilizados();
            this.LSDisponibles.Text = segmento.ToString() ;
            this.LSDUtilizados.Text = (segmento + 1).ToString();
        }
        else
        {
            SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
            foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            {
                InsertarDetalleDeSaldo(d);
            }
        }
    }

    private void InsertarDetalleDeSaldo(SaldoLicenciaDetalle detalle)
    {
        //GPR y FC 22/08/2016: Fabian nos pidio que no se muestren los periodos con disponible en 0.
        if (detalle.Disponible > 0) 
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            string[] fuentes = { "Tahoma" };
            tc.Text = "&nbsp;&nbsp;&nbsp;&nbsp;Periodo " + detalle.Periodo.ToString() + ": ";
            tc.Font.Size = FontUnit.Small;
            tc.Font.Names = fuentes;
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = detalle.Disponible.ToString() + " Días";
            this.DiasDisponibles += detalle.Disponible;
            tc.Font.Size = FontUnit.Small;
            tc.Font.Names = fuentes;
            tr.Cells.Add(tc);
            this.TDiasDisponibles.Rows.Add(tr);
        }
    }
}
