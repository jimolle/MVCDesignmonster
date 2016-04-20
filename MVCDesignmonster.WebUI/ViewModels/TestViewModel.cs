﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCDesignmonster.WordCount;

namespace MVCDesignmonster.WebUI.ViewModels
{
    public class TestViewModel
    {
        [Required]
        [MaxWords(4, ErrorMessage = "Max 4 words in {0}")]
        [MinWords(2, ErrorMessage = "Min 2 words in {0}")]
        public string Text { get; set; }
    }
}