﻿using System.ComponentModel.DataAnnotations;

namespace EduTrack.Web.Models.Entities
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public string Birthdate { get; set; }
        public bool IsActive { get; set; }


    }
}