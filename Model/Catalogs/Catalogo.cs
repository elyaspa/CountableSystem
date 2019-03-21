using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{

    [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Catalogo : ObjetoBaseEmpresa
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Catalogo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Catalogo dependencia;
        public Catalogo Dependencia
        {
            get { return dependencia; }
            set { SetPropertyValue(nameof(Dependencia), ref dependencia, value); }
        }

        string numeroCuenta;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumeroCuenta
        {
            get { return numeroCuenta; }
            set { SetPropertyValue(nameof(NumeroCuenta), ref numeroCuenta, value); }
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue(nameof(Nombre), ref nombre, value); }
            }

        int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { SetPropertyValue(nameof(Nivel), ref nivel, value); }
            }

            Enumeradores.TipoSaldo tipoSaldo;
        public Enumeradores.TipoSaldo TipoSaldo
        {
            get { return tipoSaldo; }
            set { SetPropertyValue(nameof(TipoSaldo), ref tipoSaldo, value); }
            }

            Enumeradores.TipoCuenta tipo;
        public Enumeradores.TipoCuenta Tipo
        {
            get { return tipo; }
            set { SetPropertyValue(nameof(Tipo), ref tipo, value); }
            }

            Enumeradores.EstatusCuenta estatus;
        public Enumeradores.EstatusCuenta Estatus
        {
            get { return estatus; }
            set { SetPropertyValue(nameof(Estatus), ref estatus, value); }
            }

        bool totalizadora;
        public bool Totalizadora
        {
            get { return totalizadora; }
            set { SetPropertyValue(nameof(Totalizadora), ref totalizadora, value); }
            }

            Enumeradores.EfectoSaldo efecto;
        public Enumeradores.EfectoSaldo Efecto
        {
            get { return efecto; }
            set { SetPropertyValue(nameof(Efecto), ref efecto, value); }
            }

        bool requiereCC;
        public bool RequiereCC
        {
            get { return requiereCC; }
            set { SetPropertyValue(nameof(RequiereCC), ref requiereCC, value); }
            }

        }
    }