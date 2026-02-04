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
   public class attractionsbyname : GXProcedure
   {
      public attractionsbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionsbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_NameFrom ,
                           string aP1_NameTo )
      {
         this.AV2NameFrom = aP0_NameFrom;
         this.AV3NameTo = aP1_NameTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_NameFrom ,
                                 string aP1_NameTo )
      {
         this.AV2NameFrom = aP0_NameFrom;
         this.AV3NameTo = aP1_NameTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2NameFrom,(string)AV3NameTo} ;
         ClassLoader.Execute("aattractionsbyname","GeneXus.Programs","aattractionsbyname", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
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

      private string AV2NameFrom ;
      private string AV3NameTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
