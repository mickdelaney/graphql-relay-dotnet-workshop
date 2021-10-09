﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace Workshop.Calendar.Api
{
    public partial class BookingReference
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; } = default!;
        [Required]
        [Column("uid")]
        public string Uid { get; set; } = default!;
        [Column("meetingId")]
        public string? MeetingId { get; set; }
        [Column("meetingPassword")]
        public string? MeetingPassword { get; set; }
        [Column("meetingUrl")]
        public string? MeetingUrl { get; set; }
        [Column("bookingId")]
        public int? BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("BookingReference")]
        public virtual Booking? Booking { get; set; }
    }
}