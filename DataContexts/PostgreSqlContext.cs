using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContexts;

public partial class PostgreSqlContext : DbContext
{
    public PostgreSqlContext()
    { }

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
    : base(options)
    { }


    public virtual DbSet<EstadoPedidos>? SetEstadoPedidos { get; set; }
    public virtual DbSet<LineasDistribucion>? SetLineasDistribucion { get; set; }
    public virtual DbSet<EstadosEnvioPedido>? SetEstadosEnvioPedido { get; set; }
    public virtual DbSet<EstadosPagoPedido>? SetEstadosPagoPedido { get; set; }
    public virtual DbSet<EstadosDevolucionPedido>? SetEstadosDevolucionPedido { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=cspharma_informacional;UserId=postgres;Password=12345;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

        modelBuilder.Entity("DAL.Entities.EstadoPedidos", entity =>
        {
            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("Id");

            NpgsqlPropertyBuilderExtensions.UseSerialColumn(entity.Property<int>("Id"));

            entity.Property<string>("Cod_estado_devolucion")
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_devolucion");

            entity.Property<string>("Cod_estado_envio")
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_envio");

            entity.Property<string>("Cod_estado_pago")
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_pago");

            entity.Property<string>("Cod_linea")
                .HasColumnType("character varying(11)")
                .HasColumnName("Cod_linea");

            entity.Property<string>("Cod_pedido")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("character varying(20)")
                .HasColumnName("Cod_pedido");

            entity.Property<DateTime>("Md_date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Md_date");

            entity.Property<Guid>("Md_uuid")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("Md_uuid");

            entity.HasKey("Id");

            entity.HasIndex("Cod_estado_devolucion");

            entity.HasIndex("Cod_estado_envio");

            entity.HasIndex("Cod_estado_pago");

            entity.HasIndex("Cod_linea");

            entity.ToTable("Tdc_tch_estado_pedidos", "dwh_torrecontrol");
        });

        modelBuilder.Entity("DAL.Entities.EstadosDevolucionPedido", entity =>
        {
            entity.Property<string>("Cod_estado_devolucion")
                .HasMaxLength(2)
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_devolucion");

            entity.Property<string>("Des_estado_devolucion")
                .HasMaxLength(21)
                .HasColumnType("character varying(21)")
                .HasColumnName("Des_estado_devolucion");

            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("Id");

            NpgsqlPropertyBuilderExtensions.UseSerialColumn(entity.Property<int>("Id"));

            entity.Property<DateTime>("Md_date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Md_date");

            entity.Property<Guid>("Md_uuid")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("Md_uuid");

            entity.HasKey("Cod_estado_devolucion");

            entity.ToTable("Tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");
        });

        modelBuilder.Entity("DAL.Entities.EstadosEnvioPedido", entity =>
        {
            entity.Property<string>("Cod_estado_envio")
                .HasMaxLength(2)
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_envio");

            entity.Property<string>("Des_estado_envio")
                .HasMaxLength(21)
                .HasColumnType("character varying(21)")
                .HasColumnName("Des_estado_envio");

            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("Id");

            NpgsqlPropertyBuilderExtensions.UseSerialColumn(entity.Property<int>("Id"));

            entity.Property<DateTime>("Md_date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Md_date");

            entity.Property<Guid>("Md_uuid")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("Md_uuid");

            entity.HasKey("Cod_estado_envio");

            entity.ToTable("Tdc_cat_estados_envio_pedido", "dwh_torrecontrol");
        });

        modelBuilder.Entity("DAL.Entities.EstadosPagoPedido", entity =>
        {
            entity.Property<string>("Cod_estado_pago")
                .HasMaxLength(2)
                .HasColumnType("character varying(2)")
                .HasColumnName("Cod_estado_pago");

            entity.Property<string>("Des_estado_pago")
                .HasMaxLength(20)
                .HasColumnType("character varying(20)")
                .HasColumnName("Des_estado_pago");

            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("Id");

            NpgsqlPropertyBuilderExtensions.UseSerialColumn(entity.Property<int>("Id"));

            entity.Property<DateTime>("Md_date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Md_date");

            entity.Property<Guid>("Md_uuid")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("Md_uuid");

            entity.HasKey("Cod_estado_pago");

            entity.ToTable("Tdc_cat_estados_pago_pedido", "dwh_torrecontrol");
        });

        modelBuilder.Entity("DAL.Entities.LineasDistribucion", entity =>
        {
            entity.Property<string>("Cod_linea")
                .HasMaxLength(11)
                .HasColumnType("character varying(11)")
                .HasColumnName("Cod_linea");

            entity.Property<string>("Cod_barrio")
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("character varying(3)")
                .HasColumnName("Cod_barrio");

            entity.Property<string>("Cod_municipio")
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("character varying(3)")
                .HasColumnName("Cod_municipio");

            entity.Property<string>("Cod_provincia")
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("character varying(3)")
                .HasColumnName("Cod_provincia");

            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("Id");

            NpgsqlPropertyBuilderExtensions.UseSerialColumn(entity.Property<int>("Id"));

            entity.Property<DateTime>("Md_date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Md_date");

            entity.Property<Guid>("Md_uuid")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("Md_uuid");

            entity.HasKey("Cod_linea");

            entity.ToTable("Tdc_cat_lineas_distribucion", "dwh_torrecontrol");
        });

        modelBuilder.Entity("DAL.Entities.EstadoPedidos", entity =>
        {
            entity.HasOne("DAL.Entities.EstadosDevolucionPedido", "EstadoDevolucion")
                .WithMany("ListaEstadoPedidos")
                .HasForeignKey("Cod_estado_devolucion");

            entity.HasOne("DAL.Entities.EstadosEnvioPedido", "EstadoEnvio")
                .WithMany("ListaEstadoPedidos")
                .HasForeignKey("Cod_estado_envio");

            entity.HasOne("DAL.Entities.EstadosPagoPedido", "EstadoPago")
                .WithMany("ListaEstadoPedidos")
                .HasForeignKey("Cod_estado_pago");

            entity.HasOne("DAL.Entities.LineasDistribucion", "LineaDistribucion")
                .WithMany("ListaEstadoPedidos")
                .HasForeignKey("Cod_linea");

            entity.Navigation("EstadoDevolucion");

            entity.Navigation("EstadoEnvio");

            entity.Navigation("EstadoPago");

            entity.Navigation("LineaDistribucion");
        });

        modelBuilder.Entity("DAL.Entities.EstadosDevolucionPedido", entity =>
        {
            entity.Navigation("ListaEstadoPedidos");
        });

        modelBuilder.Entity("DAL.Entities.EstadosEnvioPedido", entity =>
        {
            entity.Navigation("ListaEstadoPedidos");
        });

        modelBuilder.Entity("DAL.Entities.EstadosPagoPedido", entity =>
        {
            entity.Navigation("ListaEstadoPedidos");
        });

        modelBuilder.Entity("DAL.Entities.LineasDistribucion", entity =>
        {
            entity.Navigation("ListaEstadoPedidos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}