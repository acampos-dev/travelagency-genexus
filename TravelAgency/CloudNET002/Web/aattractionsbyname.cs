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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aattractionsbyname : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "NameFrom");
            if ( ! entryPointCalled )
            {
               AV9NameFrom = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10NameTo = GetPar( "NameTo");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aattractionsbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public aattractionsbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_NameFrom ,
                           string aP1_NameTo )
      {
         this.AV9NameFrom = aP0_NameFrom;
         this.AV10NameTo = aP1_NameTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_NameFrom ,
                                 string aP1_NameTo )
      {
         this.AV9NameFrom = aP0_NameFrom;
         this.AV10NameTo = aP1_NameTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("AttractionList.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0V0( false, 187) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 25, 25, 112, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Attractons List", 380, Gx_line+67, 573, Gx_line+94, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "e1604fc8-c115-43b6-91f0-fd4b7bf7d76a", "", context.GetTheme( )), 0, Gx_line+0, 340, Gx_line+160) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+187);
            H0V0( false, 67) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Photo", 567, Gx_line+13, 627, Gx_line+40, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(187, Gx_line+40, 660, Gx_line+40, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Country", 440, Gx_line+13, 507, Gx_line+40, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Name", 320, Gx_line+13, 380, Gx_line+40, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Id", 207, Gx_line+13, 227, Gx_line+40, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+67);
            /* Using cursor P000V2 */
            pr_default.execute(0, new Object[] {AV9NameFrom, AV10NameTo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A9CountryId = P000V2_A9CountryId[0];
               A8AttractionName = P000V2_A8AttractionName[0];
               A40000AttractionPhoto_GXI = P000V2_A40000AttractionPhoto_GXI[0];
               A7AttractionId = P000V2_A7AttractionId[0];
               A10CountryName = P000V2_A10CountryName[0];
               A13AttractionPhoto = P000V2_A13AttractionPhoto[0];
               A10CountryName = P000V2_A10CountryName[0];
               H0V0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")), 167, Gx_line+0, 234, Gx_line+27, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), 320, Gx_line+0, 413, Gx_line+27, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : A13AttractionPhoto);
               getPrinter().GxDrawBitMap(sImgUrl, 567, Gx_line+0, 660, Gx_line+67) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), 440, Gx_line+0, 540, Gx_line+27, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0V0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void H0V0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P000V2_A9CountryId = new short[1] ;
         P000V2_A8AttractionName = new string[] {""} ;
         P000V2_A40000AttractionPhoto_GXI = new string[] {""} ;
         P000V2_A7AttractionId = new short[1] ;
         P000V2_A10CountryName = new string[] {""} ;
         P000V2_A13AttractionPhoto = new string[] {""} ;
         A8AttractionName = "";
         A40000AttractionPhoto_GXI = "";
         A10CountryName = "";
         A13AttractionPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aattractionsbyname__default(),
            new Object[][] {
                new Object[] {
               P000V2_A9CountryId, P000V2_A8AttractionName, P000V2_A40000AttractionPhoto_GXI, P000V2_A7AttractionId, P000V2_A10CountryName, P000V2_A13AttractionPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A7AttractionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9NameFrom ;
      private string AV10NameTo ;
      private string A8AttractionName ;
      private string A10CountryName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private string A40000AttractionPhoto_GXI ;
      private string A13AttractionPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000V2_A9CountryId ;
      private string[] P000V2_A8AttractionName ;
      private string[] P000V2_A40000AttractionPhoto_GXI ;
      private short[] P000V2_A7AttractionId ;
      private string[] P000V2_A10CountryName ;
      private string[] P000V2_A13AttractionPhoto ;
   }

   public class aattractionsbyname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000V2;
          prmP000V2 = new Object[] {
          new ParDef("@AV9NameFrom",GXType.Char,50,0) ,
          new ParDef("@AV10NameTo",GXType.Char,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000V2", "SELECT T1.[CountryId], T1.[AttractionName], T1.[AttractionPhoto_GXI], T1.[AttractionId], T2.[CountryName], T1.[AttractionPhoto] FROM ([Attractions] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) WHERE (T1.[AttractionName] >= @AV9NameFrom) AND (T1.[AttractionName] <= @AV10NameTo) ORDER BY T2.[CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
       }
    }

 }

}
