﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;

#nullable enable

namespace Workshop.Calendar.Api
{
    [Index(nameof(Id), Name = "Webhook.id_unique", IsUnique = true)]
    public partial class Webhook
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = default!;
        [Column("userId")]
        public int UserId { get; set; }
        [Required]
        [Column("subscriberUrl")]
        public string SubscriberUrl { get; set; } = default!;
        [Column("createdAt", TypeName = "timestamp(3) without time zone")]
        public Instant CreatedAt { get; set; }
        [Required]
        [Column("active")]
        public bool? Active { get; set; }
    }
}