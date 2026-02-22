using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainseatchar
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainseatchar ()
      {
         domain["A"] = "A";
         domain["B"] = "B";
         domain["C"] = "C";
         domain["D"] = "D";
         domain["E"] = "E";
         domain["F"] = "F";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["A"] = "A";
            domainMap["B"] = "B";
            domainMap["C"] = "C";
            domainMap["D"] = "D";
            domainMap["E"] = "E";
            domainMap["F"] = "F";
         }
         return (string)domainMap[key] ;
      }

   }

}
