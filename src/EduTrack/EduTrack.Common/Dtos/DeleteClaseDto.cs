﻿using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class DeleteClaseDto
    {
        public string NameClass { get; set; }

        public string Schedule { get; set; }

        public int ProfesorId { get; set; }
    }
}
