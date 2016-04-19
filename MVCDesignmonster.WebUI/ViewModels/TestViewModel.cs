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
        [WordCount(2, 4, ErrorMessage = "Min 2, Max 4 words in {0}")]
        public string Text { get; set; }
    }
}