using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Andamios.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoCalidad.Domain.Entities;

namespace Andamios.Core.Data.Entities {
    public partial class AndamiosDominicanosContext : IdentityDbContext<Usuario>
    {
        public AndamiosDominicanosContext () { }

        public AndamiosDominicanosContext (DbContextOptions<AndamiosDominicanosContext> options) : base (options) { }

        // Libreria
        public virtual DbSet<Autor> Autores { get; set; }
        // END
        //Code First
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //END

        //Database First

        public virtual DbSet<Ddagente> Ddagente { get; set; }
        public virtual DbSet<DdclaseProd> DdclaseProd { get; set; }
        public virtual DbSet<Ddcliente> Ddcliente { get; set; }
        public virtual DbSet<DdconDespDet> DdconDespDet { get; set; }
        public virtual DbSet<DdconDespEnc> DdconDespEnc { get; set; }
        public virtual DbSet<DdconDevoDet> DdconDevoDet { get; set; }
        public virtual DbSet<DdconDevoEnc> DdconDevoEnc { get; set; }
        public virtual DbSet<DdconteoDespDet> DdconteoDespDet { get; set; }
        public virtual DbSet<DdconteoDespEnc> DdconteoDespEnc { get; set; }
        public virtual DbSet<DdconteoDevoDet> DdconteoDevoDet { get; set; }
        public virtual DbSet<DdconteoDevoEnc> DdconteoDevoEnc { get; set; }
        public virtual DbSet<DdcontrolBal> DdcontrolBal { get; set; }
        public virtual DbSet<DdcontrolFact> DdcontrolFact { get; set; }
        public virtual DbSet<DdcotiDetalle> DdcotiDetalle { get; set; }
        public virtual DbSet<DdcotiEncabezado> DdcotiEncabezado { get; set; }
        public virtual DbSet<DdfactDet> DdfactDet { get; set; }
        public virtual DbSet<DdfactEnc> DdfactEnc { get; set; }
        public virtual DbSet<DdingInvDet> DdingInvDet { get; set; }
        public virtual DbSet<DdingInvEnc> DdingInvEnc { get; set; }
        public virtual DbSet<DdmaeInventario> DdmaeInventario { get; set; }
        public virtual DbSet<Ddproyecto> Ddproyecto { get; set; }
        public virtual DbSet<Ddsuplidor> Ddsuplidor { get; set; }
        public virtual DbSet<DdtipComprobante> DdtipComprobante { get; set; }
        public virtual DbSet<DdtipoTraAju> DdtipoTraAju { get; set; }
        public virtual DbSet<DdtraAjuInv> DdtraAjuInv { get; set; }

        //END

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Data Source=VIXAR-7510\\SQLDEV;Initial Catalog=AndamiosDominicanos; Integrated Security=True;MultipleActiveResultSets=true");
        //            }
        //        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<AuditLog> ().ToTable ("AuditLogs");

            modelBuilder.HasAnnotation ("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Ddagente> (entity => {
                entity.HasKey (e => e.AgenteId);

                entity.ToTable ("DDAgente");

                entity.Property (e => e.AgenteId).HasColumnName ("AgenteID");

                entity.Property (e => e.AgenteContacto)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteContactoTelCel)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteCorreoElec)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteDescripcion)
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteDireccion)
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.AgenteFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.AgentePais)
                    .HasMaxLength (50)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteTelFax1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteTelOficina1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteTelOficina2)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.AgenteUsuRegistro)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdclaseProd> (entity => {
                entity.HasKey (e => e.ClaProdId);

                entity.ToTable ("DDClaseProd");

                entity.Property (e => e.ClaProdId).HasColumnName ("ClaProdID");

                entity.Property (e => e.ClaProdCtrlInventario)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ClaProdDesc)
                    .HasMaxLength (100)
                    .IsUnicode (false);

                entity.Property (e => e.ClaProdEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ClaProdFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.ClaProdFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.ClaProdUsuarioCreacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ClaProdUsuarioModifica)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<Ddcliente> (entity => {
                entity.HasKey (e => e.ClienteId);

                entity.ToTable ("DDCliente");

                entity.Property (e => e.ClienteId).HasColumnName ("ClienteID");

                entity.Property (e => e.ClienteCodigoVendedor)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteContacto)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteContactoCel1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteContactoCel2)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteCorreoElec)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteDescripcion)
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteDireccion)
                    .HasMaxLength (250)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.ClienteFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.ClienteGerente)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteGestorCobros)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteTelFax)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteTelOf1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteTelOf2)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteTipo)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteTipoId).HasColumnName ("ClienteTipoID");

                entity.Property (e => e.ClienteUsuarioModifica)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ClienteUsuarioRegistro)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconDespDet> (entity => {
                entity.HasKey (e => e.ConDespDetId);

                entity.ToTable ("DDConDespDet");

                entity.Property (e => e.ConDespDetId).HasColumnName ("ConDespDetID");

                entity.Property (e => e.ConDespDetProdId)
                    .HasColumnName ("ConDespDetProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);

                entity.Property (e => e.ConDespEnDetId).HasColumnName ("ConDespEnDetID");
            });

            modelBuilder.Entity<DdconDespEnc> (entity => {
                entity.HasKey (e => e.ConDespEnId);

                entity.ToTable ("DDConDespEnc");

                entity.Property (e => e.ConDespEnId).HasColumnName ("ConDespEnID");

                entity.Property (e => e.ConDespEnCliId).HasColumnName ("ConDespEnCliID");

                entity.Property (e => e.ConDespEnConteoId).HasColumnName ("ConDespEnConteoID");

                entity.Property (e => e.ConDespEnCotiId)
                    .HasColumnName ("ConDespEnCotiID")
                    .HasMaxLength (10);

                entity.Property (e => e.ConDespEnEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ConDespEnFechaEmision).HasColumnType ("datetime");

                entity.Property (e => e.ConDespEnOrdenC)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.ConDespEnProyectoId).HasColumnName ("ConDespEnProyectoID");

                entity.Property (e => e.ConDespEnTipo)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ConDespEnUsuarioCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconDevoDet> (entity => {
                entity.HasKey (e => e.ConDevoDetId);

                entity.ToTable ("DDConDevoDet");

                entity.Property (e => e.ConDevoDetId).HasColumnName ("ConDevoDetID");

                entity.Property (e => e.ConDevoCantidad).HasMaxLength (10);

                entity.Property (e => e.ConDevoDetEnId).HasColumnName ("ConDevoDetEnID");

                entity.Property (e => e.ConDevoProdId)
                    .HasColumnName ("ConDevoProdID")
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconDevoEnc> (entity => {
                entity.HasKey (e => e.ConDevoEnId);

                entity.ToTable ("DDConDevoEnc");

                entity.Property (e => e.ConDevoEnId).HasColumnName ("ConDevoEnID");

                entity.Property (e => e.ConDevoEnCliId).HasColumnName ("ConDevoEnCliID");

                entity.Property (e => e.ConDevoEnContId).HasColumnName ("ConDevoEnContID");

                entity.Property (e => e.ConDevoEnEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ConDevoEnProyectoId).HasColumnName ("ConDevoEnProyectoID");

                entity.Property (e => e.ConDevoEnTipo)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ConDevoFechaEmision).HasColumnType ("datetime");

                entity.Property (e => e.ConDevoOrdenC)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.ConDevoUsuarioCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconteoDespDet> (entity => {
                entity.HasKey (e => e.ContDespDetId)
                    .HasName ("PK_DDConteoDespDetalle");

                entity.ToTable ("DDConteoDespDet");

                entity.Property (e => e.ContDespDetId).HasColumnName ("ContDespDetID");

                entity.Property (e => e.ContDespDetEncId).HasColumnName ("ContDespDetEncID");

                entity.Property (e => e.ContDespProdId)
                    .HasColumnName ("ContDespProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconteoDespEnc> (entity => {
                entity.HasKey (e => e.ContDespEncId);

                entity.ToTable ("DDConteoDespEnc");

                entity.Property (e => e.ContDespEncId).HasColumnName ("ContDespEncID");

                entity.Property (e => e.ContDespEncClienteId).HasColumnName ("ContDespEncClienteID");

                entity.Property (e => e.ContDespEncCotiId).HasColumnName ("ContDespEncCotiID");

                entity.Property (e => e.ContDespEncEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ContDespEncFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.ContDespEncFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.ContDespEncOrden)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.ContDespEncProyectoId).HasColumnName ("ContDespEncProyectoID");

                entity.Property (e => e.ContDespEncUserCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ContDespEncUserModifica)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconteoDevoDet> (entity => {
                entity.HasKey (e => e.ContDevoDetId);

                entity.ToTable ("DDConteoDevoDet");

                entity.Property (e => e.ContDevoDetId).HasColumnName ("ContDevoDetID");

                entity.Property (e => e.ContDevoDetEncId).HasColumnName ("ContDevoDetEncID");

                entity.Property (e => e.ContDevoProdId)
                    .HasColumnName ("ContDevoProdID")
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdconteoDevoEnc> (entity => {
                entity.HasKey (e => e.ContDevoEncId);

                entity.ToTable ("DDConteoDevoEnc");

                entity.Property (e => e.ContDevoEncId).HasColumnName ("ContDevoEncID");

                entity.Property (e => e.ContDevoEncClienteId).HasColumnName ("ContDevoEncClienteID");

                entity.Property (e => e.ContDevoEncEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.ContDevoEncFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.ContDevoEncFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.ContDevoEncProyectoId).HasColumnName ("ContDevoEncProyectoID");

                entity.Property (e => e.ContDevoEncUsuCreacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ContDevoEncUsuModifica)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdcontrolBal> (entity => {
                entity.HasKey (e => e.BalId);

                entity.ToTable ("DDControlBal");

                entity.HasIndex (e => e.BalCotiId)
                    .HasName ("ix_Bal_CotiEnID");

                entity.Property (e => e.BalId).HasColumnName ("BalID");

                entity.Property (e => e.BalClienteId).HasColumnName ("BalClienteID");

                entity.Property (e => e.BalCotiId).HasColumnName ("BalCotiID");

                entity.Property (e => e.BalProdId)
                    .HasColumnName ("BalProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);

                entity.Property (e => e.BalProyectoId).HasColumnName ("BalProyectoID");
            });

            modelBuilder.Entity<DdcontrolFact> (entity => {
                entity.HasKey (e => e.CtrlGenFactura);

                entity.ToTable ("DDControlFact");

                entity.Property (e => e.CtrlGenFactura).HasColumnType ("date");
            });

            modelBuilder.Entity<DdcotiDetalle> (entity => {
                entity.HasKey (e => e.CotiDeId);

                entity.ToTable ("DDCotiDetalle");

                entity.HasIndex (e => e.CotiEnDeId)
                    .HasName ("ix_coti_encabezado");

                entity.Property (e => e.CotiDeId).HasColumnName ("CotiDeID");

                entity.Property (e => e.CotiEnDeId).HasColumnName ("CotiEnDeID");

                entity.Property (e => e.CotiPrecioProd).HasColumnType ("money");

                entity.Property (e => e.CotiProdId)
                    .HasColumnName ("CotiProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);

                entity.Property (e => e.CotiValorProd).HasColumnType ("money");
            });

            modelBuilder.Entity<DdcotiEncabezado> (entity => {
                entity.HasKey (e => e.CotiEnId);

                entity.ToTable ("DDCotiEncabezado");

                entity.Property (e => e.CotiEnId).HasColumnName ("CotiEnID");

                entity.Property (e => e.CotiEnClas)
                    .HasMaxLength (2)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnClienteId).HasColumnName ("CotiEnClienteID");

                entity.Property (e => e.CotiEnCondicionPago)
                    .HasMaxLength (25)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnDescripcion)
                    .HasMaxLength (300)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnDescuento).HasColumnType ("decimal(2, 2)");

                entity.Property (e => e.CotiEnEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnFechaActivacion).HasColumnType ("datetime");

                entity.Property (e => e.CotiEnFechaAnulacion).HasColumnType ("datetime");

                entity.Property (e => e.CotiEnFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.CotiEnImpuesto)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnOrden)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnProyectoId).HasColumnName ("CotiEnProyectoID");

                entity.Property (e => e.CotiEnTipo)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnTransporte)
                    .HasMaxLength (50)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnUsuarioActivacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnUsuarioAnulacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnUsuarioCreacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.CotiEnUsuarioVendedor)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdfactDet> (entity => {
                entity.HasKey (e => e.FactDetId);

                entity.ToTable ("DDFactDet");

                entity.Property (e => e.FactDetId).HasColumnName ("FactDetID");

                entity.Property (e => e.FactDetMonto).HasColumnType ("money");

                entity.Property (e => e.FactDetProdId)
                    .HasColumnName ("FactDetProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnDetId).HasColumnName ("FactEnDetID");
            });

            modelBuilder.Entity<DdfactEnc> (entity => {
                entity.HasKey (e => e.FactEnId);

                entity.ToTable ("DDFactEnc");

                entity.HasIndex (e => e.FactEnFechaConteo)
                    .HasName ("ix_factenc_FecConteo");

                entity.Property (e => e.FactEnId).HasColumnName ("FactEnID");

                entity.Property (e => e.FactEnClase)
                    .HasMaxLength (2)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnClienteId).HasColumnName ("FactEnClienteID");

                entity.Property (e => e.FactEnConduceId).HasColumnName ("FactEnConduceID");

                entity.Property (e => e.FactEnCotiId).HasColumnName ("FactEnCotiID");

                entity.Property (e => e.FactEnDescGlobal).HasColumnType ("decimal(2, 2)");

                entity.Property (e => e.FactEnEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnFechaConteo).HasColumnType ("date");

                entity.Property (e => e.FactEnFechaEmision).HasColumnType ("datetime");

                entity.Property (e => e.FactEnFechaValida).HasColumnType ("datetime");

                entity.Property (e => e.FactEnImpuesto).HasColumnType ("decimal(2, 2)");

                entity.Property (e => e.FactEnNumeroComprobante)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnOrden)
                    .HasMaxLength (15)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnProyectoId).HasColumnName ("FactEnProyectoID");

                entity.Property (e => e.FactEnTipo)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnUsuarioCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.FactEnVendedor)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdingInvDet> (entity => {
                entity.HasKey (e => e.TraDeIngId);

                entity.ToTable ("DDIngInvDet");

                entity.Property (e => e.TraDeIngId).HasColumnName ("TraDeIngID");

                entity.Property (e => e.TraDeEnIngId).HasColumnName ("TraDeEnIngID");

                entity.Property (e => e.TraDeProdId).HasColumnName ("TraDeProdID");
            });

            modelBuilder.Entity<DdingInvEnc> (entity => {
                entity.HasKey (e => e.TraEnIngId);

                entity.ToTable ("DDIngInvEnc");

                entity.Property (e => e.TraEnIngId).HasColumnName ("TraEnIngID");

                entity.Property (e => e.TraEnCodAgeId).HasColumnName ("TraEnCodAgeID");

                entity.Property (e => e.TraEnCodSupId).HasColumnName ("TraEnCodSupID");

                entity.Property (e => e.TraEnFactAge)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.TraEnFecCrea).HasColumnType ("datetime");

                entity.Property (e => e.TraEnFecFactAge).HasColumnType ("date");

                entity.Property (e => e.TraEnNumEmbarque)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.TraEnOrdenCompra)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.TraEnUsuCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdmaeInventario> (entity => {
                entity.HasKey (e => e.MinvId);

                entity.ToTable ("DDMaeInventario");

                entity.Property (e => e.MinvId)
                    .HasColumnName ("MInvID")
                    .HasMaxLength (10)
                    .IsUnicode (false)
                    .ValueGeneratedNever ();

                entity.Property (e => e.MinvClase).HasColumnName ("MInvClase");

                entity.Property (e => e.MinvCostoAdquisicion)
                    .HasColumnName ("MInvCostoAdquisicion")
                    .HasColumnType ("money");

                entity.Property (e => e.MinvDescripcion)
                    .HasColumnName ("MInvDescripcion")
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.MinvEstatus)
                    .HasColumnName ("MInvEstatus")
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.MinvFechaCreacion)
                    .HasColumnName ("MInvFechaCreacion")
                    .HasColumnType ("datetime");

                entity.Property (e => e.MinvFechaModifica)
                    .HasColumnName ("MInvFechaModifica")
                    .HasColumnType ("datetime");

                entity.Property (e => e.MinvPeso)
                    .HasColumnName ("MInvPeso")
                    .HasMaxLength (50)
                    .IsUnicode (false);

                entity.Property (e => e.MinvPiezaServicio)
                    .HasColumnName ("MInvPiezaServicio")
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.MinvPrecioRentaDia)
                    .HasColumnName ("MInvPrecioRentaDia")
                    .HasColumnType ("money");

                entity.Property (e => e.MinvPrecioRentaFija)
                    .HasColumnName ("MInvPrecioRentaFija")
                    .HasColumnType ("money");

                entity.Property (e => e.MinvPrecioVenta)
                    .HasColumnName ("MInvPrecioVenta")
                    .HasColumnType ("money");

                entity.Property (e => e.MinvTotalIngresado).HasColumnName ("MInvTotalIngresado");

                entity.Property (e => e.MinvTotalOrdenado).HasColumnName ("MInvTotalOrdenado");

                entity.Property (e => e.MinvTotalRentado).HasColumnName ("MInvTotalRentado");

                entity.Property (e => e.MinvUnidad)
                    .HasColumnName ("MInvUnidad")
                    .HasMaxLength (50)
                    .IsUnicode (false);

                entity.Property (e => e.MinvUsuarioCreacion)
                    .HasColumnName ("MInvUsuarioCreacion")
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.MinvUsuarioModifica)
                    .HasColumnName ("MInvUsuarioModifica")
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<Ddproyecto> (entity => {
                entity.HasKey (e => e.ProId);

                entity.ToTable ("DDProyecto");

                entity.Property (e => e.ProId)
                    .HasColumnName ("ProID")
                    .ValueGeneratedNever ();

                entity.Property (e => e.ProClienteId).HasColumnName ("ProClienteID");

                entity.Property (e => e.ProContacto)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.ProCorreoContacto)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.ProDescuentoGlobal).HasColumnType ("decimal(2, 2)");

                entity.Property (e => e.ProDireccion)
                    .IsRequired ()
                    .HasMaxLength (250)
                    .IsUnicode (false);

                entity.Property (e => e.ProFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.ProFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.ProFechaProyecto).HasColumnType ("date");

                entity.Property (e => e.ProNombre)
                    .IsRequired ()
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.ProTelContacto).HasMaxLength (10);

                entity.Property (e => e.ProUsuarioCreacion)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ProUsuarioModifica)
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.ProVendedorId)
                    .IsRequired ()
                    .HasColumnName ("ProVendedorID")
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<Ddsuplidor> (entity => {
                entity.HasKey (e => e.SuplidorId);

                entity.ToTable ("DDSuplidor");

                entity.Property (e => e.SuplidorId).HasColumnName ("SuplidorID");

                entity.Property (e => e.SuplidorContacto)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorContactoTelCel)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorCorreoElec)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorDescripcion)
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorDireccion)
                    .HasMaxLength (150)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorFechaCreacion).HasColumnType ("datetime");

                entity.Property (e => e.SuplidorFechaModifica).HasColumnType ("datetime");

                entity.Property (e => e.SuplidorPais)
                    .HasMaxLength (50)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorTelFax1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorTelOficina1)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorTelOficina2)
                    .HasMaxLength (20)
                    .IsUnicode (false);

                entity.Property (e => e.SuplidorUsuRegistro)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdtipComprobante> (entity => {
                entity.HasKey (e => e.TcompId);

                entity.ToTable ("DDTipComprobante");

                entity.Property (e => e.TcompId)
                    .HasColumnName ("TCompID")
                    .ValueGeneratedNever ();

                entity.Property (e => e.TcompDesc)
                    .HasColumnName ("TCompDesc")
                    .HasMaxLength (100);

                entity.Property (e => e.TcompEstatus)
                    .HasColumnName ("TCompEstatus")
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.TcompFechaCrea)
                    .HasColumnName ("TCompFechaCrea")
                    .HasColumnType ("datetime");

                entity.Property (e => e.TcompFechaModi)
                    .HasColumnName ("TCompFechaModi")
                    .HasColumnType ("datetime");

                entity.Property (e => e.TcompImpuesto)
                    .HasColumnName ("TCompImpuesto")
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.TcompUsuCrea)
                    .HasColumnName ("TCompUsuCrea")
                    .HasMaxLength (5)
                    .IsUnicode (false);

                entity.Property (e => e.TcompUsuModi)
                    .HasColumnName ("TCompUsuModi")
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdtipoTraAju> (entity => {
                entity.HasKey (e => e.TraTipoId);

                entity.ToTable ("DDTipoTraAju");

                entity.Property (e => e.TraTipoId).HasColumnName ("TraTipoID");

                entity.Property (e => e.TraTipoAjuste)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.TraTipoDesc)
                    .HasMaxLength (75)
                    .IsUnicode (false);

                entity.Property (e => e.TraTipoEstatus)
                    .HasMaxLength (1)
                    .IsUnicode (false);

                entity.Property (e => e.TraTipoFechaCrea).HasColumnType ("datetime");

                entity.Property (e => e.TratipoUsuCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<DdtraAjuInv> (entity => {
                entity.HasKey (e => e.TraAjuId);

                entity.ToTable ("DDTraAjuInv");

                entity.Property (e => e.TraAjuId).HasColumnName ("TraAjuID");

                entity.Property (e => e.TraAjuCodId).HasColumnName ("TraAjuCodID");

                entity.Property (e => e.TraAjuFechaCrea).HasColumnType ("datetime");

                entity.Property (e => e.TraAjuProdId)
                    .HasColumnName ("TraAjuProdID")
                    .HasMaxLength (10)
                    .IsUnicode (false);

                entity.Property (e => e.TraAjuUsuCrea)
                    .HasMaxLength (5)
                    .IsUnicode (false);
            });
        }

        // //AUDIT LOG CONTROLLER
        // public int SaveChanges (string userId, string table = "", string key = "") {
        //     // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
        //     foreach (var ent in ChangeTracker.Entries ().Where (p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified)) {
        //         // For each changed record, get the audit record entries and add them
        //         foreach (AuditLog x in GetAuditRecordsForChange (ent, userId, table, key)) {
        //             this.AuditLog.Add (x);
        //         }
        //     }

        //     // Call the original SaveChanges(), which will save both the changes made and the audit records
        //     return base.SaveChanges ();
        // }

        // private List<AuditLog> GetAuditRecordsForChange (DbEntityEntry dbEntry, string userId, string table, string key) {
        //     List<AuditLog> result = new List<AuditLog> ();

        //     DateTime changeTime = DateTime.Now;
        //     TableAttribute tableAttr = null;
        //     string tableName = "";
        //     string keyName = "";
        //     if (string.IsNullOrEmpty (table)) {

        //         // Get the Table() attribute, if one exists
        //         tableAttr = dbEntry.Entity.GetType ().GetCustomAttributes (typeof (TableAttribute), false).SingleOrDefault () as TableAttribute;

        //         // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
        //         tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType ().Name;

        //         // Get primary key value (If you have more than one key column, this will need to be adjusted)
        //         keyName = dbEntry.Entity.GetType ().GetProperties ().Single (p => p.GetCustomAttributes (typeof (KeyAttribute), false).Count () > 0).Name;

        //     } else {
        //         tableName = table;
        //         keyName = key;
        //     }

        //     if (dbEntry.State == EntityState.Added) {
        //         // For Inserts, just add the whole record
        //         // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
        //         result.Add (
        //             new AuditLog () {
        //                 AuditLogID = Guid.NewGuid (),
        //                     UserID = userId,
        //                     EventDateUTC = changeTime,
        //                     EventType = "A", // Added
        //                     TableName = tableName,
        //                     RecordID = dbEntry.CurrentValues.GetValue<object> (keyName).ToString (), // Again, adjust this if you have a multi-column key
        //                     ColumnName = "*ALL", // Or make it nullable, whatever you want
        //                     NewValue = (dbEntry.CurrentValues.ToObject () is IDescribableEntity) ? (dbEntry.CurrentValues.ToObject () as IDescribableEntity).Describe () : dbEntry.CurrentValues.ToObject ().ToString ()
        //             }
        //         );
        //     } else if (dbEntry.State == EntityState.Deleted) {
        //         // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
        //         result.Add (
        //             new AuditLog () {
        //                 AuditLogID = Guid.NewGuid (),
        //                     UserID = userId,
        //                     EventDateUTC = changeTime,
        //                     EventType = "E", // Deleted
        //                     TableName = tableName,
        //                     RecordID = dbEntry.GetDatabaseValues ().GetValue<object> (keyName).ToString (),
        //                     ColumnName = "*ALL",
        //                     NewValue = (dbEntry.OriginalValues.ToObject () is IDescribableEntity) ? (dbEntry.GetDatabaseValues ().ToObject () as IDescribableEntity).Describe () : dbEntry.GetDatabaseValues ().ToObject ().ToString ()
        //             }
        //         );
        //     } else if (dbEntry.State == EntityState.Modified) {
        //         foreach (string propertyName in dbEntry.OriginalValues.PropertyNames.Where (E => !E.Equals ("UltimaActualizacion") && !E.Equals ("Usuario"))) {
        //             // For updates, we only want to capture the columns that actually changed
        //             object cValue = dbEntry.GetDatabaseValues ().GetValue<object> (propertyName);
        //             object nValue = dbEntry.CurrentValues.GetValue<object> (propertyName);

        //             if (!object.Equals (cValue, nValue)) {
        //                 result.Add (
        //                     new AuditLog () {
        //                         AuditLogID = Guid.NewGuid (),
        //                             UserID = userId,
        //                             EventDateUTC = changeTime,
        //                             EventType = "M", // Modified
        //                             TableName = tableName,
        //                             RecordID = dbEntry.OriginalValues.GetValue<object> (keyName).ToString (),
        //                             ColumnName = propertyName,
        //                             OriginalValue = cValue == null ? null : cValue.ToString (),
        //                             NewValue = nValue == null ? null : nValue.ToString ()
        //                     }
        //                 );
        //             }
        //         }
        //     }
        //     // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

        //     return result;
        // }

    }
}