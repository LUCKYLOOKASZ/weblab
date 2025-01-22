﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Entities;

public partial class OrderHistory
{
    public int HistoryId { get; set; }

    public int? OrderId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? StatusDate { get; set; }

    public virtual CustOrder? Order { get; set; }

    public virtual OrderStatus? Status { get; set; }
}
