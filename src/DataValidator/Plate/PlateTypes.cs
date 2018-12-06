using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Plate
{
    /// <summary>
    /// Supported plate types
    /// </summary>
    public enum PlateTypes
    {
        /// <summary>
        /// Unknown plate type or no plate
        /// </summary>
        Unknown,
        /// <summary>
        /// Brazilian Plate, using format ABC1234
        /// </summary>
        Brazil,
        /// <summary>
        /// Mercosul Plate, using format ABC1D23
        /// </summary>
        Mercosul
    }
}
