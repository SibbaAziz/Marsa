using System.Collections.Generic;

namespace Marsa
{
    public static class Globals
    {
        public static Dictionary<string, string> Categories = new Dictionary<string, string>()
        {
            { "جميع الفئات", "Toutes catégories" },
            { "سيارات", "Voitures" },
            { "تأجير", "Location" },
            { "فئة أخرى", "Location" }
        };

        public static string[] Regions = new string[] 
        {
            Resources.Regions.nouakchott,
            Resources.Regions.adrar,
            Resources.Regions.assaba,
            Resources.Regions.brakna,
            Resources.Regions.dakhlet_nouadhibou,
            Resources.Regions.gorgol,
            Resources.Regions.guidimaka,
            Resources.Regions.hodh_ech_chargui,
            Resources.Regions.hodh_el_gharbi,
            Resources.Regions.inchiri,
            Resources.Regions.tagant,
            Resources.Regions.tiris_zemour,
            Resources.Regions.trarza
        };
    }
}