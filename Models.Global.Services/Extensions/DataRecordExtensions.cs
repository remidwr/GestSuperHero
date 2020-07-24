using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models.Global.Services.Extensions
{
    internal static class DataRecordExtensions
    {
        internal static SuperHero ToSuperHero(this IDataRecord dataRecord)
        {
            return new SuperHero() { Id = (int)dataRecord["Id"], Nom = (string)dataRecord["Nom"], Force = (int)dataRecord["Force"], Endurance = (int)dataRecord["Endurance"], Intelligence = (int)dataRecord["Intelligence"], Charisme = (int)dataRecord["Charisme"], UserId = (int)dataRecord["UserId"] };
        }

        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User() { Id = (int)dataRecord["Id"], Nom = (string)dataRecord["Nom"], Prenom = (string)dataRecord["Prenom"], Email = (string)dataRecord["Email"] };
        }
    }
}
