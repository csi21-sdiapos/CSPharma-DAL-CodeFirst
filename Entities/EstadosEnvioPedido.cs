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
    [Table("Tdc_cat_estados_envio_pedido", Schema = "dwh_torrecontrol")]
    public class EstadosEnvioPedido
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

        [Column("Id")]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Required]
        [Column("Cod_estado_envio")]
        [Display(Name = "Cod_estado_envio")]
        [StringLength(2, ErrorMessage = "El código del estado del envío no puede exceder los 2 caracteres")]
        public string? Cod_estado_envio { get; set; }

        [Column("Des_estado_envio")]
        [Display(Name = "Des_estado_envio")]
        [StringLength(21, ErrorMessage = "La descripción del estado del envío no puede exceder los 21 caracteres")]
        public string? Des_estado_envio { get; set; }

        /***************************************************************************************************/

        [InverseProperty("EstadoEnvio")]
        public virtual ICollection<EstadoPedidos>? ListaEstadoPedidos { get; set; }
    }
}
