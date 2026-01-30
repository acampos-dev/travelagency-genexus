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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx0091 : GXDataArea
   {
      public gx0091( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public gx0091( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pFlightId ,
                           out short aP1_pFlightSeatId ,
                           out string aP2_pFlightSeatChar )
      {
         this.AV9pFlightId = aP0_pFlightId;
         this.AV10pFlightSeatId = 0 ;
         this.AV11pFlightSeatChar = "" ;
         ExecuteImpl();
         aP1_pFlightSeatId=this.AV10pFlightSeatId;
         aP2_pFlightSeatChar=this.AV11pFlightSeatChar;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCflightseatchar = new GXCombobox();
         cmbavCflightseatlocation = new GXCombobox();
         cmbFlightSeatChar = new GXCombobox();
         cmbFlightSeatLocation = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pFlightId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pFlightId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pFlightId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV9pFlightId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9pFlightId", StringUtil.LTrimStr( (decimal)(AV9pFlightId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10pFlightSeatId = (short)(Math.Round(NumberUtil.Val( GetPar( "pFlightSeatId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10pFlightSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlightSeatId), 4, 0));
                  AV11pFlightSeatChar = GetPar( "pFlightSeatChar");
                  AssignAttri("", false, "AV11pFlightSeatChar", AV11pFlightSeatChar);
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_44 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_44"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_44_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_44_idx = GetPar( "sGXsfl_44_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cFlightSeatId = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlightSeatId"), "."), 18, MidpointRounding.ToEven));
         cmbavCflightseatchar.FromJSonString( GetNextPar( ));
         AV7cFlightSeatChar = GetPar( "cFlightSeatChar");
         cmbavCflightseatlocation.FromJSonString( GetNextPar( ));
         AV8cFlightSeatLocation = GetPar( "cFlightSeatLocation");
         AV9pFlightId = (short)(Math.Round(NumberUtil.Val( GetPar( "pFlightId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0J2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0091.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlightId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pFlightSeatId,4,0)),UrlEncode(StringUtil.RTrim(AV11pFlightSeatChar))}, new string[] {"pFlightId","pFlightSeatId","pFlightSeatChar"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCFLIGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlightSeatId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLIGHTSEATCHAR", StringUtil.RTrim( AV7cFlightSeatChar));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLIGHTSEATLOCATION", StringUtil.RTrim( AV8cFlightSeatLocation));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_44", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_44), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLIGHTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pFlightId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLIGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pFlightSeatId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLIGHTSEATCHAR", StringUtil.RTrim( AV11pFlightSeatChar));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATIDFILTERCONTAINER_Class", StringUtil.RTrim( divFlightseatidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATCHARFILTERCONTAINER_Class", StringUtil.RTrim( divFlightseatcharfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATLOCATIONFILTERCONTAINER_Class", StringUtil.RTrim( divFlightseatlocationfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0J2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0091.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlightId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pFlightSeatId,4,0)),UrlEncode(StringUtil.RTrim(AV11pFlightSeatChar))}, new string[] {"pFlightId","pFlightSeatId","pFlightSeatChar"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0091" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Seat" ;
      }

      protected void WB0J0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlightseatidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlightseatidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflightseatidfilter_Internalname, "Flight Seat Id", "", "", lblLblflightseatidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflightseatid_Internalname, "Flight Seat Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflightseatid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlightSeatId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCflightseatid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cFlightSeatId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cFlightSeatId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflightseatid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflightseatid_Visible, edtavCflightseatid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlightseatcharfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlightseatcharfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflightseatcharfilter_Internalname, "Flight Seat Char", "", "", lblLblflightseatcharfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCflightseatchar_Internalname, "Flight Seat Char", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_44_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCflightseatchar, cmbavCflightseatchar_Internalname, StringUtil.RTrim( AV7cFlightSeatChar), 1, cmbavCflightseatchar_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCflightseatchar.Visible, cmbavCflightseatchar.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx0091.htm");
            cmbavCflightseatchar.CurrentValue = StringUtil.RTrim( AV7cFlightSeatChar);
            AssignProp("", false, cmbavCflightseatchar_Internalname, "Values", (string)(cmbavCflightseatchar.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlightseatlocationfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlightseatlocationfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflightseatlocationfilter_Internalname, "Flight Seat Location", "", "", lblLblflightseatlocationfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCflightseatlocation_Internalname, "Flight Seat Location", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_44_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCflightseatlocation, cmbavCflightseatlocation_Internalname, StringUtil.RTrim( AV8cFlightSeatLocation), 1, cmbavCflightseatlocation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCflightseatlocation.Visible, cmbavCflightseatlocation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx0091.htm");
            cmbavCflightseatlocation.CurrentValue = StringUtil.RTrim( AV8cFlightSeatLocation);
            AssignProp("", false, cmbavCflightseatlocation_Internalname, "Values", (string)(cmbavCflightseatlocation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e140j1_client"+"'", TempTags, "", 2, "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl44( ) ;
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            nRC_GXsfl_44 = (int)(nGXsfl_44_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0091.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0J2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Selection List Seat", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0J0( ) ;
      }

      protected void WS0J2( )
      {
         START0J2( ) ;
         EVT0J2( ) ;
      }

      protected void EVT0J2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
                              SubsflControlProps_442( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_44_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A41FlightSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              cmbFlightSeatChar.Name = cmbFlightSeatChar_Internalname;
                              cmbFlightSeatChar.CurrentValue = cgiGet( cmbFlightSeatChar_Internalname);
                              A42FlightSeatChar = cgiGet( cmbFlightSeatChar_Internalname);
                              cmbFlightSeatLocation.Name = cmbFlightSeatLocation_Internalname;
                              cmbFlightSeatLocation.CurrentValue = cgiGet( cmbFlightSeatLocation_Internalname);
                              A43FlightSeatLocation = cgiGet( cmbFlightSeatLocation_Internalname);
                              A20FlightId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E150J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E160J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cflightseatid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLIGHTSEATID"), ".", ",") != Convert.ToDecimal( AV6cFlightSeatId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflightseatchar Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLIGHTSEATCHAR"), AV7cFlightSeatChar) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflightseatlocation Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLIGHTSEATLOCATION"), AV8cFlightSeatLocation) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E170J2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0J2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0J2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_442( ) ;
         while ( nGXsfl_44_idx <= nRC_GXsfl_44 )
         {
            sendrow_442( ) ;
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cFlightSeatId ,
                                        string AV7cFlightSeatChar ,
                                        string AV8cFlightSeatLocation ,
                                        short AV9pFlightId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLIGHTSEATID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A41FlightSeatId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_FLIGHTSEATCHAR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A42FlightSeatChar, "")), context));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATCHAR", StringUtil.RTrim( A42FlightSeatChar));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavCflightseatchar.ItemCount > 0 )
         {
            AV7cFlightSeatChar = cmbavCflightseatchar.getValidValue(AV7cFlightSeatChar);
            AssignAttri("", false, "AV7cFlightSeatChar", AV7cFlightSeatChar);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCflightseatchar.CurrentValue = StringUtil.RTrim( AV7cFlightSeatChar);
            AssignProp("", false, cmbavCflightseatchar_Internalname, "Values", cmbavCflightseatchar.ToJavascriptSource(), true);
         }
         if ( cmbavCflightseatlocation.ItemCount > 0 )
         {
            AV8cFlightSeatLocation = cmbavCflightseatlocation.getValidValue(AV8cFlightSeatLocation);
            AssignAttri("", false, "AV8cFlightSeatLocation", AV8cFlightSeatLocation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCflightseatlocation.CurrentValue = StringUtil.RTrim( AV8cFlightSeatLocation);
            AssignProp("", false, cmbavCflightseatlocation_Internalname, "Values", cmbavCflightseatlocation.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 44;
         nGXsfl_44_idx = 1;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         bGXsfl_44_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_442( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cFlightSeatLocation ,
                                                 A43FlightSeatLocation ,
                                                 A42FlightSeatChar ,
                                                 AV7cFlightSeatChar ,
                                                 AV9pFlightId ,
                                                 AV6cFlightSeatId ,
                                                 A20FlightId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cFlightSeatChar = StringUtil.PadR( StringUtil.RTrim( AV7cFlightSeatChar), 1, "%");
            lV8cFlightSeatLocation = StringUtil.PadR( StringUtil.RTrim( AV8cFlightSeatLocation), 1, "%");
            /* Using cursor H000J2 */
            pr_default.execute(0, new Object[] {AV9pFlightId, AV6cFlightSeatId, lV7cFlightSeatChar, lV8cFlightSeatLocation, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_44_idx = 1;
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A20FlightId = H000J2_A20FlightId[0];
               A43FlightSeatLocation = H000J2_A43FlightSeatLocation[0];
               A42FlightSeatChar = H000J2_A42FlightSeatChar[0];
               A41FlightSeatId = H000J2_A41FlightSeatId[0];
               /* Execute user event: Load */
               E160J2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 44;
            WB0J0( ) ;
         }
         bGXsfl_44_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLIGHTSEATID"+"_"+sGXsfl_44_idx, GetSecureSignedToken( sGXsfl_44_idx, context.localUtil.Format( (decimal)(A41FlightSeatId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FLIGHTSEATCHAR"+"_"+sGXsfl_44_idx, GetSecureSignedToken( sGXsfl_44_idx, StringUtil.RTrim( context.localUtil.Format( A42FlightSeatChar, "")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV8cFlightSeatLocation ,
                                              A43FlightSeatLocation ,
                                              A42FlightSeatChar ,
                                              AV7cFlightSeatChar ,
                                              AV9pFlightId ,
                                              AV6cFlightSeatId ,
                                              A20FlightId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cFlightSeatChar = StringUtil.PadR( StringUtil.RTrim( AV7cFlightSeatChar), 1, "%");
         lV8cFlightSeatLocation = StringUtil.PadR( StringUtil.RTrim( AV8cFlightSeatLocation), 1, "%");
         /* Using cursor H000J3 */
         pr_default.execute(1, new Object[] {AV9pFlightId, AV6cFlightSeatId, lV7cFlightSeatChar, lV8cFlightSeatLocation});
         GRID1_nRecordCount = H000J3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlightSeatId, AV7cFlightSeatChar, AV8cFlightSeatLocation, AV9pFlightId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtFlightSeatId_Enabled = 0;
         cmbFlightSeatChar.Enabled = 0;
         cmbFlightSeatLocation.Enabled = 0;
         edtFlightId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_44 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_44"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflightseatid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflightseatid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLIGHTSEATID");
               GX_FocusControl = edtavCflightseatid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cFlightSeatId = 0;
               AssignAttri("", false, "AV6cFlightSeatId", StringUtil.LTrimStr( (decimal)(AV6cFlightSeatId), 4, 0));
            }
            else
            {
               AV6cFlightSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflightseatid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cFlightSeatId", StringUtil.LTrimStr( (decimal)(AV6cFlightSeatId), 4, 0));
            }
            cmbavCflightseatchar.Name = cmbavCflightseatchar_Internalname;
            cmbavCflightseatchar.CurrentValue = cgiGet( cmbavCflightseatchar_Internalname);
            AV7cFlightSeatChar = cgiGet( cmbavCflightseatchar_Internalname);
            AssignAttri("", false, "AV7cFlightSeatChar", AV7cFlightSeatChar);
            cmbavCflightseatlocation.Name = cmbavCflightseatlocation_Internalname;
            cmbavCflightseatlocation.CurrentValue = cgiGet( cmbavCflightseatlocation_Internalname);
            AV8cFlightSeatLocation = cgiGet( cmbavCflightseatlocation_Internalname);
            AssignAttri("", false, "AV8cFlightSeatLocation", AV8cFlightSeatLocation);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLIGHTSEATID"), ".", ",") != Convert.ToDecimal( AV6cFlightSeatId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLIGHTSEATCHAR"), AV7cFlightSeatChar) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLIGHTSEATLOCATION"), AV8cFlightSeatLocation) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E150J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E150J2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Seat", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E160J2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV13Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_442( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_44_Refreshing )
         {
            DoAjaxLoad(44, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E170J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E170J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pFlightSeatId = A41FlightSeatId;
         AssignAttri("", false, "AV10pFlightSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlightSeatId), 4, 0));
         AV11pFlightSeatChar = A42FlightSeatChar;
         AssignAttri("", false, "AV11pFlightSeatChar", AV11pFlightSeatChar);
         context.setWebReturnParms(new Object[] {(short)AV10pFlightSeatId,(string)AV11pFlightSeatChar});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pFlightSeatId","AV11pFlightSeatChar"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9pFlightId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV9pFlightId", StringUtil.LTrimStr( (decimal)(AV9pFlightId), 4, 0));
         AV10pFlightSeatId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV10pFlightSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlightSeatId), 4, 0));
         AV11pFlightSeatChar = (string)getParm(obj,2);
         AssignAttri("", false, "AV11pFlightSeatChar", AV11pFlightSeatChar);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0J2( ) ;
         WS0J2( ) ;
         WE0J2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202612816232110", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx0091.js", "?202612816232111", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_idx;
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_44_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_44_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_44_idx;
         edtFlightId_Internalname = "FLIGHTID_"+sGXsfl_44_idx;
      }

      protected void SubsflControlProps_fel_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_fel_idx;
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_44_fel_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_44_fel_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_44_fel_idx;
         edtFlightId_Internalname = "FLIGHTID_"+sGXsfl_44_fel_idx;
      }

      protected void sendrow_442( )
      {
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         WB0J0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_44_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_44_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_44_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A42FlightSeatChar))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_44_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV13Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlightSeatId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41FlightSeatId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlightSeatId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbFlightSeatChar.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_44_idx;
               cmbFlightSeatChar.Name = GXCCtl;
               cmbFlightSeatChar.WebTags = "";
               cmbFlightSeatChar.addItem("A", "A", 0);
               cmbFlightSeatChar.addItem("B", "B", 0);
               cmbFlightSeatChar.addItem("C", "C", 0);
               cmbFlightSeatChar.addItem("D", "D", 0);
               cmbFlightSeatChar.addItem("E", "E", 0);
               cmbFlightSeatChar.addItem("F", "F", 0);
               if ( cmbFlightSeatChar.ItemCount > 0 )
               {
                  A42FlightSeatChar = cmbFlightSeatChar.getValidValue(A42FlightSeatChar);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatChar,(string)cmbFlightSeatChar_Internalname,StringUtil.RTrim( A42FlightSeatChar),(short)1,(string)cmbFlightSeatChar_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFlightSeatChar.CurrentValue = StringUtil.RTrim( A42FlightSeatChar);
            AssignProp("", false, cmbFlightSeatChar_Internalname, "Values", (string)(cmbFlightSeatChar.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbFlightSeatLocation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_44_idx;
               cmbFlightSeatLocation.Name = GXCCtl;
               cmbFlightSeatLocation.WebTags = "";
               cmbFlightSeatLocation.addItem("W", "Window", 0);
               cmbFlightSeatLocation.addItem("M", "Middle", 0);
               cmbFlightSeatLocation.addItem("A", "Aisle", 0);
               if ( cmbFlightSeatLocation.ItemCount > 0 )
               {
                  A43FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A43FlightSeatLocation);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatLocation,(string)cmbFlightSeatLocation_Internalname,StringUtil.RTrim( A43FlightSeatLocation),(short)1,(string)cmbFlightSeatLocation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFlightSeatLocation.CurrentValue = StringUtil.RTrim( A43FlightSeatLocation);
            AssignProp("", false, cmbFlightSeatLocation_Internalname, "Values", (string)(cmbFlightSeatLocation.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlightId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlightId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20FlightId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlightId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0J2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         /* End function sendrow_442 */
      }

      protected void init_web_controls( )
      {
         cmbavCflightseatchar.Name = "vCFLIGHTSEATCHAR";
         cmbavCflightseatchar.WebTags = "";
         cmbavCflightseatchar.addItem("A", "A", 0);
         cmbavCflightseatchar.addItem("B", "B", 0);
         cmbavCflightseatchar.addItem("C", "C", 0);
         cmbavCflightseatchar.addItem("D", "D", 0);
         cmbavCflightseatchar.addItem("E", "E", 0);
         cmbavCflightseatchar.addItem("F", "F", 0);
         if ( cmbavCflightseatchar.ItemCount > 0 )
         {
            AV7cFlightSeatChar = cmbavCflightseatchar.getValidValue(AV7cFlightSeatChar);
            AssignAttri("", false, "AV7cFlightSeatChar", AV7cFlightSeatChar);
         }
         cmbavCflightseatlocation.Name = "vCFLIGHTSEATLOCATION";
         cmbavCflightseatlocation.WebTags = "";
         cmbavCflightseatlocation.addItem("W", "Window", 0);
         cmbavCflightseatlocation.addItem("M", "Middle", 0);
         cmbavCflightseatlocation.addItem("A", "Aisle", 0);
         if ( cmbavCflightseatlocation.ItemCount > 0 )
         {
            AV8cFlightSeatLocation = cmbavCflightseatlocation.getValidValue(AV8cFlightSeatLocation);
            AssignAttri("", false, "AV8cFlightSeatLocation", AV8cFlightSeatLocation);
         }
         GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_44_idx;
         cmbFlightSeatChar.Name = GXCCtl;
         cmbFlightSeatChar.WebTags = "";
         cmbFlightSeatChar.addItem("A", "A", 0);
         cmbFlightSeatChar.addItem("B", "B", 0);
         cmbFlightSeatChar.addItem("C", "C", 0);
         cmbFlightSeatChar.addItem("D", "D", 0);
         cmbFlightSeatChar.addItem("E", "E", 0);
         cmbFlightSeatChar.addItem("F", "F", 0);
         if ( cmbFlightSeatChar.ItemCount > 0 )
         {
            A42FlightSeatChar = cmbFlightSeatChar.getValidValue(A42FlightSeatChar);
         }
         GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_44_idx;
         cmbFlightSeatLocation.Name = GXCCtl;
         cmbFlightSeatLocation.WebTags = "";
         cmbFlightSeatLocation.addItem("W", "Window", 0);
         cmbFlightSeatLocation.addItem("M", "Middle", 0);
         cmbFlightSeatLocation.addItem("A", "Aisle", 0);
         if ( cmbFlightSeatLocation.ItemCount > 0 )
         {
            A43FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A43FlightSeatLocation);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl44( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"44\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seat Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seat Char") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seat Location") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Flight Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A42FlightSeatChar)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbFlightSeatChar.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A43FlightSeatLocation)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlightId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblflightseatidfilter_Internalname = "LBLFLIGHTSEATIDFILTER";
         edtavCflightseatid_Internalname = "vCFLIGHTSEATID";
         divFlightseatidfiltercontainer_Internalname = "FLIGHTSEATIDFILTERCONTAINER";
         lblLblflightseatcharfilter_Internalname = "LBLFLIGHTSEATCHARFILTER";
         cmbavCflightseatchar_Internalname = "vCFLIGHTSEATCHAR";
         divFlightseatcharfiltercontainer_Internalname = "FLIGHTSEATCHARFILTERCONTAINER";
         lblLblflightseatlocationfilter_Internalname = "LBLFLIGHTSEATLOCATIONFILTER";
         cmbavCflightseatlocation_Internalname = "vCFLIGHTSEATLOCATION";
         divFlightseatlocationfiltercontainer_Internalname = "FLIGHTSEATLOCATIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtFlightSeatId_Internalname = "FLIGHTSEATID";
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR";
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION";
         edtFlightId_Internalname = "FLIGHTID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         cmbFlightSeatChar.Link = "";
         subGrid1_Header = "";
         edtFlightId_Jsonclick = "";
         cmbFlightSeatLocation_Jsonclick = "";
         cmbFlightSeatChar_Jsonclick = "";
         edtFlightSeatId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtFlightId_Enabled = 0;
         cmbFlightSeatLocation.Enabled = 0;
         cmbFlightSeatChar.Enabled = 0;
         edtFlightSeatId_Enabled = 0;
         cmbavCflightseatlocation_Jsonclick = "";
         cmbavCflightseatlocation.Visible = 1;
         cmbavCflightseatlocation.Enabled = 1;
         cmbavCflightseatchar_Jsonclick = "";
         cmbavCflightseatchar.Visible = 1;
         cmbavCflightseatchar.Enabled = 1;
         edtavCflightseatid_Jsonclick = "";
         edtavCflightseatid_Enabled = 1;
         edtavCflightseatid_Visible = 1;
         divFlightseatlocationfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlightseatcharfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlightseatidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Seat";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlightSeatId","fld":"vCFLIGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflightseatchar"},{"av":"AV7cFlightSeatChar","fld":"vCFLIGHTSEATCHAR"},{"av":"cmbavCflightseatlocation"},{"av":"AV8cFlightSeatLocation","fld":"vCFLIGHTSEATLOCATION"},{"av":"AV9pFlightId","fld":"vPFLIGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E140J1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLFLIGHTSEATIDFILTER.CLICK","""{"handler":"E110J1","iparms":[{"av":"divFlightseatidfiltercontainer_Class","ctrl":"FLIGHTSEATIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLIGHTSEATIDFILTER.CLICK",""","oparms":[{"av":"divFlightseatidfiltercontainer_Class","ctrl":"FLIGHTSEATIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCflightseatid_Visible","ctrl":"vCFLIGHTSEATID","prop":"Visible"}]}""");
         setEventMetadata("LBLFLIGHTSEATCHARFILTER.CLICK","""{"handler":"E120J1","iparms":[{"av":"divFlightseatcharfiltercontainer_Class","ctrl":"FLIGHTSEATCHARFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLIGHTSEATCHARFILTER.CLICK",""","oparms":[{"av":"divFlightseatcharfiltercontainer_Class","ctrl":"FLIGHTSEATCHARFILTERCONTAINER","prop":"Class"},{"av":"cmbavCflightseatchar"}]}""");
         setEventMetadata("LBLFLIGHTSEATLOCATIONFILTER.CLICK","""{"handler":"E130J1","iparms":[{"av":"divFlightseatlocationfiltercontainer_Class","ctrl":"FLIGHTSEATLOCATIONFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLIGHTSEATLOCATIONFILTER.CLICK",""","oparms":[{"av":"divFlightseatlocationfiltercontainer_Class","ctrl":"FLIGHTSEATLOCATIONFILTERCONTAINER","prop":"Class"},{"av":"cmbavCflightseatlocation"}]}""");
         setEventMetadata("ENTER","""{"handler":"E170J2","iparms":[{"av":"A41FlightSeatId","fld":"FLIGHTSEATID","pic":"ZZZ9","hsh":true},{"av":"cmbFlightSeatChar"},{"av":"A42FlightSeatChar","fld":"FLIGHTSEATCHAR","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10pFlightSeatId","fld":"vPFLIGHTSEATID","pic":"ZZZ9"},{"av":"AV11pFlightSeatChar","fld":"vPFLIGHTSEATCHAR"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlightSeatId","fld":"vCFLIGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflightseatchar"},{"av":"AV7cFlightSeatChar","fld":"vCFLIGHTSEATCHAR"},{"av":"cmbavCflightseatlocation"},{"av":"AV8cFlightSeatLocation","fld":"vCFLIGHTSEATLOCATION"},{"av":"AV9pFlightId","fld":"vPFLIGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlightSeatId","fld":"vCFLIGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflightseatchar"},{"av":"AV7cFlightSeatChar","fld":"vCFLIGHTSEATCHAR"},{"av":"cmbavCflightseatlocation"},{"av":"AV8cFlightSeatLocation","fld":"vCFLIGHTSEATLOCATION"},{"av":"AV9pFlightId","fld":"vPFLIGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlightSeatId","fld":"vCFLIGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflightseatchar"},{"av":"AV7cFlightSeatChar","fld":"vCFLIGHTSEATCHAR"},{"av":"cmbavCflightseatlocation"},{"av":"AV8cFlightSeatLocation","fld":"vCFLIGHTSEATLOCATION"},{"av":"AV9pFlightId","fld":"vPFLIGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlightSeatId","fld":"vCFLIGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflightseatchar"},{"av":"AV7cFlightSeatChar","fld":"vCFLIGHTSEATCHAR"},{"av":"cmbavCflightseatlocation"},{"av":"AV8cFlightSeatLocation","fld":"vCFLIGHTSEATLOCATION"},{"av":"AV9pFlightId","fld":"vPFLIGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_CFLIGHTSEATCHAR","""{"handler":"Validv_Cflightseatchar","iparms":[]}""");
         setEventMetadata("VALIDV_CFLIGHTSEATLOCATION","""{"handler":"Validv_Cflightseatlocation","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Flightid","iparms":[]}""");
         return  ;
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
         AV11pFlightSeatChar = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cFlightSeatChar = "";
         AV8cFlightSeatLocation = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblflightseatidfilter_Jsonclick = "";
         TempTags = "";
         lblLblflightseatcharfilter_Jsonclick = "";
         lblLblflightseatlocationfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV13Linkselection_GXI = "";
         A42FlightSeatChar = "";
         A43FlightSeatLocation = "";
         lV7cFlightSeatChar = "";
         lV8cFlightSeatLocation = "";
         H000J2_A20FlightId = new short[1] ;
         H000J2_A43FlightSeatLocation = new string[] {""} ;
         H000J2_A42FlightSeatChar = new string[] {""} ;
         H000J2_A41FlightSeatId = new short[1] ;
         H000J3_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0091__default(),
            new Object[][] {
                new Object[] {
               H000J2_A20FlightId, H000J2_A43FlightSeatLocation, H000J2_A42FlightSeatChar, H000J2_A41FlightSeatId
               }
               , new Object[] {
               H000J3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9pFlightId ;
      private short AV10pFlightSeatId ;
      private short wcpOAV9pFlightId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cFlightSeatId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A41FlightSeatId ;
      private short A20FlightId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_44 ;
      private int subGrid1_Rows ;
      private int nGXsfl_44_idx=1 ;
      private int edtavCflightseatid_Enabled ;
      private int edtavCflightseatid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtFlightSeatId_Enabled ;
      private int edtFlightId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV11pFlightSeatChar ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divFlightseatidfiltercontainer_Class ;
      private string divFlightseatcharfiltercontainer_Class ;
      private string divFlightseatlocationfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_44_idx="0001" ;
      private string AV7cFlightSeatChar ;
      private string AV8cFlightSeatLocation ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divFlightseatidfiltercontainer_Internalname ;
      private string lblLblflightseatidfilter_Internalname ;
      private string lblLblflightseatidfilter_Jsonclick ;
      private string edtavCflightseatid_Internalname ;
      private string TempTags ;
      private string edtavCflightseatid_Jsonclick ;
      private string divFlightseatcharfiltercontainer_Internalname ;
      private string lblLblflightseatcharfilter_Internalname ;
      private string lblLblflightseatcharfilter_Jsonclick ;
      private string cmbavCflightseatchar_Internalname ;
      private string cmbavCflightseatchar_Jsonclick ;
      private string divFlightseatlocationfiltercontainer_Internalname ;
      private string lblLblflightseatlocationfilter_Internalname ;
      private string lblLblflightseatlocationfilter_Jsonclick ;
      private string cmbavCflightseatlocation_Internalname ;
      private string cmbavCflightseatlocation_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtFlightSeatId_Internalname ;
      private string cmbFlightSeatChar_Internalname ;
      private string A42FlightSeatChar ;
      private string cmbFlightSeatLocation_Internalname ;
      private string A43FlightSeatLocation ;
      private string edtFlightId_Internalname ;
      private string lV7cFlightSeatChar ;
      private string lV8cFlightSeatLocation ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_44_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtFlightSeatId_Jsonclick ;
      private string GXCCtl ;
      private string cmbFlightSeatChar_Jsonclick ;
      private string cmbFlightSeatLocation_Jsonclick ;
      private string edtFlightId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_44_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV13Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCflightseatchar ;
      private GXCombobox cmbavCflightseatlocation ;
      private GXCombobox cmbFlightSeatChar ;
      private GXCombobox cmbFlightSeatLocation ;
      private IDataStoreProvider pr_default ;
      private short[] H000J2_A20FlightId ;
      private string[] H000J2_A43FlightSeatLocation ;
      private string[] H000J2_A42FlightSeatChar ;
      private short[] H000J2_A41FlightSeatId ;
      private long[] H000J3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pFlightSeatId ;
      private string aP2_pFlightSeatChar ;
   }

   public class gx0091__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000J2( IGxContext context ,
                                             string AV8cFlightSeatLocation ,
                                             string A43FlightSeatLocation ,
                                             string A42FlightSeatChar ,
                                             string AV7cFlightSeatChar ,
                                             short AV9pFlightId ,
                                             short AV6cFlightSeatId ,
                                             short A20FlightId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [FlightId], [FlightSeatLocation], [FlightSeatChar], [FlightSeatId]";
         sFromString = " FROM [FlightSeat]";
         sOrderString = "";
         AddWhere(sWhereString, "([FlightId] = @AV9pFlightId and [FlightSeatId] >= @AV6cFlightSeatId)");
         AddWhere(sWhereString, "([FlightSeatChar] like @lV7cFlightSeatChar)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cFlightSeatLocation)) )
         {
            AddWhere(sWhereString, "([FlightSeatLocation] like @lV8cFlightSeatLocation)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY [FlightId], [FlightSeatId], [FlightSeatChar]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000J3( IGxContext context ,
                                             string AV8cFlightSeatLocation ,
                                             string A43FlightSeatLocation ,
                                             string A42FlightSeatChar ,
                                             string AV7cFlightSeatChar ,
                                             short AV9pFlightId ,
                                             short AV6cFlightSeatId ,
                                             short A20FlightId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [FlightSeat]";
         AddWhere(sWhereString, "([FlightId] = @AV9pFlightId and [FlightSeatId] >= @AV6cFlightSeatId)");
         AddWhere(sWhereString, "([FlightSeatChar] like @lV7cFlightSeatChar)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cFlightSeatLocation)) )
         {
            AddWhere(sWhereString, "([FlightSeatLocation] like @lV8cFlightSeatLocation)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_H000J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000J2;
          prmH000J2 = new Object[] {
          new ParDef("@AV9pFlightId",GXType.Int16,4,0) ,
          new ParDef("@AV6cFlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@lV7cFlightSeatChar",GXType.NChar,1,0) ,
          new ParDef("@lV8cFlightSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000J3;
          prmH000J3 = new Object[] {
          new ParDef("@AV9pFlightId",GXType.Int16,4,0) ,
          new ParDef("@AV6cFlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@lV7cFlightSeatChar",GXType.NChar,1,0) ,
          new ParDef("@lV8cFlightSeatLocation",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
