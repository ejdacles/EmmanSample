// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Title Prefix
    /// </summary>
    public static class TitlePrefix
    {
        /// <summary>
        /// static strings for Titles
        /// </summary>
        private static string titleNotFound = "-1";
        private static string defaultValue = string.Empty;
        private static string dr = "Dr";
        private static string rn = "RN";
        private static string lpn = "LPN";
        private static string ma = "MA";
        private static string pa = "PA";
        private static string prof = "Prof";

        /// <summary>
        /// Gets No Title found value for display
        /// </summary>
        public static string NoTitleFound
        {
            get
            {
                return titleNotFound;
            }
        }

        /// <summary>
        /// Gets Default Title for display
        /// </summary>
        public static string Default
        {
            get
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets Doctor Title for display
        /// </summary>
        public static string Dr
        {
            get
            {
                return dr;
            }
        }

        /// <summary>
        /// Gets RN Title for display
        /// </summary>
        public static string RN
        {
            get
            {
                return rn;
            }
        }

        /// <summary>
        /// Gets LPN Title for display
        /// </summary>
        public static string LPN
        {
            get
            {
                return lpn;
            }
        }

        /// <summary>
        /// Gets MA Title for display
        /// </summary>
        public static string MA
        {
            get
            {
                return ma;
            }
        }

        /// <summary>
        /// Gets PA Title for display
        /// </summary>
        public static string PA
        {
            get
            {
                return pa;
            }
        }

        /// <summary>
        /// Gets Prof Title for display
        /// </summary>
        public static string Prof
        {
            get
            {
                return prof;
            }
        }

        /// <summary>
        /// Gets List of Allowable Titles
        /// </summary>
        public static string[] Titles
        {
            get
            {
                string[] titles = new[]
                {
                    TitlePrefix.Default,
                    TitlePrefix.Dr,
                    TitlePrefix.RN,
                    TitlePrefix.LPN,
                    TitlePrefix.MA,
                    TitlePrefix.PA,
                    TitlePrefix.Prof
                };
                return titles;
            }
        }
    }
}