﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProITM.Shared
{
    public class HostModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public bool IsWindows { get; set; }

        #region marked for delete/unlink from DB
        // Unused, as expected
        [Obsolete("URI is the only thing needed")]
        public string IP { get; set; }

        // Unused, as expected
        [Obsolete("URI is the only thing needed")]
        public int Port { get; set; }
        #endregion

        // Only addressing field in actual use
        public string URI { get; set; }

        // TODO 149 Describe Host datum
    }
}
