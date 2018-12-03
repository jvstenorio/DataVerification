using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Plate
{
    /// <summary>
    /// Plate object, containing full plate (without formatting, upper case) and a boolean indicating if it matches the ABC1234 or ABC1D23 formats
    /// </summary>
    public class Plate
    {
        /// <summary>
        /// Base ctor
        /// </summary>
        /// <param name="plate"></param>
        /// <param name="isValid"></param>
        public Plate(string plate, bool isValid)
        {
            FullPlate = plate;
            IsValid = isValid;
        }

        /// <summary>
        /// Full plate, without formatting, upper case
        /// </summary>
        public string FullPlate { get; }

        /// <summary>
        /// Boolean indicating if format matches Brazilian/MERCOSUL standards
        /// </summary>
        public bool IsValid { get; }
    }
}
