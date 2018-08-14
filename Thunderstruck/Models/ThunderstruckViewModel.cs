using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thunderstruck.Models
{
    public class ThunderstruckViewModel : ViewModelBase
    {
        [Range(1, 34, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Players { get; set; }
        public int BigDrinkers { get; set; }


        protected override void ResetSearch()
        {
            //SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }
    }
}