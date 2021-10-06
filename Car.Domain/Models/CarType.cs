using Cars.DomainHelper.Attributes;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.Domain.Models
{
    public class CarType : Entity, IAggregateRoot
    {
        public CarType(long idN, Guid idGuid, string code, string name, bool isActive, bool isDeleted)
        {
            IdN = idN;
            Id = idGuid;
            Code = code;
            Name = name;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected CarType() { }
        public string MainImg { get; set; }

        [Key]
        [Export]
        public long IdN { get; set; }
        [Export]
        public string Code { get; set; }
        [Export]
        public string Name { get; set; }
        [Export]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        

    }
}
