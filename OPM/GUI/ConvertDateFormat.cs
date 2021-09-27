using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace OPM.GUI
{
    class ConvertDateFormat
    {

    public string[] ConvertFormatDate(string date, string FormatA, string formatB)
    {

            if (date != null)
            {
                DateTime dt = DateTime.ParseExact(date, FormatA, CultureInfo.InvariantCulture);
                string dateConverted = dt.ToString(formatB);
                string[] arrDate = dateConverted.Split('-');
                return arrDate;
            }
            else return null;
            
    }
     
    }
    
}
