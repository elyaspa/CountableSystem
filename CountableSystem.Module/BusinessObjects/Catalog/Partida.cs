using CountableSystem.Module.BusinessObjects.Utilities;
using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace CountableSystem.Module.BusinessObjects.Catalog
{
    [DefaultClassOptions]
    
    public class Partida : ObjetoBaseEmpresa
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Partida(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        CalendarioFiscalPeriodo periodo;
        decimal totalCredito;
        decimal totalDebito;
        string concepto;
        TipoPartida tipo;
        int numero;
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { SetPropertyValue(nameof(Fecha), ref fecha, value); }
        }


        public int Numero
        {
            get { return numero; }
            set { SetPropertyValue(nameof(Numero), ref numero, value); }
        }


        public TipoPartida Tipo
        {
            get { return tipo; }
            set { SetPropertyValue(nameof(Tipo), ref tipo, value); }
        }


        [Size(250)]
        public string Concepto
        {
            get { return concepto; }
            set { SetPropertyValue(nameof(Concepto), ref concepto, value); }
        }


        public decimal TotalDebito
        {
            get { return totalDebito; }
            set { SetPropertyValue(nameof(TotalDebito), ref totalDebito, value); }
        }


        public decimal TotalCredito
        {
            get { return totalCredito; }
            set { SetPropertyValue(nameof(TotalCredito), ref totalCredito, value); }
        }

        
        public CalendarioFiscalPeriodo Periodo
        {
            get { return periodo; }
            set { SetPropertyValue(nameof(Periodo), ref periodo, value); }
        }

        [Association("Partida-Detalles"),DevExpress.Xpo.Aggregated]
        public XPCollection<PartidaDetalle> Detalles
        {
            get
            {
                return GetCollection<CountableSystem.Module.BusinessObjects.Catalog.PartidaDetalle>(nameof(Detalles));
            }
        }

    }
}