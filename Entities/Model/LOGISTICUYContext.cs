using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Entities.Model
{
    public partial class LOGISTICUYContext : DbContext
    {
        private readonly string _connectionString;
        public LOGISTICUYContext(string options)
        {
            this._connectionString = options;
        }

        public LOGISTICUYContext(DbContextOptions options)
            : base(options)
        {
        }

       

        public virtual DbSet<Albventacab> Albventacabs { get; set; }
        public virtual DbSet<Albventacamposlibre> Albventacamposlibres { get; set; }
        public virtual DbSet<Albventalin> Albventalins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.39.96.3;Database=LOGISTICUY;User Id=icgadmin;Password=masterkey;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Albventacab>(entity =>
            {
                entity.HasKey(e => new { e.Numserie, e.Numalbaran, e.N })
                    .HasName("ALBVENTACAB_PK");

                entity.ToTable("ALBVENTACAB");

                entity.HasIndex(e => e.Codcliente, "ALBVENTACAB_CLIENTE");

                entity.HasIndex(e => e.Codvendedor, "ALBVENTACAB_CODVENDEDOR");

                entity.HasIndex(e => new { e.Numserie, e.Numalbaran, e.N }, "ALBVENTACAB_DESC");

                entity.HasIndex(e => e.Descargar, "ALBVENTACAB_DESCARGAR");

                entity.HasIndex(e => new { e.Numserie, e.Numalbaran, e.N, e.Fecha }, "ALBVENTACAB_DOC_FECHA");

                entity.HasIndex(e => e.Entransito, "ALBVENTACAB_ENTRANSITO");

                entity.HasIndex(e => e.Fecha, "ALBVENTACAB_FECHA");

                entity.HasIndex(e => new { e.Tipodoc, e.Fecha, e.Numserie }, "ALBVENTACAB_FECHA_TIPODOC");

                entity.HasIndex(e => new { e.Fecha, e.Codvendedor, e.Hora }, "ALBVENTACAB_FECHA_VENDEDOR_HORA");

                entity.HasIndex(e => e.Idtarjeta, "ALBVENTACAB_IDTARJETA");

                entity.HasIndex(e => new { e.N, e.Fecha }, "ALBVENTACAB_N_FECHA");

                entity.HasIndex(e => new { e.Z, e.Caja }, "ALBVENTACAB_PORZCAJA");

                entity.HasIndex(e => e.Sualbaran, "ALBVENTACAB_SUALBARAN");

                entity.HasIndex(e => new { e.Numseriefac, e.Numfac, e.Nfac }, "PORNUMFAC_ALBVENTA");

                entity.Property(e => e.Numserie)
                    .HasMaxLength(4)
                    .HasColumnName("NUMSERIE")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Numalbaran).HasColumnName("NUMALBARAN");

                entity.Property(e => e.N)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Automatico)
                    .HasMaxLength(1)
                    .HasColumnName("AUTOMATICO")
                    .IsFixedLength(true);

                entity.Property(e => e.Caja)
                    .HasMaxLength(3)
                    .HasColumnName("CAJA")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Codcliente).HasColumnName("CODCLIENTE");

                entity.Property(e => e.Codenvio)
                    .HasColumnName("CODENVIO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Codmoneda).HasColumnName("CODMONEDA");

                entity.Property(e => e.Codtarifa).HasColumnName("CODTARIFA");

                entity.Property(e => e.Codvendedor).HasColumnName("CODVENDEDOR");

                entity.Property(e => e.Descargar)
                    .HasMaxLength(1)
                    .HasColumnName("DESCARGAR");

                entity.Property(e => e.Dtocomantescanjeopuntos).HasColumnName("DTOCOMANTESCANJEOPUNTOS");

                entity.Property(e => e.Dtocomercial).HasColumnName("DTOCOMERCIAL");

                entity.Property(e => e.Dtopp).HasColumnName("DTOPP");

                entity.Property(e => e.EnlaceAsiento).HasColumnName("ENLACE_ASIENTO");

                entity.Property(e => e.EnlaceEjercicio).HasColumnName("ENLACE_EJERCICIO");

                entity.Property(e => e.EnlaceEmpresa).HasColumnName("ENLACE_EMPRESA");

                entity.Property(e => e.EnlaceUsuario)
                    .HasMaxLength(10)
                    .HasColumnName("ENLACE_USUARIO");

                entity.Property(e => e.Entransito)
                    .HasMaxLength(3)
                    .HasColumnName("ENTRANSITO");

                entity.Property(e => e.Enviopor)
                    .HasMaxLength(50)
                    .HasColumnName("ENVIOPOR")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Esbarra)
                    .HasMaxLength(1)
                    .HasColumnName("ESBARRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Esdevolucion)
                    .HasMaxLength(1)
                    .HasColumnName("ESDEVOLUCION")
                    .IsFixedLength(true);

                entity.Property(e => e.Estadodelivery).HasColumnName("ESTADODELIVERY");

                entity.Property(e => e.Esunprestamo)
                    .HasMaxLength(1)
                    .HasColumnName("ESUNPRESTAMO")
                    .IsFixedLength(true);

                entity.Property(e => e.Factormoneda).HasColumnName("FACTORMONEDA");

                entity.Property(e => e.Facturado)
                    .HasMaxLength(1)
                    .HasColumnName("FACTURADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREACION");

                entity.Property(e => e.Fechaentrada)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAENTRADA");

                entity.Property(e => e.Fechafin)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAFIN");

                entity.Property(e => e.Fechaini)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAINI");

                entity.Property(e => e.Fechamodificado)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAMODIFICADO");

                entity.Property(e => e.Fecharecepcion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHARECEPCION");

                entity.Property(e => e.Fechatraspaso)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHATRASPASO");

                entity.Property(e => e.Fo)
                    .HasColumnName("FO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("HORA");

                entity.Property(e => e.Horaasignado)
                    .HasColumnType("datetime")
                    .HasColumnName("HORAASIGNADO");

                entity.Property(e => e.Horacocina)
                    .HasColumnType("datetime")
                    .HasColumnName("HORACOCINA");

                entity.Property(e => e.Horaelaborado)
                    .HasColumnType("datetime")
                    .HasColumnName("HORAELABORADO");

                entity.Property(e => e.Horaentregado)
                    .HasColumnType("datetime")
                    .HasColumnName("HORAENTREGADO");

                entity.Property(e => e.Horafin)
                    .HasColumnType("datetime")
                    .HasColumnName("HORAFIN");

                entity.Property(e => e.Horatotal)
                    .HasColumnType("datetime")
                    .HasColumnName("HORATOTAL");

                entity.Property(e => e.Idestado).HasColumnName("IDESTADO");

                entity.Property(e => e.Idmotivodto).HasColumnName("IDMOTIVODTO");

                entity.Property(e => e.Idtarjeta).HasColumnName("IDTARJETA");

                entity.Property(e => e.Impresiones)
                    .HasColumnName("IMPRESIONES")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ivaincluido)
                    .HasMaxLength(1)
                    .HasColumnName("IVAINCLUIDO")
                    .IsFixedLength(true);

                entity.Property(e => e.Mesa)
                    .HasColumnName("MESA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mmfijado)
                    .HasMaxLength(1)
                    .HasColumnName("MMFIJADO");

                entity.Property(e => e.Modifiedtotales)
                    .HasMaxLength(1)
                    .HasColumnName("MODIFIEDTOTALES");

                entity.Property(e => e.Nbultos).HasColumnName("NBULTOS");

                entity.Property(e => e.Nfac)
                    .HasMaxLength(1)
                    .HasColumnName("NFAC")
                    .IsFixedLength(true);

                entity.Property(e => e.Norecibido)
                    .HasMaxLength(1)
                    .HasColumnName("NORECIBIDO")
                    .IsFixedLength(true);

                entity.Property(e => e.Numcomensales)
                    .HasColumnName("NUMCOMENSALES")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Numeroasunto)
                    .HasColumnName("NUMEROASUNTO")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Numeroserial)
                    .HasMaxLength(150)
                    .HasColumnName("NUMEROSERIAL");

                entity.Property(e => e.Numfac).HasColumnName("NUMFAC");

                entity.Property(e => e.Numimpresiones).HasColumnName("NUMIMPRESIONES");

                entity.Property(e => e.Numrollo).HasColumnName("NUMROLLO");

                entity.Property(e => e.Numseriefac)
                    .HasMaxLength(4)
                    .HasColumnName("NUMSERIEFAC")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Porc).HasColumnName("PORC");

                entity.Property(e => e.Portespag)
                    .HasMaxLength(1)
                    .HasColumnName("PORTESPAG")
                    .IsFixedLength(true);

                entity.Property(e => e.Puntosacum).HasColumnName("PUNTOSACUM");

                entity.Property(e => e.Puntoscanjeados).HasColumnName("PUNTOSCANJEADOS");

                entity.Property(e => e.Puntoscanjeopordtocom).HasColumnName("PUNTOSCANJEOPORDTOCOM");

                entity.Property(e => e.Sala)
                    .HasColumnName("SALA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Seleccionado)
                    .HasMaxLength(1)
                    .HasColumnName("SELECCIONADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .HasColumnName("SERIE")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Serieasunto)
                    .HasMaxLength(4)
                    .HasColumnName("SERIEASUNTO")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Sualbaran)
                    .HasMaxLength(15)
                    .HasColumnName("SUALBARAN")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Tipodoc).HasColumnName("TIPODOC");

                entity.Property(e => e.Tipodocfac).HasColumnName("TIPODOCFAC");

                entity.Property(e => e.Tiquet)
                    .HasMaxLength(1)
                    .HasColumnName("TIQUET")
                    .IsFixedLength(true);

                entity.Property(e => e.Totalbruto).HasColumnName("TOTALBRUTO");

                entity.Property(e => e.Totalcargosdtos).HasColumnName("TOTALCARGOSDTOS");

                entity.Property(e => e.Totalcoste).HasColumnName("TOTALCOSTE");

                entity.Property(e => e.Totalcoste2).HasColumnName("TOTALCOSTE2");

                entity.Property(e => e.Totalcosteiva)
                    .HasColumnName("TOTALCOSTEIVA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Totalcosteiva2).HasColumnName("TOTALCOSTEIVA2");

                entity.Property(e => e.Totalimpuestos).HasColumnName("TOTALIMPUESTOS");

                entity.Property(e => e.Totalneto).HasColumnName("TOTALNETO");

                entity.Property(e => e.Totalpuntos).HasColumnName("TOTALPUNTOS");

                entity.Property(e => e.Totdtocomercial).HasColumnName("TOTDTOCOMERCIAL");

                entity.Property(e => e.Totdtopp).HasColumnName("TOTDTOPP");

                entity.Property(e => e.Totporc).HasColumnName("TOTPORC");

                entity.Property(e => e.Transporte)
                    .HasColumnName("TRANSPORTE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Traspasado)
                    .HasMaxLength(1)
                    .HasColumnName("TRASPASADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Vienedefo)
                    .HasMaxLength(1)
                    .HasColumnName("VIENEDEFO")
                    .IsFixedLength(true);

                entity.Property(e => e.Z).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Albventacamposlibre>(entity =>
            {
                entity.HasKey(e => new { e.Numserie, e.Numalbaran, e.N })
                    .HasName("ALBVENTACAMPOSLIBRES_PK");

                entity.ToTable("ALBVENTACAMPOSLIBRES");

                entity.Property(e => e.Numserie)
                    .HasMaxLength(4)
                    .HasColumnName("NUMSERIE")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Numalbaran).HasColumnName("NUMALBARAN");

                entity.Property(e => e.N)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Adenda)
                    .HasMaxLength(255)
                    .HasColumnName("ADENDA");

                entity.Property(e => e.Cae)
                    .HasMaxLength(15)
                    .HasColumnName("CAE");

                entity.Property(e => e.Caefchvenc)
                    .HasMaxLength(12)
                    .HasColumnName("CAEFCHVENC");

                entity.Property(e => e.Clauventa)
                    .HasMaxLength(3)
                    .HasColumnName("CLAUVENTA");

                entity.Property(e => e.Codigoqr)
                    .HasMaxLength(150)
                    .HasColumnName("CODIGOQR");

                entity.Property(e => e.Compraid)
                    .HasMaxLength(50)
                    .HasColumnName("COMPRAID");

                entity.Property(e => e.DescripcionCfe)
                    .HasMaxLength(30)
                    .HasColumnName("DESCRIPCION_CFE");

                entity.Property(e => e.Enviadocvm)
                    .HasMaxLength(1)
                    .HasColumnName("ENVIADOCVM")
                    .IsFixedLength(true);

                entity.Property(e => e.Fechafirma)
                    .HasMaxLength(25)
                    .HasColumnName("FECHAFIRMA");

                entity.Property(e => e.Hashcfe)
                    .HasMaxLength(6)
                    .HasColumnName("HASHCFE");

                entity.Property(e => e.Inforeferencia)
                    .HasMaxLength(20)
                    .HasColumnName("INFOREFERENCIA");

                entity.Property(e => e.Linkdgi)
                    .HasMaxLength(50)
                    .HasColumnName("LINKDGI");

                entity.Property(e => e.Modventa).HasColumnName("MODVENTA");

                entity.Property(e => e.Nrocaefin).HasColumnName("NROCAEFIN");

                entity.Property(e => e.Nrocaeini).HasColumnName("NROCAEINI");

                entity.Property(e => e.Numeronacio).HasColumnName("NUMERONACIO");

                entity.Property(e => e.Pedido)
                    .HasMaxLength(1)
                    .HasColumnName("PEDIDO")
                    .IsFixedLength(true);

                entity.Property(e => e.Replicado)
                    .HasMaxLength(1)
                    .HasColumnName("REPLICADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Tipotraslado).HasColumnName("TIPOTRASLADO");

                entity.Property(e => e.Verificado)
                    .HasMaxLength(1)
                    .HasColumnName("VERIFICADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Viatransp).HasColumnName("VIATRANSP");

                entity.HasOne(d => d.NNavigation)
                    .WithOne(p => p.Albventacamposlibre)
                    .HasForeignKey<Albventacamposlibre>(d => new { d.Numserie, d.Numalbaran, d.N })
                    .HasConstraintName("ALBVENTACAMPOSLIBRES_FK");
            });

            modelBuilder.Entity<Albventalin>(entity =>
            {
                entity.HasKey(e => new { e.Numserie, e.Numalbaran, e.N, e.Numlin })
                    .HasName("ALBVENTALIN_PK");

                entity.ToTable("ALBVENTALIN");

                entity.HasIndex(e => e.Codarticulo, "ALBVENTALINPORCODARTIC");

                entity.HasIndex(e => new { e.AbonodeN, e.AbonodeNumalbaran, e.AbonodeNumserie, e.Numserie, e.Numalbaran, e.N }, "ALBVENTALIN_ABONODE");

                entity.HasIndex(e => new { e.Codalmacen, e.Talla }, "ALBVENTALIN_ALMACEN_TALLA");

                entity.HasIndex(e => new { e.Codarticulo, e.Talla, e.Color, e.Codalmacen }, "ALBVENTALIN_ARTIC_ALMACEN");

                entity.HasIndex(e => e.Codalmacen, "ALBVENTALIN_CODALMACEN");

                entity.HasIndex(e => new { e.Codarticulo, e.Color, e.Talla }, "ALBVENTALIN_COD_COLOR_TALLA");

                entity.HasIndex(e => new { e.Numserie, e.Numalbaran, e.N, e.Codarticulo, e.Talla, e.Color }, "ALBVENTALIN_DOC_ARTICULO");

                entity.HasIndex(e => new { e.N, e.Detalledenumlinea }, "ALBVENTALIN_N_DETALLEDENUMLINEA");

                entity.HasIndex(e => e.Supedido, "ALBVENTALIN_SUPEDIDO");

                entity.HasIndex(e => e.Tipo, "ALBVENTALIN_TIPO");

                entity.Property(e => e.Numserie)
                    .HasMaxLength(4)
                    .HasColumnName("NUMSERIE")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Numalbaran).HasColumnName("NUMALBARAN");

                entity.Property(e => e.N)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Numlin).HasColumnName("NUMLIN");

                entity.Property(e => e.AbonodeN)
                    .HasMaxLength(1)
                    .HasColumnName("ABONODE_N")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.AbonodeNumalbaran).HasColumnName("ABONODE_NUMALBARAN");

                entity.Property(e => e.AbonodeNumserie)
                    .HasMaxLength(4)
                    .HasColumnName("ABONODE_NUMSERIE")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.AbonodePuntosmixmatch).HasColumnName("ABONODE_PUNTOSMIXMATCH");

                entity.Property(e => e.Abonodelinea).HasColumnName("ABONODELINEA");

                entity.Property(e => e.Cargo1).HasColumnName("CARGO1");

                entity.Property(e => e.Cargo2).HasColumnName("CARGO2");

                entity.Property(e => e.Codalmacen)
                    .HasMaxLength(3)
                    .HasColumnName("CODALMACEN")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Codarticulo).HasColumnName("CODARTICULO");

                entity.Property(e => e.Codformato)
                    .HasColumnName("CODFORMATO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Codmacro)
                    .HasColumnName("CODMACRO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Codtarifa).HasColumnName("CODTARIFA");

                entity.Property(e => e.Codvendedor).HasColumnName("CODVENDEDOR");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("COLOR")
                    .HasDefaultValueSql("('.')")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Comision).HasColumnName("COMISION");

                entity.Property(e => e.Contacto).HasColumnName("CONTACTO");

                entity.Property(e => e.Coste).HasColumnName("COSTE");

                entity.Property(e => e.Coste2).HasColumnName("COSTE2");

                entity.Property(e => e.Costeiva)
                    .HasColumnName("COSTEIVA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Costeiva2).HasColumnName("COSTEIVA2");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .HasColumnName("DESCRIPCION")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Detalledenumlinea).HasColumnName("DETALLEDENUMLINEA");

                entity.Property(e => e.Detallemodif)
                    .HasColumnName("DETALLEMODIF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dto).HasColumnName("DTO");

                entity.Property(e => e.Dtoantespromocion).HasColumnName("DTOANTESPROMOCION");

                entity.Property(e => e.Expandida)
                    .HasMaxLength(1)
                    .HasColumnName("EXPANDIDA")
                    .HasDefaultValueSql("('F')");

                entity.Property(e => e.Familiaaena).HasColumnName("FAMILIAAENA");

                entity.Property(e => e.Fechacaducidad)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACADUCIDAD");

                entity.Property(e => e.Fechaentrega)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAENTREGA");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("HORA");

                entity.Property(e => e.Horacocina)
                    .HasColumnType("datetime")
                    .HasColumnName("HORACOCINA");

                entity.Property(e => e.Idmotivoabono).HasColumnName("IDMOTIVOABONO");

                entity.Property(e => e.Idmotivodto).HasColumnName("IDMOTIVODTO");

                entity.Property(e => e.Idpromocion).HasColumnName("IDPROMOCION");

                entity.Property(e => e.Importeantespromocion).HasColumnName("IMPORTEANTESPROMOCION");

                entity.Property(e => e.Importeantespromocioniva).HasColumnName("IMPORTEANTESPROMOCIONIVA");

                entity.Property(e => e.Importepromocion).HasColumnName("IMPORTEPROMOCION");

                entity.Property(e => e.Importepromocioniva).HasColumnName("IMPORTEPROMOCIONIVA");

                entity.Property(e => e.Importetesoreriamixmatch).HasColumnName("IMPORTETESORERIAMIXMATCH");

                entity.Property(e => e.Isprecio2)
                    .HasMaxLength(1)
                    .HasColumnName("ISPRECIO2");

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Lineaoculta)
                    .HasMaxLength(1)
                    .HasColumnName("LINEAOCULTA")
                    .IsFixedLength(true);

                entity.Property(e => e.Mmpedido)
                    .HasMaxLength(1)
                    .HasColumnName("MMPEDIDO");

                entity.Property(e => e.Numkg).HasColumnName("NUMKG");

                entity.Property(e => e.Numkgexpansion).HasColumnName("NUMKGEXPANSION");

                entity.Property(e => e.Omnichannel)
                    .HasMaxLength(1)
                    .HasColumnName("OMNICHANNEL");

                entity.Property(e => e.Porcretencion).HasColumnName("PORCRETENCION");

                entity.Property(e => e.Precio).HasColumnName("PRECIO");

                entity.Property(e => e.Preciodefecto).HasColumnName("PRECIODEFECTO");

                entity.Property(e => e.Precioiva)
                    .HasColumnName("PRECIOIVA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Prestamo)
                    .HasMaxLength(1)
                    .HasColumnName("PRESTAMO")
                    .IsFixedLength(true);

                entity.Property(e => e.Puntosmixmatch).HasColumnName("PUNTOSMIXMATCH");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(15)
                    .HasColumnName("REFERENCIA")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Req).HasColumnName("REQ");

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.Property(e => e.Supedido)
                    .HasMaxLength(15)
                    .HasColumnName("SUPEDIDO")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Talla)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("TALLA")
                    .HasDefaultValueSql("('.')")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Tarifaantespromocion).HasColumnName("TARIFAANTESPROMOCION");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(2)
                    .HasColumnName("TIPO")
                    .UseCollation("Latin1_General_CS_AI");

                entity.Property(e => e.Tipodelivery).HasColumnName("TIPODELIVERY");

                entity.Property(e => e.Tipoimpuesto).HasColumnName("TIPOIMPUESTO");

                entity.Property(e => e.Tiporetencion).HasColumnName("TIPORETENCION");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.Property(e => e.Totalexpansion).HasColumnName("TOTALEXPANSION");

                entity.Property(e => e.Udmedida2).HasColumnName("UDMEDIDA2");

                entity.Property(e => e.Udmedida2expansion).HasColumnName("UDMEDIDA2EXPANSION");

                entity.Property(e => e.Udsabonadas).HasColumnName("UDSABONADAS");

                entity.Property(e => e.Udsexpansion).HasColumnName("UDSEXPANSION");

                entity.Property(e => e.Unid1)
                    .HasColumnName("UNID1")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Unid2)
                    .HasColumnName("UNID2")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Unid3)
                    .HasColumnName("UNID3")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Unid4)
                    .HasColumnName("UNID4")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Unidadespagadas).HasColumnName("UNIDADESPAGADAS");

                entity.Property(e => e.Unidadestotal).HasColumnName("UNIDADESTOTAL");

                entity.HasOne(d => d.NNavigation)
                    .WithMany(p => p.Albventalins)
                    .HasForeignKey(d => new { d.Numserie, d.Numalbaran, d.N })
                    .HasConstraintName("ALBVENTALIN_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
