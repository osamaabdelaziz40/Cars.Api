﻿using System;
using NetDevPack.Messaging;

namespace Cars.Domain.Events.Customer
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}