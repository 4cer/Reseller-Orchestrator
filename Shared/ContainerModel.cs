﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProITM.Shared
{
    public class ContainerModel
    {
        // CANNOT BE AUTOGENERATED, BINDS TO DOCKER
        public string Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        public string Name { get; set; }

        public ImageModel Image { get; set; }

        [StringLength(1000, ErrorMessage = "Opis może mieć maksymalnie 1000 znaków")]
        public string Description { get; set; }

        public virtual List<ContainerPortModel> PortBindings { get; set; } = new();

        public HostModel Machine { get; set; }

        // Ignore for DB purposes
        public string State { get; set; }

        public bool IsRunning { get; set; }

        // TODO 148 Describe additional Container datum

        [NotMapped] // For creation purposes
        public bool IsWindows { get; set; }

        // Numeric port number passed by the form
        [Obsolete("Ports now marked as Objects containing pairs")]
        [NotMapped]
        public int PortNo { get; set; }

        // Docker Image name passed by container form at creation
        [NotMapped]
        public string DockerImageName { get; set; }

        // Username of container owner, for display purposes
        [NotMapped]
        public string OwnerName { get; set; }

        [NotMapped]
        public Dictionary<ushort, string> PortBindUris { get; set; } = new();

        [NotMapped]
        public List<string> Commands { get; set; } = new();

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ContainerModel))
                return false;

            ContainerModel c_obj = (ContainerModel)obj;

            //return base.Equals(obj);
            return this.Id.Equals(c_obj.Id);
        }
    }
}
