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
    [Index(nameof(UserId), nameof(Slug), Name = "EventType.userId_slug_unique", IsUnique = true)]
    public partial class EventType
    {
        public EventType()
        {
            Availability = new HashSet<Availability>();
            Booking = new HashSet<Booking>();
            EventTypeCustomInput = new HashSet<EventTypeCustomInput>();
            Schedule = new HashSet<Schedule>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; } = default!;
        [Required]
        [Column("slug")]
        public string Slug { get; set; } = default!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("locations", TypeName = "jsonb")]
        public string? Locations { get; set; }
        [Column("length")]
        public int Length { get; set; }
        [Column("hidden")]
        public bool Hidden { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }
        [Column("teamId")]
        public int? TeamId { get; set; }
        [Column("eventName")]
        public string? EventName { get; set; }
        [Column("timeZone")]
        public string? TimeZone { get; set; }
        [Column("periodType")]
        public string? PeriodType { get; set; }
        [Column("periodStartDate", TypeName = "timestamp(3) without time zone")]
        public Instant? PeriodStartDate { get; set; }
        [Column("periodEndDate", TypeName = "timestamp(3) without time zone")]
        public Instant? PeriodEndDate { get; set; }
        [Column("periodDays")]
        public int? PeriodDays { get; set; }
        [Column("periodCountCalendarDays")]
        public bool? PeriodCountCalendarDays { get; set; }
        [Column("requiresConfirmation")]
        public bool RequiresConfirmation { get; set; }
        [Column("disableGuests")]
        public bool DisableGuests { get; set; }
        [Column("minimumBookingNotice")]
        public int MinimumBookingNotice { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Required]
        [Column("currency")]
        public string Currency { get; set; } = default!;

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("EventType")]
        public virtual Team? Team { get; set; }
        [InverseProperty("EventType")]
        public virtual ICollection<Availability> Availability { get; set; }
        [InverseProperty("EventType")]
        public virtual ICollection<Booking> Booking { get; set; }
        [InverseProperty("EventType")]
        public virtual ICollection<EventTypeCustomInput> EventTypeCustomInput { get; set; }
        [InverseProperty("EventType")]
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}