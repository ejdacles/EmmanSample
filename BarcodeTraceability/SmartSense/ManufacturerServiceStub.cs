// <copyright file="ManufacturerServiceStub.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.BarcodeTraceability.SmartSense
{
    using System;
    using SmartSenseCore.Domain.DataModels;
    using SmartSenseCore.Domain.Services;

    internal class ManufacturerServiceStub : IManufacturerService
    {
        public ManufacturerInfo GetManufacturerInfo(byte encryptionScheme)
        {
            if (encryptionScheme == 1)
                return GetBiomericInfo(encryptionScheme);

            if (encryptionScheme == 2)
                return GetPumpVendorInfo(encryptionScheme);

            throw new NotSupportedException("The encryption scheme is not supported yet.");
        }

        private static ManufacturerInfo GetPumpVendorInfo(byte encryptionScheme)
        {
            byte[] aes256SymmetricKey =
            {
                1, 103, 33, 173, 198, 7, 3, 1, 6, 82, 2, 5, 9, 105, 130, 5, 242, 232, 253, 139, 86, 211, 4, 49, 164, 34, 240,
                145, 114, 47, 214, 11
            };

            string[] allowedPartNumbers =
            {
                "TUBPTNXT",
                "Special TUB500",
                "TUB500"
            };

            return new ManufacturerInfo(encryptionScheme)
            {
                IsBlackListed = false,
                IssuedAesKey = aes256SymmetricKey,
                AllowedPartNumbers = allowedPartNumbers
            };
        }

        private static ManufacturerInfo GetBiomericInfo(byte encryptionScheme)
        {
            byte[] aes256SymmetricKey =
            {
                1, 103, 33, 173, 198, 7, 3, 1, 6, 82, 2, 5, 9, 105, 130, 5, 242, 232, 253, 139, 86, 211, 4, 49, 164, 34, 240,
                145, 114, 47, 214, 11
            };

            string[] allowedPartNumbers =
            {
                "CATT3A15",
                "CATT3A15",
                "CATT3A15",
                "CATT3A17",
                "CATT3A17",
                "CATT3A17",
                "CATT3B25X",
                "CATT3B25X",
                "CATT3B25X",
                "CATT3B27",
                "CATT3B27",
                "CATT3B27",
                "CATT3B27C",
                "CATT3B27C",
                "CATT3B27C",
                "CATT3B27X",
                "CATT3B27X",
                "CATT3B27X",
                "CATT3B37",
                "CATT3B37",
                "CATT3B37",
                "CATT3B37X",
                "CATT3B37X",
                "CATT3B37X",
                "TUBPTNXT",
                "ELE425",
                "ELE428",
                "VER001",
                "VER002",
                "VER003",
                "VER004",
                "VER005",
                "VER006",
                "Special TUB500",
                "TUB500"
            };

            return new ManufacturerInfo(encryptionScheme)
            {
                IsBlackListed = false,
                IssuedAesKey = aes256SymmetricKey,
                AllowedPartNumbers = allowedPartNumbers
            };
        }
    }
}