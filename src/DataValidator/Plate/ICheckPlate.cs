using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Plate
{
    /// <summary>
    /// Plate format verifier
    /// </summary>
    public interface ICheckPlate
    {
        /// <summary>
        /// Extracts a possible plate from a sentence/text block and checks if the format is 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Plate ExtractAndCheckPlate(string text);
        /// <summary>
        /// Checks if an already extracted plate is valid or not
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        bool IsValid(string plate);
    }
}
