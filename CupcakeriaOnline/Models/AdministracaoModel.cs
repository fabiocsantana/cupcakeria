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
    public class AdministracaoModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int pk_idAdministracao { get; set; }

        [StringLength(4000, MinimumLength = 6)]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public String loginAdmSenha { get; set; }

        [StringLength(4000)]
        public String loginAdmSalt { get; set; }
    }
}