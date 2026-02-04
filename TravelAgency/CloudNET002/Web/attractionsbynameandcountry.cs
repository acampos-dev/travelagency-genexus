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
   public class attractionsbynameandcountry : GXProcedure
   {
      public attractionsbynameandcountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionsbynameandcountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CountryId ,
                           string aP1_NameFrom ,
                           string aP2_NameTo )
      {
         this.AV2CountryId = aP0_CountryId;
         this.AV3NameFrom = aP1_NameFrom;
         this.AV4NameTo = aP2_NameTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_CountryId ,
                                 string aP1_NameFrom ,
                                 string aP2_NameTo )
      {
         this.AV2CountryId = aP0_CountryId;
         this.AV3NameFrom = aP1_NameFrom;
         this.AV4NameTo = aP2_NameTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(short)AV2CountryId,(string)AV3NameFrom,(string)AV4NameTo} ;
         ClassLoader.Execute("aattractionsbynameandcountry","GeneXus.Programs","aattractionsbynameandcountry", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
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
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private short AV2CountryId ;
      private string AV3NameFrom ;
      private string AV4NameTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
