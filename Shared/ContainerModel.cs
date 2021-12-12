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

        #region Binding user not required
        // TODO Pull UserModel to get access to class:
        //[NotMapped]
        //public UserModel Owner { get; set; }
        ////public string UserId { get; set; }
        //// Moved to ApplicationUser as list
        //[Column("ApplicationUserId")]
        //public string ApplicationUserId { get; set; }
        #endregion

        public string Name { get; set; }

        public ImageModel Image { get; set; }

        public string Description { get; set; }

        public ContainerPortModel Port { get; set; }

        public HostModel Machine { get; set; }

        // Ignore for DB purposes
        public string State { get; set; }

        public bool IsRunning { get; set; }

        // TODO 148 Describe additional Container datum

        [NotMapped] // For creation purposes
        public bool IsWindows { get; set; }

        [NotMapped]
        public int PortNo { get; set; }

        [NotMapped]
        public string ImageIdC { get; set; }

        [NotMapped]
        public string OwnerName { get; set; }
    }
}
