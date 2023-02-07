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
    [Table("Tdc_cat_lineas_distribucion", Schema = "dwh_torrecontrol")]
    public class LineasDistribucion
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
        [Column("Cod_linea")]
        [Display(Name = "Cod_linea")]
        [StringLength(11, ErrorMessage = "El código de la línea de distribución no puede exceder los 11 caracteres [XXX-YYY-ZZZ]")]
        public string? Cod_linea { get; set; }

        [Required]
        [Column("Cod_provincia")]
        [Display(Name = "Cod_provincia")]
        [StringLength(3, ErrorMessage = "El código de la provincia no puede exceder los 3 caracteres")]
        public string? Cod_provincia { get; set; }

        [Required]
        [Column("Cod_municipio")]
        [Display(Name = "Cod_municipio")]
        [StringLength(3, ErrorMessage = "El código del municipio no puede exceder los 3 caracteres")]
        public string? Cod_municipio { get; set; }

        [Required]
        [Column("Cod_barrio")]
        [Display(Name = "Cod_barrio")]
        [StringLength(3, ErrorMessage = "El código del barrio no puede exceder los 3 caracteres")]
        public string? Cod_barrio { get; set; }

        /***************************************************************************************************/

        [InverseProperty("LineaDistribucion")]
        public virtual ICollection<EstadoPedidos>? ListaEstadoPedidos { get; set; }
    }
}
