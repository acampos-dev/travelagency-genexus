using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class insertcategoryupdateattractions : GXProcedure
   {
      public insertcategoryupdateattractions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public insertcategoryupdateattractions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9category.gxTpr_Categoryname = "Tourist site";
         if ( AV9category.Insert() )
         {
            /* Using cursor P000Y2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A9CountryId = P000Y2_A9CountryId[0];
               A14CityId = P000Y2_A14CityId[0];
               n14CityId = P000Y2_n14CityId[0];
               A11CategoryId = P000Y2_A11CategoryId[0];
               n11CategoryId = P000Y2_n11CategoryId[0];
               A12CategoryName = P000Y2_A12CategoryName[0];
               A15CityName = P000Y2_A15CityName[0];
               A7AttractionId = P000Y2_A7AttractionId[0];
               A15CityName = P000Y2_A15CityName[0];
               A12CategoryName = P000Y2_A12CategoryName[0];
               AV8att.Load(A7AttractionId);
               AV8att.gxTpr_Categoryid = AV9category.gxTpr_Categoryid;
               AV8att.Update();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            context.CommitDataStores("insertcategoryupdateattractions",pr_default);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9category = new SdtCategory(context);
         P000Y2_A9CountryId = new short[1] ;
         P000Y2_A14CityId = new short[1] ;
         P000Y2_n14CityId = new bool[] {false} ;
         P000Y2_A11CategoryId = new short[1] ;
         P000Y2_n11CategoryId = new bool[] {false} ;
         P000Y2_A12CategoryName = new string[] {""} ;
         P000Y2_A15CityName = new string[] {""} ;
         P000Y2_A7AttractionId = new short[1] ;
         A12CategoryName = "";
         A15CityName = "";
         AV8att = new SdtAttraction(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.insertcategoryupdateattractions__default(),
            new Object[][] {
                new Object[] {
               P000Y2_A9CountryId, P000Y2_A14CityId, P000Y2_n14CityId, P000Y2_A11CategoryId, P000Y2_n11CategoryId, P000Y2_A12CategoryName, P000Y2_A15CityName, P000Y2_A7AttractionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A9CountryId ;
      private short A14CityId ;
      private short A11CategoryId ;
      private short A7AttractionId ;
      private string A12CategoryName ;
      private string A15CityName ;
      private bool n14CityId ;
      private bool n11CategoryId ;
      private IGxDataStore dsDefault ;
      private SdtCategory AV9category ;
      private IDataStoreProvider pr_default ;
      private short[] P000Y2_A9CountryId ;
      private short[] P000Y2_A14CityId ;
      private bool[] P000Y2_n14CityId ;
      private short[] P000Y2_A11CategoryId ;
      private bool[] P000Y2_n11CategoryId ;
      private string[] P000Y2_A12CategoryName ;
      private string[] P000Y2_A15CityName ;
      private short[] P000Y2_A7AttractionId ;
      private SdtAttraction AV8att ;
   }

   public class insertcategoryupdateattractions__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Y2;
          prmP000Y2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000Y2", "SELECT T1.[CountryId], T1.[CityId], T1.[CategoryId], T3.[CategoryName], T2.[CityName], T1.[AttractionId] FROM (([Attractions] T1 LEFT JOIN [CountryCity] T2 ON T2.[CountryId] = T1.[CountryId] AND T2.[CityId] = T1.[CityId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) WHERE (T2.[CityName] = 'Beijing') AND (T3.[CategoryName] = 'Monument') ORDER BY T1.[AttractionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y2,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 50);
                ((string[]) buf[6])[0] = rslt.getString(5, 50);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
