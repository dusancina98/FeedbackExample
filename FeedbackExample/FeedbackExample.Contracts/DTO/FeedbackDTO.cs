﻿using FeedbackExample.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Contracts.DTO
{
    public class FeedbackDTO
    {
        public Grade Grade { get; set; }
        public string Comment { get; set; }
        public Guid GradedUserId { get; set; }
    }
}
