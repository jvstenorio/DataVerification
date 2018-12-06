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
        /// <param name="plateType"></param>
        public Plate(string plate, bool isValid, PlateTypes plateType)
        {
            FullPlate = plate;
            IsValid = isValid;
            PlateType = plateType;
        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public Plate()
        {
            FullPlate = string.Empty;
            IsValid = false;
            PlateType = PlateTypes.Unknown;
        }

        /// <summary>
        /// Full plate, without formatting, upper case
        /// </summary>
        public string FullPlate { get; }

        /// <summary>
        /// Boolean indicating if format matches Brazilian/MERCOSUL standards
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Plate type from the supported formats
        /// </summary>
        public PlateTypes? PlateType { get; }
    }
}
