using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.ViewModel
{
    //
    // View Model Che Descrive l inserimento di un nuovo esame 

    public class Admin_Exam_Create
    {
        public Guid id { get;set; }
        [Display(Name = "Data Dell' esame")]
        public DateTime Data { get; set; } // Data del Esame

        [Display(Name = "Ora del esame")]
        public DateTime Ora { get; set; } // ora Del Esame

        [Display(Name = "Tipo di sessione")]
        public string TipoSessione{ get; set; } // puo contenere solo valori Aperti Chiuso

        [Display(Name = "Luogo dell esame")]
        public Guid LuogoEsameId { get; set; }
        [ValidateNever]
        public List<SelectListItem> LuogoEsameLista { get; set; }

        [Display(Name = "Esaminatore")]
        public Guid EsaminatoreId { get; set; }
        [ValidateNever]
        public List<SelectListItem> EsaminatoreLista { get; set; }

        /*
        // Aggiunta Della Lista DDei Luoghi Deop Down
        [Display(Name = "Luogo del esame")]
        public Guid PlaceSelected { get; set; }
        
        [ValidateNever]
        public List<SelectListItem> PlaceList { get; set; } = new List<SelectListItem>();
        */
    }
}
