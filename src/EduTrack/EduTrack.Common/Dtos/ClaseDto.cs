﻿using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class ClaseDto
    {
        public int Id { get; set; }
        public string NameClass { get; set; }
        public string Schedule { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorName { get; set; }
    }
}
