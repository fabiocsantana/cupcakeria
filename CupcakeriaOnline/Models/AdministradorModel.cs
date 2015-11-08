using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.Mvc;

namespace CupcakeriaOnline.Models
{
    [Table("Administrador")]
    public class AdministradorModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int pk_idAdministrador { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [DisplayName("Nome")]
        public string nomeAdministrador { get; set; }
    }
}