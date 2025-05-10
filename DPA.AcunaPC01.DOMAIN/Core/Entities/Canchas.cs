﻿using System;
using System.Collections.Generic;

namespace DPA.AcunaPC01.DOMAIN.Core.Entities;

public partial class Canchas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
