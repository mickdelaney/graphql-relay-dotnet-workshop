﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace Workshop.Calendar.Api
{
    [Keyless]
    [Table("_user_eventtype")]
    [Index(nameof(A), nameof(B), Name = "_user_eventtype_AB_unique", IsUnique = true)]
    [Index(nameof(B), Name = "_user_eventtype_B_index")]
    public partial class UserEventtype
    {
        public int A { get; set; }
        public int B { get; set; }

        [ForeignKey(nameof(A))]
        public virtual EventType ANavigation { get; set; } = default!;
        [ForeignKey(nameof(B))]
        public virtual Users BNavigation { get; set; } = default!;
    }
}