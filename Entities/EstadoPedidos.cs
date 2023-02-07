using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Entities
{
    [Table("Tdc_tch_estado_pedidos", Schema = "dwh_torrecontrol")]
    public class EstadoPedidos
    {
        [Column("Md_uuid")]
        [Display(Name = "Md_uuid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Md_uuid { get; set; } = Guid.NewGuid();

        [Column("Md_date")]
        [Display(Name = "Md_date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Md_date { get; set; } = DateTime.Now;

        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Cod_pedido")]
        [Display(Name = "Cod_pedido")]
        [StringLength(20, ErrorMessage = "El código del estado del pedido no puede exceder los 20 caracteres [provincia-codfarmacia-id] --> [sevilla-pharma1-1]")]
        public string? Cod_pedido { get; set; }

        [Column("Cod_estado_envio")]
        [Display(Name = "Cod_estado_envio")]
        public string? Cod_estado_envio { get; set; }

        [Column("Cod_estado_pago")]
        [Display(Name = "Cod_estado_pago")]
        public string? Cod_estado_pago { get; set; }

        [Column("Cod_estado_devolucion")]
        [Display(Name = "Cod_estado_devolucion")]
        public string? Cod_estado_devolucion { get; set; }

        [Column("Cod_linea")]
        [Display(Name = "Cod_linea")]
        public string? Cod_linea { get; set; }

        /***************************************************************************************/

        [ForeignKey("Cod_linea")]
        public virtual LineasDistribucion? LineaDistribucion { get; set; }

        [ForeignKey("Cod_estado_envio")]
        public virtual EstadosEnvioPedido? EstadoEnvio { get; set; }

        [ForeignKey("Cod_estado_pago")]
        public virtual EstadosPagoPedido? EstadoPago { get; set; }

        [ForeignKey("Cod_estado_devolucion")]
        public virtual EstadosDevolucionPedido? EstadoDevolucion { get; set; }
    }
}
